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
            const int expected = 0;
            const string empty = "";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_SingleStringInputShouldReturn_Single()
        {
            const int expected = 1;
            const string empty = "1";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Given_LargeSingleStringInputShouldReturn_Single()
        {
            const int expected = 120;
            const string empty = "120";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_TwoStringInputShouldReturn_Sum()
        {
            const int expected = 3;
            const string empty = "1,2";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }
     
        [Test]
        public void Given_ManyStringInputShouldReturn_Sum()
        {
            const int expected = 6;
            const string empty = "1,2,3";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Given_StringInputWithNewLineShouldReturn_Sum()
        {
            const int expected = 3;
            const string empty = "//;\n1;2";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_StringInputWithSingleCustomDelimiterShouldReturn_Sum()
        {
            const int expected = 6;
            const string empty = "1\n2,3";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

       [Test]
        public void Given_StringInputWithNegativeNumberShouldReturn_ThrowException()
        {
            const string expected = "negatives not allowed: -1";
            const string empty = "-1,2";
            var stringCalculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(()=>stringCalculator.Add(empty));
            Assert.AreEqual(expected, actual.Message);
        }

       [Test]
       public void Given_StringInputWithNegativeNumbersShouldReturn_ThrowException()
       {
           const string expected = "negatives not allowed: -1,-2";
           const string empty = "-1,-2";
           var stringCalculator = CreateCalculator();
           var actual = Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add(empty));
           Assert.AreEqual(expected, actual.Message);
       }

       [Test]
       public void Given_StringInputWithNumberGreaterThen1000ShouldReturn_Sum()
       {
           const int expected = 6;
           const string empty = "1001,6";
           var stringCalculator = CreateCalculator();
           var actual = stringCalculator.Add(empty);
           Assert.AreEqual(expected, actual);
       }

       [Test]
       public void Given_StringInputWithNumberNotGreaterThen1000ShouldReturn_Sum()
       {
           const int expected = 1006;
           const string empty = "1000,6";
           var stringCalculator = CreateCalculator();
           var actual = stringCalculator.Add(empty);
           Assert.AreEqual(expected, actual);
       }

       [Test]
       public void Given_StringInputWithCustomDelimitersOfAnyLengthShouldReturn_Sum()
       {
           const int expected = 6;
           const string empty = "//[***]\n1***2***3";
           var stringCalculator = CreateCalculator();
           var actual = stringCalculator.Add(empty);
           Assert.AreEqual(expected, actual);
       }

       [Test]
       public void Given_StringInputWithManyCustomDelimitersOfAnyLengthShouldReturn_Sum()
       {
           const int expected = 6;
           const string empty = "//[*][%]\n1*2%3";
           var stringCalculator = CreateCalculator();
           var actual = stringCalculator.Add(empty);
           Assert.AreEqual(expected, actual);
       }
        
    }
}
