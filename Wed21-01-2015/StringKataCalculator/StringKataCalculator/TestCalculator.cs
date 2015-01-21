    
using System;
using NUnit.Framework;
using StringKataCalculator;

[TestFixture]
public class TestCalculator
{
    // ReSharper disable InconsistentNaming
    [Test]
    public void Given_EmptyString_ReturnZero()
    {
        const string input = "";
        const int expected = 0;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected,results);
    }
    [Test]
    public void Given_StringWithSingleNumber_ReturnSingleNumber()
    {
        const string input = "1";
        const int expected = 1;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_StringWithLargeSingleNumber_ReturnSingleNumber()
    {
        const string input = "160";
        const int expected = 160;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }


    [Test]
    public void Given_StringWithTwoNumbers_ReturnSum()
    {
        const string input = "1,6";
        const int expected = 7;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_StringWithManyNumbers_ReturnSum()
    {
        const string input = "1,2,3,4,5,6";
        const int expected = 21;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }


    [Test]
    public void Given_StringWithNewLineInBetweenNumbers_ReturnSum()
    {
        const string input = "1\n2";
        const int expected = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_StringWithDelimiterInBetweenNumbers_ReturnSum()
    {
        const string input = "//;\n1;2";
        const int expected = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_StringWithNegativeNumberShould_ThrowException()
    {
        const string input = "-1";
        const string expected = "negatives are not allowed : -1";
        var calculator = CreateCalculator();
        var results = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
        Assert.AreEqual(expected, results.Message);
    }

    [Test]
    public void Given_StringWithNegativeNumbersShould_ThrowException()
    {
        const string input = "-1,-2";
        const string expected = "negatives are not allowed : -1,-2";
        var calculator = CreateCalculator();
        var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
        Assert.AreEqual(expected, results.Message);
    }

    [Test]
    public void Given_StringWithNumberGreaterThanThousand_IgnoreValueReturnSum()
    {
        const string input = "1001,3";
        const int expected = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_StringWithNumberNotGreaterThanThousand_ReturnSum()
    {
        const string input = "1000,3";
        const int expected = 1003;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }


    [Test]
    public void Given_StringWithDelimitersOfAnyLengthInBetweenNumbers_ReturnSum()
    {
        const string input = "//[***]\n1***2***3";
        const int expected = 6;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }


    [Test]
    public void Given_StringWithMultipleDelimitersInBetweenNumbers_ReturnSum()
    {
        const string input = "//[*][%]\n1*2%3";
        const int expected = 6;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_StringWithMultipleDelimitersOfAnyLengthInBetweenNumbers_ReturnSum()
    {
        const string input = "//[*][%][^]\n1*2%3^4";
        const int expected = 10;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }


    private static Calculator CreateCalculator()
    {
        return new Calculator();
    }
}