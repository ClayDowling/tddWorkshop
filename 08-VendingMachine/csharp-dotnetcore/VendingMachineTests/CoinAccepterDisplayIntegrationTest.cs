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
        private readonly ISerialSender _serialSender;
        private readonly ISerialReceiver _serialReceiver;

        [Fact]
        public void CoinAccepterSendsMessageToDisplay()
        {
            _accepter.DropCoin(1,2);
            _display.Value().Should().Be("5 cents");
        }

        public CoinAccepterDisplayIntegrationTest()
        {
            _serialSender = Substitute.For<ISerialSender>();
            _accepter = new CoinAccepter(_serialSender);
            _display = new Display(_serialReceiver);
        }
    }
}