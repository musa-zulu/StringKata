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
        public void Add_GivenEmptyInput_ShouldReturnZero()
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
        public void Add_GivenSingleNumberInput_ShouldReturnSingleNumber()
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
        public void Add_GivenLargeSingleNumberInput_ShouldReturnSingleNumber()
        {
            //---------------Set up test pack-------------------
            const string input = "150";
            const int expected = 150;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);

            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenTwoNumbersInput_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,5";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);

            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenManyNumbersInput_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2,5";
            const int expected = 8;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);

            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Add_GivenNumbersInputWithNewLine_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1\n2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);

            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersInputWithCustomDelimiter_ShouldReturnSum()
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
        }

        [Test]
        public void Add_GivenNumbersInputWithNegativeNumber_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            const string input = "-1";
            
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
           

            //---------------Test Result -----------------------
            Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));
        }


        [Test]
        public void Add_GivenNumbersInputWithNegativeNumbers_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            const string input = "-1,-2";
            var negatives = new List<int> {-1,-2};
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            var actual = Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));
            //---------------Test Result -----------------------
         CollectionAssert.AreEqual(negatives,actual.NegativeNumbers);
        }

        [Test]
        public void Add_GivenNumbersInputWithValueGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1001,3";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);

            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersInputWithValueNotGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);

            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Add_GivenNumbersInputWithCustomDelimiterOfLengthGreaterThanOne_ShouldReturnSum()
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
        }

        [Test]
        public void Add_GivenNumbersInputWithMultipleDelimiter_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);

            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersInputWithMultipleDelimitersOfAnyLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[*][%%%]\n1*2%%%3";
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
