
using System;
using NUnit.Framework;

namespace StringCalculatorKata
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
            const string input = "150";
            const int expected = 150;
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
            const string input = "1,2,3,4,5";
            const int expected = 15;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNewLineBetweenNumbersShould_ReturnSum()
        {
            const string input = "1\n2";
            const int expected = 3;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithDelimiterBetweenNumbersShould_ReturnSum()
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
            const string expected = "negatives are not allowed : -1";
            var calculator = CreateCalculator();

            var results = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_InputStringWithManyNegativeNumberShould_ThrowException()
        {
            const string input = "-1,-2,-3,4";
            const string expected = "negatives are not allowed : -1,-2,-3";
            var calculator = CreateCalculator();

            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_InputStringWithNumberGreaterThanThousandShould_IgnoreNumberReturnSum()
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
        public void Given_InputStringWithDelimitersInBettwenNumbers_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithMultipleDelimitersInBettwenNumbers_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithMultipleDelimitersLongerThanOneCharInBettwenNumbers_ReturnSum()
        {
            const string input = "//[&][*][%]\n1*2%3&4";
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