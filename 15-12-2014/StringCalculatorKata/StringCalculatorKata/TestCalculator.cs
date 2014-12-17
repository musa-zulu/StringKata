using System;
using NUnit.Framework;

namespace StringCalculatorKata
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

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithSingleNumber_ReturnNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithLargeSingleNumber_ReturnNumber()
        {
            const string input = "650";
            const int expected = 650;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithTwoNumbers_ReturnSum()
        {
            const string input = "6,5";
            const int expected = 11;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithManyNumbers_ReturnSum()
        {
            const string input = "1,2,3,4,6,5";
            const int expected = 21;
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
        public void Given_InputStringWithDelimiterInBetweenNumbers_ReturnSum()
        {
            const string input = "//;\n1;2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNegativeNumber_ThrowException()
        {
            const string input = "-1,2";
            const string expected = "negatives not allowed : -1";
            var calculator = CreateCalculator();
            var results =Assert.Throws<ApplicationException>(()=> calculator.Add(input));

            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_InputStringWithNegativeNumbers_ThrowException()
        {
            const string input = "-1,2,-3";
            const string expected = "negatives not allowed : -1,-3";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_InputStringWithNumberGreaterThanThousand_IgnoreNumber()
        {
            const string input = "1001,2";
            const int expected = 2;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNumberNotGreaterThanThousand_IgnoreNumber()
        {
            const string input = "1000,2";
            const int expected = 1002;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithDelimiters_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithDifferentDelimiters_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithManyDifferentDelimiters_ReturnSum()
        {
            const string input = "//[*][%][^][&]\n1*2%3^4&5";
            const int expected = 15;
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