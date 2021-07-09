using VendingMachineTests;

namespace VendingMachine
{
    public class ItemButton
    {
        private ButtonState _state;

        public ItemButton(int pin)
        {
            Gpio = new Gpio(pin);
        }

        public ButtonState State
        {
            get => _state;
            set
            {
                _state = value;
                Gpio.State = _state == ButtonState.Pressed ? GpioState.HIGH : GpioState.LOW;
            }
        }

        public Gpio Gpio { get; private set; }
    }
}