using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weathering.Model;

namespace weathering.Model.HereWeather
{
	public class Observation : CurrentWeatherMask
	{
		public Obser observations { get; set; }
		public DateTime feedCreation { get; set; }
		
		public bool metreic { get; set; }

		public override string getCurrentTemp()
		{
			return this.observations.location.First<Info>().observation.First<Result>().temperature.ToString();
		}

		public override string getDescription()
		{
			return this.observations.location.First<Info>().observation.First<Result>().description.ToString();
		}

		public override string getFeelingTemp()
		{
			throw new NotImplementedException();
		}

		public override string getHumidity()
		{
			return this.observations.location.First<Info>().observation.First<Result>().humidity.ToString();
		}

		public override string getPressure()
		{
			return this.observations.location.First<Info>().observation.First<Result>().barometerPressure.ToString();
		}

		public override string getRocio()
		{
			return this.observations.location.First<Info>().observation.First<Result>().dewPoint.ToString();		
		}

		public override string getVisibility()
		{
			return this.observations.location.First<Info>().observation.First<Result>().distance.ToString();
		}

		public override string getWindSpeed()
		{
			return this.observations.location.First<Info>().observation.First<Result>().windSpeed.ToString();
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
