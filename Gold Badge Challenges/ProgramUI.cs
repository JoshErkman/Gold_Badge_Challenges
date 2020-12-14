using Gold_Badge_Challenges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Badge_Challenges
{
    class ProgramUI
    {
        private Menu_Repository _menu = new Menu_Repository();
        public void Run()
        {
            SeedMenu();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                // Display options to user
                Console.WriteLine("Select a menu option:\n" +
                    "1. View All Menu Items\n" +
                    "2. Add Menu Item\n" +
                    "3. Remove Menu Item\n" +
                    "4. Exit");

                // Get users input
                string input = Console.ReadLine();

                // Evaluate the user input and act accordingly
                switch (input)
                {
                    case "1":
                        // View all menu items
                        DisplayAllMenuItems();
                        break;

                    case "2":
                        // Add Menu Item
                        CreateNewMenuItem();
                        break;

                    case "3":
                        // Delete Menu Item
                        DeleteMenuItem();
                        break;

                    case "4":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create new menu item
        private void CreateNewMenuItem()
        {
            Console.Clear();

            // Create new menu item
            Menu_Item item = new Menu_Item();

            // Get Menu Number
            Console.WriteLine("Give this item a number on the menu.");
            item.MealNumber = Console.ReadLine();

            // Get Item name
            Console.WriteLine("Enter the item name:");
            item.MealName = Console.ReadLine();

            // Get meal description
            Console.WriteLine("Enter item description:");
            item.MealDescription = Console.ReadLine();

            // Create new list for object
            item.Ingredients = new List<string>();

            bool keepAdding = true;
            while (keepAdding)
            {
                Console.WriteLine("\nEnter ingredient:");
                string ingredient = Console.ReadLine();

                if (!item.Ingredients.Contains(ingredient))
                {
                    item.Ingredients.Add(ingredient);
                }
                else
                {
                    Console.WriteLine("This ingredient already exist.");
                }


                bool anotherTry = true;

                while (anotherTry)
                {
                    Console.WriteLine("Would you like to add another ingredient? Y/N ");
                    string answer = Console.ReadLine().ToLower();

                    if(answer == "y")
                    {
                        keepAdding = true;
                        anotherTry = false;    
                    }
                    else if(answer == "n")
                    {
                        keepAdding = false;
                        anotherTry = false;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Entry! Try again.");
                    }
                     
                    
                }
                
            }

            // Get item price
            Console.WriteLine("Enter the price for this item:");
            string priceAsString = Console.ReadLine();
            double priceAsDouble = double.Parse(priceAsString);
            item.MealPrice = priceAsDouble;

            // Add Item to Menu
            _menu.AddMenuItem(item);
        }

        // Read all Menu Items
        private void DisplayAllMenuItems()
        {
            Console.Clear();

            List<Menu_Item> listOfMenuItems = _menu.GetMenu();
            foreach (Menu_Item item in listOfMenuItems)
            {
                Console.WriteLine($"\nNumber: {item.MealNumber}\n" +
                    $"Name: {item.MealName}\n" +
                    $"Description: {item.MealDescription}\n" +
                    $"Price: {item.MealPrice}");

                ListOfIngredients(item);
                    
            }

            
        }

        // View All ingredients helper method
        private void ListOfIngredients(Menu_Item item)
        {
            Console.WriteLine("\nIngredients:");
            foreach (string ingredient in item.Ingredients)
            {
                Console.WriteLine(ingredient);
            }
        }

        // Delete Menu Item
        private void DeleteMenuItem()
        {
            // Display Menu Items
            DisplayAllMenuItems();

            // Get menu number the user would like to delete
            Console.WriteLine("\nEnter the menu number of the item you would like to remove from the menu:");
            string input = Console.ReadLine();

            // Call the delete method
            bool WasDeleted = _menu.RemoveItemFromMenu(input);

            // check to see the item was actually deleted
            if (WasDeleted)
            {
                Console.WriteLine("\nThe item was successfully removed from the menu.");
            }
            else
            {
                Console.WriteLine("\nThe item was unable to be removed from the menu.");
            }
        }

                
        public void SeedMenu()
        {
            // seed menu items
            Menu_Item itemOne = new Menu_Item("1", "Royale With Cheese", "Amazing cheesy goodness.", new List<string>() {"Bun", "Meat", "Cheese"}, 3.99);
            Menu_Item itemTwo = new Menu_Item("2", "Chicken Sammy", "Juicy Juicy Juicy", new List<string>() { "Bun", "Chicken", "Tomato", "Lettuce", "Special Sauce" }, 4.99);

            _menu.AddMenuItem(itemOne);
            _menu.AddMenuItem(itemTwo);
        }




            

    }
}
