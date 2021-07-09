using System.Collections.Generic;

namespace VendingMachine
{
    public class ProductSelectionPanel
    {
        public ProductSelectionPanel()
        {
            ButtonList = new List<ItemButton>
            {
                new(3),
                new(4),
                new(5)
            };
        }

        public List<ItemButton> ButtonList { get; }
    }
}