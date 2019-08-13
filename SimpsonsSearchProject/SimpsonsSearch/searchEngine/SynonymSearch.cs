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
using SimpsonsSearch.Models;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.searchEngine
{
    public class SynonymSearch : SimpleSearchBase
    {
        private readonly IConversionService _conversionService;


        private FSDirectory _indexDirectory;
        private readonly IndexWriter indexWriter;
        private readonly Analyzer analyzer;
        private readonly Analyzer analyzerSearch;
        private readonly QueryParser queryParser;
        private readonly SearcherManager searcherManager;


        private readonly IEnumerable<Episode> _episodes;

        public SynonymSearch(IConversionService conversionService, IEnumerable<Episode> episodes) : base(conversionService)
        {
            _conversionService = conversionService;
            indexWriter = new IndexWriter(GetIndex(), new IndexWriterConfig(LUCENEVERSION, analyzer));
            analyzer = new StandardAnalyzer(LUCENEVERSION, StandardAnalyzer.STOP_WORDS_SET);
            analyzerSearch = new SynonymAnalyzer();
            queryParser = new MultiFieldQueryParser(LUCENEVERSION, new[] { "text" }, analyzerSearch);
            searcherManager = new SearcherManager(indexWriter, true, null);
            _episodes = episodes;
        }

        //public override string LuceneDir => @"index/test";

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

        public override SearchResults CompileResults(IndexSearcher searcher, TopDocs topDocs, string searchQuery)
        {
            var searchResults = new SearchResults() { TotalHits = topDocs.TotalHits, TopicName = searchQuery };


            foreach (var result in topDocs.ScoreDocs)
            {
                Document document = searcher.Doc(result.Doc);
                Hit searchResult = new Hit
                {
                    Location = document.GetField("location")?.GetStringValue(),
                    Id = document.GetField("id")?.GetStringValue(),
                    EpisodeId = document.GetField("episodeId")?.GetStringValue(),
                    Score = result.Score,
                    Person = document.GetField("characters")?.GetStringValue(),
                    Text = document.GetField("raw_text")?.GetStringValue(),
                    Timestamp = document.GetField("timestamp")?.GetStringValue(),

                    EpisodeName = MapScriptlinesToEpisodes(document.GetField("episodeId")?.GetStringValue()).title,
                    Season = MapScriptlinesToEpisodes(document.GetField("episodeId")?.GetStringValue()).season,
                    EpisodeInSeason = MapScriptlinesToEpisodes(document.GetField("episodeId")?.GetStringValue()).number_in_season

                };
                searchResults.Hits.Add(searchResult);
            }
            return searchResults;
        }

        public override Document BuildDocumentForEachSpeakingLine(ScriptLine scriptLine)
        {

            var doc = new Document
            {
                new StoredField("id", scriptLine.id),
                new TextField("text", scriptLine.normalized_text, Field.Store.YES),
                new TextField("characters", scriptLine.raw_character_text, Field.Store.YES),
                new TextField("location", scriptLine.raw_location_text, Field.Store.YES),
                new TextField("episodeId", scriptLine.episode_id.ToString(), Field.Store.YES),
                new StoredField("timestamp", scriptLine.timestamp_in_ms)
            };
            return doc;
        }

        public override IEnumerable<ScriptLine> BuildScene(IEnumerable<ScriptLine> scriptLines)
        {
            //bekommt alle scriptlines geliefert
            // wir gehen liste durch und fügen strings zusammen bis speakingline == false
            var sceneList = new List<ScriptLine>();
            var spokenLinesList = new List<string>();
            var linesWithNames = new List<string>();

            var charactersList = new HashSet<string>();
            var startingTime = "";
            var sceneId = 0;




            foreach (var item in scriptLines)
            {
                // solange true ist, füge die strings in normalized text zusammen 

                if (item.character_id != "")
                {
                    startingTime = _conversionService.ConvertMillisecondsToMinutes(Convert.ToDouble(item.timestamp_in_ms));
                    spokenLinesList.Add(item.normalized_text);
                    charactersList.Add(item.raw_character_text);

                    linesWithNames.Add(item.raw_text);


                }
                // schreibe zusammengefügte scene in liste 
                else if (spokenLinesList.Any())
                {
                    sceneId = sceneId + 1;

                    sceneList.Add(new ScriptLine()
                    {
                        // id wird zu einer neuen scenen id 
                        id = sceneId.ToString(),
                        episode_id = item.episode_id,
                        timestamp_in_ms = startingTime,
                        normalized_text = String.Join(" ", spokenLinesList.ToArray()),
                        raw_text = String.Join($"{Environment.NewLine}", linesWithNames.ToArray()),

                        raw_character_text = String.Join($"{Environment.NewLine}", charactersList),
                        raw_location_text = item.raw_location_text
                    });
                    spokenLinesList.Clear();
                    charactersList.Clear();
                    linesWithNames.Clear();
                };
            }
            return sceneList;
        }

        //bekommt eine liste von scenen geliefert
        public override Document BuildDocumentForEachScene(ScriptLine scriptLine)
        {

            var document = new Document
            {
            new StoredField("id", scriptLine.id),
            new TextField("text", scriptLine.normalized_text, Field.Store.YES),
            new TextField("raw_text", scriptLine.raw_text, Field.Store.YES),
            new TextField("episodeId", scriptLine.episode_id.ToString(), Field.Store.YES),
            new TextField("characters", scriptLine.raw_character_text, Field.Store.YES ),
            new TextField("location", scriptLine.raw_location_text, Field.Store.YES),
            new TextField("timestamp", scriptLine.timestamp_in_ms, Field.Store.YES)
         };
            return document;
        }

        //public override void BuildIndex()
        //{
        //    var scriptLines = BuildScene(_conversionService.ConvertCsVtoScriptLines());

        //    if (scriptLines == null) throw new ArgumentNullException();

        //    // if speaking line == false create document 
        //    foreach (var scriptLine in scriptLines)
        //    {
        //        var document = BuildDocumentForEachScene(scriptLine);
        //        //var document = BuildDocumentForEachSpeakingLine(scriptLine);

        //        indexWriter.UpdateDocument(new Term("scriptlines", scriptLine.id), document);
        //    }

        //    indexWriter.Flush(true, true);
        //    indexWriter.Commit();
        //}

        //public override FSDirectory GetIndex()
        //{
        //    _indexDirectory = FSDirectory.Open(new DirectoryInfo(LuceneDir));
        //    {
        //        if (IndexWriter.IsLocked(_indexDirectory))
        //        {
        //            IndexWriter.Unlock(_indexDirectory);
        //        }

        //        var lockFilePath = Path.Combine(LuceneDir, "write.lock");
        //        if (File.Exists(lockFilePath))
        //        {
        //            File.Delete(lockFilePath);
        //        }

        //        return _indexDirectory;
        //    }
        //}
    }
}
