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
        public static object SelectedIndex { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.Write("Enter Your Name:  ");
            string name = Console.ReadLine();

            // Application.Init();



            var player = new Character(name);
            Location shipLocation = new Location(1, 1);
            var ship = new Ship(shipLocation);

            int consoleWidth = 150;
            int consoleHeight = 50;

            Console.SetWindowSize(consoleWidth, consoleHeight);
            var root = new RootWindow();

            var dialog = new Dialog(root) { Text = "SPACE HAWKER", Width = 48, Height = 46, Top = 2, Left = 98, Border = BorderStyle.Thick };
            new Label(dialog) { Text = "Name: " + player.Name, Top = 1, Left = 4 };
            new Label(dialog) { Text = "Charcter Type: " + player.CharacterType, Top = 2, Left = 4 };
            new Label(dialog) { Text = "AGE: " + player.Age, Top = 3, Left = 4 };
            new Label(dialog) { Text = "Money: " + player.Money, Top = 4, Left = 4 };
            new Label(dialog) { Text = "Ship Name: " + ship.shipName, Top = 6, Left = 4 };
            new Label(dialog) { Text = "Ship Location: " + ship.location.x + " , " + ship.location.y, Top = 7, Left = 4 };

            var planets = Planet.PopulatePlanets();
            var planetList = new ListBox(dialog) { Top = 20, Left = 4, Width = 32, Height = 15, Border = BorderStyle.Thin };

            int i = 1;

            foreach (var planet in planets)
            {
                planetList.Items.Add("Planet #" + i + ":  " + planet.name);
                i++;

            }

            foreach (var planet in planets)
            {
                Console.WriteLine($"({ planet.name}, located at X: { planet.location.x},  Y: { planet.location.y}");
            }

            //planetList.Clicked += (s, e) => { };


            planetList.Clicked += planetList_Clicked(object s, planetList.SelectedItem);

            root.Run();
        }

        static void planetList_Clicked (object sender, EventArgs e)
        {
            
            
            //this needs to input the coordinates of the planetlist item selected
            //(sender as Button).RootWindow.Detach();
            (sender as Button).RootWindow.Show();
        }

        //static void button_Clicked(object sender, EventArgs e)
        //{
           // (sender as Button).RootWindow.Detach();
        //}

    }

    /*
            *var root = new RootWindow();
           //list.Clicked += button_Clicked;
           var dialog = new Dialog(root) { Text = "Hello World!", Width = 60, Height = 32, Top = 4, Left = 4, Border = BorderStyle.Thick };
           new Label(dialog) {Text = "This is a dialog!", Top = 2, Left = 2};
           var button = new Button(dialog) { Text = "Oooooh", Top = 4, Left = 6 };
           var button2 = new Button(dialog) { Text = "Click", Top = 4, Left = 18 };
           var list = new ListBox(dialog) { Top = 10, Left = 4, Width = 32, Height = 6, Border = BorderStyle.Thin };
           var line = new VerticalLine(dialog) { Top = 4, Left = 40, Width = 1, Height = 6, Border = BorderStyle.Thick };

           var dialog2 = new Dialog(root) { Text = "ooooh", Width = 32, Height = 5, Top = 6, Left = 6, Border = BorderStyle.Thick, Visible = false };
           var button3 = new Button(dialog2) { Text = "Bye!", Width = 8, Height = 3, Top = 1, Left = 1 };
           var button = new Button(dialog) { Text = "Oooooh", Top = 4, Left = 6 };
           button3.Clicked += (s, e) => { dialog2.Hide(); dialog.Show(); };
           button2.Clicked += (s, e) => { dialog.Hide(); dialog2.Show(); };

           for (var i = 0; i < 25; i++ )
           {
               list.Items.Add("Item " + i.ToString());
           }

           button.Clicked += button_Clicked;

           root.Run();
            * */


}
