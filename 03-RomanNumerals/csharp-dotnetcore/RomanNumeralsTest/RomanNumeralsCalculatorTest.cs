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
        
        private RomanNumeralsCalculator calculator = new RomanNumeralsCalculator();
        
    }
}
