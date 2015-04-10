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
        public void Add_GivenEmptyStringInput_ShouldReturnZero()
        {
            //---------------Araange-------------------
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenSingleStringInput_ShouldReturnSingleNumber()
        {
            //---------------Araange-------------------
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenLargeSingleStringInput_ShouldReturnSingleNumber()
        {
            //---------------Araange-------------------
            const string input = "120";
            const int expected = 120;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenTwoNumbersStringInput_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "1,2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenManyNumbersStringInput_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersStringInputWithNewLine_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersStringInputWithCustormDelimiter_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersStringInputWithNegativeNumber_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "-1";
            var expected = new List<int>{-1};
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));
            //---------------Assert----------------------
           CollectionAssert.AreEqual(actual.NegativeNumbers, expected);
        }

        [Test]
        public void Add_GivenNumbersStringInputWithNegativeNumbers_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "-1,-2,-3";
            var expected = new List<int> { -1,-2,-3 };
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));
            //---------------Assert----------------------
            CollectionAssert.AreEqual(actual.NegativeNumbers, expected);
        }

        [Test]
        public void Add_GivenNumbersStringInputWithNumberGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "1001,3";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersStringInputWithNumberNotGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersStringInputWithCustormDelimitersWithLengthGreaterThanOne_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersStringInputWithCustormDifferentDelimiters_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersStringInputWithCustormDifferentDelimitersWithLengthLongerThanOneChar_ShouldReturnSum()
        {
            //---------------Araange-------------------
            const string input = "//[*][%%%]\n1*2%%%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Act----------------
            var actual = calculator.Add(input);
            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }
    }
}
