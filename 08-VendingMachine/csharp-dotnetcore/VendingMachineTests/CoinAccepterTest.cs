using System;
using FluentAssertions;
using NSubstitute;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class CoinAccepterTest
    {
        private CoinAccepter _accepter;
        private SerialBus _serialBus;

        public CoinAccepterTest()
        {
            _serialBus = new SerialBus();
            _accepter = new CoinAccepter(_serialBus);
        }
        
        [Theory]
        [InlineData("Nickel", Constants.NickelWeight, Constants.NickelDiameter, "5")]
        [InlineData("Dime", Constants.DimeWeight, Constants.DimeDiameter, "10")]
        [InlineData("Quarter", Constants.QuarterWeight, Constants.QuarterDiameter, "25")]
        [InlineData("MagicToken", Constants.MagicTokenWeight, Constants.MagicCoinDiameter, "100")]
        public void AcceptsUsaCoins(string name, double weightGrams, double diameterMm, string expectValueCents)
        {
            _accepter.DropCoin(weightGrams, diameterMm);
            _serialBus.Recv().Should().Be(expectValueCents);
        }

        [Fact]
        public void RejectsSlug()
        {
            _accepter.DropCoin(5.7, 18);
            _serialBus.Recv().Should().Be(String.Empty);
        }

        [Fact]
        public void PublishesMessagesForAccumulatesCoins()
        {
            _accepter.DropCoin(Constants.NickelWeight, Constants.NickelDiameter);
            _serialBus.Recv().Should().Be("5");
            _accepter.DropCoin(Constants.NickelWeight, Constants.NickelDiameter);
            _serialBus.Recv().Should().Be("10");
            _accepter.DropCoin(Constants.DimeWeight, Constants.DimeDiameter);
            _serialBus.Recv().Should().Be("20");
            _accepter.DropCoin(Constants.QuarterWeight, Constants.QuarterDiameter);
            _serialBus.Recv().Should().Be("45");
        }
    }
}