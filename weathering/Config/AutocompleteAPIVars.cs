using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weathering.Config
{
	public class AutocompleteAPIVars
	{
		public static string AUTOCOMPLETE_SUGGEST_HEREapi_OLD = "https://autocomplete.geocoder.ls.hereapi.com/6.2/suggest.json?resultType=city&apiKey={key}&query={text}";
		public static string AUTOCOMPLETE_SUGGEST_HEREapi = "https://autosuggest.search.hereapi.com/v1/autosuggest?at={lat},{lang}&q={text}&apiKey={key}";
		public static string HERE_LOOKUP_BY_ID_API = "https://lookup.search.hereapi.com/v1/lookup?id={id}&apiKey={key}";
	}
}
