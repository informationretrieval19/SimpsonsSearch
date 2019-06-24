using System;
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
        private const LuceneVersion LUCENEVERSION = LuceneVersion.LUCENE_48;
        private readonly IConversionService _conversionService;
        private FSDirectory _indexDirectory;

        public SimpleSearchBase(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }




        // getter für die Properties die lucene benötigt um index zu bauen/zudurchsuchen
        public virtual string LuceneDir
        {
            get
            {
                var luceneDir = @"Index\Base";
                return luceneDir;
            }
        }

        public virtual IndexWriter IndexWriter
        {
            get
            {
                var indexWriter = new IndexWriter(GetIndex(), new IndexWriterConfig(LUCENEVERSION, Analyzer));
                return indexWriter;
            }
        }

        public virtual QueryParser QueryParser
        {
            get
            {
                var queryParser = new MultiFieldQueryParser(LUCENEVERSION, new[] { "text" }, Analyzer);
                return queryParser;
            }
        }

        public virtual Analyzer Analyzer
        {
            get
            {
                var analyzer = new StandardAnalyzer(LUCENEVERSION, StandardAnalyzer.STOP_WORDS_SET);
                return analyzer;
            }
           
        }

        public virtual SearcherManager SearcherManager
        {
            get
            {
                var searcherManager = new SearcherManager(IndexWriter, true, null);
                return searcherManager;
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

        public virtual void BuildIndex()
        {
            var scriptLines = _conversionService.ConvertCsVtoScriptLines();

            if (scriptLines == null) throw new ArgumentNullException();

            foreach (var scriptLine in scriptLines)
            {
                var document = BuildDocument(scriptLine);
                IndexWriter.UpdateDocument(new Term("id", scriptLine.id), document);
            }

            IndexWriter.Flush(true, true);
            IndexWriter.Commit();
        }

        public virtual SearchResults PrepareSearch(string searchQuery)
        {
            if (DirectoryReader.IndexExists(GetIndex()))
            {
                // wenn indexexists do no call buildindex!
            }
            else
            {
                BuildIndex();
            }

            var resultsPerPage = 20000;
            var query = QueryParser.Parse(searchQuery);
            SearcherManager.MaybeRefresh();

            var searcher = SearcherManager.Acquire();

            try
            {
                var topDocs = searcher.Search(query, resultsPerPage);
                return CompileResults(searcher, topDocs);
            }
            finally
            {
                SearcherManager.Release(searcher);

            }
        }

        private FSDirectory GetIndex()
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






