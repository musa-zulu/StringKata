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
                input = GetValues(input, ref delimiters);
            }

            return SplitAndSumAll(input, delimiters);

        }

        private static string GetValues(string input, ref string delimiters)
        {
            var index = input.IndexOf("\n");
            delimiters += input.Substring(2, index - 2);
            input = input.Substring(index + 1);
            return input;
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string Delimiters()
        {
            return "\n|,";
        }

        private static int SplitAndSumAll(string input, string delimiters)
        {
            var numbers = input.Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            NegativeNotAllowed.CheckNegative(numbers);
            return numbers.Where(x => x <= 1000).Sum();
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
