using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndInventory
{
    // This class is intended to describe products that will be stored in a warehouse.
    public class Product
    {
        // A property for writing and reading the product name.
        public string Name { get; set; }

        // A property used to write and read the number of products of a given type.
        public int Count { get; set; }

        // A property intended for recording and reading the price of products of a given type.
        public decimal Price { get; set; }

        // Property intended only for reading the type of products.
        public byte Id { get; }

        // Default constructor.
        public Product() { }

        // A constructor with parameters that are set to default 
        // values if a simple object of this class is created.
        public Product(string name = "NoName", int count = 0, decimal price = 0m, byte id = 0)
        {
            // If other field values are set during class object creation, 
            // they will be assigned to the corresponding object fields.
            Name = name;

            Count = count;

            Price = price;

            Id = id;
        }
    }
}
