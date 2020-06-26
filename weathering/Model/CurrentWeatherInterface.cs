using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathering.Model
{
	public interface CurrentWeatherInterface
	{
		string getCurrentTemp();
		string getDescription();
		string getFeelingTemp();
		string getWindSpeed();
		string getVisibility();
		string getPressure();
		string getHumidity();
		string getRocio();
	}
}
