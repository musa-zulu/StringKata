using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata_2015_11_12
{
    public class Calculator
    {
        public object Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiters = new List<string> { "\n", "," };

            if (StartsWithCustormDelimiterSlash(input))
            {
                input = Get(input, delimiters);
            }

            var numbers = Split(input, delimiters);
            CheckNegative(numbers);
            numbers = CheckNumbersGtrThan(1000, numbers);
            return numbers.Sum();
        }

        private static string Get(string input, List<string> delimiters)
        {
            var indexOf = input.IndexOf("\n");
            delimiters.AddRange(input.Substring(0, indexOf)
                .Replace("//", "")
                .Split(new[] { "]", "[" }, StringSplitOptions.RemoveEmptyEntries));
            input = input.Substring(indexOf + 1);
            return input;
        }

        private IEnumerable<int> CheckNumbersGtrThan(int maxNumbers, IEnumerable<int> numbers)
        {
            return numbers.Where(n => n <= maxNumbers);
        }

        private static bool StartsWithCustormDelimiterSlash(string input)
        {
            return input.StartsWith("//");
        }

        private static IEnumerable<int> Split(string input, List<string> delimiters)
        {
            return input.Split(delimiters.ToArray(), StringSplitOptions.None).Select(int.Parse);
        }

        private void CheckNegative(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0);
            if (negatives.Any())
            {
                throw new ApplicationException("negative numbers are not allowed : " + string.Join(",", negatives.ToArray()));
            }
        }
    }
}