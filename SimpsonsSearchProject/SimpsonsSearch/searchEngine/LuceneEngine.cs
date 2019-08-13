using System.Linq;


namespace SimpsonsSearch.searchEngine
{
    public class LuceneEngine : ISearchEngine
    {
        private readonly SimpleSearchBase _simpleSearchBase;
        private readonly SynonymSearch _synonymSearch;
        private readonly SynonymSearchAllTerms _synonymAllTerms;

        public LuceneEngine(SimpleSearchBase simpleSearchBase, SynonymSearch synonymSearch, SynonymSearchAllTerms synonymAllTerms)
        {
            _simpleSearchBase = simpleSearchBase;
            _synonymSearch = synonymSearch;
            _synonymAllTerms = synonymAllTerms;
         
        }
        // zuordnungsklasse
        // hier mapping wie und wann welche klasse zur indexbildung ausgewählt wird 
        // ruft unter bestimmtem umständen die base klasse oder eine spezielle klasse auf 


        public SearchResults Search(string query)
        {
            return _simpleSearchBase.PrepareSearch(query);
        }

        public SearchResults SearchAdvanced(string query)
        {
            var dicionaries = new Dictionaries();
            
            return _synonymSearch.PrepareSearch(query);
        }

        public SearchResults SynonymSearchAllTerms(string query)
        {
            var dicionaries = new Dictionaries();

            return _synonymAllTerms.PrepareSearch(query);
        }
        
    }
}
