namespace VendingMachine
{
    public class Gpio
    {
        public int Pin;

        public Gpio(int pin)
        {
            Pin = pin;
        }

        public GpioState State()
        {
            return GpioState.LOW;
        }
    }
}