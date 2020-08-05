using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    public class Display
    {
        public static object Name { get; private set; }
        public static object Age { get; private set; }
        public static object Money { get; private set; }

        //System.Console.WriteLine("just a test");



        public static void DisplayMap()
        {
            // foreach something in something
            {
                //Console.WriteLine();
                
                
                
                
                //Initial idea: write all items in array (this will print to screen all coordinates on the 
                // y access x number of times. Replace an empty space character with a symbol for the object
                // objects: ship, planets, pirates. How can we make object different sizes?
                
                //Method that 
            }

            

        }

        public static void DisplayPlanetInfo()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("PLANET INFO");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***********************");
        }

        public static void DisplayYourStatus()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("YOUR STATUS");
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Age:{Age}");
            Console.WriteLine($"Money:{Money}");

            Console.WriteLine("***********************");

        }

    }

    
}
