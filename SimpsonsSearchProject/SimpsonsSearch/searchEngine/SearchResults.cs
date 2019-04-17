using System.Collections.Generic;

namespace SimpsonsSearch.searchEngine
{
	// Ergebnis was lucene nach einer suche zurück gibt
	public class SearchResults
	{
		public SearchResults() => Hits = new List<Hit>();
		public string Time { get; set; }
		public int TotalHits { get; set; }
		public IList<Hit> Hits { get; set; }
	}

	// enthält alles was für jeden Suchtreffer angezeigt werden soll
	public class Hit
	{
		public string Id { get; set; }
		public string Person { get; set; }
		public string Location { get; set; }
		public string Text { get; set; }
		public float Score { get; set; }
		public float? Timestamp { get; set; }
	}
}


