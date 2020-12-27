using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndInventory
{
    // This class is intended for accounting for products of various types in a warehouse.
    public class InventoryManager
    {
        # region Propertys
        // Property for recording and displaying products of all types in the warehouse.
        public List<Product> Products { get; set; }

        // Property for recording and displaying products of the first type in the warehouse.
        public List<Product> ProductsId1 { get; set; }

        // Property for recording and displaying products of the second type in the warehouse.
        public List<Product> ProductsId2 { get; set; }

        // Property for recording and displaying products of the third type in the warehouse.
        public List<Product> ProductsId3 { get; set; }
        #endregion

        /// <summary>
        /// Displays all products in the warehouse sorted by type.
        /// </summary>
        # region ShowProducts
        public void ShowProducts()
        {
            Console.WriteLine("\n");

            // Sort by type.
            var sortedProductId = Products.OrderBy(p => p.Id);

            // Displays all products sorted by type.
            foreach (Product product in sortedProductId)
            {
                Console.Write("Name: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{product.Name}");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(", Count: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{product.Count}");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(", Price per item: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{product.Price}$");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new string('-', 50));
                Console.ForegroundColor = ConsoleColor.Gray;
            }
           
            Console.WriteLine("\n");
        }
        #endregion

        /// <summary>
        /// Distribution of all products by type.
        /// </summary>
        #region BreakdownByType
        public void BreakdownByType()
        {
            ProductsId1 = new List<Product>();

            ProductsId2 = new List<Product>();

            ProductsId3 = new List<Product>();

            // If a product collection has been created and contains at least one product.
            if (Products != null && Products.Count > 0)
            {
                // We add a product of a certain type to the corresponding collection.
                foreach (Product product in Products)
                {
                    switch (product.Id)
                    {
                        case 1: ProductsId1.Add(product); break;
                        case 2: ProductsId2.Add(product); break;
                        case 3: ProductsId3.Add(product); break;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Display of products and the sum of their quantity by type.
        /// </summary>
        /// <param name="products"></param>
        /// <param name="nameCategory"></param>
        #region ShowPrAndSumItems
        public void ShowPrAndSumItems(List<Product> products, string nameCategory)
        {
            int countElements = 0;

            if (products.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Products category {nameCategory}:");
                Console.ForegroundColor = ConsoleColor.Gray;

                foreach (Product product in products)
                {
                    countElements += product.Count;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new string('-', 50));
                Console.ForegroundColor = ConsoleColor.Gray;

                foreach (Product product in products)
                {
                    Console.Write("Name: ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{product.Name}");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write(", Count: ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{product.Count}");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write(", Price per item: ");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{product.Price}$");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(new string('-', 50));
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.Write("Total number of elements: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(countElements);

                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"There are no products in the category {nameCategory} in stock.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        #endregion
    }
}
