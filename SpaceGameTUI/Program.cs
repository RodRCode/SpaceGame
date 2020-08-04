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
            Console.WriteLine("name?");
            string name = Console.ReadLine();

            Console.WriteLine("type?");
            int charactertype = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("age?");
            double age = Convert.ToDouble(Console.ReadLine());


            Character character = new Character(name, type, age);

        }        
    }
}
