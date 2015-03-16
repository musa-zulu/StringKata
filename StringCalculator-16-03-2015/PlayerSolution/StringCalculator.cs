using System;
using System.Collections.Generic;
using System.Linq;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework.Constraints;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input)
        {
            if (IsNullOrEmpty(input))
            {
                return DefaultValue();
            }
            var delimiters = Delimiters();
            if (HasCustomDelimiter(input))
            {
                delimiters = GetValues(ref input, delimiters);
            }
            return SplitAndSumAll(input, delimiters);
        }

        private static int SplitAndSumAll(string input, string delimiters)
        {
            var numbers = input.Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            NegativeNumbersFilter.CheckNegative(numbers);
            return SumAll.Sum(numbers);
        }

        public static Func<int, bool> InRange()
        {
            return n=> n <= 1000;
        }

        private static string Delimiters()
        {
            return "\n|,";
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetValues(ref string input, string delimiters)
        {
            delimiters += input.Substring(2, input.IndexOf("\n") - 2);
            input = input.Substring(4);
            return delimiters;
        }

        public static int ParseNumbers(string input)
        {
            return int.Parse(input);
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static bool IsNullOrEmpty(string input)
        {
            return input.Length == 0;
        }

    }
}
