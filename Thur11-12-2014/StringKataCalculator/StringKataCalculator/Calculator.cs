using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;

public class Calculator
{
    public object Add(string input)
    {
        if (IsEmptyOrNull(input))
        {
            return DefaultValue();
        }
        var delimiters = "\n,";

        if (input.StartsWith("//"))
        {
            var index = input.IndexOf("\n");
            delimiters += input.Substring(2, index - 2);
            input = input.Substring(index + 1, input.Length - index -1);
        }
        return SumAll(input, delimiters);
    }

    private static object SumAll(string input, string delimiters)
    {
        var sum = 0;
        var values = Split(input, delimiters);
        CheckNegative(values);
        foreach (var value in values)
        {
            if (value.Length != 0 && int.Parse(value) <= 1000)
            {
      
                sum += int.Parse(value);
            }
        }

        return sum;
    }

    private static void CheckNegative(string[] values)
    {
        var negatives = new List<string>();

        foreach (var value in values)
        {
           
            if (value.Length != 0 && int.Parse(value) < 0)
            {
                negatives.Add(value);
               
            }
        }
        if (negatives.Count > 0)
        {
            throw new ApplicationException("negatives not allowed : " + string.Join(",", negatives.ToArray()));
        }
    }

    private static int DefaultValue()
    {
        return 0;
    }

    private static bool IsEmptyOrNull(string input)
    {
        return input.Length == 0;
    }

    private static string[] Split(string input, string delimiters)
    {
        return input.Split(delimiters.ToCharArray());
    }
}