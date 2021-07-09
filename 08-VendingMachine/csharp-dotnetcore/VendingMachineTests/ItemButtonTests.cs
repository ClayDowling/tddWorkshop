using FluentAssertions;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class ItemButtonTests
    {
        [Fact]
        public void ItemButtonStateIsReleasedByDefault()
        {
            _button.State.Should().Be(ButtonState.Released);
            _button.Gpio.State.Should().Be(GpioState.Low);
        }
        
        [Fact]
        public void PressingButtonSetsGpioHigh()
        {
            _button.State = ButtonState.Pressed;
            _button.Gpio.State.Should().Be(GpioState.High);
        }

        [Fact]
        public void ReleasingTheButtonSetsGpioBackToLow()
        {
            _button.State = ButtonState.Pressed;
            _button.State = ButtonState.Released;
            _button.Gpio.State.Should().Be(GpioState.Low);
        }

        [Fact]
        public void ItemButtonIsTiedToAGpioPinOnThePanel()
        {
            _button.Gpio.Pin.Should().Be(3);
        }
        
        private readonly ItemButton _button = new(3);
    }
}