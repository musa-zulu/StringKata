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
        public void Given_EmptyStringInputShouldReturn_Zero()
        {
            const string empty = "";
            const int expected = 0;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_SingleStringInputShouldReturn_SingleNumber()
        {
            const string empty = "1";
            const int expected = 1;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_LargeSingleStringInputShouldReturn_SingleNumber()
        {
            const string empty = "120";
            const int expected = 120;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_TwoNumbersStringInputShouldReturn_Sum()
        {
            const string empty = "1,2";
            const int expected = 3;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_ManyNumbersStringInputShouldReturn_Sum()
        {
            const string empty = "1,2,3";
            const int expected = 6;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Given_NewLineInBetweenStringInputShouldReturn_Sum()
        {
            const string empty = "1\n2,3";
            const int expected = 6;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersWithSingleCustomDelimiterInBetweenStringInputShouldReturn_Sum()
        {
            const string empty = "//;\n1;2";
            const int expected = 3;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersWithSingleANegativeNumberInBetweenStringInputShouldReturn_ThrowException()
        {
            const string empty = "1,2,-3";
            const string expected = "negatives not allowed: -3";
            var stringCalculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(()=>stringCalculator.Add(empty));
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Given_NumbersWithMultipleNegativeNumbersShouldReturn_ThrowException()
        {
            const string empty = "1,-2,-3";
            const string expected = "negatives not allowed: -2,-3";
            var stringCalculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add(empty));
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Given_NumbersStringInputWithValueGreaterThanThousandShouldReturn_Sum()
        {
            const string empty = "1001,6";
            const int expected = 6;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersStringInputWithValueNotGreaterThanThousandShouldReturn_Sum()
        {
            const string empty = "1000,6";
            const int expected = 1006;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersStringInputWithDelimitersOfLengthLongerThanOneShouldReturn_Sum()
        {
            const string empty = "//[***]\n1***2***3";
            const int expected = 6;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersStringInputWithMultipleDelimitersOfLengthLongerThanOneShouldReturn_Sum()
        {
            const string empty = "//[*][%][^^]\n1*2%3^^4";
            const int expected = 10;
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }
    }
}
