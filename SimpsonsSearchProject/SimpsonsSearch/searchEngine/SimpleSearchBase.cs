using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.TokenAttributes;
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
            var scriptLines = BuildScene(_conversionService.ConvertCsVtoScriptLines());

            if (scriptLines == null) throw new ArgumentNullException();

            // if speaking line == false create document 
            foreach (var scriptLine in scriptLines)
            {
                var document = BuildDocumentForEachScene(scriptLine);

                indexWriter.UpdateDocument(new Term("scriptlines", scriptLine.id), document);

            }

            indexWriter.Flush(true, true);
            indexWriter.Commit();
        }

        public virtual Document BuildDocumentForEachSpeakingLine(ScriptLine scriptLine)
        {

            var doc = new Document
            {
                new StoredField("id", scriptLine.id),
                new TextField("text", scriptLine.normalized_text, Field.Store.YES),
                new TextField("persons", scriptLine.raw_character_text, Field.Store.YES),
                new TextField("location", scriptLine.raw_location_text, Field.Store.YES),
                new TextField("episodeId", scriptLine.episode_id.ToString(), Field.Store.YES),
                new StoredField("timestamp", scriptLine.timestamp_in_ms)
            };
            return doc;
        }

        public IEnumerable<ScriptLine> BuildScene(IEnumerable<ScriptLine> scriptLines)
        {
            //bekommt alle scriptlines geliefert
            // wir gehen liste durch und fügen strings zusammen bis speakingline == false
            var sceneList = new List<ScriptLine>();
            var spokenLinesList = new List<string>();
            var personsList = new HashSet<string>();
            var startingTime = "";
            var testErrorList = new List<ScriptLine>();

            foreach (var item in scriptLines)
            {

                // "fix" für falsches spalten einlesen..
                // Todo
                if ((!item.speaking_line.Contains("true") && !item.speaking_line.Contains("false")))
                {
                    testErrorList.Add(item);
                    continue;
                }
                if (item.speaking_line.Length > 6)
                {
                    testErrorList.Add(item);
                    continue;
                }

                // solange true ist, füge die strings in normalized text zusammen 
                if (Convert.ToBoolean(item.speaking_line) == true)
                {

                    startingTime = _conversionService.ConvertMillisecondsToMinutes(Convert.ToDouble(item.timestamp_in_ms));

                    var textWithSpeaker = $"({item.raw_character_text}) {item.normalized_text}";
                    spokenLinesList.Add(textWithSpeaker);
                    personsList.Add(item.raw_character_text);
                }
                // schreibe zusammengefügte scene in liste 
                else
                {
                    sceneList.Add(new ScriptLine()
                    {
                        id = item.id,
                        episode_id = item.episode_id,
                        timestamp_in_ms = startingTime,
                        normalized_text = String.Join(":", spokenLinesList.ToArray()),
                        raw_character_text = String.Join(", ", personsList),
                        raw_location_text = item.raw_location_text
                    });
                    spokenLinesList.Clear();
                    personsList.Clear();
                };
            }
            return sceneList;
        }



        //bekommt eine liste von scenen geliefert
        public virtual Document BuildDocumentForEachScene(ScriptLine scriptLine)
        {

            var document = new Document
            {
            new StoredField("id", scriptLine.id),
            new TextField("text", scriptLine.normalized_text, Field.Store.YES),
            new TextField("episodeId", scriptLine.episode_id.ToString(), Field.Store.YES),
            new TextField("persons", scriptLine.raw_character_text, Field.Store.YES ),
            new TextField("location", scriptLine.raw_location_text, Field.Store.YES),
            new TextField("timestamp", scriptLine.timestamp_in_ms, Field.Store.YES)
         };
            return document;
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
                    Id = document.GetField("id")?.GetStringValue(),
                    EpisodeId = document.GetField("episodeId")?.GetStringValue(),
                    Score = result.Score,
                    Person = document.GetField("persons")?.GetStringValue(),
                    Text = document.GetField("text")?.GetStringValue(),
                    Timestamp = document.GetField("timestamp")?.GetStringValue()
                };
                searchResults.Hits.Add(searchResult);
            }

            return searchResults;
        }

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

        public void CreateQuery()
        {
            // is button bad result is pressed --> delete it for this index, or give it bad score
            // good result button is pressed --> boost score


        }

        // spliting user input into tokens 
        IList<string> Tokenize(string userInput)
        {
            List<string> tokens = new List<string>();
            using (var reader = new StringReader(userInput))
            using (TokenStream stream = analyzer.GetTokenStream("myfield", reader))
            {
                stream.Reset();
                while (stream.IncrementToken())
                    tokens.Add(stream.GetAttribute<ICharTermAttribute>().ToString());
            }
            return tokens;
        }

        class FieldDefinition
        {
            public string Name { get; set; }
            public bool IsDefault { get; set; } = false;
            //other properties omitted
        }

        //in a different class
        Query BuildQuery(string userInput, IEnumerable<FieldDefinition> fields)
        {
            BooleanQuery query = new BooleanQuery();
            IList<string> tokens = Tokenize(userInput);

            //combine tokens present in user input
            if (tokens.Count > 1)
            {
                FieldDefinition defaultField = fields.FirstOrDefault(f => f.IsDefault == true);
                query.Add(BuildExactPhraseQuery(tokens, defaultField), Occur.SHOULD);

                foreach (var q in GetIncrementalMatchQuery(tokens, defaultField))
                    query.Add(q, Occur.SHOULD);
            }

            //create a term query per field - non boosted
            foreach (var token in tokens)
                foreach (var field in fields)
                    query.Add(new TermQuery(new Term(field.Name, token)), Occur.SHOULD);

            return query;
        }

        Query BuildExactPhraseQuery(IList<string> tokens, FieldDefinition field)
        {
            //boost factor (6) and slop (2) come from configuration - code omitted for simplicity
            PhraseQuery pq = new PhraseQuery() { Boost = tokens.Count * 6, Slop = 2 };
            foreach (var token in tokens)
                pq.Add(new Term(field.Name, token));

            return pq;
        }

        IEnumerable<Query> GetIncrementalMatchQuery(IList<string> tokens, FieldDefinition field)
        {
            BooleanQuery bq = new BooleanQuery();
            foreach (var token in tokens)
                bq.Add(new TermQuery(new Term(field.Name, token)), Occur.SHOULD);

            //5 comes from config - code omitted
            int upperLimit = Math.Min(tokens.Count, 5);
            for (int match = 2; match <= upperLimit; match++)
            {
                BooleanQuery q = bq.Clone() as BooleanQuery;
                q.Boost = match * 3;
                q.MinimumNumberShouldMatch = match;
                yield return q;
            }
        }
    }
}






