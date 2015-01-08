using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKataCalculator
{
    class Calculator
    {
        public int Add(string input)
        {
            if (IsNullOrEmpty(input))
            {
                return DefaultValue();
            }
            var delimiters = DefaultDelimiters();
            if (HasCustormDelimiter(input))
            {
                input = GetNumbersAndDelimiters(input, ref delimiters);
            }
            var enumerable = GetNumbersAndSplitDelimiter(input, delimiters);

            return SumAll(enumerable);
        }

        private static string DefaultDelimiters()
        {
            return ",\n";
        }

        private static IEnumerable<string> GetNumbersAndSplitDelimiter(string input, string delimiters)
        {
            var numbers = Split(input, delimiters);
            var enumerable = numbers as string[] ?? numbers.ToArray();
            CheckNegative(enumerable);
            return enumerable;
        }

        private static bool HasCustormDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string GetNumbersAndDelimiters(string input, ref string delimiters)
        {
            var index = input.IndexOf("\n");
            delimiters += input.Substring(2, index - 2);
            input = input.Substring(index + 1, input.Length - index - 1);
            return input;
        }


        private static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = numbers.Where(number => !IsEmpty(number) && IsNegative(number)).ToList();

            if (negatives.Count > 0)
            {
                throw new ApplicationException("negatives are not allowed : " + string.Join(",", negatives));

            }
        }

        private static bool IsNegative(string number)
        {
            return int.Parse(number) < 0;
        }

        private static bool IsEmpty(string number)
        {
            return number.Length == 0;
        }

        private static int SumAll(IEnumerable<string> numbers)
        {
            return numbers.Where(number => !IsEmpty(number) && InRange(number)).Sum(number => int.Parse(number));
        }

        private static bool InRange(string number)
        {
            return int.Parse(number) <= 1000;
        }

        private static IEnumerable<string> Split(string input, string delimiters)
        {
            return input.Split(delimiters.ToCharArray(), StringSplitOptions.None);
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
