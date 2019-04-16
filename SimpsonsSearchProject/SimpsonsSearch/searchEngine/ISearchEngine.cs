using System.Collections.Generic;

namespace SimpsonsSearch.searchEngine
{
	public interface ISearchEngine
	{
		void BuildIndex();
		SearchResults Search(string query);
		IEnumerable<ScriptLine> GetDataFromFile();
	}
}
