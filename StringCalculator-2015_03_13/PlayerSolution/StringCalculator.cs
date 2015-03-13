using System;
using System.Collections.Generic;

using System.Linq;
using Katarai.StringCalculator.Interfaces;

namespace PlayerStringKata
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input)
        {
            if (IsNullOrEmpty(input))
                return DefaultValue();

            var delimiters = Delimiters();

            if (HasCustomDelimiter(input))
            {
                input = GetValues(input, ref delimiters);

            }

            return SplitAndSumAll(input, delimiters);

        }

        private static string GetValues(string input, ref string delimiters)
        {
            var indexOf = input.IndexOf("\n");
            delimiters += input.Substring(2, indexOf - 2);
            input = input.Substring(indexOf + 1);

          return input;
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static int SplitAndSumAll(string input, string delimiters)
        {
            var numbers = input.Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            CheckNegative(numbers);

            return numbers.Select(int.Parse).Where(x => x <= 1000).Sum();
        }
        private static string Delimiters()
        {
            return "\n|,";
        }

        private static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = numbers.Select(int.Parse).Where(n => n < 0);

            var enumerable = negatives as int[] ?? negatives.ToArray();

            if (enumerable.Any())
            {
                throw new NegativesNotAllowedException(enumerable.ToArray());
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
