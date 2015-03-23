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
            //---------------Set up test pack-------------------
            const string input = "";
            const int expected = 0;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenSingleInput_ShouldReturnSingleNumber()
        {
            //---------------Set up test pack-------------------
            const string input = "1";
            const int expected = 1;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenLargeSingleInput_ShouldReturnLargeSingleNumber()
        {
            //---------------Set up test pack-------------------
            const string input = "1";
            const int expected = 1;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenTwoNumbers_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2";
            const int expected = 3;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Add_GivenManyNumbers_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2,3";
            const int expected = 6;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNumbersWithNewLineInBetween_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1\n2,3";
            const int expected = 6;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Add_GivenNumbersWithCustomDelimiterInBetween_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//;\n1;2";
            const int expected = 3;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

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
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));

        }

        [Test]
        public void Add_GivenStringInputWithNegativeNumbers_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var expected = new List<int> { -1, -2 };
            const string negativeNumber = "-1,-2";
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var stringCalculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add(negativeNumber));
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(expected, actual.NegativeNumbers);
        }

        [Test]
        public void Add_GivenStringInputWithNumberGreaterThanThousand_ShouldIgnoreValueAndReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1001,3";
            const int expected = 3;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenStringInputWithNumberNotGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1000,3";
            const int expected = 1003;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenStringInputWithDelimitersOfLengthGreaterThanOne_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

     
        [Test]
        public void Add_GivenStringInputWithDifferentDelimiters_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenStringInputWithDifferentDelimitersOfAnyLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[*][%][&]\n1*2%3&4";
            const int expected = 10;
            //---------------Assert Precondition----------------

            //---------------Act----------------------
            var calculator = CreateCalculator();

            //---------------Execute Test ----------------------
            var actual = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, actual);
        }
    }
}
