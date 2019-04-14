using System;
using System.Collections.Generic;
using System.Text;

namespace luceneTest
{
	public class SearchEngine : ISearchEngine
	{
		private readonly MovieIndex index;

		public SearchEngine()
		{
			index = new MovieIndex(Settings.IndexLocation);
		}

		public void BuildIndex() => index.BuildIndex(Repository.GetMoviesFromFile());

		public SearchResults Search(string query) => index.Search(query);
	}
}