using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace SimpsonsSearch.searchEngine
{
	// model der Datasource(scriptline.csv)
	public class ScriptLine
	{
		public string id { get; set; }
		public string episode_id { get; set; }
		public string number { get; set; }
		public string raw_text { get; set; }
		public string timestamp_in_ms { get; set; }
		public string speaking_line { get; set; }
		public string character_id { get; set; }
		public string location_id { get; set; }
		public string raw_character_text { get; set; }
		public string raw_location_text { get; set; }
		public string spoken_words { get; set; }
		public string normalized_text { get; set; }
		public string word_count { get; set; }

	}
}
