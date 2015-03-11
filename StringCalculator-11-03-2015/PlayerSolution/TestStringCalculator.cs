using System;
using System.Collections.Generic;
using System.Security.Claims;
using Engine;
using Katarai.StringCalculator.Interfaces;
using Microsoft.SqlServer.Server;
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
        public void Add_GivenEmptyInputString_ShouldReturnZero()
        {
            //---------------Set up test pack-------------------
            const string input = "";
            const int actual = 0;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);
        }

        [Test]
        public void Add_GivenSingleInputString_ShouldReturnSingleNumber()
        {
            //---------------Set up test pack-------------------
            const string input = "1";
            const int actual = 1;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);

        }

        [Test]
        public void Add_GivenLargeSingleInput_ShouldReturnLargeSingleInput()
        {
            //---------------Set up test pack-------------------
            const string input = "150";
            const int actual = 150;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);
        }

        [Test]
        public void Add_GivenTwoNumbersStringInput_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2";
            const int actual = 3;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);
        }

        [Test]
        public void Add_GivenManyNumbersStringInput_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2,3";
            const int actual = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);
        }

        [Test]
        public void Add_GivenManyNumbersStringInputWithNewLine_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2\n3";
            const int actual = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);
        }

        [Test]
        public void Add_GivenManyNumbersStringInputWithSingleCustomDelimiter_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//;\n1;2;3";
            const int actual = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);
        }

        [Test]
        public void Add_GivenAnyNegativeNumber_ShouldThrowAnException()
        {
            //---------------Set up test pack-------------------
            const string negativeNumber = "-1";
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------

            //---------------Test Result -----------------------
            Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(negativeNumber));
        }

        [Test]
        public void Add_GivenANegativeNumber_ShouldThrowAnException()
        {
            //---------------Set up test pack-------------------
            var expected = new List<int> { -2 };
            const string negativeNumber = "-2";
            var stringCalculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add(negativeNumber));
            //---------------Test Result -----------------------

            CollectionAssert.AreEqual(expected, actual.NegativeNumbers);
        }


        [Test]
        public void Add_GivenMAnyNegativeNumbers_ShouldThrowAnException()
        {
            //---------------Set up test pack-------------------
            var expected = new List<int> { -1,-2,-3 };
            const string negativeNumber = "-1,-2,-3";
            var stringCalculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = Assert.Throws<NegativesNotAllowedException>(() => stringCalculator.Add(negativeNumber));
            //---------------Test Result -----------------------

            CollectionAssert.AreEqual(expected, actual.NegativeNumbers);
        }

        [Test]
        public void Add_GivenStringInputWithNumberGreaterThanThousand_ShouldIgnoreValueAndReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1001,2";
            const int actual = 2;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);
        }

        [Test]
        public void Add_GivenStringInputWithNumberNotGreaterThanThousand_ShouldIgnoreValueAndReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1000,2";
            const int actual = 1002;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);
        }

        [Test]
        public void Add_GivenStringInputWithCustomDelimitersOfLengthLongerThanOne_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[***]\n1***2***3";
            const int actual = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);
        }

        [Test]
        public void Add_GivenStringInputWithMultipleCustomDelimitersOfAnyLength_ShouldReturnSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//[*][%]\n1*2%3";
            const int actual = 6;
            var calculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var results = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(results, actual);
        }
    }
}
