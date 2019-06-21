using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using SimpsonsSearch.Services;
using System;
using System.Linq;

namespace SimpsonsSearch.searchEngine
{
   
    public class LuceneEngine : ISearchEngine
    {
        private readonly SimpleSearchBase _simpleSearchBase;
        private readonly SimpleSearchTest _simpleSearchTest;
        private readonly AdvancedSearchBase _advancedSearchBase;

        public LuceneEngine(SimpleSearchBase simpleSearchBase, SimpleSearchTest simpleSearchTest, AdvancedSearchBase advancedSearchBase)
        {
            _simpleSearchBase = simpleSearchBase;
            _simpleSearchTest = simpleSearchTest;
            _advancedSearchBase = advancedSearchBase;
        }
        // das ist die zuordnungsklasse
        // hier wird entschieden welcher index, bzw wie gesucht wird 
        // indem je nach dem ob der user den button(datenbankabfrage oder interpretative suche angekreuzt hat), der simplesearchbase oder advancedsearchbase ausgewählt wird
        // weitere unterscheidung: topic abhängig
        // wenn user bestimmte wörter eingibt die in einer wörterliste sind wird eine bestimmte klasse aufgerufen 
        // das selbe für simplesearch nur ohne wörterliste 
        // abhängig von den inputparametern der searchMethode, neben searchquery können noch weitere hinzukommen 

        public SearchResults Search(string query)
        {
            return _simpleSearchBase.PrepareSearch(query);
        }

        // hier fall unterscheidung für einfache suche 
        public SearchResults SearchSimple(string searchQuery)
        {
            return _simpleSearchBase.PrepareSearch(searchQuery);
        }
        // hier fall unterscheidung für interpretative suche 
        public SearchResults SearchAdvanced(string searchQuery)
        {
            var wordlist = new WordListBuilder();
            var list = wordlist.GetExampleList();
            if (list.Contains(searchQuery))
            {
                return _advancedSearchBase.PrepareSearch(searchQuery);
            }
            return _simpleSearchTest.PrepareSearch(searchQuery);
        }
    }
}