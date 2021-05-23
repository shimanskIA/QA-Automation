using System;
using System.Collections.Generic;
using System.Text;

namespace HW7
{
    public class InventoryControl<T>
    {
        public int Amount { get; set; }
        public T Item { get; set; }

        public InventoryControl(int amount, T item)
        {
            Amount = amount;
            Item = item;
        }
    }
}
