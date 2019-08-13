using System.Linq;


namespace SimpsonsSearch.searchEngine
{
    public class LuceneEngine : ISearchEngine
    {
        private readonly SimpleSearchBase _simpleSearchBase;
        private readonly SynonymSearch _synonymSearch;

        public LuceneEngine(SimpleSearchBase simpleSearchBase, SynonymSearch synonymSearch)
        {
            _simpleSearchBase = simpleSearchBase;
            _synonymSearch = synonymSearch;
         
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
            //if (dicionaries.alcoholDic.ContainsValue(query))
            //{
            //    return _alcoholTopic.PrepareSearch(query);
            //}
            return _synonymSearch.PrepareSearch(query);
        }
    }
}
