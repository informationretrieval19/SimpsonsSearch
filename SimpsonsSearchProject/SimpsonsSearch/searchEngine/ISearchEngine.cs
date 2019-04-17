using System.Collections.Generic;

namespace SimpsonsSearch.searchEngine
{
	// diese Fähigkeiten hat die Suchemaschine
	public interface ISearchEngine
	{

		void BuildIndex();
		SearchResults Search(string query);
	}
}
