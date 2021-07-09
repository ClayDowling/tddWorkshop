using System;

namespace VendingMachine
{
    public class Display
    {
        private readonly SerialBus _serialBus;
        private const string DefaultDisplay = "Insert Coin";
        private string _currentMessage;

        public Display(SerialBus serialBus)
        {
            _serialBus = serialBus;
            serialBus.Subscribe(AcceptMessage);
            _currentMessage = DefaultDisplay;
        }

        public void AcceptMessage(string message)
        {
            _currentMessage = $"{message} cents";
        }

        public string QueryDisplayForTesting()
        {
            return _currentMessage;
        }
    }
}