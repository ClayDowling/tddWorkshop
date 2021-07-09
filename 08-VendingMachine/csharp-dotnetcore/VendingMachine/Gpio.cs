namespace VendingMachine
{
    public class Gpio
    {
        public Gpio(int pin)
        {
            Pin = pin;
        }

        public int Pin { get; private set; }
        public GpioState State { get; set; }
    }
}