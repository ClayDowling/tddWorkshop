using VendingMachine;
using Xunit;
using FluentAssertions;

namespace VendingMachineTests
{
    public class DisplayTest
    {
        [Fact]
        public void DefaultDisplay()
        {
            _display.QueryDisplayForTesting().Should().Be("Insert Coin");
        }
        
        [Fact]
        public void TwoNicklesDimeQuarterDisplays45Cents()
        {
            _serialBus.Send("45");
            _display.QueryDisplayForTesting().Should().Be("45 cents");
        }
        
        [Fact]
        public void TwoNicklesDisplays10Cents()
        {
            _serialBus.Send("10");
            _display.QueryDisplayForTesting().Should().Be("10 cents");
        }

        public DisplayTest()
        {
            _serialBus = new SerialBus();
            _display = new(_serialBus);
        }
        
        private readonly Display _display;
        private readonly SerialBus _serialBus;
    }
}