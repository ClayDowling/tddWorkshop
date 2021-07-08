using System;

namespace VendingMachine
{
    public class Gpio
    {
        public int Pin;
        private GpioState _state;
        private Action _interrupt;
        private GpioState _triggerState;

        public GpioState State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;
                    _interrupt?.Invoke();
                }
            }
        }

        public Gpio(int pin)
        {
            Pin = pin;
            _state = GpioState.LOW;
        }

        public void AttachInterrupt(Action interrupt, GpioState triggerState)
        {
            _interrupt = interrupt;
            _triggerState = triggerState;
        }
    }
}