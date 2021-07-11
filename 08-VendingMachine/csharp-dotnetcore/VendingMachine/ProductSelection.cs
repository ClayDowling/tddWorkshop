namespace VendingMachine
{
    public class ProductSelection
    {
        private readonly int _cost;
        private readonly SerialBus _serialBus;

        public ProductSelection(int cost, SerialBus serialBus)
        {
            _cost = cost;
            _serialBus = serialBus;
        }

        public void Select()
        {
            
        }
    }
}