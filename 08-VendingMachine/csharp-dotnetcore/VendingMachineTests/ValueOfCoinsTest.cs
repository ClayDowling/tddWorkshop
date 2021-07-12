using Xunit;
using NSubstitute;
using VendingMachine;
using FluentAssertions;


namespace VendingMachineTests
{
    public class ValueOfCoinsTest
    {
        private IValueOfCoin valueOfCoin = new ValueOfCoins();

        [Theory]
        [InlineData(Coins.pennies, 0.01)]
        [InlineData(Coins.nickels, 0.05)]
        [InlineData(Coins.dimes, 0.10)]
        [InlineData(Coins.quarters, 0.25)]
        public void ValidateValueOfCoins(Coins coins, double expectedvalue)
        {
            valueOfCoin.ValueOfCoin(coins).Should().Be(expectedvalue);

        }
    }
}
