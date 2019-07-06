using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using SimpsonsSearch.Services;


namespace SimpsonsSearch.searchEngine
{
    public class SimpleSearchBase
    {
        public const LuceneVersion LUCENEVERSION = LuceneVersion.LUCENE_48;
        private readonly IConversionService _conversionService;
        private FSDirectory _indexDirectory;
        private readonly IndexWriter indexWriter;
        private readonly Analyzer analyzer;
        private readonly QueryParser queryParser;
        private readonly SearcherManager searcherManager;



        public SimpleSearchBase(IConversionService conversionService)
        {
            _conversionService = conversionService;
            analyzer = new StandardAnalyzer(LUCENEVERSION, StandardAnalyzer.STOP_WORDS_SET);
            queryParser = new MultiFieldQueryParser(LUCENEVERSION, new[] { "text" }, analyzer);
            indexWriter = new IndexWriter(GetIndex(), new IndexWriterConfig(LUCENEVERSION, analyzer));
            searcherManager = new SearcherManager(indexWriter, true, null);
        }


       // ort an dem index gespeichert wird ist überschreibbar 
        public virtual string LuceneDir
        {
            get
            {
                var luceneDir = @"Index/Base";
                return luceneDir;
            }
        }

        public virtual SearchResults PrepareSearch(string searchQuery)
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

        /// <summary>
        /// baut index
        /// </summary>
        public virtual void BuildIndex()
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
        public virtual SearchResults CompileResults(IndexSearcher searcher, TopDocs topDocs)
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

        /// <summary>
        /// Methode die für den Index Dokumente aus einem Scriptline Objekt baut, aus beliebig vielen Feldern, der eingelesenen Datei 
        /// </summary>
        /// <returns>Document</returns>
        
        /// <summary>
        /// hilfsmethode die gespeicherten index returned
        /// </summary>
        /// <returns></returns>
        public virtual FSDirectory GetIndex()
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






