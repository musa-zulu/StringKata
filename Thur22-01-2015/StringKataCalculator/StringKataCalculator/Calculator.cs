using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKataCalculator
{
    public class Calculator
    {
        public object Add(string input)
        {
            if (IsNullOrEmpty(input))
            {
                return DefaultValue();
            }
            var delimiters = DefaultDelimiters();
            if (HasCustormDelimiter(input))
            {
                input = GetValues(input, ref delimiters);
            }
            var numbers = Split(input,delimiters);

            return SumAll(numbers);
        }

        private static string GetValues(string input, ref string delimiters)
        {
            var index = input.IndexOf("\n");

            delimiters += input.Substring(2, index - 2);
            input = input.Substring(index + 1);
            return input;
        }

        private static bool HasCustormDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string DefaultDelimiters()
        {
            return "\n,";
        }

        private static object SumAll(string[] numbers)
        {
            CheckNegative(numbers);

            return numbers.Where(number => !IsEmpty(number) && IsInRange(number)).Sum(number => int.Parse(number));
        }

        private static bool IsInRange(string number)
        {
            return int.Parse(number) <= 1000;
        }

        private static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = numbers.Where(number => !IsEmpty(number) && IsNegative(number)).ToList();

            if (negatives.Count > 0)
            {
                throw new ApplicationException("negatives are not allowed : "+string.Join(",",negatives));
            }
        }

        private static bool IsNegative(string number)
        {
            return int.Parse(number) < 0;
        }

        private static bool IsEmpty(string number)
        {
            return number.Length == 0;
        }

        private static string[] Split(string input,string delimiters)
        {
            return input.Split(delimiters.ToCharArray(), StringSplitOptions.None);
        }

        private static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static int DefaultValue()
        {
            return 0;
        }
    }
}