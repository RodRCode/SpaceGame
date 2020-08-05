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

            //Planet locations 

            // planet 1 - 1,1
            // planet 2 - 37, 27
            // planet 3 - 13, 8
            // planet 4 - 25, 9
            // planet 5 - 9, 20
            // planet 6 - 47,27

            Console.Write("Enter Your Name:  ");
            string name = Console.ReadLine();
            int type = 1;
            double age = 18;
            double money = 1000;

            Console.WriteLine("\r\n\r\n\r\n");

            new Character(name, type, age, money);

            Display.DisplayYourStatus();
            
            Display.DisplayPlanetInfo();


        }
    }
}
