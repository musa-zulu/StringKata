
using System;
using NUnit.Framework;

namespace CalculatorKata
{
    [TestFixture]
    public class TestCalculator
    {
        [Test]
        public void Given_EmptyInputString_ShouldReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithSingleValue_ShouldReturnSingleValue()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputStringWithLargeSingleValue_ShouldReturnSingleValue()
        {
            const string input = "221";
            const int expected = 221;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithTwoValues_ShouldReturnSum()
        {
            const string input = "1,2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithManyValues_ShouldReturnSum()
        {
            const string input = "1,2,3,4,5";
            const int expected = 15;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNewLineInBetweenValues_ShouldReturnSum()
        {
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_InputStringWithDelimiterInBetweenValues_ShouldReturnSum()
        {
            const string input = "//;\n2;2";
            const int expected = 4;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_InputStringWithNegativeValue_ShouldThrowException()
        {
            const string input = "-1,2";
            const string expected = "negatives are not allowed : -1";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_InputStringWithNegativeValues_ShouldThrowException()
        {
            const string input = "-1,2,-3,-4";
            const string expected = "negatives are not allowed : -1,-3,-4";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            Assert.AreEqual(expected, results.Message);
        }


        [Test]
        public void Given_InputStringWithValueGreaterThanThousand_ShouldIgnoreValueReturnSum()
        {
            const string input = "1001,2";
            const int expected = 2;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }
        [Test]
        public void Given_InputStringWithValueNotGreaterThanThousand_ShouldReturnSum()
        {
            const string input = "1000,2";
            const int expected = 1002;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }
       [Test]
        public void Given_InputStringWithDelimitersOfAnyLengthInBetweenValues_ShouldReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);

            Assert.AreEqual(expected, results);
        }


       [Test]
       public void Given_InputStringWithMultipleDelimitersInBetweenValues_ShouldReturnSum()
       {
           const string input = "//[*][%]\n1*2%3";
           const int expected = 6;
           var calculator = CreateCalculator();
           var results = calculator.Add(input);

           Assert.AreEqual(expected, results);
       }

       [Test]
       public void Given_InputStringWithMultipleDelimitersWithLengthLongerThanOneCharInBetweenValues_ShouldReturnSum()
       {
           const string input = "//[*][%][&][$]\n1*2%3&4$5";
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