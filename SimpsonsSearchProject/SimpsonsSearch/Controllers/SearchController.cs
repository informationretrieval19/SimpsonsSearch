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

            //if (model.searchQuery.Contains('*'))
            //{
            //    var searchQueryEdited = model.searchQuery.Replace("*", string.Empty);
            //    var results = _searchEngine.SearchAdvanced(searchQueryEdited);
            //    _logger.LogWarning($"User {Request.HttpContext.Connection.LocalIpAddress} / {Request.HttpContext.Connection.RemoteIpAddress} searched for '{model.searchQuery}' and got {results.TotalHits} results");
            //    return View(results);
            //}
            //else
            //{
            var results = _searchEngine.Search(model.searchQuery);
            _logger.LogWarning($"User {Request.HttpContext.Connection.LocalIpAddress} / {Request.HttpContext.Connection.RemoteIpAddress} searched for '{model.searchQuery}' and got {results.TotalHits} results");
            return View(results);
            //}
        }

        public IActionResult AdvancedWithOneTerm(SearchformModel model)
        {
            
            var results = _searchEngine.SearchAdvanced(model.searchQuery);
            _logger.LogWarning($"User {Request.HttpContext.Connection.LocalIpAddress} / {Request.HttpContext.Connection.RemoteIpAddress} searched for '{model.searchQuery}' and got {results.TotalHits} results");
            return View("Results",results);
        }

        public IActionResult AdvancedWithAllTerms(SearchformModel model)
        {

            var results = _searchEngine.SynonymSearchAllTerms(model.searchQuery);
            _logger.LogWarning($"User {Request.HttpContext.Connection.LocalIpAddress} / {Request.HttpContext.Connection.RemoteIpAddress} searched for '{model.searchQuery}' and got {results.TotalHits} results");
            return View("Results", results);
        }

        public void LogResult(int id, string TopicName, string logType)
        {
            if (logType == "0")
            {
                _logger.LogWarning($"User {Request.HttpContext.Connection.LocalIpAddress} rated the result with SceneId {id} with a bad score, while searching for {TopicName}");
            }
            else
            {
                _logger.LogWarning($"User {Request.HttpContext.Connection.LocalIpAddress} rated the result with SceneId {id} with a good score, while searching for {TopicName}");

            }

            var dictionaries = new Dictionaries();
            if (dictionaries.topicDic.ContainsKey(TopicName))
            {
                var model = new EvaluationModel()
                {
                    TopicId = dictionaries.topicDic[TopicName],
                    SceneId = id.ToString(),
                    Relevance = int.Parse(logType)
                };
                _jsonBuilder.BuildJsonFile(model);
            }
            else
            {
                _logger.LogWarning($"Coundn't create Evaluation, because TopicName did not match!");
            }
        }

    }
}






