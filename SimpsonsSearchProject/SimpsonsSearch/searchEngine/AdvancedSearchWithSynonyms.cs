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
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.searchEngine
{
    public class AdvancedSearchWithSynonyms : SimpleSearchBase
    {
        private readonly IConversionService _conversionService;
        private FSDirectory _indexDirectory;
        // hier können alle methoden und attribute der klasse simplesearchbase überschrieben werden 
        public AdvancedSearchWithSynonyms(IConversionService conversionService) : base(conversionService)
        {
            _conversionService = conversionService;
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
                var queryParser = new MultiFieldQueryParser(LUCENEVERSION, new[] { "id2" }, Analyzer);
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
            var scriptLines = _conversionService.ConvertCsVtoScriptLines();
            if (scriptLines == null) throw new ArgumentNullException();
            var documentList = new List<Document>();
            foreach (var scriptLine in scriptLines)
            {

                var document = BuildDocument(scriptLine);
                try
                {
                    IndexWriter.UpdateDocument(new Term("scriptlines", scriptLine.id), document);
                }
                catch (IOException e)
                {
                    IndexWriter.Dispose();
                    IndexWriter.AddDocument(document);
                }


            }
            IndexWriter.AddDocuments(documentList);
            IndexWriter.Flush(true, true);
            IndexWriter.Commit();

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

        public override SearchResults PrepareSearch(string searchQuery)
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
                var results = CompileResults(searcher, topDocs);
                return results;
            }
            finally
            {
                SearcherManager.Release(searcher);

            }
        }

        public new FSDirectory GetIndex()
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
