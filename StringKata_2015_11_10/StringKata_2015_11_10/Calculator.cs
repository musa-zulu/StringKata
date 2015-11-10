using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata_2015_11_10
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

            if (input.StartsWith("//"))
            {
                input = GetDelimiters(input, delimiters);
            }

            var numbers = SplitDelimiters(input, delimiters);
            numbers = CheckNumbersGreaterThan(numbers, 1000);
            var enumerable = numbers as int[] ?? numbers.ToArray();
            CheckNegative(enumerable);
            return enumerable.Sum();
        }

        private static string GetDelimiters(string input, List<string> delimiters)
        {
            var indexOf = input.IndexOf("\n", StringComparison.Ordinal);
            delimiters.AddRange(input.Substring(0, indexOf)
                .Replace("//", "")
                .Split(new[] { "]", "[" }, StringSplitOptions.RemoveEmptyEntries));
            input = input.Substring(indexOf + 1);
            return input;
        }

        private IEnumerable<int> CheckNumbersGreaterThan(IEnumerable<int> numbers, int maxNumber)
        {
            return numbers.Where(n => n <= maxNumber);
        }

        private static IEnumerable<int> SplitDelimiters(string input, List<string> delimiters)
        {
            return input.Split(delimiters.ToArray(), StringSplitOptions.None).Select(int.Parse);
        }

        private void CheckNegative(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0);
            var enumerable = negatives as int[] ?? negatives.ToArray();
            if (enumerable.Any())
            {
                throw new ApplicationException("negatives are not allowed : " + string.Join(",", enumerable.ToArray()));
            }
        }
    }
}