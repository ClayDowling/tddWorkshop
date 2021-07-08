namespace VendingMachine
{
    public class Display
    {
        private readonly ISerialReceiver _serialReceiver;
        private string _value;
        private const string DefaultDisplay = "Insert Coin";

        public Display(ISerialReceiver serialReceiver)
        {
            _serialReceiver = serialReceiver;
            _value = DefaultDisplay;
        }
        public void ReceivesSignal(string signal)
        {
            _value = $"{signal} cents";
        }

        public string Value()
        {
            return _value;
        }
    }
}