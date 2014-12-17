
using System;
using System.Runtime.InteropServices;
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
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }
    [Test]
    public void Given_InputStringWithSingleValue_ReturnValue()
    {
        const string input = "1";
        const int expected = 1;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }
    [Test]
    public void Given_InputStringWithLargeSingleValue_ReturnValue()
    {
        const string input = "500";
        const int expected = 500;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_InputStringWithTwoValues_ReturnSum()
    {
        const string input = "1,2";
        const int expected = 3;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_InputStringWithManyValues_ReturnSum()
    {
        const string input = "1,2,3,4,5";
        const int expected = 15;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_InputStringWithNewLineInBetweenValues_ReturnSum()
    {
        const string input = "1\n2";
        const int expected = 3;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }
    
    
    [Test]
    public void Given_InputStringWithNewDelimiterInBetweenValues_ReturnSum()
    {
        const string input = "//;\n1;2,3";
        const int expected = 6;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }


    [Test]
    public void Given_InputStringWithNegativeValue_ThrowException()
    {
        const string input = "-1,2";
        const string expected = "negatives not allowed : -1";
        var calculator = CreateCalculator();

        var results =Assert.Throws<ApplicationException>(()=> calculator.Add(input));

        Assert.AreEqual(expected, results.Message);
    }

    [Test]
    public void Given_InputStringWithNegativeValues_ThrowException()
    {
        const string input = "-1,2,-3";
        const string expected = "negatives not allowed : -1,-3";
        var calculator = CreateCalculator();

        var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

        Assert.AreEqual(expected, results.Message);
    }



    [Test]
    public void Given_InputStringWithValueGreaterThanThousand_ShouldIgnoreValueAndReturnSum()
    {
        const string input = "1001,2";
        const int expected = 2;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }



    [Test]
    public void Given_InputStringWithValueNotGreaterThanThousand_ShouldReturnSum()
    {
        const string input = "1000,2";
        const int expected = 1002;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }


    [Test]
    public void Given_InputStringWithDelimitersOfAnyLength_ShouldReturnSum()
    {
        const string input = "//[***]\n1***2***3";
        const int expected = 6;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_InputStringWithMultipleDelimiters_ShouldReturnSum()
    {
        const string input = "//[*][%]\n1*2%3";
        const int expected = 6;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }

    [Test]
    public void Given_InputStringWithMultipleDelimitersOfAnyLength_ShouldReturnSum()
    {
        const string input = "//[*][%][^][&][$]\n1*2%3^4&5$6";
        const int expected =21 ;
        var calculator = CreateCalculator();

        var results = calculator.Add(input);

        Assert.AreEqual(expected, results);
    }
    private static Calculator CreateCalculator()
    {
        return new Calculator();
    }
}