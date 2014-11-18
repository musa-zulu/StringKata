    
using System;
using NUnit.Framework;

namespace StringKata
{
    [TestFixture]
    public class TestCalculator
    {
        // ReSharper disable InconsistentNaming
        [Test]
        public void Given_EmptyString_ReturnZero()
        {
            //------------------- Set up ---------------------
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected,resuls);
        }

        [Test]
        public void Given_StringWithASingleValue_ReturnValue()
        {
            //------------------- Set up ---------------------
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }

        [Test]
        public void Given_StringWithABigValueLessThanThousand_ReturnBigValueLessThanThousand()
        {
            //------------------- Set up ---------------------
            const string input = "111";
            const int expected = 111;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }

        [Test]
        public void Given_StringWithTwoValues_ReturnSum()
        {
            //------------------- Set up ---------------------
            const string input = "1,2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }
        
        [Test]
        public void Given_StringWithMultipleValues_ReturnSum()
        {
            //------------------- Set up ---------------------
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }


        [Test]
        public void Given_StringWithNewLineInBetweenValues_ReturnSum()
        {
            //------------------- Set up ---------------------
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }
   
        [Test]
        public void Given_StringWithDifferentDelimitersInBetweenValues_ReturnSum()
        {
            //------------------- Set up ---------------------
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }

      
        [Test]
        public void Given_StringWithASingleNegativeValues_ThrowsException()
        {
            //------------------- Set up ---------------------
            const string input = "-1";
            const string expected = "negatives not allowed : -1";
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls.Message);
        }


        [Test]
        public void Given_StringWithMultipleNegativeValues_ThrowsException()
        {
            //------------------- Set up ---------------------
            const string input = "1,-2,3,-3";
            const string expected = "negatives not allowed : -2-3";
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls.Message);
        }

        [Test]
        public void Given_StringWithValuesUpToThousand_ReturnSum()
        {
            //------------------- Set up ---------------------
            const string input = "1000,1";
            const int expected = 1001;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }


        [Test]
        public void Given_StringWithValuesGreaterThanThousand_ReturnSum()
        {
            //------------------- Set up ---------------------
            const string input = "1001,2";
            const int expected = 2;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }

        [Test]
        public void Given_StringWithDelimitersOfAnyLength_ReturnSum()
        {
            //------------------- Set up ---------------------
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }


        [Test]
        public void Given_StringWithDifferentDelimiters_ReturnSum()
        {
            //------------------- Set up ---------------------
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }


        [Test]
        public void Given_StringWithDifferentDelimitersOfAnyLength_ReturnSum()
        {
            //------------------- Set up ---------------------
            const string input = "//[*][*%%]\n1%%*2%******3";
            const int expected = 6;
            var calculator = CreateCalculator();
            //---------------------Act-------------------------
            var resuls = calculator.Add(input);
            //------------------ Assert -----------------------
            Assert.AreEqual(expected, resuls);
        }

        private static Calculator CreateCalculator()
        {
            return new Calculator();
        }
    }

}