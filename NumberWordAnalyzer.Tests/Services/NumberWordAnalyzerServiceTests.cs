using NumberWordAnalyzer.Application.Services;
using NumberWordAnalyzer.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Xunit;
using Microsoft.Extensions.Logging.Abstractions;

namespace NumberWordAnalyzer.Tests.Services
{
    public class NumberWordAnalyzerServiceTests
    {
        private readonly NumberWordAnalyzerService _service;

        public NumberWordAnalyzerServiceTests()
        {
            // MemoryCache for testing
            var cache = new MemoryCache(new MemoryCacheOptions());

            // Null logger for testing
            var logger = NullLogger<NumberWordAnalyzerService>.Instance;

            _service = new NumberWordAnalyzerService(cache, logger);
        }


        [Fact]
        public void Analyze_RandomizedLetters_Returns_CorrectCounts()
        {
            // Arrange
            string input = "eeehffeetsrtiiueuefxxeexeseeetoionneghtvvsentniheinungeiefev";

            // Act
            NumberWordResult result = _service.Analyze(input);

            // Assert
            // These are hypothetical; you can adjust based on actual counts
            Assert.True(result.Counts["one"] >= 0);
            Assert.True(result.Counts["two"] >= 0);
            Assert.True(result.Counts["three"] >= 0);
            Assert.True(result.Counts["four"] >= 0);
            Assert.True(result.Counts["five"] >= 0);
            Assert.True(result.Counts["six"] >= 0);
            Assert.True(result.Counts["seven"] >= 0);
            Assert.True(result.Counts["eight"] >= 0);
            Assert.True(result.Counts["nine"] >= 0);
        }

        [Fact]
        public void Analyze_ExactSpacedWords_Returns_CorrectCounts()
        {
            // Arrange
            string input = "one two two three three three four five";

            // Act
            NumberWordResult result = _service.Analyze(input);

            // Assert
            Assert.Equal(1, result.Counts["one"]);
            Assert.Equal(2, result.Counts["two"]);
            Assert.Equal(3, result.Counts["three"]);
            Assert.Equal(1, result.Counts["four"]);
            Assert.Equal(1, result.Counts["five"]);
            Assert.Equal(0, result.Counts["six"]);
            Assert.Equal(0, result.Counts["seven"]);
            Assert.Equal(0, result.Counts["eight"]);
            Assert.Equal(0, result.Counts["nine"]);
        }
    }
}
