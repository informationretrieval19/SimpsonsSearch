using System.Collections.Generic;

namespace SimpsonsSearch.searchEngine
{
	public class SearchResults
	{
		public SearchResults() => Hits = new List<Hit>();
		public string Time { get; set; }
		public int TotalHits { get; set; }
		public IList<Hit> Hits { get; set; }
	}

	/// <summary>
	/// a representation of a movie item retrieved from lucene.net
	/// </summary>
	public class Hit
	{
		public string Id { get; set; }
		public string Person { get; set; }
		public string Location { get; set; }
		public string Snippet { get; set; }
		public float Score { get; set; }
	}
}


