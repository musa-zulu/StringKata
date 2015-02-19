using System;
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
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            Assert.IsNotNull(calculator);
        }

        [Test]
        public void Given_EmptyInputStringShould_ReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Given_SingleNumberInputStringShould_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_LargeSingleNumberInputStringShould_ReturnSingleNumber()
        {
            const string input = "150";
            const int expected = 150;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_TwoNumbersInputStringShould_ReturnSum()
        {
            const string input = "1,5";
            const int expected = 6;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_ManyNumbersInputStringShould_ReturnSum()
        {
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithNewLineInBetweenShould_ReturnSum()
        {
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithSingleCustormDelimiterShould_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Given_NumbersInputStringWithASingleNegativeNumberShould_ThrowException()
        {
            const string input = "-1";
            const string expected = "negatives not allowed: -1";
            var calculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(()=>calculator.Add(input));
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Given_NumbersInputStringWithManyNegativeNumberShould_ThrowException()
        {
            const string input = "-1,-2";
            const string expected = "negatives not allowed: -1,-2";
            var calculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Given_NumbersInputStringWithNumberGreaterThanThousandShould_ReturnSum()
        {
            const string input = "1001,2";
            const int expected = 2;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithNumberNotGreaterThanThousandShould_ReturnSum()
        {
            const string input = "1000,2";
            const int expected = 1002;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithDelimitersOfAnyLengthShould_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithMultipleDelimitersShould_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithMultipleDelimitersOfAnyLengthShould_ReturnSum()
        {
            const string input = "//[*][%][^]\n1*2%3^4";
            const int expected = 10;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
