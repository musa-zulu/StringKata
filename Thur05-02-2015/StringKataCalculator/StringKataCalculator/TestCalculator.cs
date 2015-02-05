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
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_SingleNumberStringShould_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_LargeSingleNumberStringShould_ReturnSingleNumber()
        {
            const string input = "150";
            const int expected = 150;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_TwoNumbersStringShould_ReturnSum()
        {
            const string input = "1,2";
            const int expected = 3;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_ManyNumbersStringShould_ReturnSum()
        {
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithNewLineInBetweenShould_ReturnSum()
        {
            const string input = "1\n2";
            const int expected = 3;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithCustormDelimiterInBetweenShould_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithNegativeNumberInBetweenShould_ThrowException()
        {
            const string input = "1,-2,3";
            const string expected = "negatives not allowed : -2";
            var calculator = new Calculator();
            var results = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_NumbersWithNegativeNumbersInBetweenShould_ThrowException()
        {
            const string input = "1,-2,-3";
            const string expected = "negatives not allowed : -2,-3";
            var calculator = new Calculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_NumberGreaterThanThousand_ReturnSum()
        {
            const string input = "1001,3";
            const int expected = 3;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumberNotGreaterThanThousand_ReturnSum()
        {
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithCustormDelimitersOfAnyLengtthInBetweenShould_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithMultipleCustormDelimitersInBetweenShould_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithMultipleCustormDelimitersOfAnyLengthInBetweenShould_ReturnSum()
        {
            const string input = "//[*][%][^]\n1*2%3^4";
            const int expected = 10;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }
    }
}