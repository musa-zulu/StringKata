    
using System;
using NUnit.Framework;

[TestFixture]
public class TestCalculator
{
    // ReSharper disable InconsistentNaming
    [Test]
    public void Given_EmptyString_ReturnZero()
    {
        const string input = "";
        const int expected = 0;
        var calculator = new Calculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results,expected);
    }

    [Test]
    public void Given_SingleInputString_ReturnSingleNumber()
    {
        const string input = "1";
        const int expected = 1;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }


    [Test]
    public void Given_LargeSingleNumberInputString_ReturnSingleNumber()
    {
        const string input = "130";
        const int expected = 130;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }

    [Test]
    public void Given_TwoNumbersInputString_ReturnSum()
    {
        const string input = "1,3";
        const int expected = 4;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }


    [Test]
    public void Given_ManyNumbersInputString_ReturnSum()
    {
        const string input = "1,2,3";
        const int expected = 6;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }



    [Test]
    public void Given_StringNumbersWithNewLineInBetween_ReturnSum()
    {
        const string input = "1\n2";
        const int expected = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }


    [Test]
    public void Given_StringNumbersWithDelimiterInBetween_ReturnSum()
    {
        const string input = "//;\n1;2";
        const int expected = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }


    [Test]
    public void Given_StringWithNegativeNumberShould_ThrowException()
    {
        const string input = "-1";
        const string expected = "negatives are not allowed : -1";
        var calculator = CreateCalculator();
        var results = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
        Assert.AreEqual(results.Message, expected);
    }


    [Test]
    public void Given_StringWithNegativeNumbersShould_ThrowException()
    {
        const string input = "-1,2,-3";
        const string expected = "negatives are not allowed : -1,-3";
        var calculator = CreateCalculator();
        var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
        Assert.AreEqual(results.Message, expected);
    }

    [Test]
    public void Given_StringNumbersWithNumberGreaterThanThousand_IgnoreValueReturnSum()
    {
        const string input = "1001,2";
        const int expected = 2;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }


    [Test]
    public void Given_StringNumbersWithNumberNotGreaterThanThousand_ReturnSum()
    {
        const string input = "1000,2";
        const int expected = 1002;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }

    [Test]
    public void Given_StringNumbersWithDelimitersOfAnyLength_ReturnSum()
    {
        const string input = "//[***]\n1***2***3";
        const int expected = 6;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }


    [Test]
    public void Given_StringNumbersWithMultipleDelimiters_ReturnSum()
    {
        const string input = "//[*][%]\n1*2%3";
        const int expected = 6;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }

    [Test]
    public void Given_StringNumbersWithMultipleDelimitersOfAnyLength_ReturnSum()
    {
        const string input = "//[*][%][&]\n1*2%3&5";
        const int expected = 11;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(results, expected);
    }

    private static Calculator CreateCalculator()
    {
        return new Calculator();
    }
}