
using System;
using NUnit.Framework;

namespace StringKataCalculator
{
    [TestFixture]
    public class TestCalculator
    {
        // ReSharper disable InconsistentNaming
        [Test]
        public void Given_EmptyInputStringShould_ReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_SingleInputStringShould_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_LargeSingleInputStringShould_ReturnSingleNumber()
        {
            const string input = "110";
            const int expected = 110;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Given_TwoNumberInputStringShould_ReturnSingleNumber()
        {
            const string input = "1,2";
            const int expected = 3;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_ManyNumbersInputStringShould_ReturnSingleNumber()
        {
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Given_NumbersInputStringWithNewLineInBetweenShould_ReturnSingleNumber()
        {
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithSingleCustormDelimiterInBetweenShould_ReturnSingleNumber()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Given_NumbersInputStringWithANegativeNumberInBetweenShould_ReturnSingleNumber()
        {
            const string input = "-1";
            const string expected = "negatives not allowed: -1";
            var calculator = new Calculator();
            var actual = Assert.Throws<ApplicationException>(()=>calculator.Add(input));
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Given_NumbersInputStringWithNegativeNumbersInBetweenShould_ReturnSingleNumber()
        {
            const string input = "-1,2,-3";
            const string expected = "negatives not allowed: -1,-3";
            var calculator = new Calculator();
            var actual = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.AreEqual(expected, actual.Message);
        }


        [Test]
        public void Given_NumbersInputStringWithValueGreaterThanThousandInBetweenShould_ReturnSingleNumber()
        {
            const string input = "1001,3";
            const int expected = 3;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Given_NumbersInputStringWithValueNotGreaterThanThousandInBetweenShould_ReturnSingleNumber()
        {
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithDelimitersOfAnyLengthInBetweenShould_ReturnSingleNumber()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Given_NumbersInputStringWithMultipleDelimitersInBetweenShould_ReturnSingleNumber()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Given_NumbersInputStringWithMultipleDelimitersOfAnyLengthInBetweenShould_ReturnSingleNumber()
        {
            const string input = "//[*][%][$]\n1*2%3$4";
            const int expected = 10;
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }


    }
}