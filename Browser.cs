using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;

namespace JiaowuHelper
{
	class Browser
	{
		public static bool openAuthor = false;
		public static string updateUrl = "http://www.loveyu.net/Update/JiaowuHelper.php";
		public static void openUrl(string url) {
			try
			{
				RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
				string s = key.GetValue("").ToString().Split(' ')[0].Replace("\"","");
				System.Diagnostics.Process.Start(s, url);
			}
			catch (Exception ex){
				MessageBox.Show(ex.Message,"打开网址异常",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		public static void openAuthorPage() {
			openUrl("http://www.loveyu.org/?ref=jiaowuhelper");
			openAuthor = false;
		}
		public static void openAppPage() {
			openUrl("http://www.loveyu.net/JiaowuHelper");
		}
	}
}
