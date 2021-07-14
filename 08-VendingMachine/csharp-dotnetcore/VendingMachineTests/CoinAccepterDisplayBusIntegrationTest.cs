using System.Threading;
using FluentAssertions;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class CoinAccepterDisplayBusIntegrationTest
    {
        private readonly CoinAccepter _accepter;
        private readonly MainProcessor _mainProcessor;

        [Fact]
        public void CoinAccepterSendsMessageToDisplay()
        {
            _accepter.DropCoin(Constants.NickelWeight,Constants.NickelDiameter);
            Thread.Sleep(60);
            _mainProcessor.DisplayBus().Recv().Should().Be("5 cents");
        }

        public CoinAccepterDisplayBusIntegrationTest()
        {
            var serialBus = new SerialBus();
            _accepter = new CoinAccepter(serialBus);
            _mainProcessor =  new MainProcessor(serialBus, 10, 20, 30);
        }
    }
}