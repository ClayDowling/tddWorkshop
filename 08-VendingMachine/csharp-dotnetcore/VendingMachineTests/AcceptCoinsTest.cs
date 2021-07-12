using Xunit;
using NSubstitute;
using VendingMachine;
using FluentAssertions;

namespace VendingMachineTests
{
    public class AcceptCoinsTest
    {
        //private IAcceptCoins acceptCoins= NSubstitute.Substitute.For<IAcceptCoins>();
        //private IValueOfCoin valueOfCoin = NSubstitute.Substitute.For<IValueOfCoin>();

        private IAcceptCoins acceptCoins = new AcceptCoin();

        [Theory]
        [InlineData(Coins.pennies, false)]
        [InlineData(Coins.nickels, true)]
        [InlineData(Coins.dimes, true)]
        [InlineData(Coins.quarters, true)]
        public void ValidateCoinsTest(Coins coins, bool expected)
        {
            acceptCoins.ValidateCoins(coins).Should().Be(expected);

        }

        [Theory]
        [InlineData(Coins.nickels, 5)]
        [InlineData(Coins.dimes, 10)]
        [InlineData(Coins.quarters, 25)]

        public void AcceptCoinsTestFor(Coins coins, double expectedvalue)
        {
            acceptCoins.AcceptCoins(coins).Should().Be(expectedvalue);

        }

        [Fact]
        public void AcceptCoinsTestForCurrentAmmountQuartersAndDimes()
        {
            acceptCoins.AcceptCoins(Coins.quarters).Should().Be(25);
            acceptCoins.AcceptCoins(Coins.dimes).Should().Be(35);
            acceptCoins.AcceptCoins(Coins.nickels).Should().Be(40);
            acceptCoins.AcceptCoins(Coins.quarters).Should().Be(65);
        }
        //If there is not enough money inserted then the machine displays
        //PRICE and the price of the item and subsequent checks of the display will
        //display either INSERT COIN or the current amount as appropriate

        [Fact]
        public void DisplayProductsWhenNotEnoughMoneyInserted()
        {

        }

    }
}
