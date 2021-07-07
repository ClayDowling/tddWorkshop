using Xunit;
using FluentAssertions;

namespace Katas
{
    
    public class RomanNumeralsTest
    {
        [Fact]
        public void TestMethod1()
        {
            RomanNumeralsCalculator calculator = new RomanNumeralsCalculator();
            string actualResult = calculator.add("I", "I");

            actualResult.Should().Be("II");
        }
    }
}
