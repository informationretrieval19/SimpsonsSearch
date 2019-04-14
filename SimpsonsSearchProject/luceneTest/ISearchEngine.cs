using System;
using System.Collections.Generic;
using System.Text;

namespace luceneTest
{
	public interface ISearchEngine
	{
		void BuildIndex();
		SearchResults Search(string query);
	}
}
