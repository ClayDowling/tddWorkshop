using System;

namespace VendingMachine
{
    public class Display
    {
        private readonly SerialBus _serialBus;
        private const string DefaultDisplay = "Insert Coin";

        public Display(SerialBus serialBus)
        {
            _serialBus = serialBus;
        }

        public string QueryDisplayForTesting()
        {
            var message = _serialBus.Recv();
            if (message == string.Empty) return DefaultDisplay;
            return $"{message} cents";
        }
    }
}