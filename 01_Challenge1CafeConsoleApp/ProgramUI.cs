using _01_Challenge1Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge1CafeConsoleApp
{
    class ProgramUI
    {
        private MenuItemRepo _menuItemRepo = new MenuItemRepo();

        public void Run()
        {
            SeedMenuList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to the Komodo Cafe Management Application.");
                Console.ResetColor();

                Console.WriteLine("\nPlease choose from the following options:\n" +
                    "\n1. View All Menu Items\n" +
                    "2. Add New Menu Item\n" +
                    "3. Delete Menu Item\n" +
                    "4. Exit Application\n\n" +
                    "Please enter your selection:");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewMenuItems();
                        break;
                    case "2":
                        AddMenuItems();
                        break;
                    case "3":
                        DeleteMenuItems();
                        break;
                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Thank you for using Komodo Cafe Management Application. Goodbye!\n");
                        Console.ResetColor();

                        keepRunning = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your selection was invalid. Please enter a valid number.");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ViewMenuItems()
        {
            Console.Clear();
            List<MenuItem> listOfMenuItems = _menuItemRepo.GetMenuList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The Komodo Cafe Menu\n");
            Console.ResetColor();
            Console.WriteLine("Our current menu offerings are:\n");

            foreach (MenuItem item in listOfMenuItems)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Meal Number: {item.MealNumber} -- {item.MealName}");
                Console.ResetColor();
                
                Console.WriteLine($"Description: {item.Description}\n" +
                    $"Ingredients: {string.Join(", ", item.Ingredients.ToArray())}" +
                    $"\nPrice: ${item.Price.ToString("0.00")}\n");
            }
        }

        public void AddMenuItems()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();
          
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Adding a New Menu Item");
            Console.ResetColor();

            bool endErrorCheck = false;
            while (endErrorCheck == false)
            {
                int menuNumber = 0;

                Console.WriteLine("\nEnter the new meal number:");

                if (int.TryParse(Console.ReadLine(), out int result) == true)
                {
                    menuNumber = result;
                }

                if (menuNumber <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe meal number must be numeric and greater than zero.\n");
                    Console.ResetColor();
                }
                else
                {
                    MenuItem tempNumber = _menuItemRepo.GetMenuItemByNumber(menuNumber);
                    if (tempNumber != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThis meal number already exists. Please use a different number.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        endErrorCheck = true;
                        newItem.MealNumber = menuNumber;
                    }
                }
            }

            Console.WriteLine("\nEnter the new meal name:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("\nEnter new meal description:");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("\nEnter new meal ingredients. Each ingredient needs to be separated by a comma.");
            string ingredients = Console.ReadLine();

            string[] ingredientArray = ingredients.Split(',');
            foreach (string ingredient in ingredientArray)
            {
                newItem.Ingredients.Add(ingredient);
            }

            Console.WriteLine("\nEnter new meal price (format: 0.00):");
            newItem.Price = double.Parse(Console.ReadLine());

            _menuItemRepo.AddMenuItemToList(newItem);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe item was successfully added to the menu.\n");
            Console.ResetColor();
        }

        public void DeleteMenuItems()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Deleting an Item From the Menu");
            Console.ResetColor();

            Console.WriteLine("\nOur current menu offerings are:\n");

            List<MenuItem> listOfMenuItems = _menuItemRepo.GetMenuList();
            foreach (MenuItem item in listOfMenuItems)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Meal Number: {item.MealNumber} -- {item.MealName}");
                Console.ResetColor();
                Console.WriteLine($"Description: {item.Description}\n");
            }

            bool errorCheck = true;
            while (errorCheck == true)
            {
                Console.WriteLine("Enter the ID Number of the menu item to be deleted:");
                int input = int.Parse(Console.ReadLine());

                bool wasDeleted = _menuItemRepo.RemoveMenuItemFromList(input);
                if (wasDeleted)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThe item was successfully deleted.\n");
                    Console.ResetColor();
                    errorCheck = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe item could not be deleted.\n");
                    Console.ResetColor();
                }
            }
        }

        public void SeedMenuList()
        {
            MenuItem burger = new MenuItem(1, "Cheeseburger", "Classic cheeseburger and fries", new List<string> { "bun", "beef", "cheese", "lettuce", "tomato", "fries" }, 5.95);
            MenuItem tenders = new MenuItem(2, "Chicken Tenders", "Tenders and fries", new List<string> { "chicken", "fries" }, 4.95);
            MenuItem caesar = new MenuItem(3, "Caesar Salad", "Caesar salad and toast - it's almost healthy", new List<string> { "romaine lettuce", "caesar dressing", "parmesean cheese", "toasted baguette" }, 6.50);
            MenuItem nachos = new MenuItem(4, "Nachos", "Cheese 'n' Chips", new List<string> { "tortilla chips", "nacho cheese", "jalapenos" }, 4.50);

            _menuItemRepo.AddMenuItemToList(burger);
            _menuItemRepo.AddMenuItemToList(tenders);
            _menuItemRepo.AddMenuItemToList(caesar);
            _menuItemRepo.AddMenuItemToList(nachos);
        }
    }
}

