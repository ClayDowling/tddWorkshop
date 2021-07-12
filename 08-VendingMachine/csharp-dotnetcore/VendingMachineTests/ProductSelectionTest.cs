using System.Threading;
using FluentAssertions;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    /*
     * There are three products: cola for $1.00, chips for $0.50, and candy for $0.65.
     * When the respective button is pressed and enough money has been inserted,
     * the product is dispensed and the machine displays THANK YOU. If the display is checked again,
     * it will display INSERT COIN and the current amount will be set to $0.00.
     * If there is not enough money inserted then the machine displays PRICE
     * and the price of the item and subsequent checks of the display will display
     * either INSERT COIN or the current amount as appropriate.
     */
    public class ProductSelectionTest
    {
        private const int ColaButton = 0;
        private MainProcessor _mainProcessor;
        private readonly ProductSelection _cola;

        [Fact]
        public void ProductSelectedWithEnoughMoney()
        {
            _mainProcessor.ProductSelectionPanel.ButtonList[ColaButton].State = ButtonState.Pressed;
            Thread.Sleep(60);
            _mainProcessor.DisplayBus().Recv().Should().Be("Thank You");
        }
        
        [Fact]
        public void ProductSelectedWithoutEnoughMoney()
        {
            _cola.Select();
            // TODO Test was not selected because not enough money
        }

        public ProductSelectionTest()
        {
            var serialBus = new SerialBus();
            _mainProcessor = new MainProcessor(serialBus);
            _cola = new ProductSelection( _mainProcessor, 100);
            _mainProcessor.AttachActionForButton(0, _cola.Select);
        }
        
    }
}