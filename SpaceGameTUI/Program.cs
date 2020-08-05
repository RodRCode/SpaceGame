using System;
using System.Collections.Generic;
using System.Text;
using SGClasses;

namespace SpaceGameTUI
{
    class Program
    {
        public var earth { public get ; private set};

        PopulatePlanets();

        static void Main(string[] args)
        {
                      
            // Application.Init();

            Planet.InitialzePlanets();

            Console.WriteLine(earth);

            
            
            Console.WriteLine();
            Console.Write("Enter Your Name:  ");
            string name = Console.ReadLine();
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
