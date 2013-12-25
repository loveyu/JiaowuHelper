using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JiaowuHelper
{
	class Info
	{
		public static Dictionary<string, string> getUserInfoList()
		{
			string page = Url.readHtml(Url.getPageStream(Login.get().homeUrl + "xsgrxx.aspx?xh=" + Login.get().id + "&xm=" + Login.get().urlName + "&gnmkdm=N121501"));
			
			Dictionary<string, string> rt = new Dictionary<string, string>();
			Url.writeFile(page, "E:\\info.html");

			int n = "</span>".Length;

			string name = "";
			Regex reg = new Regex("<span id=\"xm\">(.+?)</span>");
			Match match = reg.Match(page);
			if (match.Value != "")
				name = match.Value.Substring("<span id=\"xm\">".Length, match.Value.Length - "<span id=\"xm\">".Length - n);
			rt.Add("name",name);

			string id = "";
			reg = new Regex("<span id=\"xh\">([0-9]+)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				id = match.Value.Substring("<span id=\"xh\">".Length, match.Value.Length - "<span id=\"xh\">".Length - n);
			rt.Add("id", id);

			string sex = "";
			reg = new Regex("<span id=\"lbl_xb\">(.+?)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				sex = match.Value.Substring("<span id=\"lbl_xb\">".Length, match.Value.Length - "<span id=\"lbl_xb\">".Length - n);
			rt.Add("sex", sex);

			string ethnic = "";
			reg = new Regex("<span id=\"lbl_mz\">(.+?)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				ethnic = match.Value.Substring("<span id=\"lbl_mz\">".Length, match.Value.Length - "<span id=\"lbl_mz\">".Length - n);
			rt.Add("ethnic", ethnic);

			string political = "";
			reg = new Regex("<span id=\"lbl_zzmm\">(.+?)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				political = match.Value.Substring("<span id=\"lbl_zzmm\">".Length, match.Value.Length - "<span id=\"lbl_zzmm\">".Length - n);
			rt.Add("political", political);

			string className = "";
			reg = new Regex("<span id=\"lbl_xzb\">(.+?)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				className = match.Value.Substring("<span id=\"lbl_xzb\">".Length, match.Value.Length - "<span id=\"lbl_xzb\">".Length - n);
			rt.Add("className", className);

			string grade = "";
			reg = new Regex("<span id=\"lbl_dqszj\">(.+?)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				grade = match.Value.Substring("<span id=\"lbl_dqszj\">".Length, match.Value.Length - "<span id=\"lbl_dqszj\">".Length - n);
			rt.Add("grade", grade);

			string faculty = "";
			reg = new Regex("<span id=\"lbl_xy\">(.+?)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				faculty = match.Value.Substring("<span id=\"lbl_xy\">".Length, match.Value.Length - "<span id=\"lbl_xy\">".Length - n);
			rt.Add("faculty", faculty);

			string discipline = "";
			reg = new Regex("<span id=\"lbl_zymc\">(.+?)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				discipline = match.Value.Substring("<span id=\"lbl_zymc\">".Length, match.Value.Length - "<span id=\"lbl_zymc\">".Length - n);
			rt.Add("discipline", discipline);

			string direction = "";
			reg = new Regex("<span id=\"lbl_zyfx\">(.+?)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				direction = match.Value.Substring("<span id=\"lbl_zyfx\">".Length, match.Value.Length - "<span id=\"lbl_zyfx\">".Length - n);
			rt.Add("direction", direction);

			string year = "";
			reg = new Regex("<span id=\"lbl_xz\">([1-9])</span>");
			match = reg.Match(page);
			if (match.Value != "")
				year = match.Value.Substring("<span id=\"lbl_xz\">".Length, match.Value.Length - "<span id=\"lbl_xz\">".Length - n)+"年";
			rt.Add("year", year);

			string level = "";
			reg = new Regex("<span id=\"lbl_CC\">(.+?)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				level = match.Value.Substring("<span id=\"lbl_CC\">".Length, match.Value.Length - "<span id=\"lbl_CC\">".Length - n);
			rt.Add("level", level);

			string idcard = "";
			reg = new Regex("<span id=\"lbl_sfzh\">([0-9a-zA-Z]+)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				idcard = match.Value.Substring("<span id=\"lbl_sfzh\">".Length, match.Value.Length - "<span id=\"lbl_sfzh\">".Length - n);
			rt.Add("idcard", idcard);

			string candidates = "";
			reg = new Regex("<span id=\"lbl_ksh\">([0-9]+)</span>");
			match = reg.Match(page);
			if (match.Value != "")
				candidates = match.Value.Substring("<span id=\"lbl_ksh\">".Length, match.Value.Length - "<span id=\"lbl_ksh\">".Length - n);
			rt.Add("candidates", candidates);

			return rt;
		}
		public static string getCurriculumHtmlTable()
		{
			Login login = Login.get();
			string url = login.homeUrl + "xskbcx.aspx?xh=" + login.id + "&xm=" + login.urlName + "&gnmkdm=N121602";
			string page = Url.readHtml(Url.getPageStream(url));
			Url.writeFile(page, "E://curriculum.html");
			Regex regex = new Regex("<table id=\"Table1\"(.+?)</table>", RegexOptions.Singleline);
			Match match = regex.Match(page);
			if (match.Value == "") return "";
			return "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\"><html><head>" +
			"<style>body{margin:0;color:#320;}table{border-collapse:collapse;margin:0;}table tr:hover{background:#eafcfc;}table td:hover{background:#e6e4ec;color:#f00;}table td{border:solid 1px #000;padding:2px;}</style>"
			+ "</head><body>" + match.Value + "</body></html>";
		}
		public static ListView getTestInfo() {
			Login login = Login.get();
			string url = login.homeUrl + "xskscx.aspx?xh=" + login.id + "&xm=" + login.urlName + "&gnmkdm=N121606";
			string page = Url.readHtml(Url.getPageStream(url));
			Url.writeFile(page,"E:\\TestInfo.html");
			if (page == null) return null;
			Regex reg = new Regex("<table(.+?)id=\"DataGrid1\"(.+?)/table>", RegexOptions.Singleline);
			Match match = reg.Match(page);
			if (match.Value == "")
			{
				return null;
			}
			return getListView(match.Value);
		}
		public static ListView getTestLevelInfo()
		{
			Login login = Login.get();
			string url = login.homeUrl + "xsdjkscx.aspx?xh="+login.id+"&xm="+login.urlName+"&gnmkdm=N121606";
			string page = Url.readHtml(Url.getPageStream(url));
			Url.writeFile(page,"E:\\TestLevelInfo.html");
			if (page == null) return null;
			Regex reg = new Regex("<table(.+?)id=\"DataGrid1\"(.+?)/table>", RegexOptions.Singleline);
			Match match = reg.Match(page);
			if (match.Value == "")
			{
				return null;
			}
			return getListView(match.Value);
		}
		public static ListView getListView(string table) {
			string rt = Regex.Replace(table, "\\s", "", RegexOptions.Singleline);
			rt = rt.Replace("</td><td>", "@");
			rt = Regex.Replace(rt,"class=\"(.+?)\"", "");
			rt = rt.Replace("</tr><tr>", "\n");
			rt = Regex.Replace(rt, "<(.+?)>", "", RegexOptions.None).Replace("&nbsp;", "");
			string[] split = rt.Split('\n');
			string[] split2;
			bool header = true;
			Dictionary<int, string> HeaderList = new Dictionary<int, string>();
			ArrayList List = new ArrayList();
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
					List.Add(sc);
				}
				return createListView(HeaderList,List);
			}
			catch
			{
				return null;
			}
		}
		public static ListView createListView(Dictionary<int, string> HeaderList, ArrayList List)
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
			foreach (Dictionary<string, string> list in List)
			{
				lv.Items.Add(new ListViewItem(list.Values.ToArray()));
			}
			return lv;
		}
	}
}
