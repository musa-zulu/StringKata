using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata_2015_11_11
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiters = new List<string> {"\n", ","};

            if (StartsWithCustormDelimiterSlash(input))
            {
                input = GetDelimiters(input, delimiters);
            }
            
            var numbers = SplitDelimiters(input, delimiters);

            CheckNegative(numbers);
            numbers = CheckNumbersGtrThan(1000, numbers);
            return numbers.Sum();
        }

        private static bool StartsWithCustormDelimiterSlash(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetDelimiters(string input, List<string> delimiters)
        {
            var indexOf = input.IndexOf("\n");
            delimiters.AddRange(input.Substring(0, indexOf)
                .Replace("//", "")
                .TrimStart('[')
                .TrimEnd(']')
                .Split(new[] {"]", "["}, StringSplitOptions.RemoveEmptyEntries));
            input = input.Substring(indexOf + 1);
            return input;
        }

        private static IEnumerable<int> SplitDelimiters(string input, List<string> delimiters)
        {
            return input.Split(delimiters.ToArray(),StringSplitOptions.None).Select(int.Parse);
        }

        private IEnumerable<int> CheckNumbersGtrThan(int i, IEnumerable<int> numbers)
        {
            return numbers.Where(n => n <= i);
        }

        private void CheckNegative(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0);
            if (negatives.Any())
            {
                throw new ApplicationException("negatives not allowed : "+string.Join(",", negatives.ToArray()));
            }
        }
    }
}
