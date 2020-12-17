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
            SeedBadges();
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
                        EditBadge();
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
        private void EditBadge()
        {
            Console.Clear();

            // Display All Badges
            DisplayListOfBadges();

            // Get which badge the user wants to edit
            Console.WriteLine("\nEnter the badge ID for the badge you would like to edit");
            string badgeIDAsString = Console.ReadLine();

            // Convert input to int
            int badgeIDAsInt = int.Parse(badgeIDAsString);

            // Get badge by ID
            Badge badgeToEdit = _badgeRepo.GetBadgeByID(badgeIDAsInt);

            /*Dictionary<int, Badge> listOfBadges = _badgeRepo.GetBadges();
            foreach(Badge badge in listOfBadges.Values)
            {
                Console.WriteLine($"Badge ID: {badge.BadgeID}");

                List<string> doors = badge.DoorNames;
                foreach(var door in doors)
                {
                    Console.WriteLine($" Door Access: {door}");
                }
            }*/

            Console.Clear();

            Console.WriteLine("Select from the menu\n" +
                "1. Add a door (one at a time)\n" +
                "2. Remove a door (one at a time)");
                

            string input = Console.ReadLine();

            switch (input)
            {
                // Add door
                case "1":
                    Console.Clear();

                    bool keepAdding = true;
                    while (keepAdding)
                    {
                        Console.WriteLine("Enter the door name you would like to add:");
                        string answer = Console.ReadLine();
                        if (!badgeToEdit.DoorNames.Contains(answer))
                        {
                            badgeToEdit.DoorNames.Add(answer);
                        }
                        else
                        {
                            Console.WriteLine("This door has already been added.");
                        }

                        bool addAnotherDoor = true;
                        while (addAnotherDoor)
                        {

                            Console.WriteLine("Any other doors you would like to add? y/n");

                            string anotherAnswer = Console.ReadLine().ToLower();

                            if (anotherAnswer == "y")
                            {
                                keepAdding = true;
                                addAnotherDoor = false;
                            }
                            else if(anotherAnswer == "n")
                            {
                                keepAdding = false;
                                addAnotherDoor = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid entry, please try again.");
                            }
                        }
                    }
                    break;

                // Remove door
                case "2":
                    Console.Clear();

                    bool keepRemoving = true;
                    while (keepRemoving)
                    {
                        Console.WriteLine("Enter the door name you would like to remove:");
                        string answer = Console.ReadLine();
                        if (!badgeToEdit.DoorNames.Contains(answer))
                        {
                            Console.WriteLine("This door does not exist for removal.");
                        }
                        else
                        {
                            badgeToEdit.DoorNames.Remove(answer);
                        }

                        bool removeAnotherDoor = true;
                        while (removeAnotherDoor)
                        {

                            Console.WriteLine("Any other doors you would like to remove? y/n");
                            string anotherAnswer = Console.ReadLine().ToLower();

                            if (anotherAnswer == "y")
                            {
                                keepRemoving = true;
                                removeAnotherDoor = false;
                            }
                            else if(anotherAnswer == "n")
                            {
                                keepRemoving = false;
                                removeAnotherDoor = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid entry, please try again.");
                            }
                        }
                    }
                    break;
            }
        }

        private void AddDoor()
        {
            Console.Clear();

            Console.WriteLine("Enter the door name you would like to add:");
            string input = Console.ReadLine();

            Badge updatedBadge = new Badge();

            
        }


        // List all badges
        private void DisplayListOfBadges()
        {
            Console.Clear();

            Dictionary<int, Badge> listOfBadges = _badgeRepo.GetBadges();
            foreach (KeyValuePair<int, Badge> entry in listOfBadges)
            {
                Console.WriteLine($"Badge #: {entry.Key}");
                
                foreach(string doorName in entry.Value.DoorNames)
                {
                    Console.WriteLine($"Door: {doorName}");
                }
                Console.WriteLine("\n");
            }
        }


        // Generate ID number
        private int GenerateIDNumber()
        {
            int ID = _nextID;

            _nextID++;
            return ID;
        }

        // SEED in badges
        public void SeedBadges()
        {
            Badge badgeOne = new Badge(GenerateIDNumber(), new List<string> { "F3", "G8" });
            Badge badgeTwo = new Badge(GenerateIDNumber(), new List<string> { "A9", "K4" });
            Badge badgeThree = new Badge(GenerateIDNumber(), new List<string> { "H1", "H7" });

            _badgeRepo.AddBadge(badgeOne.BadgeID, badgeOne);
            _badgeRepo.AddBadge(badgeTwo.BadgeID, badgeTwo);
            _badgeRepo.AddBadge(badgeThree.BadgeID, badgeThree);
        }
    }
}
