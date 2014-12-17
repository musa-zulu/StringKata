using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (input.Length == 0)
            {
                return 0;
            }

            var delimiters = "\n,";
            if (HasCustormDelimiter(input))
            {
                var index = input.IndexOf("\n");
                delimiters += input.Substring(2,index-2);
                input = input.Substring(index + 1);
            }
     
            var values = Split(input,delimiters);
            return SumAll(values);
        }

        private static bool HasCustormDelimiter(string input)
        {
            return input.IndexOf("//") != -1;
        }

        private static int SumAll(IEnumerable<string> values)
        {
            CheckNegative(values);

            return values.Where(value => value.Length != 0 && int.Parse(value) <= 1000).Sum(value => int.Parse(value));
        }

        private static void CheckNegative(IEnumerable<string> values)
        {
            var negatives = values.Where(value => value.Length != 0 && int.Parse(value) < 0).ToList();

            if (negatives.Count > 0)
            {
                throw new ApplicationException("negatives not allowed : "+string.Join(",",negatives));
            }
        }

        private IEnumerable<string> Split(string s, string delimiters)
        {
            return s.Split(delimiters.ToCharArray(), StringSplitOptions.None);
        }
    }
}