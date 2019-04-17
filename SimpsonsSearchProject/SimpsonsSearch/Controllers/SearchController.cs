using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using SimpsonsSearch.Helper;
using SimpsonsSearch.searchEngine;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.Controllers
{
	public class SearchController : Controller
	{
		private readonly ISearchEngine _searchEngine;
		private readonly IConversionService _conversionService;

		public SearchController(ISearchEngine searchEngine, IConversionService conversionService)
		{
			_conversionService = conversionService;
			_searchEngine = searchEngine;
		}
		public IActionResult Index(IndexViewModel model)
		{
			model.Episodes = _conversionService.ConvertCsvToEpisodes();
			return View(model);
		}

		public IActionResult Results(IndexViewModel model)
		{
			//DeleteIndexFiles();
			_searchEngine.BuildIndex();
			var results = _searchEngine.Search(model.SearchQuery);

			return View(results);
		}
		//private static void DeleteIndexFiles()
		//{
		//	foreach (FileInfo f in new DirectoryInfo(Settings.IndexLocation).GetFiles())
		//		f.Delete();
		//}
	}
}

			
