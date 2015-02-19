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
            var delimiters = Delimiters();

            if (HasCustormDelimiter(input))
            {
                input = GEtValues(input, ref delimiters);
            }
            var numbers = Split(input,delimiters);
            return SumAll(numbers);
        }

        private static string Delimiters()
        {
            return ",|\n";
        }

        private static bool HasCustormDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string GEtValues(string input, ref string delimiters)
        {
            var index = input.IndexOf("\n");
            delimiters += input.Substring(2, index - 2);
            input = input.Substring(index + 1);
            return input;
        }

        private static int SumAll(IEnumerable<string> numbers)
        {
            CheckNegative(numbers);

            return numbers.Where(number => !IsEmpty(number) && IsInRange(number)).Sum(number => Parse(number));
        }

        private static bool IsInRange(string number)
        {
            return Parse(number) <= 1000;
        }

        private static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = (from number in numbers where !IsEmpty(number) && IsNegative(number) select Parse(number)).ToList();

            if (negatives.Count > 0)
            {
                throw new NegativesNotAllowedException(negatives.ToArray());
            }
        }

        private static bool IsNegative(string number)
        {
            return Parse(number) < 0;
        }

        private static bool IsEmpty(string number)
        {
            return number.Length == 0;
        }

        private static IEnumerable<string> Split(string input,string delimiters)
        {
            return input.Split(delimiters.ToCharArray());
        }

        private static bool IsNullOrEmpty(string input)
        {
            return input.Length == 0;
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static int Parse(string input)
        {
            return int.Parse(input);
        }
    }
}
