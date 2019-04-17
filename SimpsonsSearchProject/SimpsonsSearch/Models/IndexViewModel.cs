using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpsonsSearch.Models;
using SimpsonsSearch.searchEngine;

namespace SimpsonsSearch
{
	public class IndexViewModel
	{
		public IEnumerable<ScriptLine> ScriptLines { get; set; }
		public IEnumerable<Episode> Episodes { get; set; }

		public string SearchQuery { get; set; }
	}
}
