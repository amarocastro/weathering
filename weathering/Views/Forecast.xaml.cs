using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using weathering.Helper;
using weathering.Helper.GetForecastHelper;
using weathering.Model;
using weathering.Model.HereWeather;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace weathering.Views
{
	/// <summary>
	/// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
	/// </summary>
	public sealed partial class Forecast : Page
	{
		//private Position position;
		//private CurrentWeatherMask current_mask;
		private GetForecastHelper getForecastHelper = new GetForecastHelper();
		private string currentTemp = "";
		private string currentHumidity = "";
		private string currentWindSpeed = "";
		private string currentDescription = "";

		public Forecast()
		{
			this.InitializeComponent();
		}
		
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			if (e != null)
			{
				SimpleItem item = e.Parameter as SimpleItem;
				string provider = SettingsManager.GetProviderSetting();
				this.GetForecastFromPosition(item.position,provider);
			}
		}
		private async void GetForecastFromPosition(Position position, string provider)
		{
			CurrentWeatherMask currentForecast = await getForecastHelper.GetCurrentForecast(position, provider);
			currentTemp = currentForecast.getCurrentTemp();
			currentHumidity = currentForecast.getHumidity();	
			

		}
	}
}
