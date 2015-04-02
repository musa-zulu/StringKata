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
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            //---------------Set up test pack-------------------
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        }


        [Test]
        public void Add_GivenSingleNumberString_ShouldReturnSingleNumber()
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
        public void Add_GivenLargeSingleNumberInputString_ShouldReturnSingleNumber()
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
        public void Add_GivenLargeNumbersInputString_ShouldReturnSum()
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
        }

        [Test]
        public void Add_GivenNumbersInputStringWithNewLine_ShouldReturnSum()
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
        }


        [Test]
        public void Add_GivenNumbersInputStringWithCustomDelimiter_ShouldReturnSum()
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
        public void Add_GivenNumbersInputStringWithNegativeNumber_ShouldThrowException()
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
        public void Add_GivenNumbersInputStringWithNegativeNumbers_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            const string input = "-1,-2";
            var negatives = new List<int>  {-1, -2};


            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(negatives, actual.NegativeNumbers);
        }

        [Test]
        public void Add_GivenNumbersInputStringWithNumberGreaterThanThousand_ShouldReturnSum()
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
        public void Add_GivenNumbersInputStringWithNumberNotGreaterThanThousand_ShouldReturnSum()
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
        public void Add_GivenNumbersInputStringWithNumberDelimitersOfLengthGreaterThanOne_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[***]\n1***2***3";
            const int expected =6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersInputStringWithNumberDifferentDelimiters_ShouldReturnSum()
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
        public void Add_GivenNumbersInputStringWithNumberDifferentDelimitersOfAnyLength_ShouldReturnSum()
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
