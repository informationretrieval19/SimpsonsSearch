using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpsonsSearch
{
    public class WordListBuilder
    {
        // hier für jedes Wortlistthema, Datenstruktur anlegen in der die jeweiligen Wörter gespeicher sind 
        // wird dann in luceneEngine aufgerufen, mit "list.contains("suchbegriff") 

        public IEnumerable<string> GetExampleList()
        {
            var example = new List<string>()
            {
                "wort1",
                "wort2"
            };
            return example;
        }
    }
}
