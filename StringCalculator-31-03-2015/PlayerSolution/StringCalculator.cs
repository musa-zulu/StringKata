using System;
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
            var delimiters = Delimiter();
            if (HasCustomDelimiter(input))
            {
                delimiters = GetValues(ref input, delimiters);
            }
            return SplitAndSum(input, delimiters);
        }

        private static string Delimiter()
        {
            return "\n|,";
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetValues(ref string input, string delimiters)
        {
            var indexOf = input.IndexOf("\n");
            delimiters += input.Substring(2,indexOf -2);
            input = input.Substring(indexOf+1);
            return delimiters;
        }

        private static int SplitAndSum(string input, string delimiters)
        {
            var numbers = input.Split(delimiters.ToCharArray(), StringSplitOptions.
                RemoveEmptyEntries);
            CheckNegative(numbers);
            return numbers.Select(int.Parse).Where(n=>n<=1000).Sum();
        }

        private static void CheckNegative(string[] numbers)
        {
            var negatives = numbers.Select(int.Parse).Where(n => n < 0);

            if (negatives.Any())
            {
                throw new NegativesNotAllowedException(negatives.ToArray());
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
