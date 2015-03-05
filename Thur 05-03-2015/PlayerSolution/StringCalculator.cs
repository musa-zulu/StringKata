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
            if (IsNullOrWhiteSpace(input))
            {
                return DefaultValue();
            }
            var delimiters = Delimiters();
            if (HasCustomDelimiter(input))
            {
                input = GetNumbers(input, ref delimiters);
            }

            return SplitAndSumAllNumbers(input, delimiters);
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string Delimiters()
        {
            return "\n|,";
        }

        private static string GetNumbers(string input, ref string delimiters)
        {
            var indexOf = input.IndexOf("\n");
            delimiters += input.Substring(2, indexOf - 2);
            input = input.Substring(indexOf + 1);
            return input;
        }

        private static int SplitAndSumAllNumbers(string input, string delimiters)
        {
            var numbers = input.Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x <= 1000);
            CheckNegative(numbers);
            return numbers.Sum();
        }

        private static void CheckNegative(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(number => number < 0).ToList();

            if (negatives.Count > 0)
            {
                throw new NegativesNotAllowedException(negatives.ToArray());
            }
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static bool IsNullOrWhiteSpace(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
    }
}
