using System.Collections.Generic;
using SimpsonsSearch.Models;
using SimpsonsSearch.searchEngine;

namespace SimpsonsSearch
{
    /// <summary>
    /// Klasse die alle Daten enthält die in den Views angezeigt werden sollen oder Daten die aus View geladen werden sollen
    /// </summary>
	public class IndexViewModel
	{
		public IEnumerable<ScriptLine> ScriptLines { get; set; }
		public IEnumerable<Episode> Episodes { get; set; }

	}
}
