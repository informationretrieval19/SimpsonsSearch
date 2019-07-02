using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.searchEngine
{
    public class AdvancedSearchWithSynonyms : SimpleSearchBase
    {
        // hier können alle methoden und attribute der klasse simplesearchbase überschrieben werden 
        public AdvancedSearchWithSynonyms(IConversionService conversionService) : base(conversionService)
        {
        }

        public override string LuceneDir => @"index/test";

        public override Analyzer Analyzer
        {
            get
            {
                var analyzer = new SynonymAnalyzer();
                return analyzer;
            }
        }

        public override IndexWriter IndexWriter
        {
            get
            {
                var indexWriter = new IndexWriter(GetIndex(), new IndexWriterConfig(LUCENEVERSION, Analyzer));
                return indexWriter;
            }
        }

        public override QueryParser QueryParser {
            get
            {
                var queryParser = new MultiFieldQueryParser(LUCENEVERSION, new[] { "text" }, Analyzer);
                return queryParser;
            }
        }
        public override SearcherManager SearcherManager {
            get
            {
                var searcherManager = new SearcherManager(IndexWriter, true, null);
                return searcherManager;
            }
        }
        public override Document BuildDocument(ScriptLine scriptLine)
        {
            return base.BuildDocument(scriptLine);
        }

        public override void BuildIndex()
        {
            base.BuildIndex();
        }

        public override SearchResults CompileResults(IndexSearcher searcher, TopDocs topDocs)
        {
            return base.CompileResults(searcher, topDocs);
        }

        public override SearchResults PrepareSearch(string searchQuery)
        {
            return base.PrepareSearch(searchQuery);
        }

       
    }
}
