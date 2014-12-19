using System;
using System.Collections.Generic;
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
            var delimiters = InitialDelimiters();
            
            if (HasCustormDelimiter(input))
            {
                var index = IndexOf(input);
                delimiters += GetDelimiters(input, index);
                input = Get(input, index);
            }

            var values = Split(delimiters, input);
            CheckNegative(values);
            return SumAll(values);
        }

        private static string InitialDelimiters()
        {
            return "\n,";
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static bool IsNullOrEmpty(string input)
        {
            return input.Length == 0;
        }

        private static string Get(string input, int index)
        {
            return input.Substring(index + 1);
        }

        private static string GetDelimiters(string input, int index)
        {
            return (input.Substring(2, index - 2));
        }

        private static int IndexOf(string input)
        {
            return input.IndexOf("\n");
        }

        private static bool HasCustormDelimiter(string input)
        {
            return input.IndexOf("//") != -1;
        }

        public void CheckNegative(IEnumerable<string> values)
        {
            var negatives = new LinkedList<string>();
            foreach (var value in values.Where(value => value.Length != 0 && int.Parse(value) < 0))
            {
                negatives.AddLast(value);
            }
            if (negatives.Count > 0)
            {
                throw new ApplicationException("negatives are not allowed : "+string.Join(",",negatives));
            }
        }

        private static string[] Split(string delimiters, string input)
        {
            return input.Split(delimiters.ToCharArray(), StringSplitOptions.None);
        }

        private static object SumAll(IEnumerable<string> values)
        {
            return values.Where(value => value.Length != 0 && int.Parse(value) <= 1000).Sum(value => int.Parse(value));
        }
    }
}