
using System;
using NUnit.Framework;

namespace StringKataCalculator
{
    [TestFixture]
    public class TestCalculator
    {
        // ReSharper disable InconsistentNaming
        [Test]
        public void Given_EmptyInput_ReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results,expected);
        }

        [Test]
        public void Given_SingleInput_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results,expected);
        }

        [Test]
        public void Given_LargeSingleInput_ReturnSingleNumber()
        {
            const string input = "150";
            const int expected = 150;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results,expected);
        }


        [Test]
        public void Given_InputWithTwoNumbers_ReturnSum()
        {
            const string input = "1,5";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results,expected);
        }

        [Test]
        public void Given_InputWithManyNumbers_ReturnSum()
        {
            const string input = "1,2,3,4";
            const int expected = 10;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results,expected );
        }


        [Test]
        public void Given_InputWithNewLineInBetweenNumbers_ReturnSum()
        {
            const string input = "1\n2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputWithDelimiterInBetweenNumbers_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }


        [Test]
        public void Given_InputWithNegativeNumber_ThrowException()
        {
            const string input = "-1";
            const string expected = "negatives are not allowed : -1";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
            Assert.AreEqual(results.Message, expected);
        }



        [Test]
        public void Given_InputWithNegativeNumbers_ThrowException()
        {
            const string input = "-1,2,-3";
            const string expected = "negatives are not allowed : -1,-3";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(results.Message, expected);
        }


        [Test]
        public void Given_InputWithNumberGreaterThanThousand_IgnoreValueReturnSum()
        {
            const string input = "1001,3";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }


        [Test]
        public void Given_InputWithNumberNotGreaterThanThousand_ReturnSum()
        {
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputWithDelimitersOfAnyLength_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputWithMultipleDelimiters_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(results, expected);
        }

        [Test]
        public void Given_InputWithMultipleDelimitersOfAnyLength_ReturnSum()
        {
            const string input = "//[*][%][&]\n1*2%3&4";
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