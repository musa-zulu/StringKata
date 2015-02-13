    
using System;
using System.Collections.Specialized;
using NUnit.Framework;
using StringKataCalculator;

[TestFixture]
public class TestCalculator
{
    // ReSharper disable InconsistentNaming
    [Test]
    public void Given_EmptyInputStringShould_ReturnZero()
    {
        const string input = "";
        const int expected = 0;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected,actual);
    }

    [Test]
    public void Given_SingleNumberInputStringShould_ReturnSingleNumber()
    {
        const string input = "1";
        const int expected = 1;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Given_LargeSingleNumberInputStringShould_ReturnSingleNumber()
    {
        const string input = "120";
        const int expected = 120;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Given_TwoNumbersInputStringShould_ReturnSum()
    {
        const string input = "1,2";
        const int expected = 3;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Given_ManyNumbersInputStringShould_ReturnSum()
    {
        const string input = "1,2,3";
        const int expected = 6;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Given_NumberInputStringWithNewLineShould_ReturnSum()
    {
        const string input = "1\n2,3";
        const int expected = 6;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Given_NumberInputStringWithSingleCustomDelimiterShould_ReturnSum()
    {
        const string input = "//;\n1;2";
        const int expected = 3;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Given_NumberInputStringWithANegativeShould_ThrowException()
    {
        const string input = "-1";
        const string expected = "negatives are not allowed: -1";
        var calculator = new Calculator();
        var actual = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
        Assert.AreEqual(expected, actual.Message);
    }

    [Test]
    public void Given_NumberInputStringWithNegativeNumbersShould_ThrowException()
    {
        const string input = "-1,2,3,-4";
        const string expected = "negatives are not allowed: -1,-4";
        var calculator = new Calculator();
        var actual = Assert.Throws<ApplicationException>(() => calculator.Add(input));
        Assert.AreEqual(expected, actual.Message);
    }

    [Test]
    public void Given_NumberInputStringWithValueGreaterThanThousandShould_ReturnSum()
    {
        const string input = "1001,3";
        const int expected = 3;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }


    [Test]
    public void Given_NumberInputStringWithValueNotGreaterThanThousandShould_ReturnSum()
    {
        const string input = "1000,3";
        const int expected = 1003;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Given_NumberInputStringWithDelimitersOfAnyLengthShould_ReturnSum()
    {
        const string input = "//[***]\n1***2***3";
        const int expected = 6;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Given_NumberInputStringWithMultipleDelimitersShould_ReturnSum()
    {
        const string input = "//[*][%]\n1*2%3";
        const int expected = 6;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Given_NumberInputStringWithMultipleDelimitersOfAnyLengthShould_ReturnSum()
    {
        const string input = "//[*][%][$]\n1*2%3$4";
        const int expected = 10;
        var calculator = new Calculator();
        var actual = calculator.Add(input);
        Assert.AreEqual(expected, actual);
    }
}