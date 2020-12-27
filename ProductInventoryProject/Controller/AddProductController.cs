using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductInventoryProject.Model;
using ProductAndInventory;

namespace ProductInventoryProject.Controller
{
    // A class for adding a product of one type to a warehouse.
    class AddProductController
    {
        MyModel<Product> _products;

        // When creating an instance of the class, it will work directly 
        // with the collection of products stored in the warehouse.
        public AddProductController(MyModel<Product> products)
        {
            _products = products;
        }

        /// <summary>
        /// Method for entering yes or no 
        /// (consent or disagreement to add an item to the product collection).
        /// </summary>
        /// <param name="yesNo"></param>
        #region Enter yes or no
        public void YesNo(ref string yesNo)
        {
            // The method must assign some value to a variable from 
            // another class, so the ref parameter is passed to ref. 

            // The cycle will continue until it is entered "y" or "n".
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
        #region Value yes/no
        public void ValueYesNo(ref string yesNo)
        {
            switch (yesNo)
            {
                case "y": AddMenu(); break;
                case "n": Console.Clear(); break;
                default: Console.WriteLine("You have not chosen an action."); break;
            }
        }
        #endregion

        /// <summary>
        /// Method for displaying the menu when adding an item to the collection.
        /// </summary>
        #region AddMenu
        public void AddMenu()
        {
            Console.Clear();

            Console.Write("\t");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Add Menu:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Select the item category number to enter:");
            Console.WriteLine("1 - Vegetables/fruits;");
            Console.WriteLine("2 - Electronics;");
            Console.WriteLine("3 - Furniture.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nEnter the number: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        /// <summary>
        /// A method that allows you to enter a number corresponding 
        /// to one of the items added to the collection.
        /// </summary>
        /// <param name="idProduct"></param>
        #region Enter number AddMenu
        public void EnterNumberAddMenu(ref byte idProduct)
        {
            while (true)
            {
                try
                {
                    idProduct = byte.Parse(Console.ReadLine());

                    var condition = idProduct > 0 && idProduct < 4;

                    if (condition)
                    {
                        break;
                    }
                    // If a number is entered, but its value does not meet 
                    // the condition, then an exception is forced.
                    else
                    {
                        throw new Exception("Enter a number from 1 to 3: ");
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        // If a non-number is entered, a type mismatch exception with 
                        // the required message is forced, and when it is processed, 
                        // this message is displayed on the screen and the value is re-entered.
                        if (ex.GetType().ToString() == "System.FormatException")
                        {
                            throw new FormatException("Enter a number from 1 to 3: ");
                        }
                        // The same goes for excluding the overflow value of 
                        // the quantity of goods that can be stored in the warehouse.
                        else if (ex.GetType().ToString() == "System.OverflowException")
                        {
                            throw new OverflowException("Enter a number from 1 to 3: ");
                        }
                        else
                        {
                            Console.Clear();

                            AddMenu();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\r" + ex.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    catch (OverflowException exc)
                    {
                        Console.Clear();

                        AddMenu();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\r" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    catch (FormatException exc)
                    {
                        Console.Clear();

                        AddMenu();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\r" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// A method that adds to the warehouse a product of 
        /// the type that matches the entered number from the menu.
        /// </summary>
        /// <param name="idProduct"></param>
        /// <param name="countItems"></param>
        /// <param name="yesNo"></param>
        #region Processing the entered menu number.
        public void SwitchNumberAddMenu(ref byte idProduct, ref int countItems, ref string yesNo)
        {
            // Variable to account for the way food is stored in the warehouse 
            // (vegetables, fruits are stored in boxes).
            string storageMethod = "";

            // Variable for one of three types of products.
            string typeOfProduct = "";

            switch (idProduct)
            {
                case 1:
                    {
                        storageMethod = "boxes";

                        typeOfProduct = "fruit or vegetable";

                        CaseNumberAddMenu(storageMethod, typeOfProduct, ref countItems, ref yesNo, ref idProduct);
                    }
                    break;
                case 2:
                    {
                        storageMethod = "items";

                        typeOfProduct = "electronics";

                        CaseNumberAddMenu(storageMethod, typeOfProduct, ref countItems, ref yesNo, ref idProduct);
                    }
                    break;
                case 3:
                    {
                        storageMethod = "items";

                        typeOfProduct = "furniture";

                        CaseNumberAddMenu(storageMethod, typeOfProduct, ref countItems, ref yesNo, ref idProduct);
                    }
                    break;

            }
        }
        #endregion

        /// <summary>
        /// The method implements all options for adding goods to the warehouse.
        /// </summary>
        /// <param name="storageMethod"></param>
        /// <param name="typeOfProduct"></param>
        /// <param name="countItems"></param>
        /// <param name="yesNo"></param>
        /// <param name="idProduct"></param>
        #region CaseNumberAddMenu
        public void CaseNumberAddMenu(string storageMethod, string typeOfProduct, ref int countItems, ref string yesNo, ref byte idProduct)
        {
            Console.Clear();

            // Name, count and price of the goods added to the warehouse.
            string nameProduct = "No name";

            int countProduct = 0;

            decimal priceProduct = 0m;

            Console.Write($"Enter the name of the {typeOfProduct}: ");
            nameProduct = Console.ReadLine();

            string.Intern(nameProduct);

            // Checking whether there is already an item with the same name in stock.
            for (int index = 0; index < _products.Products.Count; index++)
            {
                if (nameProduct == _products.Products[index].Name)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is already a product with this name.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    return;
                }
            }

            // All properties of the added product, except for the name, must be entered 
            // taking into account the check for compliance of types and values.
            Console.Write($"Enter the number of {storageMethod}: ");
            while (true)
            {
                try
                {
                    countProduct = int.Parse(Console.ReadLine());

                    var condition = countProduct > 0 && countProduct < 101;

                    if (condition)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception($"The warehouse can store no more than 100 {storageMethod}.\nEnter a number from 1 to 100: ");
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.GetType().ToString() == "System.FormatException")
                        {
                            throw new FormatException($"The warehouse can store no more than 100 boxes {storageMethod}.\nEnter a number from 1 to 100: ");
                        }
                        else if (ex.GetType().ToString() == "System.OverflowException")
                        {
                            throw new OverflowException($"The warehouse can store no more than 100 {storageMethod}.\nEnter a number from 1 to 100:  ");
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine($"Enter the number of {storageMethod} {nameProduct}.");

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(ex.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    catch (OverflowException exc)
                    {
                        Console.Clear();

                        Console.WriteLine($"Enter the number of {storageMethod} {nameProduct}.");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    catch (FormatException exc)
                    {
                        Console.Clear();

                        Console.WriteLine($"Enter the number of {storageMethod} {nameProduct}.");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }

            Console.Write($"Enter the price for {nameProduct}: ");
            while (true)
            {
                try
                {
                    priceProduct = decimal.Parse(Console.ReadLine());

                    break;
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.GetType().ToString() == "System.FormatException")
                        {
                            throw new FormatException("Enter a price value, for example 2,99: ");
                        }
                        else if (ex.GetType().ToString() == "System.OverflowException")
                        {
                            throw new OverflowException("Enter the real price for this product: ");
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine($"Enter the number of {storageMethod} {nameProduct}.");

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(ex.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    catch (OverflowException exc)
                    {
                        Console.Clear();

                        Console.WriteLine($"Enter the price {nameProduct}.");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    catch (FormatException exc)
                    {
                        Console.Clear();

                        Console.WriteLine($"Enter the price {nameProduct}.");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }

            // Increase in the number of items of goods stored in the warehouse.
            countItems++;

            // Zeroing the string yes/no for further correct use.
            yesNo = "";

            // Adding a product with the entered field values.
            _products.Add(new Product(nameProduct, countProduct, priceProduct, idProduct));

            Console.Clear();
        }
        #endregion
    }
}
