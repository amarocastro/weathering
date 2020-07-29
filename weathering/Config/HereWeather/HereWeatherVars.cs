using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathering.Config.HereWeather
{
	public static class HereWeatherVars
	{
		public static string HERE_WEATHER_URL = "https://weather.ls.hereapi.com/weather/1.0/report.json?product={product}&latitude={lat}&longitude={lng}";
		public const string HERE_FORECAST_SEVEN_DAYS = "forecast_7days";
		public const string HERE_FORECAST_CURRENT = "observation";
		public const string HERE_FORECAST_SEVEN_DAYS_SIMPLE = "forecast_7days_simple";
		public const string HERE_FORECAST_HOURLY = "forecast_hourly";
		public const string HERE_ALERTS = "alerts";

	}
}
