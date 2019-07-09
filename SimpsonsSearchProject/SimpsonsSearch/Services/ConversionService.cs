﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using SimpsonsSearch.Models;
using SimpsonsSearch.searchEngine;
using SimpsonsSearch.Services;

namespace SimpsonsSearch.Helper
{
    /// <summary>
    /// KLasse die Methoden zur Umwandlung von csv Dateien in Objekte zur Verfügung stellt 
    /// </summary>
	public class ConversionService : IConversionService
    {
        public IEnumerable<ScriptLine> _scriptLineRecords;
        public IEnumerable<Episode> _episodeRecords;


        /// <summary>
        /// Methode zur Umwandlung von sciptlines.csv zu einer Liste von ScriptLine Objekten
        /// zur HIlfe wird hier eine Library benutzt die es sehr einfach ermöglicht .csv Dateien umzuwandeln(csvHelper)
        /// </summary>
        /// <returns>Liste von Scriptline objekten</returns>
        public IEnumerable<ScriptLine> ConvertCsVtoScriptLines()
        {
            IList<string> _badRecords = new List<string>();

            using (var reader = new StreamReader(@"data/simpsons_script_lines.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = ",";
                //csv.Configuration.IgnoreQuotes = true;
                csv.Configuration.MissingFieldFound = null;


                csv.Configuration.BadDataFound = context =>
                {
                    _badRecords.Add(context.RawRecord);
                };

                _scriptLineRecords = csv.GetRecords<ScriptLine>().ToList();
                return _scriptLineRecords;
            }
        }

        /// <summary>
        /// Methode zur Umwandlung der Episodes.csv in LIste von Episode Objekten
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Episode> ConvertCsvToEpisodes()
        {
            IList<string> _badRecords = new List<string>();

            using (var reader = new StreamReader(@"Data\simpsons_episodes.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = ",";
                csv.Configuration.IgnoreQuotes = true;


                csv.Configuration.BadDataFound = context =>
                {
                    _badRecords.Add(context.RawRecord);
                };

                _episodeRecords = csv.GetRecords<Episode>().ToList();


                return _episodeRecords;
            }
        }

        public double ConvertMillisecondsToMinutes(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalMinutes;
        }
    }
}
