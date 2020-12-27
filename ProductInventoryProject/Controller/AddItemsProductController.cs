using ProductAndInventory;
using ProductInventoryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryProject.Controller
{
    class AddItemsProductController
    {
        MyModel<Product> _products;

        public AddItemsProductController(MyModel<Product> products)
        {
            _products = products;
        }

        /// <summary>
        /// The method adds the entered quantity of goods already in the warehouse, 
        /// but not more than the maximum quantity.
        /// </summary>
        /// <param name="products"></param>
        #region Add items
        public void AddItems(MyModel<Product> products)
        {
            // You can add something only if there are already goods in the warehouse.
            if (products.Products.Count > 0)
            {
                // First, we enter the name of the product, the quantity of which we want to increase.
                Console.WriteLine("Enter a product name to increase the number of items in warehouse: ");

                string nameItemAdd = Console.ReadLine();

                int countAdd = 0;

                // The flag provides an exit from the loop.
                bool flag = false;

                // First, we find the product with the desired name, 
                // then enter the quantity by which we want to increase.
                for (int index = 0; index < products.Products.Count; index++)
                {
                    if (nameItemAdd == products.Products[index].Name)
                    {
                        while (true)
                        {
                            Console.WriteLine("Enter the number of items to add: ");

                            countAdd = EnterCountAddOrRemove("add");

                            // If the sum of the entered value and the quantity of this product 
                            // already in the warehouse is greater than the maximum possible quantity 
                            // that can be stored, then we display a message about this and offer to enter another value.
                            if ((products.Products[index].Count + countAdd) > 100)
                            {
                                Console.Clear();

                                Console.WriteLine($"The warehouse can store no more than 100 items {products.Products[index].Name}.\nEnter a number from 1 to {100 - products.Products[index].Count}: ");

                                continue;
                            }
                            // If the amount is less than or equal, then we add the entered value to the existing one.
                            else
                            {
                                products.Products[index].Count += countAdd;

                                break;
                            }
                        }
 
                        flag = true;

                        break;
                    }
                }
                // If there is no product with this name in stock, we display a message about it.
                if (!flag)
                {
                    Console.WriteLine("No product found with this name!");

                    Console.ReadKey();
                }
            }
            // If the goods are in stock, then just exit the method.
            else
            {
                return;
            }
        }
        #endregion

        /// <summary>
        /// The method provides input of the quantity of the added item.
        /// </summary>
        /// <returns></returns>
        #region Enter count for add
        public static int EnterCountAddOrRemove(string addOrRemove)
        {
            var countAdd = 0;

            // The loop checks the compliance of the format of the input value and its overflow.
            while (true)
            {
                try
                {
                    countAdd = int.Parse(Console.ReadLine());

                    break;
                }
                catch (Exception ex)
                {
                    // It checks which exception was thrown and forcibly 
                    // throws this exception with the required message.
                    try
                    {
                        if (ex.GetType().ToString() == "System.FormatException")
                        {
                            throw new FormatException($"Enter the number of items to {addOrRemove}: ");
                        }
                        else if (ex.GetType().ToString() == "System.OverflowException")
                        {
                            throw new OverflowException($"Enter the number of items to {addOrRemove}: ");
                        }
                        else
                        {
                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\r" + ex.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    catch (OverflowException exc)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\r" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    catch (FormatException exc)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\r" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }

            return countAdd;
        }
        #endregion
    }
}
