using System.Collections.Generic;
using System.Linq;

namespace PlayerStringKata
{
    public class SumAll
    {
        public static int Sum(IEnumerable<string> numbers)
        {
            return numbers.Select(StringCalculator.ParseNumbers).Where(StringCalculator.InRange()).Sum();
        }
    }
}