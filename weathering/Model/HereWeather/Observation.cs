using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weathering.Model;

namespace weathering.Model.HereWeather
{
	public class Observation : CurrentWeatherInterface
	{
		public Obser observation { get; set; }
		public DateTime feedCreation { get; set; }
		
		public bool metreic { get; set; }

		public string getCurrentTemp()
		{
			return this.observation.location.First<Info>().observation.First<Result>().temperature.ToString();
		}

		public string getDescription()
		{
			return this.observation.location.First<Info>().observation.First<Result>().description.ToString();
		}

		public string getFeelingTemp()
		{
			throw new NotImplementedException();
		}

		public string getHumidity()
		{
			return this.observation.location.First<Info>().observation.First<Result>().humidity.ToString();
		}

		public string getPressure()
		{
			return this.observation.location.First<Info>().observation.First<Result>().barometerPressure.ToString();
		}

		public string getRocio()
		{
			return this.observation.location.First<Info>().observation.First<Result>().dewPoint.ToString();		
		}

		public string getVisibility()
		{
			return this.observation.location.First<Info>().observation.First<Result>().distance.ToString();
		}

		public string getWindSpeed()
		{
			return this.observation.location.First<Info>().observation.First<Result>().windSpeed.ToString();
		}
	}

	public class Obser
	{
		public List<Info> location { get; set; }
		public int timiezone { get; set; }
	}
	public class Info
	{
		public List<Result> observation { get; set; }
	}
	public class Result
	{
		public string description { get; set; }
		public int skyInfo { get; set; }
		public string skyDescription { get; set; }
		public decimal temperature { get; set; }
		public string temperatureDesc { get; set; }
		public decimal comfort { get; set; }
		public decimal highTemperature { get; set; }
		public decimal lowTemperature { get; set; }
		public int humidity { get; set; }
		public decimal dewPoint { get; set; }
		public decimal windSpeed { get; set; }
		public decimal windDirection { get; set; }
		public string windDesc { get; set; }
		public string windDescShort { get; set; }
		public decimal barometerPressure { get; set; }
		public string iconName {get; set;}
		public decimal distance { get; set; }

		public DateTime utcTime { get; set; }

	}
}
