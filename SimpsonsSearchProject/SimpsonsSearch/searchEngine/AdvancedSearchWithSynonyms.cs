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
        
        
        public AdvancedSearchWithSynonyms(IConversionService conversionService) : base(conversionService)
        {
            _conversionService = conversionService;
        }

        public override string LuceneDir => @"index/test";

        
        
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

       

       

    }
}
