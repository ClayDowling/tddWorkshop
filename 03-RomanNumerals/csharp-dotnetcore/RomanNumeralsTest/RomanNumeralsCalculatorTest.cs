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
        
        [Fact]
        public void FifteenPlusFiveGivesTwenty()
        {
            calculator.Add("XV", "V").Should().Be("XX");
        }

        [Fact]
        public void FourPlusFiveIsNine()
        {
            calculator.Add("IV", "V").Should().Be("IX");
        }
        
        private RomanNumeralsCalculator calculator = new RomanNumeralsCalculator();
        
    }
}
