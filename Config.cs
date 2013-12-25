using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Configuration;

namespace JiaowuHelper
{
	class ConfigInfo
	{
		public string url = "";
		public string username = "";
		public string password = "";
		public bool autoLogin = false;
	}
	class Config
	{
		public static ConfigInfo get()
		{
			ConfigInfo ci = new ConfigInfo();
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			if (config.AppSettings.Settings.AllKeys.Contains("user"))
				ci.username = config.AppSettings.Settings["user"].Value;
			if (config.AppSettings.Settings.AllKeys.Contains("url"))
				ci.url = config.AppSettings.Settings["url"].Value;
			if (config.AppSettings.Settings.AllKeys.Contains("password"))
				ci.password = config.AppSettings.Settings["password"].Value;
			if (config.AppSettings.Settings.AllKeys.Contains("autoLogin"))
				ci.autoLogin = Boolean.Parse(config.AppSettings.Settings["autoLogin"].Value);
			return ci;
		}
		public static bool save(ConfigInfo ci)
		{
			try
			{
				Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				if (config.AppSettings.Settings.AllKeys.Contains("user"))
					config.AppSettings.Settings["user"].Value = ci.username;
				else
					config.AppSettings.Settings.Add("user", ci.username);

				if (config.AppSettings.Settings.AllKeys.Contains("url"))
					config.AppSettings.Settings["url"].Value = ci.url;
				else
					config.AppSettings.Settings.Add("url", ci.url);

				if (config.AppSettings.Settings.AllKeys.Contains("password"))
					config.AppSettings.Settings["password"].Value = ci.password;
				else
					config.AppSettings.Settings.Add("password", ci.password);

				if (config.AppSettings.Settings.AllKeys.Contains("autoLogin"))
					config.AppSettings.Settings["autoLogin"].Value = ci.autoLogin.ToString();
				else
					config.AppSettings.Settings.Add("autoLogin", ci.autoLogin.ToString());

				config.Save(ConfigurationSaveMode.Minimal);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public static bool delete() {
			try
			{
				Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				File.Delete(config.FilePath);
				return true;
			}
			catch {
				return false;
			}
		}
	}
}
