using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKataCalculator
{
    public class StringCalcaulator : IStringCalcaulator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            //input = input.Replace("\n", ",");
            var delimiters = new List<string> { ",", "\n" };

            if (input.StartsWith("//"))
            {
                delimiters.Add(input.Substring(0, input.IndexOf("\n")).Replace("//", ""));
                input = input.Substring(4);
            }
            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.None).Select(int.Parse);

            return numbers.Sum();
        }
    }
}
