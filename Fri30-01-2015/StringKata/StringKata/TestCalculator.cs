    
using System;
using NUnit.Framework;

namespace StringKata
{
    [TestFixture]
    public class TestCalculator
    {
       
        [Test]
        public void Given_EmptyString_ReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected,results);
        }

        [Test]
        public void Given_SingleNumberInputString_ReturnNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual( expected,results);
        }


        [Test]
        public void Given_LargeSingleNumberInputString_ReturNumber()
        {
            const string input = "111";
            const int expected = 111;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected,results);
        }
        

        [Test]
        public void Given_TwoNumbersInputString_ReturnSum()
        {
            const string input = "1,1";
            const int expected = 2;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual( expected,results);
        }

        [Test]
        public void Given_ManyNumberInputString_ReturnSum()
        {
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected,results);
        }

        [Test]
        public void Given_NumbersWithNewLineInBetweenInputString_ReturnSum()
        {
            const string input = "1\n2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }



        [Test]
        public void Given_NumbersWithDelimiterInBetweenInputString_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithNegativeNumberInputString_ThrowException()
        {
            const string input = "-1";
            const string expected = "Negatives are not allowed : -1";
            var calculator = CreateCalculator();
            var results =Assert.Throws<ApplicationException>(()=> calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_NumbersWithNegativeNumbersInputString_ThrowException()
        {
            const string input = "-1,-2,-3";
            const string expected = "Negatives are not allowed : -1,-2,-3";
            var calculator = CreateCalculator();
            var results = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, results.Message);
        }

        [Test]
        public void Given_NumberGreaterThanThousandInputString_IgnoreValueReturnSum()
        {
            const string input = "1001,3";
            const int expected = 3;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }


        [Test]
        public void Given_NumberNotGreaterThanThousandInputString_ReturnSum()
        {
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithDelimitersInBetweenInputString_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithMulpleDelimitersInBetweenInputString_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void Given_NumbersWithMulpleDelimitersOfAnyLengthInBetweenInputString_ReturnSum()
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