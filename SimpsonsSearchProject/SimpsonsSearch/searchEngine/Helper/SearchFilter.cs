using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Index;
using Lucene.Net.Search;


namespace SimpsonsSearch.searchEngine.Helper
{
    public class SearchFilter
    {
        public void CreateTermFilter(Dictionary<string,string> dictionary)
        {
            // hier filter hinzufügen der document filtert und score bootstet 
            var filter = new TermsFilter();

            foreach (var term in dictionary.Values.ToList())
            {
                
            }

        }

    }
}
