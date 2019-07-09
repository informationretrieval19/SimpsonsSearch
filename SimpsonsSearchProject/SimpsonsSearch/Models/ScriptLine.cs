using System.Collections.Generic;

namespace SimpsonsSearch.searchEngine
{
    // Klasse die Daten aus Exceltabelle simpsons_episodes.csv enthält
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

        public List<string> persons { get; set; }

	}
}
