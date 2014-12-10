using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CalculatorKata
{
    public class Calculator
    {
        public object Add(string input)
        {
            if (IsNullOrEmpty(input))
            {
                return DefaultValue();
            }

            string delimiters = "\n,";

            if (HasCustormDelimiter(input))
            {
                var index = input.IndexOf("\n");
                delimiters += GetDelimiters(input, index);
                input = GetNumbers(input, index);
            }
            var values = Split(delimiters, input);
            return SumAll(values);
        }

        private static bool HasCustormDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetNumbers(string input, int index)
        {
            return input.Substring(index + 1, input.Length - index - 1);
        }

        private static string GetDelimiters(string input, int index)
        {
            return input.Substring(2, index - 2);
        }

        private static IEnumerable<string> Split(string delimiters, string input)
        {
            return input.Split(delimiters.ToCharArray());
        }

        private static object SumAll(IEnumerable<string> values)
        {

            CheckNegative(values);
            return values.Where(value => value.Length != 0 && int.Parse(value) <= 1000).Sum(value => int.Parse(value));
        }

        private static void CheckNegative(IEnumerable<string> values)
        {

            var list = new LinkedList<string>();
            foreach (var value in values.Where(value => value.Length != 0 && int.Parse(value) < 0))
            {
                list.AddLast(value);
            }

            if (list.Count > 0)
            {
                throw new ApplicationException("negatives are not allowed : " + string.Join(",", list));
            }
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}