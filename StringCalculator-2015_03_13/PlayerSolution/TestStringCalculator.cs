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
        public void Add_GivenEmptyStringInput_ShouldReturnZero()
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
        public void Add_GivenSingleValueInput_ShouldReturnSingleValue()
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
        public void Add_GivenLargeSingleValueInput_ShouldReturnLargeSingleValue()
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
        }


        [Test]
        public void Add_GivenManyNumbersInputStringWithNewLineInBetweeen_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2\n3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Add_GivenManyNumbersInputStringWithCustomDelimiterInBetweeen_ShouldReturnSum()
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
        public void Add_GivenInputStringWithANegativeNumber_ShouldThrowException()
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
       public void Add_GivenInputStringWithNegativeNumber_ShouldThrowException()
       {
           //---------------Set up test pack-------------------
           const string input = "-1";
           var expected = new List<int> { -1 };
           var calculator = CreateCalculator();
           //---------------Assert Precondition----------------

           //---------------Execute Test ----------------------
           var actual = Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));
           //---------------Test Result -----------------------
           CollectionAssert.AreEqual(expected, actual.NegativeNumbers);
          
       }

       [Test]
       public void Add_GivenInputStringWithNegativeNumbers_ShouldThrowException()
       {
           //---------------Set up test pack-------------------
           const string input = "-1,-2";
           var expected = new List<int> { -1,-2 };
           var calculator = CreateCalculator();
           //---------------Assert Precondition----------------

           //---------------Execute Test ----------------------
           var actual = Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));
           //---------------Test Result -----------------------
           CollectionAssert.AreEqual(expected, actual.NegativeNumbers);

       }

       [Test]
       public void Given_StringInputWithValueGreaterThanThousandShould_ReturnSum()
       {
           //---------------Set up test pack-------------------
           const int expected = 15;
           const string empty = "1001,15";
           var stringCalculator = CreateCalculator();
           //---------------Assert Precondition----------------
           //---------------Execute Test ----------------------
           var actual = stringCalculator.Add(empty);
           //---------------Test Result -----------------------
           Assert.AreEqual(expected, actual);
       }

       [Test]
       public void Given_StringInputWithValueNotGreaterThanThousandShould_ReturnSum()
       {
           //---------------Set up test pack-------------------
           const int expected = 1015;
           const string empty = "1000,15";
           var stringCalculator = CreateCalculator();
           //---------------Assert Precondition----------------
           //---------------Execute Test ----------------------
           var actual = stringCalculator.Add(empty);
           //---------------Test Result -----------------------
           Assert.AreEqual(expected, actual);
       }

       [Test]
       public void Given_StringInputWithDelimitersLongerThanOne_ShouldReturnSum()
       {
           //---------------Set up test pack-------------------
           const int expected = 6;
           const string empty = "//[***]\n1***2***3";
           var stringCalculator = CreateCalculator();
           //---------------Assert Precondition----------------
           //---------------Execute Test ----------------------
           var actual = stringCalculator.Add(empty);
           //---------------Test Result -----------------------
           Assert.AreEqual(expected, actual);
       }


       [Test]
       public void Given_StringInputWithDelimitersLongerThanOneAndMixed_ShouldReturnSum()
       {
           //---------------Set up test pack-------------------
           const int expected = 6;
           const string empty = "//[*][%]\n1*2%3";
           var stringCalculator = CreateCalculator();
           //---------------Assert Precondition----------------
           //---------------Execute Test ----------------------
           var actual = stringCalculator.Add(empty);
           //---------------Test Result -----------------------
           Assert.AreEqual(expected, actual);
       }


    }
}
