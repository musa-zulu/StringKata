using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata
{
    public class Calculator
    {
        public object Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiterList = "\n,";

            if (!HasCustormDelimiter(input)) return SumAll(input, delimiterList.ToCharArray());
            var index = IndexOf(input);
            delimiterList+=GetDelimiters(input, index);
            input = GetValues(input, index);

            return SumAll(input, delimiterList.ToCharArray());
        }



        private static string GetValues(string input, int index)
        {
            return input.Substring(index + 1, input.Length - index - 1);
        }

        private static string GetDelimiters(string input, int index)
        {
            return input.Substring(2,index-2);
        }

        private static object SumAll(string input, IEnumerable<char> delimiterList)
        {
      
            var values = Split(delimiterList, input);
            CheckNegative(values);


            return values.Where(value => value.Length != 0 && int.Parse(value) <= 1000).Sum(value => int.Parse(value));
        }

        private static void CheckNegative(IEnumerable<string> values)
        {
            var negatives = values.Where(value => value.Length != 0 && int.Parse(value) < 0).ToList();

            if (negatives.Count > 0)
            {
                throw new ApplicationException("negatives are not allowed : "+string.Join(",",negatives));
            }
        }

        private static int IndexOf(string input)
        {
            return input.IndexOf("\n");
        }

        private static bool HasCustormDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        private static string[] Split(IEnumerable<char> delimiterList, string input)
        {
            return input.Split(delimiterList.ToArray(), StringSplitOptions.None);
        }
    }
}