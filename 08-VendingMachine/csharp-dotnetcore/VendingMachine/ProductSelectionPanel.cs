using System.Collections.Generic;

namespace VendingMachine
{
    public class ProductSelectionPanel
    {
        public ProductSelectionPanel()
        {
            ButtonList = new List<ItemButton>
            {
                new ItemButton(3),
                new ItemButton(4),
                new ItemButton(5)
            };
        }

        public List<ItemButton> ButtonList { get; }
    }
}