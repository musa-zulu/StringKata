using System;
using System.Collections.Generic;
using System.Linq;


namespace StringKata
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (IsNullOrEmpty(input))
            {
                return DefaultValue();
            }

            var delimiters = Delimiters();

            if (HasCustormDelimiter(input))
            {
                input = GetValues(input, ref delimiters);
            }
            var numbers = input.Split(delimiters.ToCharArray(), StringSplitOptions.None);
            return SumAll(numbers);
        }

        private static bool HasCustormDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetValues(string input, ref string delimiters)
        {
            var index = input.IndexOf("\n");
            delimiters += input.Substring(2, index - 2);
            input = input.Substring(index + 1);
            return input;
        }

        private static bool IsNullOrEmpty(string input)
        {
            return input.Length == 0;
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static int SumAll(string[] numbers)
        {
            CheckNagative(numbers);

            return numbers.Where(number => number.Length != 0 && int.Parse(number) <= 1000).Sum(number => int.Parse(number));
        }

        private static void CheckNagative(IEnumerable<string> numbers)
        {
            var negatives = numbers.Where(number => number.Length != 0 && int.Parse(number) < 0).ToList();
            if (negatives.Count > 0)
            {
                throw new ApplicationException("negatives are not allowed : "+string.Join(",",negatives));
            }
        }

        private static string Delimiters()
        {
            return "\n,";
        }
    }
}