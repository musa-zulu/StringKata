using System;
using NUnit.Framework;

namespace StringKataCalculator
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
        public void Given_InputStringWithSingleValueShould_ReturnSingleValue()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputStringWithLargeSingleValueShould_ReturnLargeSingleValue()
        {
            const string input = "582";
            const int expected = 582;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputStringWithTwoValuesShould_ReturnSumOfValues()
        {
            const string input = "5,2";
            const int expected = 7;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithManyValuesShould_ReturnSumOfValues()
        {
            const string input = "1,2,3,4";
            const int expected = 10;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNewLineInBetweenValuesShould_ReturnSumOfValues()
        {
            const string input = "1\n2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithADelimiterInBetweenValuesShould_ReturnSumOfValues()
        {
            const string input = "//;\n1;3";
            const int expected = 4;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithANegativeValueShould_ThrowException()
        {
            const string input = "-1,2,3";
            const string expected = "negatives are not allowed : -1";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_InputStringWithNegativeValuesShould_ThrowException()
        {
            const string input = "-1,2,-3";
            const string expected = "negatives are not allowed : -1,-3";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_InputStringWithAValueGreaterThanThousandShould_IgnoreValueAndReturnSum()
        {
            const string input = "1001,2";
            const int expected = 2;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithAValueNotGreaterThanThousandShould_ReturnSum()
        {
            const string input = "1000,2";
            const int expected = 1002;
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
            const string input = "//[*][%]\n2*4%6";
            const int expected = 12;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithMultipleDelimitersOfAnyLength_ReturnSum()
        {
            const string input = "//[*][%][^][!]\n2*4%6^8!10";
            const int expected = 30;
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