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
                Console.WriteLine($"({ planet.name}, located at X: { planet.x},  Y: { planet.y}");
            }
            int type = 1;
            double age = 18;
            double money = 1000;

            Console.WriteLine("\r\n\r\n\r\n");

            var player = new Character(name, type, age, money);

            Display.DisplayYourStatus(player);

            //Display Ship
            
            int shipType = 1;
            string shipName = "funship";
            double totalCapacity = 1000;
            double speed = 1;
            double fuelLevel = 100;
            double offence = 1;
            double defense = 1;
            double shield = 1;

            var ship = new Ship(shipType, shipName, totalCapacity, speed, fuelLevel, offence, defense, shield);

            Display.DisplayShipInfo();



        }
    }
}
