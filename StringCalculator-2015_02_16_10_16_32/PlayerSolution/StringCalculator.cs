using System.Collections.Generic;
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
                input = GetValues(input, ref delimiters);
            }
            var numbers = Split(input, delimiters);
            return SumAll(numbers);
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

        private static bool HasCustormDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static int SumAll(IEnumerable<string> numbers)
        {
            CheckNegative(numbers);
            var sum = 0;
            foreach (var number in numbers)
            {
                if (number.Length > 0 && IsInRange(number))
                sum += int.Parse(number);
            }
            return sum;
        }

        private static bool IsInRange(string number)
        {
            return int.Parse(number) <= 1000;
        }

        private static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = new List<int>();

            foreach (var number in numbers)
            {
                if (number.Length > 0 && IsNegative(number))
                {
                    negatives.Add(int.Parse(number));
                }
            }
            if (negatives.Count > 0)
            {
                throw new NegativesNotAllowedException(negatives.ToArray());
            }
        }

        private static bool IsNegative(string number)
        {
            return int.Parse(number) < 0;
        }

        private static IEnumerable<string> Split(string input, string delimiters)
        {
            return input.Split(delimiters.ToCharArray());
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
