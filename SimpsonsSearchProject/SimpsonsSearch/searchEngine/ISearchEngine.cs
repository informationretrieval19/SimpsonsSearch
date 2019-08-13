namespace SimpsonsSearch.searchEngine
{
    // Interface für eine Suchmaschine
    public interface ISearchEngine
	{
		//void BuildIndex();
		SearchResults Search(string query);
        SearchResults SearchAdvanced(string query);
        SearchResults SynonymSearchAllTerms(string query);
    }
}
