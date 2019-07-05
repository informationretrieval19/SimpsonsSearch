using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Queries;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using SimpsonsSearch.Services;
using FilterClause = Lucene.Net.Search.FilterClause;

namespace SimpsonsSearch.searchEngine
{
    public class AdvancedSearchWithSynonyms : SimpleSearchBase
    {
        private readonly IConversionService _conversionService;
        private FSDirectory _indexDirectory;
        private readonly IndexWriter indexWriter;
        private readonly Analyzer analyzer;
        private readonly Analyzer analyzerSearch;
        private readonly QueryParser queryParser;
        private readonly SearcherManager searcherManager;

        public AdvancedSearchWithSynonyms(IConversionService conversionService) : base(conversionService)
        {
            _conversionService = conversionService;
            analyzer = new StandardAnalyzer(LUCENEVERSION, StandardAnalyzer.STOP_WORDS_SET);
            analyzerSearch = new SynonymAnalyzer();
            queryParser = new MultiFieldQueryParser(LUCENEVERSION, new[] { "text" }, analyzerSearch);
            indexWriter = new IndexWriter(GetIndex(), new IndexWriterConfig(LUCENEVERSION, analyzer));
            searcherManager = new SearcherManager(indexWriter, true, null);
        }

        public override string LuceneDir => @"index/test";

        public override SearchResults PrepareSearch(string searchQuery)
        {
            if (!DirectoryReader.IndexExists(GetIndex()))
            {
                BuildIndex();
            }

            var resultsPerPage = 20000;
            var query = queryParser.Parse(searchQuery);
            searcherManager.MaybeRefresh();

            var searcher = searcherManager.Acquire();

            try
            {
                var topDocs = searcher.Search(query, resultsPerPage);
                var results = CompileResults(searcher, topDocs);
                return results;
            }
            finally
            {
                searcherManager.Release(searcher);

            }
        }


        public override void BuildIndex()
        {
            var scriptLines = _conversionService.ConvertCsVtoScriptLines();
            if (scriptLines == null) throw new ArgumentNullException();

            foreach (var scriptLine in scriptLines)
            {
                var document = BuildDocument(scriptLine);


                indexWriter.UpdateDocument(new Term("scriptlines", scriptLine.id), document);

            }

            indexWriter.Flush(true, true);
            indexWriter.Commit();
        }

        public override Document BuildDocument(ScriptLine scriptLine)
        {
            return base.BuildDocument(scriptLine);
        }


        public override SearchResults CompileResults(IndexSearcher searcher, TopDocs topDocs)
        {
            var searchResults = new SearchResults() { TotalHits = topDocs.TotalHits };
            foreach (var result in topDocs.ScoreDocs)
            {
                Document document = searcher.Doc(result.Doc);
                Hit searchResult = new Hit
                {
                    Location = document.GetField("location")?.GetStringValue(),
                    Id = document.GetField("episodeId")?.GetStringValue(),
                    Score = result.Score,
                    Person = document.GetField("person")?.GetStringValue(),
                    Text = document.GetField("text")?.GetStringValue(),
                    Timestamp = document.GetField("timestamp")?.GetSingleValue()
                };
                searchResults.Hits.Add(searchResult);
            }

            return searchResults;
        }


        public override FSDirectory GetIndex()
        {
            _indexDirectory = FSDirectory.Open(new DirectoryInfo(LuceneDir));
            {
                if (IndexWriter.IsLocked(_indexDirectory))
                {
                    IndexWriter.Unlock(_indexDirectory);
                }

                var lockFilePath = Path.Combine(LuceneDir, "write.lock");
                if (File.Exists(lockFilePath))
                {
                    File.Delete(lockFilePath);
                }

                return _indexDirectory;
            }
        }
    }
}
