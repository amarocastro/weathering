using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathering.Config
{
	public class AutocompleteAPIVars
	{
		public static string AUTOCOMPLETE_SUGGEST_HEREapi = "https://autocomplete.geocoder.ls.hereapi.com/6.2/suggest.json?resultType=city&apiKey={key}&query={text}";
		public static string HERE_LOOKUP_BY_ID_API = "https://lookup.search.hereapi.com/v1/lookup?id={id}&apiKey={key}";
	}
}
