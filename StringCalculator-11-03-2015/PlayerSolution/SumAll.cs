using System.Collections.Generic;
using System.Linq;

namespace PlayerStringKata
{
    public class SumAll
    {
        public static int SumAllNumbers(IEnumerable<string> numbers)
        {
            return numbers.Select(StringCalculator.NumberParser()).Where(StringCalculator.IsInRange()).Sum();
        }
    }
}