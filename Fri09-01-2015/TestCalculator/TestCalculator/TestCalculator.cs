
using System;
using NUnit.Framework;

namespace TestCalculator
{
    [TestFixture]
    public class TestCalculator
    {

        [Test]
        public void Given_EmptyStringShould_ReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithSingleNumberShould_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithLargeSingleNumberShould_ReturnSingleNumber()
        {
            const string input = "185";
            const int expected = 185;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithTwoNumbersShould_ReturnSum()
        {
            const string input = "1,8";
            const int expected = 9;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithManyNumbersShould_ReturnSum()
        {
            const string input = "1,2,3,4,5,6,7,8";
            const int expected = 36;
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
            const string input = "//;\n2;3";
            const int expected = 5;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNegativeNumberShould_ThrowException()
        {
            const string input = "-1";
            const string expected = "negative input not allowed : -1";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_InputStringWithNegativeNumbersShould_ThrowException()
        {
            const string input = "-1,2,-3";
            const string expected = "negative input not allowed : -1,-3";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_InputStringWithNumberGreaterThanThousandShould_IgnoreNumberAndReturnSum()
        {
            const string input = "1001,5";
            const int expected = 5;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNumberNotGreaterThanThousandShould_ReturnSum()
        {
            const string input = "1000,5";
            const int expected = 1005;
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
            const string input = "//[*][%]\n2*3%4";
            const int expected = 9;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithMultipleDelimitersOfAnyLengthInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//[*][%][#]\n1*2%3#4";
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