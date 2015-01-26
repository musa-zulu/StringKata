using System;
using NUnit.Framework;

namespace StringKataCalculator
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
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithSingleNumberShould_ReturnNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithLargeSingleNumberShould_ReturnNumber()
        {
            const string input = "120";
            const int expected = 120;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithTwoNumbersShould_ReturnSum()
        {
            const string input = "1,2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithManyNumbersShould_ReturnSum()
        {
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNewLineInBetweenNumbersShould_ReturnSum()
        {
            const string input = "1\n2,3";
            const int expected = 6;
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
        public void Given_InputStringWithNegativeNumberShould_ThrowException()
        {
            const string input = "-1,2";
            const string expected = "negatives not allowed : -1";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_InputStringWithNegativeNumbersShould_ThrowException()
        {
            const string input = "-1,-2,3";
            const string expected = "negatives not allowed : -1,-2";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }



        [Test]
        public void Given_InputStringWithNumberGreaterThanThousandShould_IngnoreValueReturnSum()
        {
            const string input = "1001,3";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNumberNotGreaterThanThousandShould_ReturnSum()
        {
            const string input = "1000,3";
            const int expected = 1003;
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
}