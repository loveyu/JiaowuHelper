using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JiaowuHelper
{
	class Score
	{
		Login login;
		string url = "";
		string postData = "";
		Dictionary<int, string> HeaderList;
		ArrayList scoreList;
		public Score()
		{
			login = Login.get();

		}
		public TabPage[] getAll()
		{
			url = login.homeUrl + "xscjcx.aspx?xh=" + login.id + "&xm=" + login.urlName + "&gnmkdm=N121613";
			if (postData == "")
				postData = getPostData();
			string page = getPostPage(postData);
			Url.writeFile(page, "E:\\socre.post.html");
			if (parse(page))
			{
				Dictionary<string, ListView> list = createListView();
				TabPage[] tabPages = new TabPage[list.Count];
				int i = 0;
				foreach (string name in list.Keys)
				{
					tabPages[i] = new TabPage();
					tabPages[i].Text = name;
					tabPages[i].Controls.Add(list[name]);
					i++;
				}
				return tabPages;
			}
			return null;
		}
		private Dictionary<string, ListView> createListView()
		{
			Dictionary<string, ListView> dlv = new Dictionary<string, ListView>();
			foreach (Dictionary<string, string> list in scoreList)
			{
				string name = list[HeaderList[0]] + " " + list[HeaderList[1]];
				if (!dlv.Keys.Contains(name))
				{
					ListView lv = new ListView();
					lv.View = View.Details;
					lv.FullRowSelect = true;
					lv.GridLines = true;
					foreach (string str in HeaderList.Values)
					{
						ColumnHeader header1 = new ColumnHeader();
						header1.Width = -2;
						header1.Text = str;
						header1.TextAlign = HorizontalAlignment.Left;
						lv.Columns.Add(header1);
					}
					lv.Dock = DockStyle.Fill;
					dlv.Add(name, lv);
				}
				dlv[name].Items.Add(new ListViewItem(list.Values.ToArray()));
			}
			return dlv;
		}
		private string getPostData()
		{
			string page = Url.readHtml(Url.getPageStream(url));
			Url.writeFile(page, "E:\\score.html");
			if (page == "") return "";
			string rt = "__EVENTTARGET=&__EVENTARGUMENT=&hidLanguage=&ddlXN=&ddlXQ=&ddl_kcxz=&btn_zcj=%C0%FA%C4%EA%B3%C9%BC%A8&__VIEWSTATE=";
			Regex reg = new Regex("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"(.+?)\" />");
			Match match = reg.Match(page);
			if (match.Value == "") return "";
			rt += HttpUtility.UrlEncode(match.Value.Substring("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"".Length, match.Length - "<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"".Length - "\" />".Length), Encoding.GetEncoding("gb2312"));
			return rt;
		}
		private string getPostPage(string postData)
		{
			Stream stream = Url.getPostStream(url, postData);
			return Url.readHtml(stream);
		}
		private bool parse(string page)
		{
			Regex reg = new Regex("<table class=\"datelist\" cellspacing=\"0\" cellpadding=\"3\" border=\"0\" id=\"Datagrid1\" style=\"DISPLAY:block\">(.+?)/table>", RegexOptions.Singleline);
			Match match = reg.Match(page);
			if (match.Value == "")
			{
				return false;
			}

			string rt = Regex.Replace(match.Value, "\\s", "", RegexOptions.Singleline).Replace("</td><td>", "@").Replace("class=\"alt\"", "").Replace("</tr><tr>", "\n");
			rt = Regex.Replace(rt, "<(.+?)>", "", RegexOptions.None).Replace("&nbsp;", "");
			string[] split = rt.Split('\n');
			string[] split2;
			bool header = true;
			HeaderList = new Dictionary<int, string>();
			scoreList = new ArrayList();
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
								HeaderList.Add(i, split2[i]);
						}
						header = false;
						continue;
					}
					Dictionary<string, string> sc = new Dictionary<string, string>();
					foreach (int i in HeaderList.Keys)
					{
						sc.Add(HeaderList[i], split2[i]);
					}
					scoreList.Add(sc);
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
