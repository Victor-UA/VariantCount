using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariantCount
{
    class Item
    {
        public string Name { get; private set; }
        public double Price;
        public string Description;

        public Item(string name, double price = 0, string description = "")
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
