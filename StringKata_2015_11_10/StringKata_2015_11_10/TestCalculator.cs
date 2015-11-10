using System;
using NUnit.Framework;

namespace StringKata_2015_11_10
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
        public void Add_GivenInputStringWithANegativeNumber_ShouldThrowApplicationExption()
        {
            //---------------Set up test pack-------------------
            var input = "1,-2";
            var expected = "negatives are not allowed : -2";
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut.Message);
        }

        [Test]
        public void Add_GivenInputStringWithCustormDelimiterInBetween_ShouldHandleCustomDelimiterAndReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "//;\n1;2";
            var expected = 3;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenInputStringWithDelimitersOfAnyLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "//[***]\n1***2***3";
            var expected = 6;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenInputStringWithDifferentDelimitersOfAnyLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "//[***][^^%]\n1***2^^%3";
            var expected = 6;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenInputStringWithNegativeNumbers_ShouldThrowApplicationExption()
        {
            //---------------Set up test pack-------------------
            var input = "1,-2,-3";
            var expected = "negatives are not allowed : -2,-3";
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut.Message);
        }

        [Test]
        public void Add_GivenInputStringWithNumberGreaterThanThousand_ShouldIgnoreNumbersGtrThen1000AndReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "1001,3";
            var expected = 3;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenInputStringWithNumberNotGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "1000,3";
            var expected = 1003;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenLargeSingleNumberInputString_ShouldReturnSingleNumber()
        {
            //---------------Set up test pack-------------------
            var input = "120";
            var expected = 120;
            var calculator = new Calculator();
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
            var input = "1,2,3";
            var expected = 6;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenManyNumbersInputStringWithNewLineInBetween_ShouldReplaceNewLineAndReturnSum()
        {
            //---------------Set up test pack-------------------
            var input = "1\n2,3";
            var expected = 6;
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
            var calculator = new Calculator();
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
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }
    }
}