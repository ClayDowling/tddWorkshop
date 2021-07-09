using VendingMachine;

namespace VendingMachineTests
{
    public class MainProcessor
    {
        public MainProcessor()
        {
            ProductSelectionPanel = new ProductSelectionPanel();
        }
        public ProductSelectionPanel ProductSelectionPanel { get; }
    }
}