using System;
using System.Collections.Generic;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;

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
            if (HasCustormDelimiters(input))
            {
                input = GetValues(input, ref delimiters);
            }
            var numbers = Split(input, delimiters);

            return SumAll(numbers);
        }

        private static bool HasCustormDelimiters(string input)
        {
            return input.StartsWith("//");
        }

        private static string Delimiters()
        {
            return ",|\n";
        }

        private static string GetValues(string input, ref string delimiters)
        {
            var index = input.IndexOf("\n");
            delimiters += input.Substring(2, index - 2);
            input = input.Substring(index + 1);
            return input;
        }

        private static string[] Split(string input, string delimiters)
        {
            return input.Split(delimiters.ToCharArray());
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
            var negatives = new List<int>();
            foreach (var number in numbers)
            {
                if (number.Length != 0 && int.Parse(number) < 0)
                {
                    negatives.Add(int.Parse(number));
                }
            }

            if (negatives.Count > 0)
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
