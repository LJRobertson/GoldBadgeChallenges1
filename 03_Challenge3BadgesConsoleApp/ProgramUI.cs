using _03_Challenge3BadgesRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge3BadgesConsoleApp
{
    class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            SeedBadgeDictionary();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to the Komodo Insurance Badge Door Access Application. \n");
                Console.ResetColor();

                Console.WriteLine("What would you like to do?\n" +
                    "\n1. View All Badges and Door Access\n" +
                    "2. Create a New Badge\n" +
                    "3. Update Door Access on a Badge\n" +
                    "4. Exit Application\n\n" +
                    "Please enter your selection:");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllBadgesAndDoors();
                        break;
                    case "2":
                        CreateANewBadge();
                        break;
                    case "3":
                        UpdateDoorAccess();
                        break;
                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Thank you for using Komodo Insurance Badge Door Application. Goodbye!\n");
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

        private void ViewAllBadgesAndDoors()
        {
            Console.Clear();
            Dictionary<int, Badge> badgeDictionary = _badgeRepo.GetBadges();

            string badgeID = "Badge ID";
            string doors = "Door Access";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(badgeID.PadRight(25) + doors);
            Console.ResetColor();

            foreach (KeyValuePair<int, Badge> kvp in badgeDictionary)
            {
                Badge badge = kvp.Value;
                Console.WriteLine("\n" + kvp.Key.ToString().PadRight(25) + string.Join(", ", badge.DoorNamesList.ToArray()));
            }
            Console.ReadLine();
        }

        private void CreateANewBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Creating a New Badge\n");
            Console.ResetColor();

            bool endErrorCheck = false;
            while (endErrorCheck == false)
            {
                int badgeNumber = 0;

                Console.WriteLine("Enter the new Badge ID number:");
                if (int.TryParse(Console.ReadLine(), out int result) == true)
                {
                    badgeNumber = result;
                }
                if (badgeNumber <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe badge number must be numeric and greater than zero.\n");
                    Console.ResetColor();
                }
                else
                {
                    Badge tempNumber = _badgeRepo.GetBadgeByIDNumberTryGetValue(badgeNumber);
                    if (tempNumber != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThis badge number already exists. Please use a different number for the new badge.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        endErrorCheck = true;
                        newBadge.BadgeID = badgeNumber;
                    }
                }
            }

            Console.WriteLine("\nEnter the doors for this badge to have access to. Separate each door with a comma (ie: B25, B27, C11):");
            string doorNames = Console.ReadLine();
            string[] doorArray = doorNames.Split(',');

            foreach (string door in doorArray)
            {
                newBadge.DoorNamesList.Add(door.Trim());
            }
            _badgeRepo.CreateNewBadge(newBadge.BadgeID, newBadge);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nBadge was created successfully!\n");
            Console.ResetColor();
        }

        private void UpdateDoorAccess()
        {
            bool keepUpdateMenuRunning = true;
            while (keepUpdateMenuRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Updating Door Access on a Badge");
                Console.ResetColor();

                Console.WriteLine("\nWhat would you like to do?\n" +
                    "1. Assign Doors to a Badge\n" +
                    "2. Remove Doors from a Badge\n" +
                    "\nOr press any other key to return to the Main Menu.\n\n" +
                    "Please enter your selection:");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Adding Door Access\n");
                        Console.ResetColor();
                        Console.WriteLine("Please select from the following options:\n\n" +
                            "1. Assign All New Doors to a Badge\n" +
                            "\t This will overwrite any doors currently assigned to the Badge.\n\n" +
                            "2. Add a New Door to a Badge\n" +
                            "\t This will add a new door to a Badge. All previous door access will remain unchanged.\n\n" +
                            "Please enter your selection:");
                        string updateInput = Console.ReadLine();
                        switch (updateInput)
                        {
                            case "1":
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Assigning All New Doors to a Badge\n");
                                Console.ResetColor();

                                Console.WriteLine("The Badge will only have access to the doors provided here.\n\n" +
                                    "Please enter the Badge ID of the Badge to be updated:\n");
                                string badgeID = Console.ReadLine();

                                if (_badgeRepo.GetBadgeByIDNumberTryGetValue(Int32.Parse(badgeID)) == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nThe Badge ID entered was invalid. Returning to Update Door Access Menu...\n");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    break;
                                }

                                Console.WriteLine("\nEnter the doors for this badge to have access to. If adding more than one door, separate each door with a comma (ie: B25, B27, C11):");
                                string doorNumbers = Console.ReadLine();

                                _badgeRepo.UpdateDoorsOnBadge(Int32.Parse(badgeID), doorNumbers);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nDoors successfully replaced on Badge {badgeID}.\n");
                                Console.ResetColor();
                                Console.ReadLine();

                                keepUpdateMenuRunning = false;
                                break;

                            case "2":
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Adding a Door to a Badge\n");
                                Console.ResetColor();

                                Console.WriteLine("The Badge will have access to all currently assigned doors plus the door(s) provided here.\n\n" +
                                  "Please enter the Badge ID of the Badge to be updated:\n");
                                string badgeID2 = Console.ReadLine();

                                if (_badgeRepo.GetBadgeByIDNumberTryGetValue(Int32.Parse(badgeID2)) == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nThe Badge ID entered was invalid. Returning to the Update Door Access Menu...\n");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    break;
                                }

                                Console.WriteLine($"\nBadge {badgeID2} currently has access to the following doors:");
                                Badge tempBadge = (_badgeRepo.GetBadgeByIDNumberTryGetValue(Int32.Parse(badgeID2)));
                                string doorList = tempBadge.DoorNamesList.ToString();
                                Console.WriteLine(string.Join(", ", tempBadge.DoorNamesList.ToArray()));

                                Console.WriteLine("\nEnter the doors to be added to this badge. If adding more than one door, separate each door with a comma(ie: B25, B27, C11):\n");
                                string doorNumbers2 = Console.ReadLine();

                                Badge errorCheckBadge = _badgeRepo.GetBadgeByIDNumberTryGetValue(Int32.Parse(badgeID2));
                                int initialDoorCount = errorCheckBadge.DoorNamesList.Count;

                                _badgeRepo.AddDoorsToBadge(Int32.Parse(badgeID2), doorNumbers2);

                                int newDoorCount = errorCheckBadge.DoorNamesList.Count;
                                if (initialDoorCount >= newDoorCount)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\nError: Unable to add door(s) to Badge {badgeID2}.\n");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    break;
                                }

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nDoors successfully added to Badge {badgeID2}.\n");
                                Console.ResetColor();
                                Console.ReadLine();

                                keepUpdateMenuRunning = false;
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Invalid selection. Returning to previous menu...\n");
                                Console.ResetColor();
                                Console.ReadLine();
                                break;
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Removing Door Access\n");
                        Console.ResetColor();

                        Console.WriteLine("Please select from the following options:\n\n" +
                        "1. Remove All Doors From a Badge\n" +
                        "\t This will delete any doors currently assigned to the Badge.\n\n" +
                        "2. Remove Selected Door(s) From a Badge\n" +
                        "\t This will remove requested door(s) from a Badge. All other door access will remain unchanged.\n\n" +
                        "Please enter your selection:");

                        string removeInput = Console.ReadLine();
                        switch (removeInput)
                        {
                            case "1":
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Removing All Doors From Badge\n");
                                Console.ResetColor();

                                Console.WriteLine("All door access permissions will be permanently removed from entered Badge.\n\n" +
                                 "Please enter the Badge ID of the Badge to be updated:");
                                string badgeID = Console.ReadLine();

                                if (_badgeRepo.GetBadgeByIDNumberTryGetValue(Int32.Parse(badgeID)) == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nThe Badge ID entered was invalid. Returning to the Updating Door Access Menu...\n");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    break;
                                }

                                _badgeRepo.RemoveDoorsFromBadge(Int32.Parse(badgeID));

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nDoors successfully deleted on Badge {badgeID}.\n");
                                Console.ResetColor();
                                Console.ReadLine();

                                keepUpdateMenuRunning = false;
                                break;

                            case "2":
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Removing Select Doors From Badge\n");
                                Console.ResetColor();

                                Console.WriteLine("This will remove selected door access permissions to entered Badge. All other door access permissions will remain.\n\n" +
                           "Please enter the Badge ID of the Badge to be updated:");
                                string badgeID2 = Console.ReadLine();

                                if (_badgeRepo.GetBadgeByIDNumberTryGetValue(Int32.Parse(badgeID2)) == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nThe Badge ID entered was invalid. Returning to the Updating Door Access Menu...\n");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    break;
                                }

                                Console.WriteLine($"\nBadge {badgeID2} currently has access to the following doors:");
                                Badge tempBadge = (_badgeRepo.GetBadgeByIDNumberTryGetValue(Int32.Parse(badgeID2)));
                                string doorList = tempBadge.DoorNamesList.ToString();
                                Console.WriteLine(string.Join(", ", tempBadge.DoorNamesList.ToArray()));

                                Console.WriteLine("\nEnter the doors to be removed this badge. If removing more than one door, separate each door with a comma(ie: B25, B27, C11):\n");
                                string doorNumbers2 = Console.ReadLine();

                                Badge errorCheckBadge = _badgeRepo.GetBadgeByIDNumberTryGetValue(Int32.Parse(badgeID2));
                                int initialDoorCount = errorCheckBadge.DoorNamesList.Count;

                                _badgeRepo.RemoveSelectedDoorsFromBadge(Int32.Parse(badgeID2), doorNumbers2);

                                int newDoorCount = errorCheckBadge.DoorNamesList.Count;

                                if (initialDoorCount <= newDoorCount)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\nError: Unable to remove door(s) from Badge {badgeID2}.\nReturning to the Updating Door Access Menu...");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    break;
                                }

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nDoors successfully removed from Badge {badgeID2}.\n");
                                Console.ResetColor();
                                Console.ReadLine();

                                keepUpdateMenuRunning = false;
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid selection. Returning to previous menu...\n");
                                Console.ResetColor();
                                Console.ReadLine();
                                break;
                        }

                        break;
                    default:
                        Console.WriteLine("Returning to Main Menu...");
                        keepUpdateMenuRunning = false;
                        break;
                }
            }
        }

        public void SeedBadgeDictionary()
        {
            Badge one = new Badge(101);
            Badge two = new Badge(102);
            Badge three = new Badge(103);

            _badgeRepo.CreateNewBadge(one.BadgeID, one);
            _badgeRepo.CreateNewBadge(two.BadgeID, two);
            _badgeRepo.CreateNewBadge(three.BadgeID, three);

            _badgeRepo.UpdateDoorsOnBadge(101, "A1, B2, B3");
            _badgeRepo.UpdateDoorsOnBadge(102, "A11, B2, B4, C13");
            _badgeRepo.UpdateDoorsOnBadge(103, "D12, B2");
        }
    }
}

