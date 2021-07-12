using Xunit;
using NSubstitute;
using VendingMachine;
using FluentAssertions;

namespace VendingMachineTests
{
    public class AcceptCoinsTest
    {
        public AcceptCoinsTest()
        {
            serialBus = new SerialBus();
            acceptCoins = new AcceptCoin(serialBus);
        }
        private IAcceptCoins acceptCoins;
        private SerialBus serialBus;

        const int Nickle = 5;
        const int Dime = 10;
        const int Quarters = 25;

        const double WeightOfNickle = 5.00;
        const double WeightOfQuater = 5.67;
        const double WeightOfDime = 2.268;

        const double DiameterOfNickle = 21.21;
        const double DiameterofQuater = 24.26;
        const double DiameterofDime = 17.91;

        [Theory]
        [InlineData(Nickle, WeightOfNickle, DiameterOfNickle)]
        [InlineData(Dime, WeightOfDime, DiameterofDime)]
        [InlineData(Quarters, WeightOfQuater, DiameterofQuater)]
        public void AcceptCoinsTestFor(double expectedvalue, double weightOfCoin, double diameterOfCoin)
        {
            acceptCoins.AcceptCoins( weightOfCoin, diameterOfCoin).Should().Be(expectedvalue);

        }

        [Theory]
        [InlineData(2.5, 19.05)]
        [InlineData(3.2, 23.56)]
        [InlineData(3.5, 24.05)]
        [InlineData(5.5, 23.05)]
        public void RejectInvalidCoins(double weightOfCoin, double diameterOfCoin)
        {
            acceptCoins.AcceptCoins(weightOfCoin, diameterOfCoin).Should().Be(0);

        }

       [Fact]
        public void AcceptCoinsTestForCurrentAmmountQuartersAndDimes()
        {
            acceptCoins.AcceptCoins(WeightOfNickle, DiameterOfNickle).Should().Be(Nickle);
            acceptCoins.AcceptCoins(WeightOfDime, DiameterofDime).Should().Be(Nickle+Dime);
            acceptCoins.AcceptCoins(WeightOfQuater, DiameterofQuater).Should().Be(Nickle + Dime+ Quarters);
            acceptCoins.AcceptCoins(WeightOfQuater, DiameterofQuater).Should().Be(Nickle + Dime + Quarters+ Quarters);

        }


        [Fact]
        public void DisplayMessageInsertCoinsWhenNoCoins()
        {
             serialBus.Recv().Should().Be("Insert Coins");
        }

    }
}
