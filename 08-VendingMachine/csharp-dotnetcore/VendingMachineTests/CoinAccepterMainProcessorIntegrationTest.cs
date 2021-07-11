using System.Threading;
using VendingMachine;
using Xunit;
using FluentAssertions;

namespace VendingMachineTests
{
    public class CoinAccepterMainProcessorIntegrationTest
    {
        private readonly SerialBus _serialBus;
        private readonly MainProcessor _mainProcessor;
        private readonly CoinAccepter _coinAccepter;

        [Fact]
        public void MainProcessorGetsCashAvailableViaSerialBus()
        {
            _coinAccepter.DropCoin(Constants.NickelWeight,Constants.NickelDiameter);
            Thread.Sleep(300);
            _mainProcessor.AvailableCash().Should().Be(5);
        }

        public CoinAccepterMainProcessorIntegrationTest()
        {
            _serialBus = new SerialBus();
            _mainProcessor = new MainProcessor(_serialBus);
            _coinAccepter = new CoinAccepter(_serialBus);
        }
    }
}