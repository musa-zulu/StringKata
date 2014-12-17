using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using NUnit.Framework;

public class Calculator
{
    public int Add(string input)
    {
        if (IsNullOrEmpty(input))
        {
            return DefaultValue();
        }
        var delimiters = "\n,";

        if (HasCustormDelimiters(input))
        {
            var index = GetIndex(input);
            delimiters += GetDelimiters(input, index);
            input = GetInput(input, index);
        }
        var values = Split(input, delimiters);
        return SumAll(values);
    }

    private static int DefaultValue()
    {
        return 0;
    }

    private static bool IsNullOrEmpty(string input)
    {
        return string.IsNullOrEmpty(input);
    }

    private static bool HasCustormDelimiters(string input)
    {
        return input.IndexOf("//") != -1;
    }

    private static int SumAll(string[] values)
    {
        CheckNegative(values);

        return values.Where(value => value.Length != 0 && int.Parse(value) <= 1000).Sum(value => int.Parse(value));
    }

    private static string GetInput(string input, int index)
    {
        return input.Substring(index + 1);
    }

    private static string GetDelimiters(string input, int index)
    {
        return input.Substring(2,index-2);
    }

    private static int GetIndex(string input)
    {
        return input.IndexOf("\n");
    }

    private static void CheckNegative(IEnumerable<string> values)
    {
        var negatives = values.Where(value => value.Length != 0 && int.Parse(value) < 0).ToList();

        if (negatives.Count > 0)
        {
            throw new ApplicationException("negatives not allowed : "+string.Join(",",negatives.ToArray()));
        }
    }

    private static string[] Split(string input, string delimiters)
    {
        return input.Split(delimiters.ToCharArray(), StringSplitOptions.None);
    }
}