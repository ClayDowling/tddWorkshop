using FluentAssertions;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class ProductSelectionPanelTests
    {
        [Fact]
        public void PanelHasThreeButtons()
        {
            var serialBus = new SerialBus();
            var panel = new ProductSelectionPanel();

            panel.ButtonList.Count.Should().Be(3);
            panel.ButtonList[0].Gpio.Pin.Should().Be(3);
            panel.ButtonList[1].Gpio.Pin.Should().Be(4);
            panel.ButtonList[2].Gpio.Pin.Should().Be(5);
        }
    }
}