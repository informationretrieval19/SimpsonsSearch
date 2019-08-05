using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpsonsSearch.Helper;
using SimpsonsSearch.Models;
using SimpsonsSearch.searchEngine;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.Controllers
{
    /// test1
    /// <summary>
    /// Klasse die Datenablauf steuert 
    /// </summary>
	public class SearchController : Controller
    {
        private readonly ISearchEngine _searchEngine;
        private readonly ILogger<SearchController> _logger;

        // Konstruktur der duch 'Dependency Injektion' den SeachEngineService und einen ConversionService initialisiert
        // somit stehen alle Methoden die in diesen KLassen erstellt wurden zur Verfügug
        public SearchController(ISearchEngine searchEngine, ILoggerFactory loggerFactory)
        {
            _searchEngine = searchEngine;
            _logger = loggerFactory.CreateLogger<SearchController>();
        }

        // Methode die aufgerufen wird wenn man die seite: ../search/Index aufruft
        // returned ein Actionresult, in unserem Fall ist dies eine view(html seite)
        // durchsucht den Views Ornder nach einer Datei die Index.cshtml heißt und rendert diese
        public IActionResult Index()
        {
            return View();
        }

        // Methode die die View Results.cshtml benutzt 
        // benutzt auch ein IndexviewModel - hier enthält dieses Model nur einen String Searchquery, 
        // der über die Nutzereingabe über die View hierhergelangt
        public IActionResult Results(SearchformModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger.LogError($"hello, here is the logger,  and this is the current userid: {userId}");

            var results = _searchEngine.Search(model.searchQuery);
            return View(results);

        }

        public IActionResult Evaluation(SearchformModel model)
        {
            var results = _searchEngine.Search(model.searchQuery);
            return View(results);
        }
    }
}


