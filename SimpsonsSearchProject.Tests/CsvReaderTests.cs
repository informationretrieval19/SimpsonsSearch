using System;
using System.Linq;
using SimpsonsSearch.Helper;
using SimpsonsSearch.searchEngine;
using Xunit;
using FluentAssertions;

namespace SimpsonsSearchProject.Tests
{
    public class CsvReaderTests
    {
        [Fact]
        public void ConvertCsVtoScriptLines_WhenReadingScriptLines_WeAssertSecondScriptLine()
        {
            // Arrange
            const string pathToTestCsv = "./simpsons_script_lines_test.csv";


            var csv = new ConversionService();
            var expectedScriptLine = new ScriptLine()
            {
                id = "9549",
                raw_text = "Miss Hoover: No, actually, it was a little of both. Sometimes when a disease is in all the magazines and all the news shows, it's only natural that you think you have it.",
                word_count = "31",
                // TODO: all other properties.
            };

            // Act
            var actualScriptLine = csv.ConvertCsVtoScriptLines(pathToTestCsv).Single();

            // Assert
            actualScriptLine.id.Should().Be(expectedScriptLine.id);
            actualScriptLine.raw_text.Should().Be(expectedScriptLine.raw_text);
            actualScriptLine.word_count.Should().Be(expectedScriptLine.word_count);
        }
    }
}
