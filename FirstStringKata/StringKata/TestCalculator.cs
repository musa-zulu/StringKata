    
using System;
using NUnit.Framework;

namespace StringKata
{
    [TestFixture]
    public class TestCalculator
    {
     
        [Test]
        public void Given_EmptyInputString_ShouldReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

           Assert.AreEqual(expected,actualResults);

        }

        [Test]
        public void Given_InputStringWithSingleValue_ShouldReturnSingleValue()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

            Assert.AreEqual(expected, actualResults);

        }

        [Test]
        public void Given_InputStringWithLargeSingleValue_ShouldReturnLargeSingleValue()
        {
            const string input = "865";
            const int expected = 865;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

            Assert.AreEqual(expected, actualResults);
        }

        [Test]
        public void Given_InputStringWithTwoValues_ShouldReturnSum()
        {
            const string input = "1,2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

            Assert.AreEqual(expected, actualResults);
        }



        [Test]
        public void Given_InputStringWithMayValues_ShouldReturnSum()
        {
            const string input = "1,2,3,5";
            const int expected = 11;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

            Assert.AreEqual(expected, actualResults);
        }



        [Test]
        public void Given_InputStringWithNewLineInBetweenValues_ShouldReturnSum()
        {
            const string input = "1\n2,5";
            const int expected = 8;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

            Assert.AreEqual(expected, actualResults);
        }


        [Test]
        public void Given_InputStringWithANegetiveValue_ShouldThrowException()
        {
            const string input = "-1,2,5";
            const string expected = "negetives not allowed : -1";
            var calculator = CreateCalculator();
            var actualResults = Assert.Throws<ApplicationException>(()=> calculator.Add(input));

            Assert.AreEqual(expected, actualResults.Message);
        }


        [Test]
        public void Given_InputStringWithNegetiveValues_ShouldThrowException()
        {
            const string input = "-1,2,-5";
            const string expected = "negetives not allowed : -1,-5";
            var calculator = CreateCalculator();
            var actualResults = Assert.Throws<ApplicationException>(() => calculator.Add(input));

            Assert.AreEqual(expected, actualResults.Message);
        }




        [Test]
        public void Given_InputStringWithValueGreaterThanThousand_ShouldIgnoreValueReturnSum()
        {
            const string input = "1001,2";
            const int expected = 2;
            var calculator = CreateCalculator();
            var actualResults =  calculator.Add(input);

            Assert.AreEqual(expected, actualResults);
        }



        [Test]
        public void Given_InputStringWithValueNotGreaterThanThousand_ShouldReturnSum()
        {
            const string input = "1000,2";
            const int expected = 1002;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

            Assert.AreEqual(expected, actualResults);
        }

        [Test]
        public void Given_InputStringWithDelimitersBetweenValue_ShouldReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

            Assert.AreEqual(expected, actualResults);
        }


        [Test]
        public void Given_InputStringWithDelimitersOfAnyLengthBetweenValue_ShouldReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

            Assert.AreEqual(expected, actualResults);
        }


        [Test]
        public void Given_InputStringWithMultipleDelimitersBetweenValue_ShouldReturnSum()
        {
            const string input = "//[*][%]\n2*4%6";
            const int expected = 12;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

            Assert.AreEqual(expected, actualResults);
        }


        [Test]
        public void Given_InputStringWithMultipleDelimitersOfAnyLengthBetweenValue_ShouldReturnSum()
        {
            const string input = "//[$&*][%###]\n2$*4%6&&&&&&&&&&*********#8";
            const int expected = 20;
            var calculator = CreateCalculator();
            var actualResults = calculator.Add(input);

            Assert.AreEqual(expected, actualResults);
        }


        private static Calculator CreateCalculator()
        {
            return new Calculator();
        }
    }
}