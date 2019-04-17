using System;
using System.Collections.Generic;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Support;
using Lucene.Net.Util;
using SimpsonsSearch.Helper;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.searchEngine
{
	// Klasee zur Index Bildung
	public class SimpsonsIndex : IDisposable
	{
		private const LuceneVersion MATCH_LUCENE_VERSION = LuceneVersion.LUCENE_48;
		private readonly IndexWriter writer;
		private readonly Analyzer analyzer;
		private readonly QueryParser queryParser;
		private readonly SearcherManager searchManager;
		private readonly IConversionService _conversionService;


		// bug mit DirectoryWriter.. deswegen RAMDirectory --> inperformant bei größeren Datensätzen

		public SimpsonsIndex(IConversionService conversionService)
		{
			_conversionService = conversionService;
			analyzer = new StandardAnalyzer(MATCH_LUCENE_VERSION, StandardAnalyzer.STOP_WORDS_SET);
			//analyzer = new KeywordAnalyzer();
			queryParser = SetupQueryParser(analyzer);
			//writer = new IndexWriter(FSDirectory.Open(indexPath), new IndexWriterConfig(MATCH_LUCENE_VERSION, analyzer));
			writer = new IndexWriter(new RAMDirectory(), new IndexWriterConfig(MATCH_LUCENE_VERSION, analyzer));
			searchManager = new SearcherManager(writer, true, null);
		}

		private QueryParser SetupQueryParser(Analyzer analyzer)
		{
			return new MultiFieldQueryParser(
				MATCH_LUCENE_VERSION,
				new[] { "text" },
				analyzer
			);
		}

		public void BuildIndex(IEnumerable<ScriptLine> scriptLines)
		{
			if (scriptLines == null) throw new ArgumentNullException();

			foreach (var scriptLine in scriptLines)
			{
				var document = BuildDocument(scriptLine);
				writer.UpdateDocument(new Term("id", scriptLine.id), document);
			}

			writer.Flush(true, true);
			writer.Commit();
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

		

		public SearchResults Search(string queryString)
		{
			int resultsPerPage = 10;
			var query = BuildQuery(queryString);
			searchManager.MaybeRefreshBlocking();
			var searcher = searchManager.Acquire();

			try
			{
				var topdDocs = searcher.Search(query, resultsPerPage);
				return CompileResults(searcher, topdDocs);
			}
			finally
			{
				searchManager.Release(searcher);
				searcher = null;
			}
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
