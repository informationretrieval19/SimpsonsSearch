using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using SimpsonsSearch.Models;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.searchEngine
{
    public class SynonymSearchAllTerms : SynonymSearch
    {
        private readonly IndexWriter indexWriter;
        private readonly Analyzer analyzer;
        private readonly Analyzer analyzerSearch;
        private readonly QueryParser queryParser;
        private readonly SearcherManager searcherManager;

        public SynonymSearchAllTerms(IConversionService conversionService, IEnumerable<Episode> episodes) : base(conversionService, episodes)
        {
            
            indexWriter = new IndexWriter(GetIndex(), new IndexWriterConfig(LUCENEVERSION, analyzer));
            analyzer = new StandardAnalyzer(LUCENEVERSION, StandardAnalyzer.STOP_WORDS_SET);
            analyzerSearch = new SynonymAnalyzer();
            queryParser = new MultiFieldQueryParser(LUCENEVERSION, new[] { "text", "characters", "location" }, analyzerSearch);
            searcherManager = new SearcherManager(indexWriter, true, null);
           
        }

        public override SearchResults PrepareSearch(string searchQuery)
        {
            if (!DirectoryReader.IndexExists(GetIndex()))
            {
                BuildIndex();
            }

            var resultsPerPage = 100;
            var query = queryParser.Parse(searchQuery);
            searcherManager.MaybeRefresh();

            var searcher = searcherManager.Acquire();

            try
            {
                var topDocs = searcher.Search(query, resultsPerPage);
                var results = CompileResults(searcher, topDocs, searchQuery);
                return results;
            }
            finally
            {
                searcherManager.Release(searcher);

            }
        }

    }
}
