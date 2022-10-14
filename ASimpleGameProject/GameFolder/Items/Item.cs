using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleGameProject.Items
{
    internal class Item
    {
        public string ItemName { get; private set; }
        private string ItemType { get; set; }
        private int ItemCount { get; set; }
        private int ItemPrice { get; set; }
        public Weapon Weapon { get; set; }

        public Item(string name, string type, int count, int price)
        {
            ItemName = name;
            ItemType = type;
            ItemCount = count;
            ItemPrice = price;
        }
    }
}
