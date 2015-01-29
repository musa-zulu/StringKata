using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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
            var delimiters = Delimiters();

            if (HasCustomDelimiter(input))
            {
                input = GetNumbers(input, ref delimiters);
            }
            var numbers = Split(input, delimiters);
            return SumAll(numbers);
        }

        private static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static string Delimiters()
        {
            return "\n,";
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetNumbers(string input, ref string delimiters)
        {
            var index = input.IndexOf("\n");
            delimiters += input.Substring(2, index - 2);
            input = input.Substring(index + 1);
            return input;
        }

        private static string[] Split(string input, string delimiters)
        {
            return input.Split(delimiters.ToCharArray());
        }

        private static object SumAll(string[] numbers)
        {
            CheckNegative(numbers);
            return numbers.Where(number => number.Length != 0 && int.Parse(number) <= 1000).Sum(number => int.Parse(number));
        }

        private static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = numbers.Where(number => number.Length != 0 && int.Parse(number) < 0).ToList();

            if (negatives.Count > 0)
            {
                throw new ApplicationException("negative numbers are not allowed : "+string.Join(",",negatives));
            }
        }
    }
}