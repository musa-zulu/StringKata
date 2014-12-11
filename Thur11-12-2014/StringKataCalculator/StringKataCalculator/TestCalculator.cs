    
using System;
using NUnit.Framework;

[TestFixture]
public class TestCalculator
{
    // ReSharper disable InconsistentNaming
    [Test]
    public void Given_EmptyInputStringShould_ReturnZero()
    {
        const string input = "";
        const int expect = 0;
        var calculator = new Calculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect,results);
    }

    [Test]
    public void Given_InputStringWithSingleShould_ReturnValue()
    {
        const string input = "1";
        const int expect = 1;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }

    [Test]
    public void Given_InputStringWithLArgeSingleShould_ReturnValue()
    {
        const string input = "950";
        const int expect = 950;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }

    [Test]
    public void Given_InputStringWithTwoValuesShould_ReturnSum()
    {
        const string input = "9,5";
        const int expect = 14;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }

    [Test]
    public void Given_InputStringWithManyValuesShould_ReturnSum()
    {
        const string input = "1,2,3,4,5";
        const int expect = 15;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }

    [Test]
    public void Given_InputStringWithNewLineInBetweenValuesShould_ReturnSum()
    {
        const string input = "1\n2";
        const int expect = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }
  
    [Test]
    public void Given_InputStringWithNegativeValueShould_ThrowException()
    {
        const string input = "-1,2";
        const string expect = "negatives not allowed : -1";
        var calculator = CreateCalculator();
        var results = Assert.Throws<ApplicationException>(()=> calculator.Add(input));

        Assert.AreEqual(expect, results.Message);
    }

    [Test]
    public void Given_InputStringWithNegativeValuesShould_ThrowException()
    {
        const string input = "-1,2,-3";
        const string expect = "negatives not allowed : -1,-3";
        var calculator = CreateCalculator();
        var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

        Assert.AreEqual(expect, results.Message);
    }


    [Test]
    public void Given_InputStringWithDelimiterShould_ReturnSum()
    {
        const string input = "//;\n1;2";
        const int expect = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }

    [Test]
    public void Given_InputStringWithNumbersGreaterThanThousandShouldIgnoreValue_ReturnSum()
    {
        const string input = "1001,3";
        const int expect = 3;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }

    [Test]
    public void Given_InputStringWithNumbersNotGreaterThanThousandShould_ReturnSum()
    {
        const string input = "1000,3";
        const int expect = 1003;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }

    [Test]
    public void Given_InputStringWithDelimitersOfAnyLengthShould_ReturnSum()
    {
        const string input = "//[***]\n1***2***3";
        const int expect = 6;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }

    [Test]
    public void Given_InputStringWithMultipleDelimitersShould_ReturnSum()
    {
        const string input = "//[*][%]\n2*4%6";
        const int expect = 12;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }


    [Test]
    public void Given_InputStringWithMultipleDelimitersOfAnyLengthShould_ReturnSum()
    {
        const string input = "//[*][%][!][@][$][^][&][(][)][-]\n1*2%3!4@5$6^7&8(9)10";
        const int expect = 55;
        var calculator = CreateCalculator();
        var results = calculator.Add(input);

        Assert.AreEqual(expect, results);
    }
    private static Calculator CreateCalculator()
    {
        return new Calculator();
    }
}