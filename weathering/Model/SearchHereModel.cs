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

	public class LookUpByID
	{
		public AddressLookUp address { get; set; }
		public Position position { get; set; }
	}
	public class Position
	{
		public decimal lat { get; set; }
		public decimal lng { get; set; }
	}

	public class AddressLookUp
	{
		public string countryName { get; set; }
		public string countryCode { get; set; }
		public string state { get; set; }
		public string county { get; set; }
		public string city { get; set; }
	}
}
