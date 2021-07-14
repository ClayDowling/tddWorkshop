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
        private const int ChipsButton = 1;
        private const int CandyButton = 2;
        private readonly MainProcessor _mainProcessor;
        private readonly SerialBus _serialBus;

        [Fact]
        public void ColaSelectedWithEnoughMoney()
        {
            _serialBus.Send("100");
            Thread.Sleep(60);
            _mainProcessor.ProductSelectionPanel.ButtonList[ColaButton].State = ButtonState.Pressed;
            Thread.Sleep(60);
            _mainProcessor.DisplayBus().Recv().Should().Be("Thank You");
            Thread.Sleep(4000);
            _mainProcessor.DisplayBus().Recv().Should().Be("Insert Coin");
        }
        
        [Fact]
        public void ChipsSelectedWithEnoughMoney()
        {
            _serialBus.Send("50");
            Thread.Sleep(60);
            _mainProcessor.ProductSelectionPanel.ButtonList[ChipsButton].State = ButtonState.Pressed;
            Thread.Sleep(60);
            _mainProcessor.DisplayBus().Recv().Should().Be("Thank You");
            Thread.Sleep(4000);
            _mainProcessor.DisplayBus().Recv().Should().Be("Insert Coin");
        }
        
        [Fact]
        public void CandySelectedWithEnoughMoney()
        {
            _serialBus.Send("65");
            Thread.Sleep(60);
            _mainProcessor.ProductSelectionPanel.ButtonList[CandyButton].State = ButtonState.Pressed;
            Thread.Sleep(60);
            _mainProcessor.DisplayBus().Recv().Should().Be("Thank You");
            Thread.Sleep(4000);
            _mainProcessor.DisplayBus().Recv().Should().Be("Insert Coin");
        }
        
        [Fact]
        public void ProductSelectedWithTooMuchMoney()
        {
            _serialBus.Send("110");
            Thread.Sleep(60);
            _mainProcessor.ProductSelectionPanel.ButtonList[ColaButton].State = ButtonState.Pressed;
            Thread.Sleep(60);
            _mainProcessor.DisplayBus().Recv().Should().Be("Thank You");
            Thread.Sleep(4000);
            _mainProcessor.DisplayBus().Recv().Should().Be("Insert Coin");
            
            // TODO: how to verify change was given?
        }
        
        [Fact]
        public void ProductSelectedWithNoMoney()
        {
            _mainProcessor.ProductSelectionPanel.ButtonList[ColaButton].State = ButtonState.Pressed;
            Thread.Sleep(60);
            _mainProcessor.DisplayBus().Recv().Should().Be("Price 100");
            Thread.Sleep(4000);
            _mainProcessor.DisplayBus().Recv().Should().Be("Insert Coin");
        }

        [Fact]
        public void ProductSelectedWithoutEnoughMoney()
        {
            _serialBus.Send("10");
            Thread.Sleep(60);
            _mainProcessor.ProductSelectionPanel.ButtonList[ColaButton].State = ButtonState.Pressed;
            Thread.Sleep(60);
            _mainProcessor.DisplayBus().Recv().Should().Be("Price 100");
            Thread.Sleep(4000);
            _mainProcessor.DisplayBus().Recv().Should().Be("10 cents");
        }
        
        public ProductSelectionTest()
        {
            _serialBus = new SerialBus();
            _mainProcessor = new MainProcessor(_serialBus, 100, 50, 65);
        }
        
    }
}