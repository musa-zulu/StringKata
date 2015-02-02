using System;
using NUnit.Framework;

namespace StringKata
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
            var calculator = new Calculator();
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
            const string input = "111";
            const int expected = 111;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_TwoNumbersShould_ReturnSum()
        {
            const string input = "1,2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_ManyNumbersShould_ReturnSum()
        {
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithNewLineInBetweenShould_ReturnSum()
        {
            const string input = "1\n2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithDelimitersInBetweenShould_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithNegativeNumberShould_ThrowsException()
        {
            const string input = "-1";
            const string expected = "negatives are not allowed : -1";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_NumbersWithNegativeNumbersShould_ThrowsException()
        {
            const string input = "-1,-2";
            const string expected = "negatives are not allowed : -1,-2";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_NumbersWithValueGreaterThanThousandInBetweenShould_IgnoreValueReturnSum()
        {
            const string input = "1001,3";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithValueNotGreaterThanThousandInBetweenShould_ReturnSum()
        {
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_NumbersWithDelimitersOfAnyLengthInBetweenShould_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithMultipleDelimitersInBetweenShould_ReturnSum()
        {
            const string input = "//[*][%][$]\n1*2%3$4";
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