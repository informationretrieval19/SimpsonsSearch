using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace SimpsonsSearchProject.searchEngine
{
	public class luceneTest
	{
		
		public void createIndex()
		{
			// Ensures index backwards compatibility
			var AppLuceneVersion = LuceneVersion.LUCENE_48;

			var indexLocation = @"C:\Index";
			var dir = FSDirectory.Open(indexLocation);

			//create an analyzer to process the text
			Analyzer analyzer = new StandardAnalyzer(AppLuceneVersion);
			

			//create an index writer
			var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
			var writer = new IndexWriter(dir, indexConfig);

			var source = new
			{
				Name = "Kermit the Frog",
				FavouritePhrase = "The quick brown fox jumps over the lazy dog"
			};
			var doc = new Document();
			// StringField indexes but doesn't tokenise
			doc.Add(new StringField("name", source.Name, Field.Store.YES));

			doc.Add(new TextField("favouritePhrase", source.FavouritePhrase, Field.Store.YES));

			writer.AddDocument(doc);
			writer.Flush(triggerMerge: false, applyAllDeletes: false);
		}
	}
}
