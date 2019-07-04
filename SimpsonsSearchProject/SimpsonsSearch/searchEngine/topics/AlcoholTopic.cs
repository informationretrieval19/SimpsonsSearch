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
            return base.CompileResults(searcher, topDocs);
        }
    }
}
