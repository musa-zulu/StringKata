using System;
using NUnit.Framework;

namespace StringKata
{
    [TestFixture]
    public class TestCalculator
    {
        // ReSharper disable InconsistentNaming
        [Test]
        public void Given_EmptyInputString_ReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected,results);
        }

        [Test]
        public void Given_InputStringWithSingleValue_ReturnSingleValue()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithLargeSingleValue_ReturnLargeSingleValue()
        {
            const string input = "559";
            const int expected =559;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithTwoValues_ReturnSum()
        {
            const string input = "5,5";
            const int expected = 10;
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
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithDefaultDelimiterInBetweenValues_ReturnSum()
        {
            const string input = "//;\n1;2,4";
            const int expected = 7;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithANegativeValue_ShouldThrowException()
        {
            const string input = "-2,5,6";
            const string expected = "negatives are not allowed : -2";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(()=> calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }



        [Test]
        public void Given_InputStringWithNegativeValues_ShouldThrowException()
        {
            const string input = "-2,5,-6";
            const string expected = "negatives are not allowed : -2,-6";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }



        [Test]
        public void Given_InputStringWithValueGreaterThanThousand_ShouldIgnoreValueAndReturnSum()
        {
            const string input = "1001,7";
            const int expected = 7;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithValueNotGreaterThanThousand_ShouldReturnSum()
        {
            const string input = "1000,7";
            const int expected = 1007;
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
            const string input = "//[*&][%^]\n1&*2%^3^6";
            const int expected = 12;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        private static Calculator CreateCalculator()
        {
            return new Calculator();
        }
    }
}