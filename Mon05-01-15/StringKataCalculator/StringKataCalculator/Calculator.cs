using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKataCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (IsNullOrEmpty(input))
            {
                return DefaultValue();
            }
            var delimiters = DefaultDelimiter();

            if (HasCustormDelimiter(input))
            {
                var index = input.IndexOf("\n");
                delimiters += GetDelimiters(input, index);
                input = GetInput(input, index);
            }

            var values = Split(delimiters,input);
            CheckNegative(values);
            return SumAll(values);
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static bool IsNullOrEmpty(string input)
        {
            return input.Length == 0;
        }

        private static string GetInput(string input, int index)
        {
            return input.Substring(index + 1);
        }

        private static string GetDelimiters(string input, int index)
        {
            return (input.Substring(2, index - 2));
        }

        private static string DefaultDelimiter()
        {
            return "\n,";
        }

        private static bool HasCustormDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static void CheckNegative(IEnumerable<string> values)
        {
            var negatives = values.Where(value => value.Length != 0 && int.Parse(value) < 0).ToList();

            if (negatives.Count > 0)
            {
                throw new ApplicationException("negatives are not allowed : "+string.Join(",",negatives));
            }
        }

        private static string[] Split(string delimiters, string input)
        {
            return input.Split(delimiters.ToCharArray(), StringSplitOptions.None);
        }

        private static int SumAll(IEnumerable<string> values)
        {
            return values.Where(value => value.Length != 0 && int.Parse(value) <= 1000).Sum(value => int.Parse(value));
        }
    }
}