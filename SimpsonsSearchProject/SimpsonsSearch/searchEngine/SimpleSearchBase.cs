using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Microsoft.AspNetCore.Mvc;
using SimpsonsSearch.Models;
using SimpsonsSearch.Services;
using Directory = Lucene.Net.Store.Directory;

namespace SimpsonsSearch.searchEngine
{
    public class SimpleSearchBase
    {
        private const LuceneVersion LUCENEVERSION = LuceneVersion.LUCENE_48;
        private string _luceneDir = @"Index\Base";
        private readonly IConversionService _conversionService;

        private FSDirectory _indexDirectory;
        private readonly QueryParser _queryParser;
        private readonly IndexWriter _indexWriter;
        private readonly SearcherManager _searcherManager;

        public SimpleSearchBase(IConversionService conversionService)
        {
            _conversionService = conversionService;
            Analyzer analyzer = new StandardAnalyzer(LUCENEVERSION, StandardAnalyzer.STOP_WORDS_SET);
            _queryParser = new MultiFieldQueryParser(LUCENEVERSION, new[] { "text" }, analyzer);
            _indexWriter = new IndexWriter(GetIndex(), new IndexWriterConfig(LUCENEVERSION, analyzer));
            _searcherManager = new SearcherManager(_indexWriter, true, null);
        }

        public FSDirectory GetIndex()
        {

            _indexDirectory = FSDirectory.Open(new DirectoryInfo(_luceneDir));
            {
                if (IndexWriter.IsLocked(_indexDirectory))
                {
                    IndexWriter.Unlock(_indexDirectory);
                }

                var lockFilePath = Path.Combine(_luceneDir, "write.lock");
                if (File.Exists(lockFilePath))
                {
                    File.Delete(lockFilePath);
                }

                return _indexDirectory;
            }

        }

        /// <summary>
        /// Methode die für den Index Dokumente aus einem Scriptline Objekt baut, aus beliebig vielen Feldern, der eingelesenen Datei 
        /// </summary>
        /// <returns>Document</returns>
        public virtual Document BuildDocument(ScriptLine scriptLine)
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

        /// <summary>
        /// Methode die aus gefundenen Documenten im INdex, ein Ergebnis erstellt 
        /// </summary>
        /// <returns>SearchResults</returns>
        public SearchResults CompileResults(IndexSearcher searcher, TopDocs topDocs)
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

        public void BuildIndex()
        {
            var scriptLines = _conversionService.ConvertCsVtoScriptLines();

            if (scriptLines == null) throw new ArgumentNullException();

            foreach (var scriptLine in scriptLines)
            {
                var document = BuildDocument(scriptLine);
                _indexWriter.UpdateDocument(new Term("id", scriptLine.id), document);
            }

            _indexWriter.Flush(true, true);
            _indexWriter.Commit();
        }

        public SearchResults PrepareSearch(string searchQuery)
        {
            if (DirectoryReader.IndexExists(GetIndex()))
            {
                // wenn indexexists do no call buildindex please!
            }
            else
            {
                BuildIndex();
            }

            var resultsPerPage = 20000;
            var query = _queryParser.Parse(searchQuery);
            _searcherManager.MaybeRefresh();

            var searcher = _searcherManager.Acquire();

            try
            {
                var topDocs = searcher.Search(query, resultsPerPage);
                return CompileResults(searcher, topDocs);
            }
            finally
            {
                _searcherManager.Release(searcher);

            }
        }


    }
}






