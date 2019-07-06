using System.Linq;


namespace SimpsonsSearch.searchEngine
{
    public class LuceneEngine : ISearchEngine
    {
        private readonly SimpleSearchBase _simpleSearchBase;
       

        public LuceneEngine(SimpleSearchBase simpleSearchBase)
        {
            _simpleSearchBase = simpleSearchBase;
         
        }
        // zuordnungsklasse
        // hier mapping wie und wann welche klasse zur indexbildung ausgewählt wird 
        // ruft unter bestimmtem umständen die base klasse oder eine spezielle klasse auf 


        public SearchResults Search(string query)
        {
            return _simpleSearchBase.PrepareSearch(query);
        }

 
    }
}
