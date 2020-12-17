using _02_Challenge2ClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge2ClaimsConsoleApp
{

    class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            SeedClaimQueue();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to the Komodo Claims Department Application. \n");
                Console.ResetColor();

                Console.WriteLine("Please choose from the following options:\n" +
                    "\n1. View All Claims\n" +
                    "2. Process Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit Application\n\n" +
                    "Please enter your selection:");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewClaimsQueue();
                        break;
                    case "2":
                        ProcessNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Thank you for using Komodo Claims Department Application. Goodbye!\n");
                        Console.ResetColor();
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Your selection was invalid. Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ViewClaimsQueue()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _claimRepo.GetClaimQueue();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Claim".PadRight(10) + "Type".PadRight(10) + "Description".PadRight(20) + "Amount".PadRight(15) + "DateOfAccident".PadRight(20) + "DateOfClaim".PadRight(20) + "IsValid");
            Console.ResetColor();

            foreach (Claim claim in queueOfClaims)
            {
                Console.WriteLine("\n" + claim.ClaimID.ToString().PadRight(10) + claim.ClaimType.ToString().PadRight(10) + claim.Description.PadRight(20) + "$" + claim.ClaimAmount.ToString("0.00").PadRight(15) + claim.DateOfIncident.Date.ToShortDateString().PadRight(20) + claim.DateOfClaim.Date.ToShortDateString().PadRight(20) + claim.IsValid);
            }
            Console.ReadLine();
        }

        public void ProcessNextClaim()
        {
            Console.Clear();

            _claimRepo.GetClaimQueue();
            Queue<Claim> claimQueue = _claimRepo.GetClaimQueue();
            Claim nextClaim = claimQueue.Peek();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Here are the details for the next claim to be handled:\n");
            Console.ResetColor();

            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n" +
                $"Description: { nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"DateOfAccident: {nextClaim.DateOfIncident.Date.ToShortDateString()}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim.Date.ToShortDateString()}\n" +
                $"IsValid: {nextClaim.IsValid}\n\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            Console.ResetColor();

            string dealWith = Console.ReadLine().ToLower();
            if (dealWith == "y")
            {
                claimQueue.Dequeue();
            }
        }

        public void CreateNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Creating a New Claim\n");
            Console.ResetColor();

            bool endErrorCheck = false;
            while (endErrorCheck == false)
            {
                int claimNumber = 0;

                Console.WriteLine("Enter the new claim ID:");

                if (int.TryParse(Console.ReadLine(), out int result) == true)
                {
                    claimNumber = result;
                }

                if (claimNumber <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe claim ID must be numeric and greater than zero.\n");
                    Console.ResetColor();
                }
                else
                {
                    Claim tempNumber = _claimRepo.GetClaimByIDViaQueue(claimNumber);
                    if (tempNumber != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThis claim ID already exists. Please select a new ID.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        endErrorCheck = true;
                        newClaim.ClaimID = claimNumber;
                    }
                }
            }
            Console.WriteLine("\nEnter the Claim Type: \n" +
                "For Car Enter 1\n" +
                "For Home Enter 2\n" +
                "For Theft Enter 3");

            bool errorCheck = true;
            while (errorCheck == true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        newClaim.ClaimType = TypeOfClaim.Car;
                        errorCheck = false;
                        break;
                    case "2":
                        newClaim.ClaimType = TypeOfClaim.Home;
                        errorCheck = false;
                        break;
                    case "3":
                        newClaim.ClaimType = TypeOfClaim.Theft;
                        errorCheck = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYour selection was invalid. Please enter 1, 2, or 3.");
                        Console.ResetColor();
                        break;
                }
            }

            Console.WriteLine("\nEnter the claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("\nEnter the dollar amount of the claim:");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("\nWhat date did the incident occur? Format: MM/DD/YYYY");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nToday's date will automatically be used for the Date of Claim.");
            newClaim.DateOfClaim = DateTime.Now.Date;

            if (newClaim.IsValid == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nThis claim is valid.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThis claim is not valid.");
                Console.ResetColor();
            }

            _claimRepo.CreateANewClaimToQueue(newClaim);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nThis claim has been added to the queue.");
            Console.ResetColor();
            Console.ReadLine();
        }

        public void SeedClaimQueue()
        {
            Claim one = new Claim(1, TypeOfClaim.Car, "Crash on 465", 3000.00, DateTime.Parse("03/17/2016"), DateTime.Parse("04/08/2016"));
            Claim two = new Claim(2, TypeOfClaim.Home, "Water damage", 1000.00, DateTime.Parse("05/07/2016"), DateTime.Parse("11/11/2018"));
            Claim three = new Claim(3, TypeOfClaim.Theft, "Stolen ring", 400.00, DateTime.Parse("12/24/2017"), DateTime.Parse("01/05/2018"));

            _claimRepo.CreateANewClaimToQueue(one);
            _claimRepo.CreateANewClaimToQueue(two);
            _claimRepo.CreateANewClaimToQueue(three);
        }
    }
}
