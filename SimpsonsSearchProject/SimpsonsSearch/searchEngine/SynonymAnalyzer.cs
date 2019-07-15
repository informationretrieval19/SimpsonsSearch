using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Synonym;
using Lucene.Net.Analysis.Util;
using Lucene.Net.Util;

namespace SimpsonsSearch.searchEngine
{
    public class SynonymAnalyzer : Analyzer
    {
        protected override TokenStreamComponents CreateComponents(string fieldName, TextReader reader)
        {
            
            var tokenizer = new StandardTokenizer(SimpleSearchBase.LUCENEVERSION, reader);


            var result = new SynonymFilter(tokenizer, GetSynonyms(), true);

            return new TokenStreamComponents(tokenizer, result);
        }

        
        // hier wortlisten er synonymmap hinzufügen
        // herausfinden wie man mehr als ein string einer base hinzufügt.. 
        public SynonymMap GetSynonyms()
        {

            var dictionaries = new Dictionaries();
            

            var sBuilder = new SynonymMap.Builder(true);
            
            for (int i = 1;  i <= dictionaries.alcoholDic.Count(); i++)
            {
                var key = $"key{i}";
                
                    sBuilder.Add(new CharsRef("alcohol"), new CharsRef(dictionaries.alcoholDic[key]), true);
                
            }

            var synonyms = sBuilder.Build();
            return synonyms;
        }

        

    }
}
