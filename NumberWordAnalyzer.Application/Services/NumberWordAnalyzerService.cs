using NumberWordAnalyzer.Application.Interfaces;
using NumberWordAnalyzer.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberWordAnalyzer.Application.Services
{
    public class NumberWordAnalyzerService : INumberWordAnalyzerService
    {
        private readonly string[] numberWords =
            { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        private readonly IMemoryCache _cache;
        private readonly ILogger<NumberWordAnalyzerService> _logger;

        public NumberWordAnalyzerService(IMemoryCache cache, ILogger<NumberWordAnalyzerService> logger)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public NumberWordResult Analyze(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new NumberWordResult(); // safe

            // Check cache first
            if (_cache.TryGetValue(input, out NumberWordResult? cachedResult) && cachedResult != null)
            {
                _logger.LogInformation("Cache hit for input of length {Length}", input.Length);
                return cachedResult;
            }

            _logger.LogInformation("Analyzing input of length {Length}", input.Length);

            var result = new NumberWordResult(); // ensure Counts is initialized in NumberWordResult
            string lower = input.ToLower();

            // Count letters efficiently
            var letterCounts = lower
                .AsParallel()
                .Where(char.IsLetter)
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var word in numberWords)
            {
                int count = CountWordOccurrences(letterCounts, word);
                result.Counts[word] = count;

                // Reduce letters to avoid double-counting
                foreach (var c in word)
                {
                    if (letterCounts.ContainsKey(c))
                        letterCounts[c] -= count;
                }
            }

            // Cache result for 10 minutes
            _cache.Set(input, result, TimeSpan.FromMinutes(10));

            return result;
        }

        private int CountWordOccurrences(Dictionary<char, int> letterCounts, string word)
        {
            int minCount = int.MaxValue;

            foreach (var c in word)
            {
                if (!letterCounts.ContainsKey(c) || letterCounts[c] <= 0)
                    return 0;

                minCount = Math.Min(minCount, letterCounts[c]);
            }

            return minCount;
        }
    }
}
