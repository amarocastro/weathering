using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weathering.Config;
using weathering.Config.HereWeather;
using weathering.Model;
using weathering.Model.HereWeather;
using Windows.ApplicationModel.Contacts;
using Windows.ApplicationModel.Core;
using Windows.Foundation;

namespace weathering.Helper.GetForecastHelper
{
	public class GetForecastHelper
	{

		public async Task<CurrentWeatherMask> GetCurrentForecast(Position position, string provider)
		{
			Type type = SelectProviderClass(provider); //get the provider type for later storing the response
			CurrentWeatherMask maskedCurrent = (CurrentWeatherMask)Activator.CreateInstance(type); //builds the instance for storing the response with the propper type
			
			string query = SelectAPIUrlFromProvider(position, provider); //get api request

			await Task.Run(() =>
			{
				//run the request
				this.ExecuteQueryGetCurrentForecast(query, provider,
					(response) =>
					{
						IAsyncAction a = CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
						{
							if (response != null)
							{
								maskedCurrent = response;
							}
						});
						return true;
					},
					 (error) =>
					 {
						 IAsyncAction a = CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
						 {
							 System.Diagnostics.Debug.WriteLine(error);
						 });
						 return false;
					 });

			});
			return maskedCurrent;
		}

		private async void ExecuteQueryGetCurrentForecast(string query, string provider, Func<CurrentWeatherMask, bool> success, Func<string, bool> error)
		{
			//select the propper provider so later we can parse the json response to the propper class type and executes
				try
			{
				if (provider == Consts.PROVIDERS_LIST.here_weather.ToString()){
					success(await ApiConnector.DoQueryAsync<Observation>(query));
				}
			}
			catch (Exception e)
			{
				error(e.Message);
			}
		}
		private string SelectAPIUrlFromProvider(Position position, string provider)
		{
			//Builds de URL for getting the forecast data
			string query = "";
			if (provider == Consts.PROVIDERS_LIST.here_weather.ToString())
			{
				query = HereWeatherVars.HERE_WEATHER_URL;
				query = query.Replace("{product}", HereWeatherVars.HERE_FORECAST_CURRENT); //period of forecast data current, hourly , 7 days
				query = query.Replace("{lat}", position.lat); //latitude
				query = query.Replace("{lng}", position.lng); //longitude
				query = query.Replace("{key}", Consts.HERE_APIKEY); //key
			}

			return query;
		}
		private Type SelectProviderClass(string provider)
		{
			//gets the provider class from the name set in configure ['provider']
			if (provider == Consts.PROVIDERS_LIST.here_weather.ToString())
			{
				return typeof(Observation);
			}
			else
			{
				return typeof(Observation);
			}
		}
	}
}
