using System.Collections.Generic;
using System.Linq;
using Katarai.StringCalculator.Interfaces;

namespace PlayerStringKata
{
    public class NegativeNotAllowedFilter
    {
        public static void CheckNegative(IEnumerable<string> numbers)
        {
            var negatives = numbers.Select(int.Parse).Where(parsedNumber => parsedNumber < 0).ToList();

            if (negatives.Count > 0)
            {
                throw new NegativesNotAllowedException(negatives.ToArray());
            }
        }

    }
}