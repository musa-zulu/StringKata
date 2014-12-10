
using System;
using NUnit.Framework;

namespace CalculatorKata
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
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }


        [Test]
        public void Given_InputStringWithSingleNumber_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_InputStringWithLargeSingleNumber_ReturnSingleNumber()
        {
            const string input = "520";
            const int expected = 520;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_InputStringWithTwoNumbers_ReturnSum()
        {
            const string input = "5,2";
            const int expected = 7;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_InputStringWithManyNumbers_ReturnSum()
        {
            const string input = "1,2,3,4,5";
            const int expected = 15;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_InputStringWithNewLineInBetweenNumbers_ReturnSum()
        {
            const string input = "1\n2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_InputStringWithDelimiterBetweenNumbers_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_InputStringWithNegativeNumber_ShouldThrowException()
        {
            const string input = "-1,2,3";
            const string expected =("negatives are not allowed : -1");
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));


            Assert.AreEqual(expected, results.Message);

        }

        [Test]
        public void Given_InputStringWithNegativeNumbers_ShouldThrowException()
        {
            const string input = "-1,2,-3";
            const string expected = ("negatives are not allowed : -1,-3");
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));


            Assert.AreEqual(expected, results.Message);

        }


        [Test]
        public void Given_InputStringWithNumberGreaterThanThousand_IgnoreValue()
        {
            const string input = "1001,1";
            const int expected =1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }


        [Test]
        public void Given_InputStringWithNumberNotGreaterThanThousand_ReturnSum()
        {
            const string input = "1000,1";
            const int expected = 1001;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }



        [Test]
        public void Given_InputStringWithDelimitersOfAnyLength_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }


        [Test]
        public void Given_InputStringWithMultipleDelimiters_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%4";
            const int expected = 7;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_InputStringWithMultipleDelimitersOfAnyLength_ReturnSum()
        {
            const string input = "//[%%%%%%%%%%%%%%%%%%%%%%%%%%*][%]\n1*2%4%%%%%%%%%%%%%%%%2";
            const int expected = 9;
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