using System;
using System.Collections.Generic;
using Engine;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;

namespace PlayerStringKata
{
    public class TestStringCalculator : ITestPack<IStringCalculator>
    {
        public Func<IStringCalculator> CreateSUT { get; set; }

        [SetUp]
        public void SetupTest()
        {
            CreateSUT = () => new StringCalculator();
        }

        private IStringCalculator CreateCalculator()
        {
            return CreateSUT();
        }

        /// <summary>
        /// This is a sample test that shows how the StringCalculator 
        /// should be created in future tests. 
        /// </summary>
        [Test]
        public void Constructor()
        {
            //---------------Arrange-------------------

            //---------------Act----------------------
            var calculator = CreateCalculator();
            //---------------Assert-----------------------
            Assert.IsNotNull(calculator);
        }

        [Test]
        public void Add_GivenEmptyInputString_ShouldReturnZero()
        {
            //---------------Set up test pack-------------------
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Add_GivenSingleInputString_ShouldReturnSingleNumber()
        {
            //---------------Set up test pack-------------------
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Add_GivenLargeSingleInputString_ShouldReturnSingleNumber()
        {
            //---------------Set up test pack-------------------
            const string input = "120";
            const int expected = 120;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Add_GivenTwoNumbersInputString_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Add_GivenManyNumbersInputString_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        } [Test]
        public void Add_GivenManyNumbersInputStringWithNewLine_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }[Test]
        public void Add_GivenManyNumbersInputStringWithCustomDelimiter_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }[Test]
        public void Add_GivenManyNumbersInputStringWithNegativeNumber_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            const string input = "-1";
            var expected = new List<int>{-1};
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = Assert.Throws<NegativesNotAllowedException>(()=>calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual.NegativeNumbers);
        }[Test]
        public void Add_GivenManyNumbersInputStringWithNegativeNumbers_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            const string input = "-1,-2";
            var expected = new List<int>{-1,-2};
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = Assert.Throws<NegativesNotAllowedException>(()=>calculator.Add(input));
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(expected, actual.NegativeNumbers);
        }

        [Test]
        public void Add_GivenManyNumbersInputStringWithNumberGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1006,6";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        } [Test]
        public void Add_GivenManyNumbersInputStringWithNumberNotGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1000,6";
            const int expected = 1006;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenManyNumbersInputStringWithCustomDelimiterOFAnyLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }[Test]
        public void Add_GivenManyNumbersInputStringWithDifferentCustomDelimiterOFAnyLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[*][%^^&]\n1*2%^^&3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
    }
}
