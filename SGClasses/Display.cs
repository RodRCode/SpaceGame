using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    public class Display
    {


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

        public static void CreateStarField()
        {
            var randomX = new Random();
            var randomY = new Random();
            var randomColor = new Random();

            for (int i = 0; i < 200; i++)
            {
                int x = randomX.Next(3, 94);
                int y = randomY.Next(2, 48);
                Console.ForegroundColor = (ConsoleColor)randomColor.Next(0, 15);
                Console.SetCursorPosition(x, y);
                Console.Write(".");
            }
            Console.ForegroundColor = (ConsoleColor)1;
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
        public static void DisplayShipInfo(Ship ship)
        {
            Console.WriteLine("***********************");
            Console.WriteLine("SHIP INFO");
            Console.WriteLine(ship.shipName);
            Console.WriteLine(ship.totalCapacity);
            Console.WriteLine(ship.speed);
            Console.WriteLine(ship.fuelLevel);
            Console.WriteLine("***********************");

        }
        public static void DisplayYourStatus(Character Player)
        {
            Console.WriteLine("***********************");
            Console.WriteLine("YOUR STATUS");
            Console.WriteLine($"Name:{Player.Name}");
            Console.WriteLine($"Age:{Player.Age}");
            Console.WriteLine($"Money:{Player.Money}");

            Console.WriteLine("***********************");

        }

    }


}
