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
        [InlineData(Coins.nickels, 5)]
        [InlineData(Coins.dimes, 10)]
        [InlineData(Coins.quarters, 25)]
        public void ValidateValueOfCoins(Coins coins, double expectedvalue)
        {
            valueOfCoin.ValueOfCoin(coins).Should().Be(expectedvalue);

        }
    }
}
