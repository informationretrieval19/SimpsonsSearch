using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.searchEngine.topics
{
    public class AlcoholTopic : AdvancedSearchWithSynonyms
    {
        public AlcoholTopic(IConversionService conversionService) : base(conversionService)
        {
            //suchergebnis bearbeiten sodass es episoden anzeigt indem episoden angezeigt werden die spezifischen topic begriffe besonders viel enthalten 
        }

        public override SearchResults CompileResults(IndexSearcher searcher, TopDocs topDocs)
        {
            var searchResults = new SearchResults() { TotalHits = topDocs.TotalHits };
            foreach (var result in topDocs.ScoreDocs)
            {
                Document document = searcher.Doc(result.Doc);
                Hit searchResult = new Hit {
                    Id = document.GetField("episodeId")?.GetStringValue(),
                    Score = result.Score,
                };
                searchResults.TopicName = "Alcohol";
                searchResults.Hits.Add(searchResult);
            }

            return searchResults;
        }
    }
}
