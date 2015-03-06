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
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var calculator = CreateCalculator();
            //---------------Test Result -----------------------
            Assert.IsNotNull(calculator);
        }


        [Test]
        public void Given_EmptyStringInputShould_ReturnZero()
        {
            const int expected = 0;
            const string empty = "";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_SingleStringInputShould_ReturnSingleNumber()
        {
            const int expected = 1;
            const string empty = "1";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_LargeSingleStringInputShould_ReturnSingleNumber()
        {
            const int expected = 120;
            const string empty = "120";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_TwoNumbersStringInputShould_ReturnSum()
        {
            const int expected = 3;
            const string empty = "1,2";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_ManyNumbersStringInputShould_ReturnSum()
        {
            const int expected = 15;
            const string empty = "1,2,3,4,5";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_StringInputWithNewLineShould_ReturnSum()
        {
            const int expected = 15;
            const string empty = "1\n2,3,4,5";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Given_StringInputWithCustomDelimiterShould_ReturnSum()
        {
            const int expected = 3;
            const string empty = "//;\n1;2";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_StringInputWithANegativeNumberShould_ThrowException()
        {
            const string negativeNumber = "-1";
            var stringCalculator = CreateCalculator();
            Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add(negativeNumber));
        }



        [Test]
        public void Given_StringInputWithSingleNegativeNumberShould_ThrowException()
        {
            var expected = new List<int> { -2 };
            const string negativeNumber = "-2";
            var stringCalculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add(negativeNumber));

            CollectionAssert.AreEqual(expected, actual.NegativeNumbers);
        }


        [Test]
        public void Given_StringInputWithMultipleNegativeNumberShould_ThrowException()
        {
            var expected = new List<int> { -2,-1 };
            const string negativeNumber = "-2,-1";
            var stringCalculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add(negativeNumber));

            CollectionAssert.AreEqual(expected, actual.NegativeNumbers);
        }

        [Test]
        public void Given_StringInputWithValueGreaterThanThousandShould_ReturnSum()
        {
            const int expected = 15;
            const string empty = "1001,15";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_StringInputWithValueNotGreaterThanThousandShould_ReturnSum()
        {
            const int expected = 1015;
            const string empty = "1000,15";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_StringInputWithDelimitersLongerThanOne_ShouldReturnSum()
        {
            const int expected = 6;
            const string empty = "//[***]\n1***2***3";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Given_StringInputWithDelimitersLongerThanOneAndMixed_ShouldReturnSum()
        {
            const int expected = 6;
            const string empty = "//[*][%]\n1*2%3";
            var stringCalculator = CreateCalculator();
            var actual = stringCalculator.Add(empty);
            Assert.AreEqual(expected, actual);
        }
    }
}
