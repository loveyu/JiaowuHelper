using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;

namespace JiaowuHelper
{
	class Login
	{
		private bool isLoginFlag = false;
		private bool isLogoutFlag = false;
		private static Login self = null;
		public string homeUrl = "";
		public CookieCollection cookie;
		public string loginPage;
		public string loginActionPage = "";
		public string id = "";
		public string name = "";
		public string urlName = "";
		public string LoginError = "";
		public bool requirdCheckCode = true;
		public Dictionary<string, string> info = null;
		public ConfigInfo ci = Config.get();
		public static Login get()
		{
			if (self == null)
			{
				self = new Login();
			}
			return self;
		}
		public void init()
		{
			isLoginFlag = false;
			isLogoutFlag = false;
		}
		public bool isLogin()
		{
			return isLoginFlag;
		}
		public bool isLogout()
		{
			return isLogoutFlag;
		}
		public void setLogin(bool flag)
		{
			isLoginFlag = flag;
			isLogoutFlag = false;
		}
		public void setloginPage(string page)
		{
			loginPage = page;
			Regex reg = new Regex("<img(.+?)src=\"CheckCode.aspx\"");
			Match match = reg.Match(page);
			if (match.Value == "")
			{
				requirdCheckCode = false;
			}
			else
			{
				requirdCheckCode = true;
			}
		}
		public bool PageInfoParse(string page)
		{
			Regex reg = new Regex("<span id=\"xhxm\">" + id + "  (.+?)同学</span>");
			Match match = reg.Match(page);
			if (match.Value == "") return false;
			string t1 = "<span id=\"xhxm\">" + id;
			name = match.Value.Substring(t1.Length, match.Value.Length - t1.Length - "同学</span>".Length).Trim();
			urlName = HttpUtility.UrlEncode(name, Encoding.GetEncoding("gb2312")).Trim().ToUpper();
			return true;
		}
		public void Logout()
		{
			isLogoutFlag = true;
			isLoginFlag = false;
			ci.autoLogin = false;
		}
	}
}
