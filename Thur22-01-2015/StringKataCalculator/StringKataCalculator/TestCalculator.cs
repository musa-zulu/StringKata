
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
        public void Given_StringWithSingleNumberShould_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_StringWithLargeSingleNumberShould_ReturnSingleNumber()
        {
            const string input = "150";
            const int expected = 150;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_StringWithTwoNumbersShould_ReturnSum()
        {
            const string input = "1,5";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_StringWithManyNumbersShould_ReturnSum()
        {
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_StringWithNewLineInBetweenNumbersShould_ReturnSum()
        {
            const string input = "1\n2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_StringWithDelimiterInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);

        }


        [Test]
        public void Given_StringWithNegativeNumberInBetweenNumberShould_ThrowException()
        {
            const string input = "-1";
            const string expected = "negatives are not allowed : -1";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
            Assert.AreEqual(expected, results.Message);

        }

        [Test]
        public void Given_StringWithNegativeNumbersInBetweenNumberShould_ThrowException()
        {
            const string input = "-1,2,-3";
            const string expected = "negatives are not allowed : -1,-3";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);

        }



        [Test]
        public void Given_StringWithNumberGreaterThanThousandShould_IgnoreValueReturnSum(){
            const string input = "1001,3";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_StringWithNumberNotGreaterThanThousandShould_IgnoreValueReturnSum()
        {
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);

        }


        [Test]
        public void Given_StringWithDelimitersOfAnyLengthInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);

        }



        [Test]
        public void Given_StringWithMultipleDelimitersInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);

        }

        [Test]
        public void Given_StringWithMultipleDelimitersOfAnyLengthInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//[*][%][^]\n1*2%3^4";
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