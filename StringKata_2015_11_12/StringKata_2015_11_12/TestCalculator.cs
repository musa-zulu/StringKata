using System;
using NUnit.Framework;

namespace StringKata_2015_11_12
{
    [TestFixture]
    public class TestCalculator
    {
        [Test]
        public void Add_GivenEmptyInputString_ShouldReturnZero()
        {
            //---------------Set up test pack-------------------
            var input = "";
            var expected = 0;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenSingleNumberInputString_ShouldReturnSingleNumber()
        {
            //---------------Set up test pack-------------------
            var input = "1";
            var expected = 1;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenLargeSingleNumberInputString_ShouldReturnLargeSingleNumber()
        {
            //---------------Set up test pack-------------------
            var input = "120";
            var expected = 120;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenTwoNumbersInputString_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "1,2";
            var expected = 3;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenManyNumbersInputString_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "1,2,6";
            var expected = 9;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenManyNumbersWithNewLineInBetween_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "1\n2,6";
            var expected = 9;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenNumbersWithCustomDelimiterInBetween_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "//;\n1;2";
            var expected = 3;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var input = "-1";
            var expected = "negative numbers are not allowed : -1";
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut.Message);
        }

        [Test]
        public void Add_GivenManyNegativeNumbers_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var input = "-1,2,-3";
            var expected = "negative numbers are not allowed : -1,-3";
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut.Message);
        }

        [Test]
        public void Add_GivenNumberGreaterThanThousand_ShouldIgnoreNumberAndReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "1001,1";
            var expected = 1;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut =calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenNumberNotGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "1000,1";
            var expected = 1001;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenNumbersWithDelimitersOfAnyLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "//[***]\n1***2***3";
            var expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenNumbersWithDifferentDelimitersOfAnyLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "//[*%%^][%##@]\n1*%%^2%##@3";
            var expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        private static Calculator CreateCalculator()
        {
            return new Calculator();
        }
    }
}