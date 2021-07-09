using FluentAssertions;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    // TODO: we should get the message from the main processor and not the display
    public class CoinAccepterDisplayIntegrationTest
    {
        private readonly CoinAccepter _accepter;
        private readonly Display _display;

        [Fact]
        public void CoinAccepterSendsMessageToDisplay()
        {
            _accepter.DropCoin(Constants.NickelWeight,Constants.NickelDiameter);
            _display.QueryDisplayForTesting().Should().Be("5 cents");
        }

        public CoinAccepterDisplayIntegrationTest()
        {
            var serialBus = new SerialBus();
            _accepter = new CoinAccepter(serialBus);
            _display = new Display(serialBus);
        }
    }
}