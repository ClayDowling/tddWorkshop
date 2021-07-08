using FluentAssertions;
using VendingMachine;
using Xunit;
using NSubstitute;

namespace VendingMachineTests
{
    public class CoinAccepterDisplayIntegrationTest
    {
        private readonly CoinAccepter _accepter;
        private readonly Display _display;
        private readonly SerialBus _serialBus;

        [Fact]
        public void CoinAccepterSendsMessageToDisplay()
        {
            _accepter.DropCoin(Constants.NickelWeight,Constants.NickelDiameter);
            _display.QueryDisplayForTesting().Should().Be("5 cents");
        }

        public CoinAccepterDisplayIntegrationTest()
        {
            _serialBus = new SerialBus();
            _accepter = new CoinAccepter(_serialBus);
            _display = new Display(_serialBus);
        }
    }
}