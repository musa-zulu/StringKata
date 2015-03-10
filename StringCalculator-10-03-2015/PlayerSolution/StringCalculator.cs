using System;
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

            if (!HasCustomDelimiter(input))
                return SplitAndSumAll(input, delimiters);

            input = GetValues(input, ref delimiters);

            return SplitAndSumAll(input, delimiters);
        }

        private static string Delimiters()
        {
            return ",|\n";
        }

        private static string GetValues(string input, ref string delimiters)
        {
            var indexOf = input.IndexOf("\n");

            delimiters += input.Substring(2, indexOf - 2);
            input = input.Substring(indexOf+1);
            return input;
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static int SplitAndSumAll(string input, string delimiters)
        {
            var numbers = input.Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            NegativesNotAllowed.CheckNegative(numbers);
            return SumAll.SumAllNumbers(numbers);
        }

        public static Func<string, int> NumberParser()
        {
            return int.Parse;
        }

        public static Func<int, bool> IsInRange()
        {
            return n => n <= 1000;
        }


        public static Func<int, bool> IsNegative()
        {
            return n => n < 0;
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
