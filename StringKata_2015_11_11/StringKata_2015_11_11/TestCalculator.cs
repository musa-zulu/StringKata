using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringKata_2015_11_11
{
    [TestFixture]
    public class TestCalculator
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
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
            var calculator = new Calculator();
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
        public void Add_GivenNumbersInputStringWithCustormDelimiter_ShouldReplaceHandleCustormDelimiterAndReturnSum()
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
        public void Add_GivenNumbersInputStringWithANegativeNumber_ShouldthrowApplicationExcepton()
        {
            //---------------Set up test pack-------------------
            var input = "-1";
            var expected = "negatives not allowed : -1";
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut.Message);
        }

        [Test]
        public void Add_GivenNumbersInputStringWithManyNegativeNumber_ShouldthrowApplicationException()
        {
            //---------------Set up test pack-------------------
            var input = "-1,-2";
            var expected = "negatives not allowed : -1,-2";
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut.Message);
        }

        [Test]
        public void Add_GivenNumbersInputStringWithANumberGreaterThanThousand_ShouldIgnoreValueAndRetunSum()
        {
            //---------------Set up test pack-------------------
            var input = "1001,2";
            var expected = 2;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenNumbersInputStringWithNumberNotGreaterThanThousand_ShouldRetunSum()
        {
            //---------------Set up test pack-------------------
            var input = "1000,2";
            var expected = 1002;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void Add_GivenNumbersInputStringWithDelimitersOfAnyLength_ShouldRetunSum()
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
        public void Add_GivenNumbersInputStringWithDifferentDelimitersOfAnyLength_ShouldRetunSum()
        {
            //---------------Set up test pack-------------------
            var input = "//[*$$$][%]\n1*$$$2%3";
            var expected = 6;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var sut = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sut);
        }
    }
}
