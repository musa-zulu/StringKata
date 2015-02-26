﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            string delimiters = DefaultDelimiters();
            if (HasCustomDelimiter(input))
            {
                delimiters = GetValues(ref input, delimiters);
            }

            return SpitAndSumAll(input, delimiters);
        }

        private static string GetValues(ref string input, string delimiters)
        {
            var indexOf = input.IndexOf("\n");
            delimiters += input.Substring(2, indexOf - 1);
            input = input.Substring(indexOf + 1);
            return delimiters;
        }

        private static bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string DefaultDelimiters()
        {
            return ",|\n";
        }

        private static int SpitAndSumAll(string input, string delimiters)
        {
            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).Where(x => x <= 1000);

            CheckNegative(numbers);
            return numbers.Sum();
        }

        private static void CheckNegative(IEnumerable<int> numbers)
        {
            var parsedNumber = numbers.Where(x => x < 0);

            var negatives = parsedNumber.ToList();

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
