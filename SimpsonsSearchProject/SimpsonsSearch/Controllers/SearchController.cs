using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using SimpsonsSearch.searchEngine;

namespace SimpsonsSearch.Controllers
{
	public class SearchController : Controller
	{
		private readonly ISearchEngine _searchEngine;

		public SearchController(ISearchEngine searchEngine)
		{
			_searchEngine = searchEngine;
		}
		public IActionResult Index(IndexViewModel model)
		{

			model.ScriptLines = _searchEngine.GetDataFromFile();
			return View(model);
		}

		public IActionResult Results(string query)
		{
			//DeleteIndexFiles();
			_searchEngine.BuildIndex();
			var results = _searchEngine.Search("Edna Krabappel-Flanders: Bart?");

			return View(results);
		}
		private static void DeleteIndexFiles()
		{
			foreach (FileInfo f in new DirectoryInfo(Settings.IndexLocation).GetFiles())
				f.Delete();
		}
	}
}

			
