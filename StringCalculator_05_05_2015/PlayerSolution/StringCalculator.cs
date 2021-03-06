﻿using System;
using System.Collections.Generic;
using System.Linq;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
            var delimiter = new List<string> {"\n",","};
            if (StartsWithCustomDelimiter(input))
            {
                input = GetDelimiters(input, delimiter);
            }
            var numbers = SplitNumbers(input, delimiter);
            numbers = FilterNumbersGreaterThan(1000,numbers);
            CheckNegative(numbers);
            return numbers.Sum();
        }

        private static string GetDelimiters(string input, List<string> delimiter)
        {
            delimiter.AddRange(input.Substring(0, input.IndexOf("\n")).Replace("//", "")
                .TrimStart('[')
                .TrimEnd(']')
                .Split(new[] {"]["}, StringSplitOptions.None));
            input = input.Substring(input.IndexOf("\n") + 1);
            return input;
        }

        private IEnumerable<int> FilterNumbersGreaterThan(int i, IEnumerable<int> numbers)
        {

            return numbers.Where(n => n <= i);
        }

        private static bool StartsWithCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static IEnumerable<int> SplitNumbers(string input, List<string> delimiter)
        {
            return input.Split(delimiter.ToArray(), StringSplitOptions.None).Select(int.Parse);
        }

        private void CheckNegative(IEnumerable<int> numbers)
        {

            var negatives = numbers.Where(n => n < 0);
            if (negatives.Any())
            {
                throw new NegativesNotAllowedException(negatives.ToArray());
            }
        }
    }
}
