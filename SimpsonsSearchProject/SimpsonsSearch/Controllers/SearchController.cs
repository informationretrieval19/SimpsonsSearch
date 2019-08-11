using System;
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
        private readonly JsonBuilder _jsonBuilder;

        // Konstruktur der duch 'Dependency Injektion' den SeachEngineService initialisiert
        // somit stehen alle Methoden in dieser KLasse  zur Verfügug
        public SearchController(ISearchEngine searchEngine, ILoggerFactory loggerFactory, JsonBuilder jsonBuilder)
        {
            _searchEngine = searchEngine;
            _logger = loggerFactory.CreateLogger<SearchController>();
            _jsonBuilder = jsonBuilder;
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
            var results = _searchEngine.Search(model.searchQuery);

            //sollte eigenlich nur info sein, aber da werden zusätzlich weitere dinge gelogt, deswegen "fix" --> höheres loglevel 
            _logger.LogWarning($"User {Request.HttpContext.Connection.LocalIpAddress} / {Request.HttpContext.Connection.RemoteIpAddress} searched for '{model.searchQuery}' and got {results.TotalHits} results");

      

            return View(results);
        }

        public void LogGoodResult(Hit hit)
        {
            _logger.LogWarning($"User {Request.HttpContext.Connection.LocalIpAddress} rated the result with SceneId {hit.Id} with a good score!");
            _jsonBuilder.BuildJsonFile();
        }

        public void LogBadResult(int id, string TopicName)
        {
            _logger.LogWarning($"User {Request.HttpContext.Connection.LocalIpAddress} rated the result with SceneId {id} with a bad score!");
            _jsonBuilder.BuildJsonFile();

        }
    }
}





   
