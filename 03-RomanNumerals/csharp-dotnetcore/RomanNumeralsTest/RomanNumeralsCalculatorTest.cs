using Xunit;
using FluentAssertions;

namespace Katas
{

    public class RomanNumeralsTest
    {
        [Fact]
        public void OnePlusOne()
        {
            Roman.Add("I", "I").Should().Be("II");
        }

        [Fact]
        public void OnePlusTwo()
        {
            Roman.Add("I", "II").Should().Be("III");
        }

        [Fact]
        public void FifteenPlusFiveGivesTwenty()
        {
            Roman.Add("XV", "V").Should().Be("XX");
        }

        [Fact]
        public void FourPlusFiveIsNine()
        {
            Roman.Add("IV", "V").Should().Be("IX");
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("VI", 6)]
        [InlineData("VII", 7)]
        [InlineData("IX", 9)]
        [InlineData("X", 10)]
        [InlineData("XI", 11)]
        [InlineData("XX", 20)]
        [InlineData("XXVI", 26)]
        [InlineData("L", 50)]
        public void ToInt_GivenRoman_ReturnsInt(string roman, int arabic)
        {
            Roman.ToInt(roman).Should().Be(arabic);
        }

        
        [Theory]
        [InlineData("D","CD","CM")]
        [InlineData("XC", "X", "C")]
        [InlineData("XL", "V", "XLV")]
        public void AddRomanNumerals(string romanNumeral1, string romanNumeral2, string expectedResult)
        {
            Roman.Add(romanNumeral1, romanNumeral2).Should().Be(expectedResult);
        }
    }
}
