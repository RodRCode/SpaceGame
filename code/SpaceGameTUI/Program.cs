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
            int consoleWidth = 150;
            int consoleHeight = 52;

            Console.SetWindowSize(consoleWidth, consoleHeight);

            Console.WriteLine();
            Console.Write("Enter Your Name:  ");
            string name = Console.ReadLine();
            Console.Beep();

            // Application.Init();

            var player = new Player(name);
            Location shipLocation = new Location(1, 1);
            var ship = new Ship(shipLocation);

            var root = new RootWindow();

            

            // All the stuff to display main game info (start)
            var displayMainstatus = new DisplayMainStatus(root) { Text = "SPACE HAWKER", Width = 43, Height = 20, Top = 3, Left = 104, Border = BorderStyle.Thick };
            var status = new StatusListBox(displayMainStatus) { Top = 1, Left = 0, Width = 43, Height = 8, Border = BorderStyle.Thin, Visible = true };

            new Label(displayMainstatus) { Text = "Name: " + player.Name, Top = 1, Left = 4 };
            new Label(displayMainstatus) { Text = "Charcter Type: " + player.CharacterType, Top = 2, Left = 4 };
            new Label(displayMainstatus) { Text = "AGE: " + player.Age, Top = 3, Left = 4 };
            new Label(displayMainstatus) { Text = "Money: " + player.Money, Top = 4, Left = 4 };
            new Label(displayMainstatus) { Text = "Ship Name: " + ship.shipName, Top = 6, Left = 4 };
            new Label(displayMainstatus) { Text = "Ship Location:" + " Earth " + ship.location.x + " , " + ship.location.y, Top = 7, Left = 4 };
            new Label(displayMainstatus) { Text = "Fuel: " + ship.fuelLevel, Top = 8, Left = 4 };
            // All the stuff to display main game info (end)


            //all the stuff to populate and choose planets (start)

            var planets = Planet.PopulatePlanets();

            var displayPlanetList = new DisplayPlanetList(root) { Text = "Planet List", Width = 43, Height = 10, Top = 27, Left = 104, Border = BorderStyle.Thin, Visible = true };
            var showPlanetListButton = new Button(displayPlanetList) { Text = "Travel", Width = 10, Height = 3, Top = -14, Left = 4, Visible = true };
            var planetList = new ListBox(displayPlanetList) { Top = 1, Left = 0, Width = 41, Height = 8, Border = BorderStyle.Thin, Visible = false };
            foreach (var planet in planets)
            {
                string textForPlanet = planet.name + " location: " + Location.ToString(planet.location);
                planetList.Items.Add(textForPlanet);
            }
            int selectedIndexOfPlanetList = planetList.SelectedIndex;
            showPlanetListButton.Clicked += (s, e) => { planetList.Show(); planetList.SetFocus(); };

            //showPlanetListButton.Clicked += TravelButton_Clicked;
            //all the stuff to populate and choose planets (end)


            // Implements game diaglog box
            var displayGameDialog = new DisplayGameDialog(root) { Text = "Game Dialog", Width = 98, Height = 10, Top = 40, Left = 2, Border = BorderStyle.Thin };
            var dialogList = new DialogListBox(displayGameDialog) { Top = 1, Left = 0, Width = 98, Height = 8, Border = BorderStyle.Thin, Visible = true };

            //all the stuff to sell inventory (start)  
            var displayInventoryList = new DisplayShipInventory(root) { Text = "Inventory", Width = 43, Height = 10, Top = 40, Left = 104, Border = BorderStyle.Thin, Visible = true };
            var showSellButton = new Button(displayInventoryList) { Text = "Sell", Width = 10, Height = 3, Top = -27, Left = 28, Visible = true };
            var inventoryList = new ListBox(displayInventoryList) { Top = 1, Left = 0, Width = 43, Height = 8, Border = BorderStyle.Thin, Visible = true };
         

            int selectedIndexOfInventory = planetList.SelectedIndex;
            showSellButton.Clicked += (s, e) => { planetList.Hide(); inventoryList.Show(); inventoryList.SetFocus(); };

            planetList.Clicked += (s, e) =>
            {
                getindex(planetList.SelectedIndex);
                showPlanetListButton.Show();
                planetList.Hide();

     //           new Label(displayMainstatus) { Text = "\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\b\b\b\b\b\b\b   Ship Location: " + planets[planetList.SelectedIndex].name + "  " + ship.location.x + " , " + ship.location.y + "    " };
                
                dialogList.Items.Add("You traveled to " + planets[planetList.SelectedIndex].name);
                root.Run();
            };

            var showBuyButton = new Button(displayPlanetList) { Text = "Buy", Width = 10, Height = 3, Top = -14, Left = 16, Visible = true };

            var showBuyOptions = new DisplayShipInventory(displayPlanetList) { Text = "Inventory", Width = 43, Height = 8, Top = 1, Left = 0, Border = BorderStyle.Thin, Visible = false };


            var showReserved1 = new Button(displayPlanetList) { Text = "Res 1", Width = 10, Height = 3, Top = -9, Left = 4, Visible = true };
            var showReserved2 = new Button(displayPlanetList) { Text = "Res 2", Width = 10, Height = 3, Top = -9, Left = 16, Visible = true };
            var showSaveButton = new Button(displayPlanetList) { Text = "Save", Width = 10, Height = 3, Top = -9, Left = 28, Visible = true };

            showSellButton.Clicked += (s, e) => { };
            showReserved1.Clicked += (s, e) => { };
            showReserved2.Clicked += (s, e) => { };
            showSaveButton.Clicked += (s, e) => { };

            var displayMap = new DisplayMap(root) { Text = "MAP", Width = 98, Height = 35, Top = 2, Left = 2, Border = BorderStyle.Thin };

            CreateStarField(displayMap);

            PutPlanetsOnMap(planets, displayMap);

            void getindex(int index)
            {
                ship.location = planets[index].location;
            }
           
            root.Run();
            
        }

        private static void PutPlanetsOnMap(List<Planet> planets, DisplayMap displayMap)
        {
            foreach (var planet in planets)
            {   
                // add an if statement here to make the selected planet a spinner
                new Label(displayMap) { Text = "██ - " + planet.name, Top = planet.location.y, Left = planet.location.x };
            }
        }

        private static void CreateStarField(DisplayMap displayMap)
        {
            var randomX = new Random();
            var randomY = new Random();
            var randomColor = new Random();

            for (int i = 0; i < 300; i++)
            {
                int x = randomX.Next(0, 98);
                int y = randomY.Next(0, 35);
                ConsoleColor starColor = (ConsoleColor)randomColor.Next(0, 15);
                new Label(displayMap) { Text = ".", Top = y, Left = x, Foreground = starColor };
            }
        }

        // commented out for now
     //   private static void TravelButton_Clicked(object sender, EventArgs e)
     //   {
     //       //this needs to input the coordinates of the planetlist item selected
     //       // (sender as Button).RootWindow.Show();
     //       (sender as Button).RootWindow.Show();
     //   }

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
