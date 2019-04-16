using System;
using System.Collections.Generic;
using System.Text;

namespace luceneTest
{
	// diese Fähigkeiten hat die Suchmaschine
	public interface ISearchEngine
	{
		void BuildIndex();
		SearchResults Search(string query);
	}
}
