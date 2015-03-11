using System;
using System.Collections.Generic;
using System.Linq;
using Katarai.StringCalculator.Interfaces;

namespace PlayerStringKata
{
    public class NegativesNotAllowed
    {
        public static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = numbers.Select(StringCalculator.NumberParser()).Where(StringCalculator.IsNegative());
            var enumerable = negatives as int[] ?? negatives.ToArray();

            if (enumerable.Any())
            {
                throw new NegativesNotAllowedException(enumerable);
            }
        }

    }
}