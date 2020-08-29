using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace weathering.Helper
{
	public static class SettingsManager
	{
		public static string GetProviderSetting()
		{
			ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
			string provider_string = localSettings.Values["provider"].ToString();
			if (provider_string == null)
			{
				provider_string = "";

			}
			return provider_string;
		}

		public static void SaveProviderSetting(string provider)
		{
			ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
			localSettings.Values["provider"] = provider;
		}
	}
}
