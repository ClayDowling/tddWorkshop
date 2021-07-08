using System;
using FluentAssertions;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class CoinAccepterTest
    {
        private const double NickelWeight = 5.000;
        private const double NickelDiameter = 21.21;
        private const double DimeWeight = 2.268;
        private const double DimeDiameter = 17.91;
        private const double QuarterWeight = 5.670;
        private const double QuarterDiameter = 24.26;
        private const int MagicTokenWeight = 8;
        private const int MagicCoinDiameter = 30;
        private CoinAccepter _accepter;

        public CoinAccepterTest()
        {
            _accepter = new CoinAccepter();
        }
        
        [Theory]
        [InlineData("Nickel", NickelWeight, NickelDiameter, 5)]
        [InlineData("Dime", DimeWeight, DimeDiameter, 10)]
        [InlineData("Quarter", QuarterWeight, QuarterDiameter, 25)]
        [InlineData("MagicToken", MagicTokenWeight, MagicCoinDiameter, 100)]
        public void AcceptsUsaCoins(string name, double weightGrams, double diameterMm, int expectValueCents)
        {
            _accepter.DropCoin(weightGrams, diameterMm);
            _accepter.Value().Should().Be(expectValueCents);
        }

        [Fact]
        public void RejectsSlug()
        {
            _accepter.DropCoin(5.7, 18);
            _accepter.Value().Should().Be(0);
            // TODO: verify coin return?
        }

        [Fact]
        public void AccumulatesCoins()
        {
            _accepter.DropCoin(NickelWeight, NickelDiameter);
            _accepter.DropCoin(NickelWeight, NickelDiameter);
            _accepter.DropCoin(DimeWeight, DimeDiameter);
            _accepter.DropCoin(QuarterWeight, QuarterDiameter);

            _accepter.Value().Should().Be(45);
        }
    }
}