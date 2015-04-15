using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            var delimiter = GetDelimiters(ref input);

            var numbers = SplitNumbers(input, delimiter).ToList();
            CheckForNegatives(numbers);
            numbers = FilterNumbersGreaterThan(1000, numbers);
            return SumAll(numbers);
        }

        private List<int> FilterNumbersGreaterThan(int maxAllowedNumber, List<int> numbers)
        {
            return numbers.Where(i => i<=maxAllowedNumber).ToList();
        }

        private static string[] GetDelimiters(ref string input)
        {
            var defaultDelimiters = new List<string> {",", "\n"};
            var delimiters = defaultDelimiters;
            if (HasCustomDelimiter(input))
            {
                delimiters.AddRange(GetCustomDelimiters(input));
                input = input.Substring(input.IndexOf("\n")+1);
            }
            return delimiters.ToArray();
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static List<string> GetCustomDelimiters(string input)
        {
            var delimiters = input.Substring(0, input.IndexOf("\n")).Replace("//", "")
                .TrimStart('[')
                .TrimEnd(']')
                .Split(new[] { "][" }, StringSplitOptions.None);
            return delimiters.ToList();
        }


        private void CheckForNegatives(IEnumerable<int> numbers)
        {

            var negatives = numbers.Where(n => n < 0).ToList();
            if (negatives.Any())
            {
                throw new ApplicationException("negatives are not allowed: " + string.Join(",", negatives.ToArray()));
            }
        }

        private static IEnumerable<int> SplitNumbers(string input, string[] delimiter)
        {
            return input.Split(delimiter, StringSplitOptions.None).Select(int.Parse);
        }

        private static int SumAll(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }
    }
}