using ProductAndInventory;
using ProductInventoryProject.Model;
using ProductInventoryProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryProject.Controller
{
    class RemoveProductController
    {
        MyModel<Product> _products;

        public RemoveProductController(MyModel<Product> products)
        {
            _products = products;
        }

        /// <summary>
        /// The method displays a menu for selecting a product category to be deleted.
        /// </summary>
        #region Remove menu
        public void RemoveMenu()
        {
            MyView.StartMenu();

            Console.Write("\rRemove a product? ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("(Y/N) ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        /// <summary>
        /// Input method "yes" or "no" 
        /// (consent or disagreement to remove an item from the collection).
        /// </summary>
        /// <param name="yesNo"></param>
        #region Enter yes or no
        public void YesNo(ref string yesNo)
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    yesNo = Console.ReadLine();

                    if (yesNo.ToLower() == "y" || yesNo.ToLower() == "n")
                        break;
                    else
                        throw new Exception("You must enter either 'y' or 'n'.");
                }
                catch (Exception ex)
                {
                    Console.Clear();

                    Console.WriteLine("(Y/N) ");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(ex.Message + " ");
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        /// <summary>
        /// The method, depending on the yes/no value, does one or another action.
        /// </summary>
        /// <param name="yesNo"></param>
        /// <param name="countItems"></param>
        #region Value yes or no
        public void ValueYesNo(ref string yesNo, ref int countItems)
        {
            switch (yesNo)
            {
                case "y": RemoveProduct(ref countItems); break;
                case "n": break;
                default: Console.WriteLine("You have not chosen an action."); break;
            }
        }
        #endregion

        /// <summary>
        /// The method removes products from the collection by its name.
        /// </summary>
        /// <param name="countItems"></param>
        #region Remove product
        public void RemoveProduct(ref int countItems)
        {
            // If there are goods in the warehouse, then choose which one to delete.
            if (countItems > 0)
            {
                Console.Write("Enter product name for complete removal: ");

                bool flag = false;

                string nameCompleteRem = Console.ReadLine();

                // Comparison of the entered product name with those in stock. 
                // If there is such a product, then delete it, if not, then 
                // display a message about it.
                for (int index = 0; index < _products.Products.Count; index++)
                {
                    if (nameCompleteRem == _products.Products[index].Name)
                    {
                        _products.Delete(index);

                        flag = true;

                        break;
                    }
                }

                if (!flag)
                {
                    Console.WriteLine("No product found with this name!");

                    Console.ReadKey();

                    return;
                }

                countItems--;
            }
            // If there are no goods in the warehouse, then we display a message about it.
            else
            {
                Console.WriteLine("There are currently no products in stock.");
            }
        }
    }
    #endregion
}
