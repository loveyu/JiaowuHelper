using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Diagnostics;

namespace JiaowuHelper
{
	class Url
	{
		private static string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.57 Safari/537.36";
		public static Uri GetTrueUrl(string Url)
		{
			//设置网址时获取教务网重定向的页面，并且保存Cookie
			HttpWebResponse ResponseObject = null;
			try
			{
				HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(Url);
				HttpWReq.CookieContainer = new CookieContainer();
				HttpWReq.UserAgent = UserAgent;
				HttpWReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
				HttpWReq.KeepAlive = true;
				ResponseObject = (HttpWebResponse)HttpWReq.GetResponse();
				if (ResponseObject == null)
				{
					return null;
				}
				string loginPgae = readHtml(ResponseObject.GetResponseStream());
				Login.get().setloginPage(loginPgae);
				writeFile(Login.get().loginPage, "E:\\login.html");
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
			finally
			{
				if (ResponseObject != null)
					ResponseObject.Close();
			}
			Login.get().cookie = ResponseObject.Cookies;

			return ResponseObject.ResponseUri;
		}
		public static Image GetImageWithCookie(string url)
		{
			//获取一张图片
			try
			{
				Image img = Image.FromStream(getPageStream(url));
				return img;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
		}
		public static bool PostLogin(string form)
		{
			//进行登录验证
			try
			{
				Stream stream = getPostStream(Login.get().loginActionPage, form);
				if (stream == null) return false;
				string result = readHtml(stream);
				writeFile(result, @"E:\\post.html");
				if (Login.get().PageInfoParse(result) == false)
				{
					//获取登录错误提示
					Regex reg = new Regex("<script language='javascript' defer>alert\\('(.+?)'\\);document.getElementById");
					Match match = reg.Match(result);
					if (match.Value != "")
						Login.get().LoginError = match.Value.Substring("<script language='javascript' defer>alert('".Length, match.Value.Length - "<script language='javascript' defer>alert('".Length - "');document.getElementById".Length);
					return false;
				}
				return true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return false;
			}
		}
		public static Stream getPostStream(string url, string postData)
		{
			//提交一个POST表单到指定页面
			try
			{
				HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(url);
				HttpWReq.CookieContainer = new CookieContainer();
				HttpWReq.CookieContainer.Add(Login.get().cookie);
				HttpWReq.UserAgent = UserAgent;
				HttpWReq.Method = "POST";
				HttpWReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
				HttpWReq.KeepAlive = true;
				HttpWReq.ContentType = "application/x-www-form-urlencoded";
				HttpWReq.Referer = url;
				byte[] postBytes = Encoding.ASCII.GetBytes(postData);
				HttpWReq.ContentLength = postBytes.Length;
				using (Stream reqStream = HttpWReq.GetRequestStream())
				{
					//写入POST表单
					reqStream.Write(postBytes, 0, postBytes.Length);
				}
				HttpWebResponse ResponseObject = (HttpWebResponse)HttpWReq.GetResponse();
				return ResponseObject.GetResponseStream();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
		}
		public static string readHtml(Stream stream)
		{
			//读取HTML网页并关闭流
			if (stream == null) return "";
			MemoryStream destination = new MemoryStream();
			StreamCopy(stream,destination);
			stream.Close();
			return Encoding.GetEncoding("gb2312").GetString(destination.ToArray());
		}
		private static void StreamCopy(Stream src, MemoryStream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = src.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}
		public static void writeFile(string str, string file)
		{
#if DEBUG
			try
			{
				StreamWriter sw = new StreamWriter(new FileStream(file, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8);
				sw.Write(str);
				sw.Close();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
#endif
		}

		public static Stream getPageStream(string url)
		{
			Login login = Login.get();
			try
			{
				HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(url);
				HttpWReq.CookieContainer = new CookieContainer();
				if (login.cookie != null)
					HttpWReq.CookieContainer.Add(login.cookie);
				HttpWReq.UserAgent = UserAgent;
				HttpWReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
				HttpWReq.KeepAlive = true;
				HttpWReq.Referer = url;
				HttpWebResponse ResponseObject = (HttpWebResponse)HttpWReq.GetResponse();
				return ResponseObject.GetResponseStream();

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
		}
	}
}
