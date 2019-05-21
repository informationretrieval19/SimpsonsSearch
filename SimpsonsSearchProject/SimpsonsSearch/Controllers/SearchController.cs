﻿using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using SimpsonsSearch.Helper;
using SimpsonsSearch.Models;
using SimpsonsSearch.searchEngine;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.Controllers
{
    /// <summary>
    /// Klasse die Datenablauf steuert 
    /// </summary>
	public class SearchController : Controller
	{
		private readonly ISearchEngine _searchEngine;
		private readonly IConversionService _conversionService;

        // Konstruktur der duch 'Dependency Injektion' den SeachEngineService und einen ConversionService initialisiert
        // somit stehen alle Methoden die in diesen KLassen erstellt wurden zur Verfügug
		public SearchController(ISearchEngine searchEngine, IConversionService conversionService)
		{
			_conversionService = conversionService;
			_searchEngine = searchEngine;
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
			//DeleteIndexFiles();
			_searchEngine.BuildIndex();
			var results = _searchEngine.Search(model.searchQuery);

			return View(results);
		}
	}
}

			
