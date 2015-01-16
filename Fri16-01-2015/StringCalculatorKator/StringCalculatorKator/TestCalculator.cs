    
using System;
using NUnit.Framework;

namespace StringCalculatorKator
{
    [TestFixture]
    public class TestCalculator
    {
        // ReSharper disable InconsistentNaming
        [Test]
        public void Given_EmptyStringShould_ReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected,results);
        }

        [Test]
        public void Given_SingleInputStringShould_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_LargeSingleInputStringShould_ReturnSingleNumber()
        {
            const string input = "150";
            const int expected = 150;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithTwoNumbersShould_ReturnSum()
        {
            const string input = "1,5";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithManyNumbersShould_ReturnSum()
        {
            const string input = "1,2,3,4,5";
            const int expected = 15;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNewLineInBetweenNumbersShould_ReturnSum()
        {
            const string input = "1\n2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithDelimiterInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithANegativeNumberShould_ThrowException()
        {
            const string input = "-1";
            const string expected = "Negative numbers are not allowed : -1";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_InputStringWithManyNegativeNumbersShould_ThrowException()
        {
            const string input = "-1,2,-3";
            const string expected = "Negative numbers are not allowed : -1,-3";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_InputStringWithNumberGreaterThanThousandShould_ReturnSum()
        {
            const string input = "1001,2";
            const int expected = 2;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNumberNotGreaterThanThousandShould_ReturnSum()
        {
            const string input = "1000,2";
            const int expected = 1002;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithDelimitersOfAnyLengthInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithMultipleDelimitersInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithMultipleDelimitersOfAnyLengthInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//[*][&][%]\n1*2%3&4";
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
}