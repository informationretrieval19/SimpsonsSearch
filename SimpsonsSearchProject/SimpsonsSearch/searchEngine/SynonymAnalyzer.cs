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
            var test = "weihnachtsmann";
            var syn1 = "christmas";
            var syn2 = "easter";

            var alcolDic = new Dictionary<string, string>
            {
                { "key1", "abuse" },
                { "key2", "addiction" },
                {"key3","alcoholic" },
                {"key4","alcoholism" },
                {"key5","bar" },
                {"key6","beer" },
                {"key7","wine" },
                {"key8","cider" },
                {"key9","duff" },
                {"key10","brew" },
                {"key11","brewery" },
                {"key12","vomit" },
                {"key13", "underage" }, {"key14","drink" }, {"key15","cocktail" }, {"key16","disorder" }, {"key17","liquer" }
            };


            var sBuilder = new SynonymMap.Builder(true);
            
            for (int i = 1;  i <= alcolDic.Count(); i++)
            {
                var key = $"key{i}";
                
                    sBuilder.Add(new CharsRef("alcohol"), new CharsRef(alcolDic[key]), true);
                
            }

            var synonyms = sBuilder.Build();
            return synonyms;
        }

    }
}
