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

namespace SimpsonsSearch.searchEngine
{
   
    public class LuceneEngine : ISearchEngine
    {
        private readonly SimpleSearchBase _simpleSearchBase;
        private readonly SimpleSearchTest _simpleSearchTest;

        public LuceneEngine(SimpleSearchBase simpleSearchBase, SimpleSearchTest simpleSearchTest)
        {
            _simpleSearchBase = simpleSearchBase;
            _simpleSearchTest = simpleSearchTest;
        }


        public SearchResults Search(string searchQuery)
        {
            return _simpleSearchBase.PrepareSearch(searchQuery);
            //return _simpleSearchTest.PrepareSearch(searchQuery);
        }
    }
}