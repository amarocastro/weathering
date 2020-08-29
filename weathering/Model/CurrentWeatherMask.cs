using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathering.Model
{
	public abstract class CurrentWeatherMask : CurrentWeatherInterface
	{
		public abstract string getCurrentTemp();
		public abstract string getDescription();
		public abstract string getFeelingTemp();
		public abstract string getHumidity();
		public abstract string getPressure();
		public abstract string getRocio();
		public abstract string getVisibility();
		public abstract string getWindSpeed();
	}
}
