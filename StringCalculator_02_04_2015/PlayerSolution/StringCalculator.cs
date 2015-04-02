using System;
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
            if (Match(input))
            {
                delimiters = GetDelimiters(ref input, delimiters);
            }
            return SplitAndSum(input, delimiters);
        }

        private static int SplitAndSum(string input, string delimiters)
        {
          
            var numbers = input.Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            CheckNegative(numbers);
            return numbers.Select(int.Parse).Where(n=>n <= 1000).Sum();
        }

        private static void CheckNegative(string[] numbers)
        {

            var negatives = numbers.Select(int.Parse).Where(n => n < 0);
            if (negatives.Any())
            {
               throw new NegativesNotAllowedException(negatives.ToArray());
            }

        }

        private static string GetDelimiters(ref string input, string delimiters)
        {
            var indexOf = input.IndexOf("\n");
            delimiters += input.Substring(2,indexOf- 2);
            input = input.Substring(indexOf+1);
            return delimiters;
        }

        private static bool Match(string input)
        {
            return input.StartsWith("//");
        }

        private static string Delimiters()
        {
            return "\n|,";
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
