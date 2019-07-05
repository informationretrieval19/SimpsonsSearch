using System.Linq;
using SimpsonsSearch.searchEngine.topics;

namespace SimpsonsSearch.searchEngine
{
    public class LuceneEngine : ISearchEngine
    {
        private readonly SimpleSearchBase _simpleSearchBase;
        private readonly AdvancedSearchWithSynonyms _advancedSearchWithSynonyms;
        private readonly AdvancedSearchBase _advancedSearchBase;
        private readonly AlcoholTopic _alcoholTopic;

        public LuceneEngine(SimpleSearchBase simpleSearchBase, AdvancedSearchWithSynonyms advancedSearchWithSynonyms, AdvancedSearchBase advancedSearchBase, AlcoholTopic alcoholTopic)
        {
            _simpleSearchBase = simpleSearchBase;
            _advancedSearchWithSynonyms = advancedSearchWithSynonyms;
            _advancedSearchBase = advancedSearchBase;
            _alcoholTopic = alcoholTopic;
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
            var dicionaries = new Dictionaries();
            if (dicionaries.alcoholDic.ContainsValue(searchQuery))
            {
                return _alcoholTopic.PrepareSearch(searchQuery);
            }
            return _advancedSearchWithSynonyms.PrepareSearch(searchQuery);
        }
    }
}
