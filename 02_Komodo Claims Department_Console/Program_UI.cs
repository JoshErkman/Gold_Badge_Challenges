using _02_Komodo_Claims_Department_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_Komodo_Claims_Department_Repository.Claim;

namespace _02_Komodo_Claims_Department_Console
{
    class Program_UI
    {
        private Claims_Repository _claimsQueue = new Claims_Repository();
        private int _nextID = 1;
        public void Run()
        {
            SeedClaims();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display Menu to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. View All Claims\n" +
                    "2. Take Care Of Next Claim\n" +
                    "3. Enter A New Claim\n" +
                    "4. Exit");

                // Get user input
                string input = Console.ReadLine();

                // Evaluate the user input and act accordingly
                switch (input)
                {
                    case "1":
                        // View all Claims
                        ViewAllClaims();
                        break;

                    case "2":
                        // Take Care of next claim
                        NextClaim();
                        break;

                    case "3":
                        // Enter A New Claim
                        CreateNewClaim();
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

                Console.WriteLine("\n\n\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        // 1 View All Claims
        private void ViewAllClaims()
        {
            Console.Clear();


            Queue<Claim> queueOfClaims = _claimsQueue.GetClaims();
            Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-8} {4,-18} {5,-15} {6,-5}\n", "ClaimID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid");
            foreach(Claim claim in queueOfClaims)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-30} {3,-8} {4,-18} {5,-15} {6,-5}", claim.ClaimId, claim.TypeOfClaim,claim.Description,claim.ClaimAmount, claim.DateOfIncident.ToShortDateString(), claim.DateOfClaim.ToShortDateString(), claim.IsValid);
            }

        }

        // 2 Take Care Of Next Claim
        private void NextClaim()
        {
            Console.Clear();

            // Display next claim
            Claim claim = _claimsQueue.ViewNextClaim();
            Console.WriteLine($"\nClaim ID: {claim.ClaimId}\n" +
                $"Claim Type: {claim.TypeOfClaim}\n" +
                $"Claim Description: {claim.Description}\n" +
                $"Claim Amount: ${claim.ClaimAmount}\n" +
                $"Date of Incident: {claim.DateOfIncident.ToShortDateString()}\n" +
                $"Date of Claim: {claim.DateOfClaim.ToShortDateString()}");
            
            Console.WriteLine("\nDo you want to deal with this claim now(y/n)?");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                _claimsQueue.TakeCareOfClaim();
            }
            
        }

        // Create New Claim
        private void CreateNewClaim()
        {
            Console.Clear();

            // Create new claim
            Claim claim = new Claim();

            // Assign Claim an ID
            Console.WriteLine("This claim will automatically be assigned an ID.");
            claim.ClaimId = GenerateIDNumber();

            // Get Claim Type
            Console.WriteLine("Enter the claim type by number\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");

            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            claim.TypeOfClaim = (ClaimType)claimTypeAsInt;

            // Get Claim Description
            Console.WriteLine("Enter a claim description:");
            claim.Description = Console.ReadLine();

            // Get claim amount
            Console.WriteLine("Enter the claim amount:");
            string claimAmountAsString = Console.ReadLine();
            double claimAmountAsDouble = Convert.ToDouble(claimAmountAsString);
            claim.ClaimAmount = claimAmountAsDouble;

            // Get Date Of Incident
            Console.WriteLine("Enter the date of the incedent (mm/dd/yyyy):");
            string dateOfIncidentAsString = Console.ReadLine();
            claim.DateOfIncident = DateTime.Parse(dateOfIncidentAsString);

            // Get Date of Claim
            Console.WriteLine("Enter the date of the claim (mm/dd/yyyy):");
            string dateOfClaimAsString = Console.ReadLine();
            claim.DateOfClaim = DateTime.Parse(dateOfClaimAsString);

            _claimsQueue.AddClaim(claim);
        }

        // Generate random ID
        private string GenerateIDNumber()
        {
            int ID = _nextID;

            _nextID++; 
            return ID.ToString();
            
        }

        // Seed Claims
        public void SeedClaims()
        {
            Claim claimOne = new Claim(GenerateIDNumber(), ClaimType.Car, "Car accident on 464.", 400.00, new DateTime(2018 , 04 , 25), new DateTime(2018 , 04 , 27));
            Claim claimTwo = new Claim(GenerateIDNumber(), ClaimType.Home, "House was broke into", 2000.00, new DateTime(2020 , 07 , 25), new DateTime(2020 , 07 , 27));
            Claim claimThree = new Claim(GenerateIDNumber(), ClaimType.Theft, "Someone stole my underpants", 2.00, new DateTime(2020 , 01 , 12), new DateTime(2020 , 01 , 20));

            // Add Seeds to queue
            _claimsQueue.AddClaim(claimOne);
            _claimsQueue.AddClaim(claimTwo);
            _claimsQueue.AddClaim(claimThree);

        }
    }
}
