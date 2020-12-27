using ProductAndInventory;
using ProductInventoryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryProject.Controller
{
    class RemoveItemsProductController
    {
        MyModel<Product> _products;

        public RemoveItemsProductController(MyModel<Product> products)
        {
            _products = products;
        }

        /// <summary>
        /// A method for removing a certain amount of an item from an item already in stock.
        /// </summary>
        /// <param name="products"></param>
        /// <param name="countItemsOfWarehouse"></param>
        #region Remove items product
        public void RemoveItems(MyModel<Product> products, ref int countItemsOfWarehouse)
        {
            // The logic of this method is the same as for the method 
            // of adding the quantity of goods to the warehouse.
            if (products.Products.Count > 0)
            {
                Console.WriteLine("Enter a product name to reduce the number of items in warehouse: ");

                string nameItemAdd = Console.ReadLine();

                int countAdd = 0;

                bool flag = false;

                for (int index = 0; index < products.Products.Count; index++)
                {
                    if (nameItemAdd == products.Products[index].Name)
                    {
                        while (true)
                        {
                            Console.WriteLine("Enter the number of items to remove: ");

                            countAdd = EnterCountRemove();

                            if ((products.Products[index].Count - countAdd) < 0)
                            {
                                Console.Clear();

                                Console.WriteLine($"There can be no {products.Products[index].Name} less than zero in the warehouse.\nEnter a number from 1 to {products.Products[index].Count}: ");

                                continue;
                            }
                            // If, when deleting, the quantity of an item with this name is equal to zero, 
                            // then such item is completely removed from the warehouse.
                            if ((products.Products[index].Count - countAdd) == 0)
                            {
                                products.Delete(index);

                                countItemsOfWarehouse--;

                                break;
                            }
                            else
                            {
                                products.Products[index].Count -= countAdd;

                                break;
                            }
                        }

                        flag = true;

                        break;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("No product found with this name!");

                    Console.ReadKey();
                }
            }
            else
            {
                return;
            }
        }
        #endregion

        /// <summary>
        /// The method provides input of the quantity of the removed item.
        /// </summary>
        /// <returns></returns>
        #region Enter count for remove
        public int EnterCountRemove()
        {
            var countRemove = AddItemsProductController.EnterCountAddOrRemove("remove");

            return countRemove;
        }
        #endregion
    }
}
