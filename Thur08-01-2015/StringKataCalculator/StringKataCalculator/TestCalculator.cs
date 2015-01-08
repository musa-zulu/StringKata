using System;
using NUnit.Framework;

namespace StringKataCalculator
{
    [TestFixture]
    public class TestCalcator
    {
        [Test]
        public void Given_EmptyStringInputShould_ReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringInputWithSingleNumberShould_ReturnNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringInputWithLargeSingleNumberShould_ReturnNumber()
        {
            const string input = "185";
            const int expected = 185;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringInputWithTwoNumbersShould_ReturnSum()
        {
            const string input = "1,8";
            const int expected = 9;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringInputWithManyNumbersShould_ReturnSum()
        {
            const string input = "1,2,3,4,5,6,7,8";
            const int expected = 36;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringInputWithNewLineBetweenNumbersShould_ReturnSum()
        {
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringInputWithDelimiterBetweenNumbersShould_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_StringInputWithNegativeNumberShould_ThrowException()
        {
            const string input = "-1,2";
            const string expected = "negatives are not allowed : -1";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_StringInputWithNegativeNumbersShould_ThrowException()
        {
            const string input = "-1,2,-3,-4";
            const string expected = "negatives are not allowed : -1,-3,-4";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_StringInputWithNumberGreaterThanThousandShould_IgnoreNumberReturnSum()
        {

            const string input = "1001,3";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_StringInputWithNumberNotGreaterThanThousandShould_ReturnSum()
        {

            const string input = "1000,3";
            const int expected = 1003;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringInputWithDelimitersInBetweenNumbersShould_ReturnSum()
        {

            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringInputWithMultipleDelimitersInBetweenNumbersShould_ReturnSum()
        {

            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_StringInputWithMultipleDelimitersOfAnyLengthInBetweenNumbersShould_ReturnSum()
        {

            const string input = "//[*][%][@][#]\n1*2%3@4#5";
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