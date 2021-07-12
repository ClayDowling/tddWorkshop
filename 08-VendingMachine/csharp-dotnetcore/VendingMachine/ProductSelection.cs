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
            // TODO: move this to the processor loop?
            _mainProcessor.DisplayBus().Send("Thank You");
        }
    }
}