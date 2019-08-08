using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace SimpsonsSearch.searchEngine
{
	// Suchergebnisse von lucene und selbst festgelegte
	public class SearchResults
	{
		public SearchResults() => Hits = new List<Hit>();
		public string Time { get; set; }
		public int TotalHits { get; set; }
		public IList<Hit> Hits { get; set; }


        public string TopicName { get; set; }
    }

	// enthält alles was für jeden Suchtreffer angezeigt werden soll
	public class Hit
	{
		public string Id { get; set; }
        public string EpisodeId { get; set; }
		public string Person { get; set; }
		public string Location { get; set; }
		public string Text { get; set; }
		public float Score { get; set; }
		public string Timestamp { get; set; }

        //aus episodes.csv, mapping über episodeId aus scriptlines.csv
        public string episodeName { get; set; }
        public string season { get; set; }
	}
}


