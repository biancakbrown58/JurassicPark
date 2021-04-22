using System;

namespace JurassicPark
{
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
}




