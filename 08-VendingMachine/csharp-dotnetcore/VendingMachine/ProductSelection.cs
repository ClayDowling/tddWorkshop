namespace VendingMachine
{
    public class ProductSelection
    {
        private readonly MainProcessor _mainProcessor;
        private readonly int _cost;

        public ProductSelection(MainProcessor mainProcessor, int cost)
        {
            _mainProcessor = mainProcessor;
            _cost = cost;
        }

        public void Select()
        {
            if(_mainProcessor.AvailableCash() >= _cost)
                _mainProcessor.DisplayBus().Send("Thank You");
            else
            {
                _mainProcessor.DisplayBus().Send($"Price {_cost}");
            }
        }
    }
}