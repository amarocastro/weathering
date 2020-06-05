using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathering.Model
{
	public class Suggestions
	{
		public List<Item> suggestions { get; set; }
	}

	public class Item
	{
		public Address address { get; set; }
		public string locationId { get; set; }
		public string matchlevel { get; set; }
	}
	public class Address 
	{
		public string country { get; set; }
		public string state { get; set; }
		public string county { get; set; }
		public string city { get; set; }
	}
}
