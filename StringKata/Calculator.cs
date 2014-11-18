using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            const string newLine = "\n";
            if (IsNullOrEmpty(numbers))
            {
                return DefaultValue();
            }

            if (StartsWithCustomDelimiterSlash(numbers))
            {
                numbers = GetNumbers(numbers, newLine);
            }

            var values = SplitCustormDelimeters(numbers);

            CheckNegative(values);

            return SumAll(values);
        }

        private static void CheckNegative(IEnumerable<string> values)
        {
            var negetives = (from value in values where value.Length != 0 && int.Parse(value) < 0 select int.Parse(value)).ToList();

            if (negetives.Count <= 0)
            {
                return;
            }
            
            var results = negetives.Aggregate("", (current, negetive) => current + negetive);
            throw new ApplicationException("negatives not allowed : " + results);
        }

        private static string GetNumbers(string numbers, string newLine)
        {
            var indexOfNewLine = numbers.IndexOf(newLine);
            numbers = numbers.Substring(indexOfNewLine + 1);
            return numbers;
        }

        private static bool StartsWithCustomDelimiterSlash(string numbers)
        {
            return numbers.StartsWith("//");
        }

        private static int SumAll(IEnumerable<string> values)
        {
            return values.Where(value => value.Length != 0 && int.Parse(value) <= 1000).Sum(value => int.Parse(value));
        }

        private static IEnumerable<string> SplitCustormDelimeters(string numbers)
        {
            return numbers.Split(',', '\n', ';', '*', '%');
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static bool IsNullOrEmpty(string numbers)
        {
            return string.IsNullOrEmpty(numbers);
        }
    }
}