using System.Collections.Generic;
using System.Linq;
using Katarai.StringCalculator.Interfaces;

namespace PlayerStringKata
{
    public class NegativeNotAllowed
    {
        public static void CheckNegative(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(number => number < 0).ToList();

            if (negatives.Count > 0)
            {
                throw new NegativesNotAllowedException(negatives.ToArray());
            }
        }
    }
}