
using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace StringKataCalculator
{
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
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_SingleNumberInput_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }


        [Test]
        public void Given_LargeSingleNumberInput_ReturnSingleNumber()
        {
            const string input = "150";
            const int expected = 150;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }


        [Test]
        public void Given_TwoNumbersInput_ReturnSum()
        {
            const string input = "1,5";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }


        [Test]
        public void Given_ManyNumbersInput_ReturnSum()
        {
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }



        [Test]
        public void Given_InputWithNewLineInBetweenNumbers_ReturnSum()
        {
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputWithDelimiterInBetweenNumbers_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputWithNegativeNumber_ThrowException()
        {
            const string input = "-1";
            const string expected = "negative numbers are not allowed : -1";
            var calculator = new Calculator();
            var results = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
            Assert.AreEqual(results.Message, expected);
        }

        [Test]
        public void Given_InputWithNegativeNumbers_ThrowException()
        {
            const string input = "-1,-2";
            const string expected = "negative numbers are not allowed : -1,-2";
            var calculator = new Calculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(results.Message, expected);
        }


        [Test]
        public void Given_InputWithNumberGreaterThanThousand_IgnoreValueReturnSum()
        {
            const string input = "1001,6";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputWithNumberNotGreaterThanThousand_IgnoreValueReturnSum()
        {
            const string input = "1000,6";
            const int expected = 1006;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputWithDelimitersOfAnyLength_ShouldReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }


        [Test]
        public void Given_InputWithMultipleDelimiters_ShouldReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputWithMultipleDelimitersOfAnyLength_ShouldReturnSum()
        {
            const string input = "//[*][%][&]\n1*2%3&4";
            const int expected = 10;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

    }
}