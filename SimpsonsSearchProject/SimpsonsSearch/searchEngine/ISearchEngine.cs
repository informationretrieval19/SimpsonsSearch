namespace SimpsonsSearch.searchEngine
{
    // Interface für eine Suchmaschine
    public interface ISearchEngine
	{
		//void BuildIndex();
		SearchResults Search(string query);
        SearchResults SearchSimple(string query);
        SearchResults SearchAdvanced(string query);
    }
}
