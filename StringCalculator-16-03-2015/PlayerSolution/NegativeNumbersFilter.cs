using System.Collections.Generic;
using System.Linq;
using Katarai.StringCalculator.Interfaces;

namespace PlayerStringKata
{
    public class NegativeNumbersFilter
    {
        public static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = numbers.Select(int.Parse).Where(n => n < 0);
            var enumerable = negatives as int[] ?? negatives.ToArray();

            if (enumerable.Any())
            {
                throw new NegativesNotAllowedException(enumerable.ToArray());
            }
        }
    }
}