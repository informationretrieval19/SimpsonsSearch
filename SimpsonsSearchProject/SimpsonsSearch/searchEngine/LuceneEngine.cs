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
    /// <summary>
    /// Enthält Implementation der Lucene Suchengine
    /// </summary>
    public class LuceneEngine : ISearchEngine
	{
		private readonly IConversionService _conversionService;

        // Lucene Objekte die benötigt werden
        private const LuceneVersion MATCH_LUCENE_VERSION = LuceneVersion.LUCENE_48;
        private readonly IndexWriter writer;
        private readonly Analyzer analyzer;
        private readonly QueryParser queryParser;
        private readonly SearcherManager searchManager;

        public LuceneEngine(IConversionService conversionService)
		{
			_conversionService = conversionService;

            analyzer = new StandardAnalyzer(MATCH_LUCENE_VERSION, StandardAnalyzer.STOP_WORDS_SET);
            queryParser = SetupQueryParser(analyzer);
            writer = new IndexWriter(new RAMDirectory(), new IndexWriterConfig(MATCH_LUCENE_VERSION, analyzer));
            searchManager = new SearcherManager(writer, true, null);
        }

		public void BuildIndex()
		{
			var scriptLines = _conversionService.ConvertCsVtoScriptLines();

            if (scriptLines == null) throw new ArgumentNullException();

            foreach (var scriptLine in scriptLines)
            {
                var document = BuildDocument(scriptLine);
                writer.UpdateDocument(new Term("id", scriptLine.id), document);
            }

            writer.Flush(true, true);
            writer.Commit();
        } 

		public SearchResults Search(string searchQuery)
		{
            int resultsPerPage = 20000;
            var query = BuildQuery(searchQuery);
            searchManager.MaybeRefreshBlocking();
            var searcher = searchManager.Acquire();

            try
            {
                var topDocs = searcher.Search(query, resultsPerPage);
                return CompileResults(searcher, topDocs);
            }
            finally
            {
                searchManager.Release(searcher);
                searcher = null;
            }
        }

        private QueryParser SetupQueryParser(Analyzer analyzer)
        {
            return new MultiFieldQueryParser(
                MATCH_LUCENE_VERSION,
                new[] { "text", "person" },
                analyzer
            );
        }

        private Document BuildDocument(ScriptLine scriptLine)
        {

            var doc = new Document
            {
                new StoredField("id", scriptLine.id),
                new TextField("text", scriptLine.spoken_words, Field.Store.YES),
                new TextField("person", scriptLine.raw_character_text, Field.Store.YES),
                new TextField("location", scriptLine.raw_location_text, Field.Store.YES),
                new TextField("episodeId", scriptLine.episode_id.ToString(), Field.Store.YES),
                new StoredField("timestamp", scriptLine.timestamp_in_ms)
            };

            return doc;
        }

        private SearchResults CompileResults(IndexSearcher searcher, TopDocs topdDocs)
        {
            var searchResults = new SearchResults() { TotalHits = topdDocs.TotalHits };
            foreach (var result in topdDocs.ScoreDocs)
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

        private Query BuildQuery(string queryString) => queryParser.Parse(queryString);

        public void Dispose()
        {
            searchManager?.Dispose();
            analyzer?.Dispose();
            writer?.Dispose();
        }
    }
}