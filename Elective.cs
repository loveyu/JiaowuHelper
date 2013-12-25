using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace JiaowuHelper
{
	class Elective
	{
		private bool status = false;
		string url = "";
		Login login;
		Dictionary<int, string> SelectedHeaderList;
		ArrayList SelectedList;
		Dictionary<int, string> CurriculmHeaderList;
		ArrayList CurriculmList;
		string page = "";
		bool isClosedElective = false;
		public bool getStatus()
		{
			login = Login.get();
			url = login.homeUrl + "xf_xsqxxxk.aspx?xh=" + login.id + "&xm=" + login.urlName + "&gnmkdm=N121203";
			int i = 20;
			while (i-- > 0)
			{
				page = Url.readHtml(Url.getPageStream(url));
				if (page.Length > 100) break;
				Thread.Sleep(1000);
			}

			Url.writeFile(page, "E:\\elective.html");

			if (page == "" || checkClosed() == true) return false;

			string postData = GetPostData();
			i = 20;
			while (i-- > 0)
			{
				page = Url.readHtml(Url.getPostStream(url, postData));
				if (page.Length > 100) break;
				Thread.Sleep(1000);
			}

			Url.writeFile(page, "E:\\elective.post.html");

			return status = (ParseSelected() && ParseCurriculm());
		}
		private string GetPostData()
		{
			Regex reg = new Regex("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"(.+?)\" />");
			Match match = reg.Match(page);
			if (match.Value == "") return "";
			string rt = "__EVENTTARGET=ddl_ywyl&__EVENTARGUMENT=&__VIEWSTATE=";
			rt += HttpUtility.UrlEncode(match.Value.Substring("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"".Length, match.Length - "<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"".Length - "\" />".Length), Encoding.GetEncoding("gb2312"));
			return rt + "&ddl_kcxz=&ddl_ywyl=%D3%D0&ddl_kcgs=&ddl_xqbs=1&ddl_sksj=&TextBox1=&dpkcmcGrid%3AtxtChoosePage=1&dpkcmcGrid%3AtxtPageSize=200&dpDataGrid2%3AtxtChoosePage=1&dpDataGrid2%3AtxtPageSize=200";
		}
		private bool checkClosed()
		{
			Regex reg = new Regex("<script language='javascript'>alert(.+?);");
			Match match = reg.Match(page);
			isClosedElective = match.Value != "";
			return isClosedElective;
		}
		public bool isClosed()
		{
			return isClosedElective;
		}
		public ListView getSelectView()
		{
			ListView view = Info.createListView(SelectedHeaderList, SelectedList);
			view.MouseDoubleClick += new MouseEventHandler(cancelSelected);
			return view;
		}
		public void cancelSelected(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			string data = lv.FocusedItem.SubItems[lv.FocusedItem.SubItems.Count - 1].Text;
			string postData = getCanclePostData(data);
			int i = 20;
			while (i-- > 0)
			{
				string page = Url.readHtml(Url.getPostStream(url, postData));
				if (page.Length > 100) break;
				Thread.Sleep(1000);
			}
			MessageBox.Show("退选数据已提交请刷新查看");
		}
		public void SelectedCurriculum(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			string data = lv.FocusedItem.SubItems[0].Text;
			string postData = getSelectedPostData(data);
			int i = 20;
			while (i-- > 0)
			{
				string page = Url.readHtml(Url.getPostStream(url, postData));
				if (page.Length > 100) break;
				Thread.Sleep(1000);
			}
			MessageBox.Show("选课数据已提交请刷新查看");
		}
		private string getCanclePostData(string data)
		{
			Regex reg = new Regex("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"(.+?)\" />");
			Match match = reg.Match(page);
			if (match.Value == "") return "";
			string rt = "__EVENTTARGET=" + data.Replace("$", "%3A") + "&__EVENTARGUMENT=&__VIEWSTATE=";
			rt += HttpUtility.UrlEncode(match.Value.Substring("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"".Length, match.Length - "<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"".Length - "\" />".Length), Encoding.GetEncoding("gb2312"));
			return rt + "&ddl_kcxz=&ddl_ywyl=%D3%D0&ddl_kcgs=&ddl_xqbs=1&ddl_sksj=&TextBox1=&dpkcmcGrid%3AtxtChoosePage=1&dpkcmcGrid%3AtxtPageSize=6&dpDataGrid2%3AtxtChoosePage=1&dpDataGrid2%3AtxtPageSize=150";
		}
		private string getSelectedPostData(string data)
		{
			Regex reg = new Regex("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"(.+?)\" />");
			Match match = reg.Match(page);
			if (match.Value == "") return "";
			string rt = "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=";
			rt += HttpUtility.UrlEncode(match.Value.Substring("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"".Length, match.Length - "<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"".Length - "\" />".Length), Encoding.GetEncoding("gb2312"));
			return rt + "&ddl_kcxz=&ddl_ywyl=%D3%D0&ddl_kcgs=&ddl_xqbs=1&ddl_sksj=&TextBox1=&"
				+ HttpUtility.UrlEncode(data).ToUpper() + "=on&dpkcmcGrid%3AtxtChoosePage=1&dpkcmcGrid%3AtxtPageSize=6&Button1=++%CC%E1%BD%BB++";
		}
		public ListView getCurriculum()
		{
			ListView view = Info.createListView(CurriculmHeaderList, CurriculmList);
			view.MouseDoubleClick += new MouseEventHandler(SelectedCurriculum);
			return view;
		}
		private bool ParseSelected()
		{
			Regex reg = new Regex("<table class=\"datelist\" cellspacing=\"[0-9]+\" cellpadding=\"[0-9]+\" border=\"[0-9]+\" id=\"DataGrid2\" width=\"[0-9]+%\">(.+?)</table>", RegexOptions.Singleline);
			Match match = reg.Match(page);
			if (match.Value == "")
			{
				return false;
			}
			string rt = Regex.Replace(match.Value, "\\s", "", RegexOptions.Singleline).Replace("&nbsp;", "");
			rt = Regex.Replace(rt, "<aonclick=\"returnconfirm\\('.+?'\\);\"href=\"javascript:__doPostBack\\('(.+?)',''\\)\">.+?</a>", "$1", RegexOptions.None);
			rt = Regex.Replace(rt, "<a.+?>(.+?)</a>", "$1", RegexOptions.None);
			rt = Regex.Replace(rt, "<tdtitle=\"(.+?)\">.+?</td>", "<td>$1</td>", RegexOptions.None);
			rt = Regex.Replace(rt, "class=\"(.+?)\"", "", RegexOptions.None).Replace("</td><td>", "@").Replace("</tr><tr>", "\n");
			rt = Regex.Replace(rt, "<(.+?)>", "", RegexOptions.None);
			string[] split = rt.Split('\n');
			string[] split2;
			bool header = true;
			SelectedHeaderList = new Dictionary<int, string>();
			SelectedList = new ArrayList();
			try
			{
				foreach (string tmp in split)
				{
					split2 = tmp.Split('@');
					if (header)
					{
						for (int i = 0; i < split2.Length; i++)
						{
							if (split2[i] != "")
								SelectedHeaderList.Add(i, split2[i]);
						}
						header = false;
						continue;
					}
					Dictionary<string, string> sc = new Dictionary<string, string>();
					foreach (int i in SelectedHeaderList.Keys)
					{
						sc.Add(SelectedHeaderList[i], split2[i]);
					}
					SelectedList.Add(sc);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			return true;
		}
		private bool ParseCurriculm()
		{
			Regex reg = new Regex("<table(.+?)id=\"kcmcGrid\"(.+?)</table>", RegexOptions.Singleline);
			Match match = reg.Match(page);
			if (match.Value == "")
			{
				return false;
			}
			string rt = Regex.Replace(match.Value, "\\s", "", RegexOptions.Singleline).Replace("&nbsp;", "");
			rt = Regex.Replace(rt, "<a.+?>(.+?)</a>", "$1", RegexOptions.None);
			rt = Regex.Replace(rt, "<inputid=\".+?\"type=\"checkbox\"name=\"(.+?)\"/>", "$1", RegexOptions.None);
			rt = Regex.Replace(rt, "<tdtitle=\"(.+?)\">.+?</td>", "<td>$1</td>", RegexOptions.None);
			rt = Regex.Replace(rt, "class=\"(.+?)\"", "", RegexOptions.None).Replace("</td><td>", "@").Replace("</tr><tr>", "\n");
			rt = Regex.Replace(rt, "<(.+?)>", "", RegexOptions.None);
			string[] split = rt.Split('\n');
			string[] split2;
			bool header = true;
			CurriculmHeaderList = new Dictionary<int, string>();
			CurriculmList = new ArrayList();
			try
			{
				foreach (string tmp in split)
				{
					split2 = tmp.Split('@');
					if (split2.Length < 10) continue;
					if (header)
					{
						for (int i = 0; i < split2.Length; i++)
						{
							if (split2[i] != "")
								CurriculmHeaderList.Add(i, split2[i]);
						}
						header = false;
						continue;
					}
					Dictionary<string, string> sc = new Dictionary<string, string>();
					foreach (int i in CurriculmHeaderList.Keys)
					{
						sc.Add(CurriculmHeaderList[i], split2[i]);
					}
					CurriculmList.Add(sc);
				}
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}
