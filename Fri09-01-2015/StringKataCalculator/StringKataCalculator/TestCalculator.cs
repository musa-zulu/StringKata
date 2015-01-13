
using System;
using NUnit.Framework;

namespace StringKataCalculator
{
    [TestFixture]
    public class TestCalcualtor
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
        public void Given_StringWithSingleNumberInputShould_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithLargeSingleNumberInputShould_ReturnSingleNumber()
        {
            const string input = "180";
            const int expected = 180;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithTwoNumbersShould_ReturnSum()
        {
            const string input = "1,8";
            const int expected = 9;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithManyNumbersShould_ReturnSum()
        {
            const string input = "1,2,3,4,5,6,7,8";
            const int expected = 36;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_StringWithNewLineInBetweenNumbersShould_ReturnSum()
        {
            const string input = "1\n2";
            const int expected = 3;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_StringWithNegativeNumberShould_ThrowException()
        {
            const string input = "-1";
            const string expected = "negative numbers not allowed : -1";
            var calculator = new Calculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            Assert.AreEqual(expected, results.Message);
        }
        [Test]
        public void Given_StringWithDelimiterInBetweenNumbeersShould_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_StringWithNegativeNumbersShould_ThrowException()
        {
            const string input = "-1,2,-3";
            const string expected = "negative numbers not allowed : -1,-3";
            var calculator = new Calculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_StringWithNumberGreaterThanThousandShould_IgnoreNumberReturnSum()
        {
            const string input = "1001,2";
            const int expected = 2;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithNumberNotGreaterThanThousandShould_ReturnSum()
        {
            const string input = "1000,2";
            const int expected = 1002;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }
        

        [Test]
        public void Given_StringWithDelimitersOfAnyLengthInBetweenNumbers_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_StringWithManyDelimitersInBetweenNumbers_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_StringWithManyDelimitersOfAnyLengthInBetweenNumbers_ReturnSum()
        {
            const string input = "//[*][%][@]\n1*2%3@4";
            const int expected = 10;
            var calculator = new Calculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

    }
}