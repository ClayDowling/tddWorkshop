using FluentAssertions;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class ProductSelectionPanelTests
    {
        /*
         * There are three products: cola for $1.00, chips for $0.50, and candy for $0.65.
         * When the respective button is pressed and enough money has been inserted,
         * the product is dispensed and the machine displays THANK YOU. If the display is checked again,
         * it will display INSERT COIN and the current amount will be set to $0.00.
         * If there is not enough money inserted then the machine displays PRICE and the price of the item and
         * subsequent checks of the display will display either INSERT COIN or the current amount as appropriate.
         */
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