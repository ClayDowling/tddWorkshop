namespace VendingMachine
{
    public class Display
    {
        private string _value;

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