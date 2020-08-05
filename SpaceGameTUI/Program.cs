using System;
using System.Collections.Generic;
using System.Text;
using SGClasses;

namespace SpaceGameTUI
{
    class Program
    {

        static void Main(string[] args)
        {

            // Application.Init();

            var planets = Planet.PopulatePlanets();


            Console.WriteLine();
            Console.Write("Enter Your Name:  ");
            string name = Console.ReadLine();

            foreach (var planet in planets)
            {
                Console.WriteLine(planet.name, "located at X:", planet.x, " Y: ", planet.y);
            }
            int type = 1;
            double age = 18;
            double money = 1000;

            Console.WriteLine("\r\n\r\n\r\n");

            var player = new Character(name, type, age, money);

            Display.DisplayYourStatus(player);

            //Display.Ship
            //DisplayPlanetInfo();


        }
    }
}
