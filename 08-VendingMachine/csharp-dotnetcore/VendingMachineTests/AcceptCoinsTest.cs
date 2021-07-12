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
        [InlineData(Coins.pennies,false)]
        [InlineData(Coins.nickels, true)]
        [InlineData(Coins.dimes, true)]
        [InlineData(Coins.quarters, true)]
        public void ValidateCoinsTest(Coins coins, bool expected)
        {
            acceptCoins.ValidateCoins(coins).Should().Be(expected);

        }

        [Theory]
        [InlineData(Coins.nickels, 0.05)]
        [InlineData(Coins.dimes, 0.10)]
        [InlineData(Coins.quarters, 0.25)]

        public void AcceptCoinsTestFor(Coins coins, double expectedvalue)
        {
            acceptCoins.AcceptCoins(coins).Should().Be(expectedvalue);

        }

        [Fact]
        public void AcceptCoinsTestForCurrentAmmount()
        {
            acceptCoins.AcceptCoins(Coins.quarters);
            acceptCoins.AcceptCoins(Coins.dimes).Should().Be(0.35);

        }

        //[Fact]
        //public void NoCoinsInserted()
        //{
        //    acceptCoins.DisplayMessage(null).Should().Be("No Coins Inserted");
        //}

        //[Fact]
        //public void DisplayCurrentAmount()
        //{
        //    acceptCoins.DisplayMessage(Coins.dimes).Should().Be("INSERT COIN");
        //}
    }
}
