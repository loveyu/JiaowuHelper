using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JiaowuHelper
{
	class Update
	{
		public void run() {
			Thread th = new Thread(new ThreadStart(process));
			th.Start();
		}
		private void process() {
			string page = Url.readHtml(Url.getPageStream(Browser.updateUrl));
			if (page == "") return;
			string[] list = page.Split('\n');
			Version vsNew = new Version(list[0]);
			Version vs = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			if (vsNew.CompareTo(vs) <= 0) return;
			if (MessageBox.Show(Encoding.UTF8.GetString(Encoding.GetEncoding("gb2312").GetBytes(page)), "是否升级新版本？",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Browser.openAppPage();
			}
			else {
				Browser.openAuthor = true;
			}
		}
	}
}
