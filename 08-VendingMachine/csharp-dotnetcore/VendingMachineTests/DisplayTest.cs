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
            _display.Value().Should().Be("Insert Coin");
        }
        
        [Fact]
        public void TwoNicklesDimeQuarterDisplays45Cents()
        {
            _display.ReceivesSignal("45");
            _display.Value().Should().Be("45 cents");
        }
        
        [Fact]
        public void TwoNicklesDisplays10Cents()
        {
            _display.ReceivesSignal("10");
            _display.Value().Should().Be("10 cents");
        }
        
        private readonly Display _display = new(null);

    }
}