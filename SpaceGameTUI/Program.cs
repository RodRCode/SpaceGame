using System;
using System.Collections.Generic;
using System.Text;
using SGClasses;
using CLRCLI;
using CLRCLI.Widgets;

//todo  STRETCH GOAL, what happens if we add Tribbles to this? Cargo capacity increases over time?  Ship bursts during travel

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
                Console.WriteLine($"({ planet.name}, located at X: { planet.location.x},  Y: { planet.location.y}");
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
            Location shipLocation = new Location(1, 1);


            var ship = new Ship(shipType, shipName, totalCapacity, speed, fuelLevel, offence, defense, shield, shipLocation);

            Display.DisplayShipInfo(ship);


            int consoleWidth = 150;
            int consoleHeight = 50;

            Console.SetWindowSize(consoleWidth, consoleHeight);
            var root = new RootWindow();

            var banner = new Dialog(root) { Text = "SPACE HAWKER", Width = 48, Height = 46, Top = 2, Left = 98, Border = BorderStyle.Thick };
            new Label(banner) { Text = "Name: " + player.Name, Top = 1, Left = 4 };
            new Label(banner) { Text = "AGE: " + player.Age, Top = 2, Left = 4 };
            new Label(banner) { Text = "Bank Account" + player.Money, Top = 3, Left = 4 };
            new Label(banner) { Text = "Name: " + player.Name, Top = 3, Left = 4 };
            new Label(banner) { Text = "AGE: " + player.Age, Top = 4, Left = 4 };
            new Label(banner) { Text = "Bank Account" + player.Money, Top = 5, Left = 4 };
            new Label(banner) { Text = "Name: " + player.Name, Top = 6, Left = 4 };
            new Label(banner) { Text = "AGE: " + player.Age, Top = 7, Left = 4 };
            new Label(banner) { Text = "Bank Account" + player.Money, Top = 8, Left = 4 };
            new Label(banner) { Text = "Name: " + player.Name, Top = 9, Left = 4 };
            new Label(banner) { Text = "AGE: " + player.Age, Top = 10, Left = 4 };
            new Label(banner) { Text = "Bank Account" + player.Money, Top = 11, Left = 4 };
            new Label(banner) { Text = "Name: " + player.Name, Top = 12, Left = 4 };
            new Label(banner) { Text = "AGE: " + player.Age, Top = 13, Left = 4 };
            new Label(banner) { Text = "Bank Account" + player.Money, Top = 14, Left = 4 };

            //var button = new Button(dialog) { Text = "Play", Top = 4, Left = 6 };
            //var button2 = new Button(dialog) { Text = "Click", Top = 4, Left = 18 };
            //var list = new ListBox(dialog) { Top = 10, Left = 4, Width = 32, Height = 6, Border = BorderStyle.Thin };
            //var line = new VerticalLine(dialog) { Top = 4, Left = 40, Width = 1, Height = 6, Border = BorderStyle.Thick };
            //var dialog2 = new Dialog(root) { Text = "ooooh", Width = 32, Height = 5, Top = 6, Left = 6, Border = BorderStyle.Thick, Visible = false };
            //var button3 = new Button(dialog2) { Text = "Bye!", Width = 8, Height = 3, Top = 1, Left = 1 };

            //button3.Clicked += (s, e) => { dialog2.Hide(); dialog.Show(); };
            //button2.Clicked += (s, e) => { dialog.Hide(); dialog2.Show(); };

            //for (var i = 0; i < 25; i++ )
            //{
            //    list.Items.Add("Item " + i.ToString());
            //}

            //button.Clicked += button_Clicked;

            root.Run();


        }
        static void button_Clicked(object sender, EventArgs e)
        {
            (sender as Button).RootWindow.Detach();
        }

    }
}
