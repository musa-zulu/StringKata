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
            var delimiters = "\n|,";
            if (input.StartsWith("//"))
            {
                var indexOf = input.IndexOf("\n");
                delimiters += input.Substring(2, indexOf-1);
              
                input = input.Substring(indexOf+1);
            }
            return SplitAndSum(input, delimiters);
        }

        private static int SplitAndSum(string input, string delimiters)
        {
            
            var numbers = input.Split(delimiters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            CheckNegative(numbers);
            return numbers.Select(int.Parse).Where(n => n <= 1000).Sum();
        }

        private static void CheckNegative(IEnumerable<string> numbers)
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
