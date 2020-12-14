using _03_Komodo_Insurance_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Insurance_Console
{
    class Program_UI
    {
        private Badge_Repository _badgeRepo = new Badge_Repository();
        private int _nextID = 1;

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display Menu to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");

                // Get User Input
                string input = Console.ReadLine();

                // Evaluate the user input and act accordingly
                switch (input)
                {
                    case "1":
                        // Add a badge
                        AddBadge();
                        break;

                    case "2":
                        // Edit a badge
                        break;

                    case "3":
                        // List all badges
                        DisplayListOfBadges();
                        break;

                    case "4":
                        // Exit
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

        // 1 Add a badge
        private void AddBadge()
        {
            Console.Clear();

            // Create new badge
            Badge badge = new Badge();

            // Assign badge an ID
            Console.WriteLine("This badge will automatically be assigned an ID.");
            badge.BadgeID = GenerateIDNumber();


            bool keepAdding = true;
            while (keepAdding)
            {
                // Get list of Doors for access
                Console.WriteLine("List a door that this badge needs access to:");
                string input = Console.ReadLine();
                badge.DoorNames.Add(input);

                Console.WriteLine("Any other doors you would like to add? y/n");
                string answer = Console.ReadLine().ToLower();

                if(answer == "y")
                {
                    keepAdding = true;
                }
                else
                {
                    keepAdding = false;
                }
            }

            _badgeRepo.AddBadge(badge.BadgeID, badge);
        }

        // Edit a badge

        // List all badges
        private void DisplayListOfBadges()
        {
            Console.Clear();

            Dictionary<int, Badge> listOfBadges = _badgeRepo.GetBadges();
            foreach (KeyValuePair<int, Badge> entry in listOfBadges)
            {
                Console.WriteLine($"Badge #: {entry.Key}\n" +
                    $"Door Access: {entry.Value}"); 
            }
        }


        // Generate ID number
        private int GenerateIDNumber()
        {
            int ID = _nextID;

            _nextID++;
            return ID;
        }
    }
}
