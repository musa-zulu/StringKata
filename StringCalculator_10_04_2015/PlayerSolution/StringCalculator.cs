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
            int defaultValue;
            if (EmptyStringInput(input, out defaultValue)) return defaultValue;
            var delimiters = Delimiters();
            input = Matches(input, ref delimiters);
            return SplitAndSum(input, delimiters);
        }

        private static string Matches(string input, ref string delimiters)
        {
            if (StartsWithDelimiter(input))
            {
                input = GetValues(input, ref delimiters);
            }
            return input;
        }

        private static string Delimiters()
        {
            return "\n|,";
        }

        private static bool StartsWithDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetValues(string input, ref string delimiters)
        {
            var indexOf = input.IndexOf("\n");
            delimiters += input.Substring(2, indexOf - 2);
            input = input.Substring(indexOf + 1);
            return input;
        }

        private static bool EmptyStringInput(string input, out int defaultValue)
        {
            if (IsNullOrEmpty(input))
            {
                {
                    defaultValue = DefaultValue();
                    return true;
                }
            }
            defaultValue = 0;
            return false;
        }

        private static int SplitAndSum(string input, string s)
        {
            var numbers = SplitDelimiters(input, s);
            CheckNegative(numbers);
            return SelectInteger(numbers).Where(InRange()).Sum();
        }

        private static Func<int, bool> InRange()
        {
            return n => n <= 1000;
        }

        private static IEnumerable<int> SelectInteger(IEnumerable<string> numbers)
        {
            return numbers.Select(int.Parse);
        }

        private static string[] SplitDelimiters(string input, string s)
        {
            return input.Split(s.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = SelectInteger(numbers).Where(IsNegativeValue());
            var enumerable = negatives as int[] ?? negatives.ToArray();
            if (enumerable.Any())
            {
                throw new NegativesNotAllowedException(enumerable.ToArray());
            }
        }

        private static Func<int, bool> IsNegativeValue()
        {
            return n => n < 0;
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
