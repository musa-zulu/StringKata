using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace StringKataCalculator
{
    public class Calculator
    {
        //work on refactoring
        public object Add(string input)
        {
            if (input.Length == 0)
            {
                return 0;
            }

            var delimiters = DefaultDelimiters();

            if (HasCustormDelimiters(input))
            {
                input = GetValues(input, ref delimiters);
            }

            var numbers = Split(input, delimiters);
            var sum = SumAll(numbers);
            
            return sum;
        }

        private static string DefaultDelimiters()
        {
            return "\n,";
        }

        private static bool HasCustormDelimiters(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetValues(string input, ref string delimiters)
        {
            var index = input.IndexOf("\n");
            delimiters += input.Substring(2, index - 2);
            input = input.Substring(index + 1, input.Length - index - 1);
            return input;
        }

        private static string[] Split(string input, string delimiters)
        {
            return input.Split(delimiters.ToCharArray(),StringSplitOptions.None);
        }

        private static int SumAll(string[] numbers)
        {
            CheckNegative(numbers);
            var sum = 0;

            foreach (var number in numbers)
            {
                if (number.Length != 0 && int.Parse(number) <= 1000)
                    sum += int.Parse(number);
            }
            return sum;
        }

        private static void CheckNegative(string[] numbers)
        {
            var negatives = new List<string>();
            foreach (var number in numbers)
            {
                if (number.Length != 0 && int.Parse(number) < 0)
                {
                    negatives.Add(number);
                }
            }

            if (negatives.Count > 0)
            {
                throw new ApplicationException("negative numbers not allowed : " + string.Join(",", negatives));
            }
        }
    }
}