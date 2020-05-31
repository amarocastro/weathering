using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathering.Model
{
	public class Suggestions
	{
		public Address address { get; set; }
		public string locationId { get; set; }
	}
	public class Address 
	{
		public string country { get; set; }
		public string state { get; set; }
		public string county { get; set; }
		public string city { get; set; }
	}
}
