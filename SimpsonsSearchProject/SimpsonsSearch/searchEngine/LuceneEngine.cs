using System.Linq;

namespace SimpsonsSearch.searchEngine
{
    public class LuceneEngine : ISearchEngine
    {
        private readonly SimpleSearchBase _simpleSearchBase;
        private readonly AdvancedSearchWithSynonyms _advancedSearchWithSynonyms;
        private readonly AdvancedSearchBase _advancedSearchBase;

        public LuceneEngine(SimpleSearchBase simpleSearchBase, AdvancedSearchWithSynonyms advancedSearchWithSynonyms, AdvancedSearchBase advancedSearchBase)
        {
            _simpleSearchBase = simpleSearchBase;
            _advancedSearchWithSynonyms = advancedSearchWithSynonyms;
            _advancedSearchBase = advancedSearchBase;
        }
        // zuordnungsklasse
        // hier mapping wie und wann welche klasse zur indexbildung ausgewählt wird 
        // ruft unter bestimmtem umständen die base klasse oder eine spezielle klasse auf 


        public SearchResults Search(string query)
        {
            return _simpleSearchBase.PrepareSearch(query);
        }

        public SearchResults SearchSimple(string searchQuery)
        {

            return _simpleSearchBase.PrepareSearch(searchQuery);
        }
        
        public SearchResults SearchAdvanced(string searchQuery)
        {
            return _advancedSearchWithSynonyms.PrepareSearch(searchQuery);
        }
    }
}
