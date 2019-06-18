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

        public LuceneEngine(SimpleSearchBase simpleSearchBase)
        {
            _simpleSearchBase = simpleSearchBase;
        }


        public SearchResults Search(string searchQuery)
        {
            return _simpleSearchBase.PrepareSearch(searchQuery);
        }
    }
}