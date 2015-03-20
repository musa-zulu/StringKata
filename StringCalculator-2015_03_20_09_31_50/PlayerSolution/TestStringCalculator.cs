using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void Add_GivenEmptyStringInput_ShouldReturnZero()
        {
            //---------------Set up test pack-------------------
            const string input = "";
            const int expected = 0;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }


        [Test]
        public void Add_GivenSingleValue_ShouldReturnSingleValue()
        {
            //---------------Set up test pack-------------------
            const string input = "1";
            const int expected = 1;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_GivenLargeSingleValue_ShouldReturnSingleValue()
        {
            //---------------Set up test pack-------------------
            const string input = "120";
            const int expected = 120;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }


        [Test]
        public void Add_GivenTwoNumbersSeparatedByComma_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2";
            const int expected = 3;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_GivenManyNumbersSeparatedByComma_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2,3,4";
            const int expected = 10;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }


        [Test]
        public void Add_GivenManyNumbersWithNewLineInBetween_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2,3\n4";
            const int expected = 10;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }


        [Test]
        public void Add_GivenNumbersWithCustomDelimiterInBetween_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//;\n1;2";
            const int expected = 3;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_GivenNumbersWithNegativeNumber_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            const string input = "-1";

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));
        }

        [Test]
        public void Add_GivenNumbersWithANegativeNumber_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var expected = new List<int> { -2 };
            const string negativeNumber = "-2";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var stringCalculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add(negativeNumber));
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(expected, actual.NegativeNumbers);
        }

        [Test]
        public void Add_GivenNumbersWithNegativeNumbers_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var expected = new List<int> { -1,-2,-3 };
            const string negativeNumber = "-1,-2,-3";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var stringCalculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add(negativeNumber));
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(expected, actual.NegativeNumbers);
        }



        [Test]
        public void Add_GivenNumbersWithNumberGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1001,3";
            const int expected = 3;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_GivenNumbersWithNumberNotGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1000,3";
            const int expected = 1003;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_GivenNumbersWithDelimitersOfLengthGreaterThanOne_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Add_GivenNumbersWithDelimitersOfAnyLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[*][%%%%]\n1*2%%%%3";
            const int expected = 6;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(actual, expected);
        }
    }
}
