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
            {
                return DefaultValue();
            }
            var delimiter = Delimiter();
            if (StartsWith(input))
            {
                input = GetValues(input, ref delimiter);
            }
            return SplitAndSum(input, delimiter);
        }

        private static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static string GetValues(string input, ref string delimiter)
        {
            var indexOf = input.IndexOf("\n");

            delimiter += input.Substring(2, indexOf - 2);
            input = input.Substring(indexOf + 1);
            return input;
        }

        private static bool StartsWith(string input)
        {
            return input.StartsWith("//");
        }

        private static string Delimiter()
        {
            return "\n|,";
        }

        private static int SplitAndSum(string input, string delimiter)
        {
            var numbers = input.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            CheckNegative(numbers);
            return numbers.Select(NumberParser()).Where(IsInRange()).Sum();
        }

        private static Func<string, int> NumberParser()
        {
            return int.Parse;
        }

        private static Func<int, bool> IsInRange()
        {
            return n => n <= 1000;
        }

        private static void CheckNegative(IEnumerable<string> numbers)
        {

            var negatives = numbers.Select(NumberParser()).Where(n => n < 0);

            var enumerable = negatives as int[] ?? negatives.ToArray();
            if (enumerable.Any())
            {
                throw new NegativesNotAllowedException(enumerable.ToArray());
            }
        }
    }
}
