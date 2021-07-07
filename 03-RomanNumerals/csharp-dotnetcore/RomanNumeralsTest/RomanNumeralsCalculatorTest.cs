using Xunit;
using FluentAssertions;

namespace Katas
{
    
    public class RomanNumeralsTest
    {
        [Fact]
        public void OnePlusOne()
        {
            calculator.Add("I", "I").Should().Be("II");
        }
        
        [Fact]
        public void OnePlusTwo()
        {
            calculator.Add("I", "II").Should().Be("III");
        }
        
        private RomanNumeralsCalculator calculator = new RomanNumeralsCalculator();
        
    }
}
