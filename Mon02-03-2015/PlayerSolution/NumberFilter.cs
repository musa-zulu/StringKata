using System.Linq;

namespace PlayerStringKata
{
    public class NumberFilter
    {
        public static int SumAll(string[] numbers)
        {
            return numbers.Select(int.Parse).Where(x => x <= 1000).Sum();
        }
    }
}