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
        private ISerialSender _serialSender;

        public CoinAccepterTest()
        {
            _serialSender = Substitute.For<ISerialSender>();
            _accepter = new CoinAccepter(_serialSender);
        }
        
        [Theory]
        [InlineData("Nickel", Constants.NickelWeight, Constants.NickelDiameter, "5")]
        [InlineData("Dime", Constants.DimeWeight, Constants.DimeDiameter, "10")]
        [InlineData("Quarter", Constants.QuarterWeight, Constants.QuarterDiameter, "25")]
        [InlineData("MagicToken", Constants.MagicTokenWeight, Constants.MagicCoinDiameter, "100")]
        public void AcceptsUsaCoins(string name, double weightGrams, double diameterMm, string expectValueCents)
        {
            _accepter.DropCoin(weightGrams, diameterMm);
            _serialSender.Received(1).Send(expectValueCents);
        }

        [Fact]
        public void RejectsSlug()
        {
            _accepter.DropCoin(5.7, 18);
            _serialSender.Received(0).Send(Arg.Any<string>());
            // TODO: verify coin return?
        }

        [Fact]
        public void AccumulatesCoins()
        {
            _accepter.DropCoin(Constants.NickelWeight, Constants.NickelDiameter);
            _accepter.DropCoin(Constants.NickelWeight, Constants.NickelDiameter);
            _accepter.DropCoin(Constants.DimeWeight, Constants.DimeDiameter);
            _accepter.DropCoin(Constants.QuarterWeight, Constants.QuarterDiameter);

            _serialSender.Received(1).Send("5");
            _serialSender.Received(1).Send("10");
            _serialSender.Received(1).Send("20");
            _serialSender.Received(1).Send("45");
        }
    }
}