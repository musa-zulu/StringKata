﻿using System;
using Engine;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;

/*
  BEFORE YOU START :
  This Kata is meant to teach TDD cadence, growing a solution using tests and speed. 
  It’s designed to be a bit long for the time you have when you start, and the idea 
  is to practice it until you can do it really fast, while rigorously practising TDD. 
  This will ingrain the cadence of TDD and the keyboard shortcuts and refactorings 
  you need to be fast. Remember, the only way to go fast is to go well. 
*/

/*
  RULES : 
  1.	Strictly practice TDD: Red, Green, Refactor
  2.	Clean Code is required:
    2.1.	Intention-revealing names
    2.2.	Verb/verb-phrase method names
    2.3.	Methods should do one thing and be short, with no side-effects
    2.4.	Methods should contain only one level of abstraction
    2.5.	Code should read like a top-down narrative
    2.6.	No unnecessary code
    2.7.	DRY
    2.8.	Unit tests that test pieces of the algorithm, not only acceptance level tests.
*/

/*
  GOALS : 
  +	Silver: 25 minutes
  +	Gold:   20 minutes
*/

/*
  THE KATA : 
  1.  Create a simple String calculator with a method int Add(string numbers) 
      1.1.	The method can take 0, 1 or 2 numbers, and will return their sum 
	       (for an empty string it will return 0) for example “” or “1” or “1,2”
      1.2.	Start with the simplest test case of an empty string and move to 1 
	        and two numbers
      1.3.	Remember to solve things as simply as possible so that you force 
	        yourself to write tests you did not think about
      1.4.	Remember to refactor after each passing test
  2.  Allow the Add method to handle an unknown amount of numbers
  3.  Allow the Add method to handle new lines between numbers (instead of commas). 
      3.1.	the following input is ok:  “1\n2,3”  (will equal 6)
      3.2.	the following input is NOT ok:  “1,\n” (not need to prove it - just 
	        clarifying)
  4.  Support different delimiters 
      4.1.	to change a delimiter, the beginning of the string will contain a 
	        separate line that looks like this:   “//[delimiter]\n[numbers…]” 
			for example “//;\n1;2” should return three where the default 
			delimiter is ‘;’ . 
      4.2.	the first line is optional. All existing scenarios should still be 
	        supported.
  5.  Calling Add with a negative number should throw the provided 
      NegativesNotAllowedException. You should verify that the negative numbers
	  are contained in the NegativeNumbers property of the thrown exception. 
	  If there are multiple negatives, then all of them should be included in 
	  the NegativeNumbers property.
  6.  Numbers bigger than 1000 should be ignored, so adding 2 + 1001  = 2
  7.  Delimiters can be of any length with the following format:  “//[delimiter]\n” 
      for example: “//[***]\n1***2***3” should return 6
  8.  Allow multiple delimiters like this:  “//[delim1][delim2]\n” 
      for example “//[*][%]\n1*2%3” should return 6.
  9.  Make sure you can also handle multiple delimiters with length longer than 
      one char
 */


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
        public void Given_EmptyInputStringShould_ReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Given_SingleNumberInputStringShould_ReturnSingleNumber()
        {
            const string input = "1";
            const int expected = 1;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_LargeSingleNumberInputStringShould_ReturnSingleNumber()
        {
            const string input = "130";
            const int expected = 130;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Given_TwoNumbersInputStringShould_ReturnSum()
        {
            const string input = "1,3";
            const int expected = 4;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_ManyNumbersInputStringShould_ReturnSum()
        {
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithNewLineInBetweenShould_ReturnSum()
        {
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithSingleCustormDelimiterInBetweenShould_ReturnSum()
        {
            const string input = "//;\n1;2";
            const int expected = 3;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Given_NumbersInputStringWithANegativeInBetweenShould_ThrowException()
        {
            const string input = "-1";
            const string expected = "negatives not allowed: -1";
            var calculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(()=>calculator.Add(input));
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Given_NumbersInputStringWithNegativesInBetweenShould_ThrowException()
        {
            const string input = "-1,-2";
            const string expected = "negatives not allowed: -1,-2";
            var calculator = CreateCalculator();
            var actual = Assert.Throws<NegativesNotAllowedException>(() => calculator.Add(input));
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Given_NumbersInputStringWithNumberGreaterThanThousandInBetweenShould_ReturnSum()
        {
            const string input = "1001,3";
            const int expected = 3;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithNumberNotGreaterThanThousandInBetweenShould_ReturnSum()
        {
            const string input = "1000,3";
            const int expected = 1003;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithCustormDelimitersInBetweenShould_ReturnSum()
        {
            const string input = "//[***]\n1***2***3";
            const int expected =6;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithMultipleCustormDelimitersInBetweenShould_ReturnSum()
        {
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Given_NumbersInputStringWithMultipleCustormDelimitersOfAnyLengthInBetweenShould_ReturnSum()
        {
            const string input = "//[*][%][^]\n1*2%3^4";
            const int expected = 10;
            var calculator = CreateCalculator();
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }



     
    }
}
