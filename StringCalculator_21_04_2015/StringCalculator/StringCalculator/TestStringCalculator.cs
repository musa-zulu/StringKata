
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class TestStringCalculator
    {

        [Test]
        public void Add_EmptyStringInput_ShouldReturnZero()
        {
            //---------------Arrange-------------------
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_SingleNumberStringInput_ShouldReturnSingleNumber()
        {
            //---------------Arrange-------------------
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Add_LargeSingleNumberStringInput_ShouldReturnSingleNumber()
        {
            //---------------Arrange-------------------
            const string input = "120";
            const int expected = 120;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_TwoNumberStringInput_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            const string input = "1,2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Add_ManyNumberStringInput_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_ManyNumberStringInputWithNewLine_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Add_ManyNumberStringInputWithCustomDelimiter_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_NumberStringInputWithSingleNegativeNumber_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            const string input = "-1";
            const string expected = "negatives are not allowed: -1";
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = Assert.Throws<ApplicationException>(()=>calculator.Add(input));

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_NumberStringInputWithNegativeNumbers_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            const string input = "-1,-2,-3";
            const string expected = "negatives are not allowed: -1,-2,-3";
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_NumberStringInputWithNumberGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            const string input = "1001,3";
            const int expected = 3;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Add_NumberStringInputWithNumberNotGreaterThanThousand_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_ManyNumberStringInputWithCustomDelimitersOfAnyLength_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Add_ManyNumberStringInputWithDifferentCustomDelimitersOfAnyLength_ShouldReturnSum()
        {
            //---------------Arrange-------------------
            const string input = "//[*][&%]\n1*2&%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //----------------Act---------------------
            var actual = calculator.Add(input);

            //---------------Assert----------------------
            Assert.AreEqual(expected, actual);
        }
        private static Calculator CreateCalculator()
        {
            return new Calculator();
        }
    }
}