using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JiaowuHelper
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]

		static void Main()
		{
			Login login = Login.get();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			new Update().run();
			while (true)
			{
				if (!login.isLogin())
				{
					Application.Run(new FormLogin());
				}
				if (login.isLogin())
				{
					Application.Run(new FormMain());
				}
				if (login.isLogout() == false) break;
			}
			if (Browser.openAuthor)
				Browser.openAuthorPage();
		}
	}
}
