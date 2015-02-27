
using System;
using NUnit.Framework;
using StringKataCalculator;

[TestFixture]
public class TestCalculator
{
    // ReSharper disable InconsistentNaming
    [Test]
    public void Given_EmptyInputShould_ReturnZero()
    {
        const string input = "";
        const int expected = 0;
        var calculator = new Calculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_SingleNumberShould_ReturnSingleNumber()
    {
        const string input = "1";
        const int expected = 1;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_LargeSingleNumberShould_ReturnSingleNumber()
    {
        const string input = "160";
        const int expected = 160;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_TwoNumbersShould_ReturnSum()
    {
        const string input = "1,2";
        const int expected = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }


    [Test]
    public void Given_ManyNumbersShould_ReturnSum()
    {
        const string input = "1,2,3,4";
        const int expected = 10;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }


    [Test]
    public void Given_NumbersWithNewLineInBetweenShould_ReturnSum()
    {
        const string input = "1\n2";
        const int expected = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_NumbersWithDelimiterInBetweenShould_ReturnSum()
    {
        const string input = "//;\n1;2";
        const int expected = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_InputWithNegativeNumberShould_ReturnSum()
    {
        const string input = "-1";
        const string expected = "negatives are not allowed  : -1";
        var calculator = CreateCalculator();
        var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
        Assert.AreEqual(expected, results.Message);
    }

    [Test]
    public void Given_InputWithNegativeNumbersShould_ReturnSum()
    {
        const string input = "-1,2,-3";
        const string expected = "negatives are not allowed  : -1,-3";
        var calculator = CreateCalculator();
        var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
        Assert.AreEqual(expected, results.Message);
    }



    [Test]
    public void Given_NumberGreaterThanThousandShould_IgnoreValueReturnSum()
    {
        const string input = "1001,2";
        const int expected = 2;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_NumberNotGreaterThanThousandShould_IgnoreValueReturnSum()
    {
        const string input = "1000,2";
        const int expected = 1002;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_InputWithDelimitersShould_ReturnSum()
    {
        const string input = "//[***]\n1***2***3";
        const int expected = 6;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_InputWithMultipleDelimitersShould_ReturnSum()
    {
        const string input = "//[*][%]\n1*2%3";
        const int expected = 6;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);
        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_InputWithMultipleDelimitersOfAnyLengthShould_ReturnSum()
    {
        const string input = "//[*][%][&]\n1*2%3&4";
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