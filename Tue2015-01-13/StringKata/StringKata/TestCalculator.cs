    
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
            Assert.AreEqual(results, expected);
        }
        [Test]
        public void Given_SingleInputStringShould_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_LargeSingleInputStringShould_ReturnSingleNumber()
        {
            const string input = "152";
            const int expected = 152;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual( results,expected);
        }

        [Test]
        public void Given_InputStringWithTwoNumbersShould_ReturnSum()
        {
            const string input = "1,5";
            const int expected = 6;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputStringWithManyNumbersShould_ReturnSum(){
            const string input = "1,2,3,4,5";
            const int expected = 15;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputStringWithNewLineInBetweenNumbersShould_ReturnSum()
        {
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }


        [Test]
        public void Given_InputStringWithDelimiterInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputStringWithNegativeNumberShould_ThrowException()
        {
            const string input = "-1,2,3";
            const string expected = "negatives are not allowed : -1";
            var calculator = CreateCalculator();

            var results = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
            Assert.AreEqual(results.Message, expected);
        }


        [Test]
        public void Given_InputStringWithNegativeNumbersShould_ThrowException()
        {
            const string input = "-1,2,-3";
            const string expected = "negatives are not allowed : -1,-3";
            var calculator = CreateCalculator();

            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(results.Message, expected);
        }


        [Test]
        public void Given_InputStringNumberGreaterThanThoussandShould_ReturnSum()
        {
            const string input = "1001,2";
            const int expected = 2;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }


        [Test]
        public void Given_InputStringNumberNotGreaterThanThoussandShould_ReturnSum()
        {
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }


        [Test]
        public void Given_InputStringWithDelimiterOfAnyLengthInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }


        [Test]
        public void Given_InputStringWithMultipleDelimiterInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputStringWithMultipleDelimiterOfAnyLengthInBetweenNumbersShould_ReturnSum()
        {
            const string input = "//[*][%][^]\n1*2%3^4";
            const int expected = 10;
            var calculator = CreateCalculator();

            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        private static Calculator CreateCalculator()
        {
            return new Calculator();
        }
    }
}