using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (IsNullOrEmpty(input))
            {
                return DefaultValue();
            }
            var delimiters = DelfaultDelimiters();
            if (HasCustromDelimiter(input))
            {
                input = GetInputAndDelimiters(input, ref delimiters);
            }

            var numbers = Split(input, delimiters);
            CheckNegative(numbers);
            return SumAll(numbers);
        }

        private static string GetInputAndDelimiters(string input, ref string delimiters)
        {
            var index = input.IndexOf("\n");
            delimiters += GetDelimiters(input, index);
            input = GetNewValues(input, index);
            return input;
        }

        private static string GetNewValues(string input, int index)
        {
            return input.Substring(index + 1, input.Length - index - 1);
        }

        private static string GetDelimiters(string input, int index)
        {
            return input.Substring(2, index - 2);
        }

        private static bool HasCustromDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string DelfaultDelimiters()
        {
            return "\n,";
        }

        private static int DefaultValue()
        {
            return 0;
        }

        private static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = numbers.Where(number => IsEmpty(number) && IsNegative(number)).ToList();

            if (negatives.Count > 0)
            {
                throw new ApplicationException("negatives are not allowed : " + string.Join(",", negatives.ToArray()));

            }
        }

        private static bool IsNegative(string number)
        {
            return int.Parse(number) < 0;
        }

        private static string[] Split(string input, string delimiters)
        {
            return input.Split(delimiters.ToCharArray(), StringSplitOptions.None);
        }

        private static int SumAll(IEnumerable<string> numbers)
        {
            return numbers.Where(number => IsEmpty(number) && IsInclusive(number)).Sum(number => int.Parse(number));
        }

        private static bool IsInclusive(string number)
        {
            return int.Parse(number) <= 1000;
        }

        private static bool IsEmpty(string number)
        {
            return number.Length != 0;
        }
    }
}