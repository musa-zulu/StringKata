    
using NUnit.Framework;

namespace ClassLibrary1
{
    [TestFixture]
    public class TestCalculator
    {

        [Test]
        public void Given_EmptyInputStringShould_ReturnZero()
        {
            const string input = "";
            const int expected = 0;
            var calculator = new Calculator();
            var results = calculator.Add(input);
            Assert.AreEqual(expected,results);
        }
    }

 
}