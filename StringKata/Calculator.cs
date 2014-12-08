using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace StringKata
{
    public class Calculator
    {
        private static object List;

        public int Add(string input)
        {
            if (IsNullOrEmpty(input))
            {
                return 0;
            }
            var delimiters = GetDefaultDelimiters();
            if (!HasCustormDelimiter(input)) 
                return SumAll(input, delimiters);

            var index = GetIndex(input);
            delimiters = GetDefaultDelimiters(input, index);
            input = GetValues(input, index);

            return SumAll(input, delimiters);
        }

        private static string GetValues(string input, int index)
        {
            return input.Substring(index + 1, input.Length - index - 1);
        }

        private static bool HasCustormDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetDefaultDelimiters(string input, int index)
        {
            return input.Substring(2, index -2);
        }

        private static int GetIndex(string input)
        {
            return input.IndexOf("\n");
        }

        private static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static int SumAll(string input, string delimiters)
        {
            var values = Split(input, delimiters);
            CheckNegetives(values);
            return values.Where(value => value.Length != 0 && int.Parse(value) <= 1000).Sum(value => int.Parse(value));
        }

        private static void CheckNegetives(IEnumerable<string> values)
        {
            var negetives = values.Where(value => !IsNullOrEmpty(value) && int.Parse(value) < 0).ToList();

            if (negetives.Count > 0)
            {
                throw new ApplicationException("negetives not allowed : "+string.Join(",",negetives.ToArray()));
            }
        }

        private static string GetDefaultDelimiters()
        {
            return ",\n";
        }

        private static string[] Split(string input, string delimiters)
        {
            return input.Split(delimiters.ToCharArray(), StringSplitOptions.None);
        }
    }
}