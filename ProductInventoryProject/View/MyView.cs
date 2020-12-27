using ProductAndInventory;
using ProductInventoryProject.Controller;
using ProductInventoryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryProject.View
{
    static class MyView
    {
        #region Fields
        static int countItemsOfWarehouse = 0;

        static string yesNo = "";

        static byte idProduct = 0;

        static string[] nameCategory =
        {
            "Vegetables/fruits",
            "Electronics",
            "Furniture"
        };

        static MyModel<Product> products = new MyModel<Product>();

        static InventoryManager inventoryManager = new InventoryManager();

        static AddProductController addProduct = new AddProductController(products);

        static RemoveProductController removeProduct = new RemoveProductController(products);

        static AddItemsProductController addItemsProduct = new AddItemsProductController(products);

        static RemoveItemsProductController removeItemsProduct = new RemoveItemsProductController(products);
        #endregion

        ///<summary>
        ///Greeting output.
        ///</summary>
        #region Show greeting
        static void ShowGreeting()
        {
            // Greeting output
            // Output of the inscription approximately to the middle of the window
            Console.Write("\t\t");

            var greeting = "Hello! Welcome to the program that simulates working with a warehouse for storing food.";

            // Change font and background color
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(greeting);

            // Return color and background
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();
        }
        #endregion

        /// <summary>
        /// The method displays the main menu of the program.
        /// </summary>
        #region Main menu
        static void MainMenu()
        {
            Console.Write("\t");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("MENU:");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();

            Console.WriteLine("press 1 to add products to warehouse;");
            Console.WriteLine("press 2 to remove products from warehouse;");
            Console.WriteLine("press 3 to add the quantity of some product in warehouse;");
            Console.WriteLine("press 4 to remove a certain amount of a product from warehouse;");
            Console.WriteLine("press 5 to view products in warehouse;");
            Console.WriteLine("press 6 for program information;");
            Console.WriteLine("press 7 to exit the program.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("select the required action: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        /// <summary>
        /// The method provides input of the required menu action.
        /// </summary>
        /// <returns></returns>
        #region Enter number main menu
        static int EnterNumberMainMenu()
        {
            var numberMenu = 0;

            // Cycle until one of the menu item numbers is entered
            while (true)
            {
                // The required menu number is entered, taking into account 
                // the overflow and the format of the entered number.
                try
                {
                    numberMenu = int.Parse(Console.ReadLine());

                    var condition = numberMenu > 0 && numberMenu < 8;

                    if (condition)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("Enter a number from 1 to 7: ");
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.GetType().ToString() == "System.FormatException")
                        {
                            throw new FormatException("Enter a number from 1 to 7: ");
                        }
                        else if (ex.GetType().ToString() == "System.OverflowException")
                        {
                            throw new OverflowException("Enter a number from 1 to 7: ");
                        }
                        else
                        {
                            Console.Clear();

                            MainMenu();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\r" + ex.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    catch (OverflowException exc)
                    {
                        Console.Clear();

                        MainMenu();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\r" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    catch (FormatException exc)
                    {
                        Console.Clear();

                        MainMenu();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\r" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }

            return numberMenu;
        }
        #endregion

        /// <summary>
        /// The method reacts to the entered menu value and 
        /// performs the action corresponding to it (number).
        /// </summary>
        #region Working out the number of the main menu (SwitchProgram).
        static void SwitchProgram()
        {
            switch (EnterNumberMainMenu())
            {
                // Adding a product.
                case 1:
                    {
                        Console.Clear();

                        AddingProcuct(addProduct);
                    }
                    break;

                // Removing an item.
                case 2:
                    {
                        Console.Clear();

                        if (products.Products.Count == 0)
                        {
                            InventoryManager();
                        }
                        else
                        {
                            RemovingProduct(removeProduct);
                        }
                    }
                    break;

                // Increase in the quantity of goods.
                case 3:
                    {
                        Console.Clear();

                        InventoryManager();

                        addItemsProduct.AddItems(products);
                    }
                    break;

                // Reducing the quantity of goods.
                case 4:
                    {
                        Console.Clear();

                        InventoryManager();

                        removeItemsProduct.RemoveItems(products, ref countItemsOfWarehouse);
                    }
                    break;

                // Display of goods of all categories and the amount of their quantity in the warehouse.
                case 5:
                    {
                        Case5ForSwitchProgram();
                    }
                    break;

                // Displaying information about the program.
                case 6:
                    {
                        Console.Clear();

                        AboutProgram();
                    }
                    break;

                // Exit the program.
                case 7: Environment.Exit(0); break;
            }
        }
        #endregion

        /// <summary>
        /// The method displays products and their quantity in the warehouse by category.
        /// </summary>
        #region Display of goods by category (Case5ForSwitchProgram).
        static void Case5ForSwitchProgram()
        {
            Console.Clear();

            inventoryManager.BreakdownByType();

            inventoryManager.ShowPrAndSumItems(inventoryManager.ProductsId1, nameCategory[0]);

            Console.WriteLine("\n");

            inventoryManager.ShowPrAndSumItems(inventoryManager.ProductsId2, nameCategory[1]);

            Console.WriteLine("\n");

            inventoryManager.ShowPrAndSumItems(inventoryManager.ProductsId3, nameCategory[2]);

            Console.ReadKey();
        }
        #endregion

        /// <summary>
        /// The method displays the menu used when adding and removing products.
        /// </summary>
        #region Start menu
        public static void StartMenu()
        {
            Console.WriteLine("You have a warehouse for storing three types of goods:");
            Console.WriteLine("1 - Vegetables/fruits;");
            Console.WriteLine("2 - Electronics;");
            Console.WriteLine("3 - Furniture.\n");
            Console.WriteLine($"There are currently {countItemsOfWarehouse} items in stock.");
            Console.Write("Add a product? ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("(Y/N) ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion

        /// <summary>
        /// The method that collected all the steps to add an item to the warehouse.
        /// </summary>
        /// <param name="addProduct"></param>
        #region Adding product
        static void AddingProcuct(AddProductController addProduct)
        {
            // Adding product
            while (true)
            {
                StartMenu();

                addProduct.YesNo(ref yesNo);

                addProduct.ValueYesNo(ref yesNo);

                if (yesNo == "n")
                {
                    break;
                }

                addProduct.EnterNumberAddMenu(ref idProduct);

                addProduct.SwitchNumberAddMenu(ref idProduct, ref countItemsOfWarehouse, ref yesNo);
            }
        }
        #endregion

        /// <summary>
        /// The method that collected all the steps to remove an item from the warehouse.
        /// </summary>
        /// <param name="removeProduct"></param>
        #region Removing product
        static void RemovingProduct(RemoveProductController removeProduct)
        {
            Console.Clear();

            while (true)
            {
                InventoryManager();

                removeProduct.RemoveMenu();

                removeProduct.YesNo(ref yesNo);

                removeProduct.ValueYesNo(ref yesNo, ref countItemsOfWarehouse);

                if (yesNo == "n")
                    break;
            }
        }
        #endregion

        /// <summary>
        /// The method tracks all changes in the warehouse and displays 
        /// all available items on the screen.
        /// </summary>
        #region Inventory manager
        static void InventoryManager()
        {
            Console.Clear();

            inventoryManager.Products = products.Products;

            // If there are goods in the warehouse, then all their data is displayed.
            if (inventoryManager.Products.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The following products are in warehouse: ");
                Console.ForegroundColor = ConsoleColor.Gray;

                inventoryManager.ShowProducts();
            }
            // If there are no goods in the warehouse, a message about this is displayed.
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are currently no products in warehouse.\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        #endregion

        /// <summary>
        /// The method displays information about the program 
        /// (version, program and developer capabilities).
        /// </summary>
        #region About program
        static void AboutProgram()
        {
            Console.WriteLine("A program that simulates work with a product warehouse, version 1.0");
            Console.WriteLine();
            Console.WriteLine("Allows you to perform the following operations:");
            Console.WriteLine("- adding products to the warehouse;");
            Console.WriteLine("- removal of products from the warehouse;");
            Console.WriteLine("- increasing and decreasing the number of products already in warehouse;");
            Console.WriteLine("- counting and displaying the number of items by product category.");
            Console.WriteLine();
            Console.WriteLine("Developer - Yarmalkevich V.I.");

            Console.ReadKey();
        }
        #endregion

        /// <summary>
        /// The method starts the program for execution.
        /// </summary>
        #region Start program
        public static void StartProgram()
        {
            bool flag = true;

            ShowGreeting();

            while (true)
            {
                // At the first launch, there are no products yet, 
                // so not all functionality is needed.
                if (!flag)
                {
                    Console.Clear();

                    InventoryManager();
                }

                MainMenu();

                SwitchProgram();

                flag = false;
            }
        }
        #endregion
    }
}
