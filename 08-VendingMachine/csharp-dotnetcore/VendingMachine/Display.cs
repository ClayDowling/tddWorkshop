
namespace VendingMachine
{
    public class Display
    {
        private const string DefaultDisplay = "Insert Coin";
        private string _currentMessage;

        public Display(SerialBus serialBus)
        {
            serialBus.Subscribe(AcceptMessage);
            _currentMessage = DefaultDisplay;
        }

        private void AcceptMessage(string message)
        {
            _currentMessage = $"{message} cents";
        }

        public string QueryDisplayForTesting()
        {
            return _currentMessage;
        }
    }
}