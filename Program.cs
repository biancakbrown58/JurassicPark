using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    class DinosaurDatabase
    {
        private List<Dinosaur> dinosaurs = new List<Dinosaur>();

        //Add a Dinosaur to the Dinosaur list
        public void AddDinosaur(Dinosaur newDinosaur)
        {
            dinosaurs.Add(newDinosaur);
        }

        //Gets all Dinosaurs in Dinosaur list
        public List<Dinosaur> GetAllDinosaurs()
        {

            var sortedDino = dinosaurs.OrderBy(dinosaur => dinosaur.WhenAcquired).ToList();
            return sortedDino;

        }



        // Searching for Dinosaurs
        public Dinosaur SearchDinosaurs(string name)
        {
            Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == name);
            return foundDinosaur;
        }

        // Removing a Dinosaur
        public void RemoveDinosaur(Dinosaur dinosaurToRemove)
        {
            dinosaurs.Remove(dinosaurToRemove);
        }


    }
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; } = DateTime.Now;
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }
        // Counting
        public int CountDinosaurs()
        {
            if (DietType == "Carnivore")
            {
                return 1;
            }
            else
            {
                return 1;
            }

        }

    }
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("    Welcome to Jurassic Park!    ");
            Console.WriteLine("---------------------------------");
        }

        static string AskForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }



        static int AskForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var intUserInput = Int32.TryParse(Console.ReadLine(), out userInput);
            //while statement to have user able to try another time to enter a number?
            if (intUserInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Invalid Entry.");
                return 0;
            }
        }

        static string CarnivoreOrHerbivore(string carnOrHerb)
        {
            Console.Write(carnOrHerb);
            // string userInput;
            var userInputCorH = Console.ReadLine().ToUpper();
            if (userInputCorH == "H")
            {
                return userInputCorH = "Herbivore";
            }
            else if (userInputCorH == "C")
            {
                return userInputCorH = "Carnivore";
            }
            else
            {
                Console.WriteLine("Invalid");
                return "Invalid";
            }

        }

        static void Main(string[] args)
        {
            DisplayGreeting();

            var database = new DinosaurDatabase();
            var isRunning = true;
            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                Console.Write("(A)dd -- (S)how -- (T)ransfer -- (C)ount -- (R)emove -- (Q)uit ");
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Q":
                        isRunning = false;
                        break;

                    // Add a Dinosaur
                    case "A":
                        var dinosaur = new Dinosaur();

                        dinosaur.Name = AskForString("What is the Dinosaur's name? ");
                        dinosaur.DietType = CarnivoreOrHerbivore("Are they (C)arnivore or (H)erbivore? ");



                        dinosaur.EnclosureNumber = AskForInteger("What is their enclosure number? ");
                        dinosaur.Weight = AskForInteger("How much do they weigh? ");
                        database.AddDinosaur(dinosaur);
                        break;

                    // Showing all Dinosuars
                    case "S":
                        var allDinosaurs = database.GetAllDinosaurs();

                        // Checking if there are any dinosaurs in the list (? = null conditional operator)
                        if (allDinosaurs?.Any() != true)
                        {
                            Console.WriteLine("There aren't any dinosaurs here!");
                        }
                        // If there are dinosaurs in the list print to console.
                        else
                        {
                            foreach (var dinosaursToShow in allDinosaurs)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Date Added: {dinosaursToShow.WhenAcquired}");
                                Console.WriteLine($"Name: {dinosaursToShow.Name}");
                                Console.WriteLine($"-----------------");
                                Console.WriteLine($"Diet Type: {dinosaursToShow.DietType}");
                                Console.WriteLine($"Enclosure: {dinosaursToShow.EnclosureNumber}");
                                Console.WriteLine($"Weight: {dinosaursToShow.Weight}");

                            }
                        }

                        break;

                    //Removing a Dinosaur
                    case "R":
                        var dinosaurToRemove = AskForString("Who would you like to remove?: ");
                        Dinosaur foundDinosaur = database.SearchDinosaurs(dinosaurToRemove);
                        if (foundDinosaur == null)
                        {
                            Console.WriteLine("That dinosaur is not here...");
                        }
                        else
                        {
                            database.RemoveDinosaur(foundDinosaur);
                            Console.WriteLine($"{dinosaurToRemove} was deleted");
                        }
                        break;

                    // Updating enclosure number for a dinosaur
                    case "T":
                        var dinoToUpdate = AskForString("Who's enclosure do you want to change?: ");
                        Dinosaur updateDinosaur = database.SearchDinosaurs(dinoToUpdate);

                        if (updateDinosaur == null)
                        {
                            Console.WriteLine("That dinosaur is not here...");

                        }
                        else
                        {
                            var newEnclosure = AskForInteger("What enclosure are the moving to? ");
                            updateDinosaur.EnclosureNumber = newEnclosure;
                        }
                        break;

                    // Counting Herbivores & Carnivores
                    case "C":
                        var countDinosaurs = database.GetAllDinosaurs();
                        int howManyHerbivores = countDinosaurs.Count(dinosaur => dinosaur.DietType == "Herbivore");
                        Console.WriteLine($"Herbivores Count: {howManyHerbivores}");

                        int howManyCarnivores = countDinosaurs.Count(dinosaur => dinosaur.DietType == "Carnivore");
                        Console.WriteLine($"Carnivore Count:  {howManyCarnivores}");

                        break;


                }
            }
        }
    }
}




