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
            Location oldLocation = new Location(1,1);
            Location newLocation = new Location();
            int warpSpeed = 1;
            var root = new RootWindow();
            var planets = Planet.PopulatePlanets();

            Console.SetWindowSize(consoleWidth, consoleHeight);

            Location shipLocation = new Location(1, 1);
            var ship = new Ship(shipLocation);

            Console.WriteLine();
            Console.Write("Enter Your Name:  ");
            string name = "Zaphod Beeblebrox";
 //           string name = Console.ReadLine();
            var player = new Player(name);

            // Application.Init();

            // Create the windows on the display

            StatusListBox status = CurrentStatusBox(root);  //Status box "Galactic Hawker" box

            DialogListBox dialogList = GameDialogBox(root); //Game Dialog Box

            Button showPlanetListButton, showReserved1, showReserved2, showSaveButton, showSellButton;
            ActionButtonBox(root, out showPlanetListButton, out showReserved1, out showReserved2, out showSaveButton, out showSellButton);

            DisplayPlanetList displayPlanetList;
            ListBox planetList;
            PlanetListBox(root, out displayPlanetList, out planetList);

            ListBox inventoryList = InventoryListBox(root);


            // Start the business of what happens when they use enters stuff

            int selectedIndexOfPlanetList = planetList.SelectedIndex;
            foreach (var planet in planets)
            {
                string textForPlanet = planet.name + " location: " + Location.ToString(planet.location);
                planetList.Items.Add(textForPlanet);
            }

            showPlanetListButton.Clicked += (s, e) => { planetList.Show(); planetList.SetFocus(); };

            string planetName = planets[planetList.SelectedIndex].name;

            oldLocation = ship.location;
            var statusitems = CurrentInfo.Update(player, ship, planets, planetName);

            foreach (var item in statusitems)
            {
                status.Items.Add(item);
            }

            //showPlanetListButton.Clicked += TravelButton_Clicked;
            //all the stuff to populate and choose planets (end)




            int selectedIndexOfInventory = planetList.SelectedIndex;
            showSellButton.Clicked += (s, e) => { planetList.Hide(); inventoryList.Show(); inventoryList.SetFocus(); };

            planetList.Clicked += (s, e) =>
            {
                getindex(planetList.SelectedIndex);
                showPlanetListButton.Show();
                planetList.Hide();

                newLocation = planets[planetList.SelectedIndex].location;
                dialogList.Items.Add("You traveled to " + planets[planetList.SelectedIndex].name);

                double tempDistance = 42.9;
                tempDistance = SpaceTravel.DistanceCalculation(oldLocation, newLocation);
                dialogList.Items.Add("Distance was " + tempDistance);

                SpaceTravel.TravelToNewPlanet(oldLocation, newLocation, ship, player, warpSpeed);

                //           new Label(displayMainstatus) { Text = "\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\b\b\b\b\b\b\b   Ship Location: " + planets[planetList.SelectedIndex].name + "  " + ship.location.x + " , " + ship.location.y + "    " };



                planetName = planets[planetList.SelectedIndex].name;

                status.Items.Clear();

                statusitems = CurrentInfo.Update(player, ship, planets, planetName);
                oldLocation = ship.location;

                foreach (var item in statusitems)
                {
                    status.Items.Add(item);
                }

                //   root.Run();
            };


            var showBuyOptions = new DisplayShipInventory(displayPlanetList) { Text = "Inventory", Width = 43, Height = 8, Top = 1, Left = 0, Border = BorderStyle.Thin, Visible = false };


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

        private static ListBox InventoryListBox(RootWindow root)
        {
            var displayInventoryList = new DisplayShipInventory(root) { Text = "Inventory", Width = 43, Height = 10, Top = 40, Left = 104, Border = BorderStyle.Thin, Visible = true };
            var inventoryList = new ListBox(displayInventoryList) { Top = 1, Left = 0, Width = 43, Height = 8, Border = BorderStyle.Thin, Visible = true };
            return inventoryList;
        }

        private static void PlanetListBox(RootWindow root, out DisplayPlanetList displayPlanetList, out ListBox planetList)
        {
            displayPlanetList = new DisplayPlanetList(root) { Text = "Planet List", Width = 43, Height = 10, Top = 27, Left = 104, Border = BorderStyle.Thin, Visible = true };
            planetList = new ListBox(displayPlanetList) { Top = 1, Left = 0, Width = 41, Height = 8, Border = BorderStyle.Thin, Visible = false };
        }

        private static void ActionButtonBox(RootWindow root, out Button showPlanetListButton, out Button showReserved1, out Button showReserved2, out Button showSaveButton, out Button showSellButton)
        {
            var actionBox = new DisplayPlanetList(root) { Text = "Actions", Width = 43, Height = 10, Top = 14, Left = 104, Border = BorderStyle.Thick };
            showPlanetListButton = new Button(actionBox) { Text = "Travel", Width = 10, Height = 3, Top = 1, Left = 4, Visible = true };
            var showBuyButton = new Button(actionBox) { Text = "Buy", Width = 10, Height = 3, Top = 1, Left = 16, Visible = true };
            showSellButton = new Button(actionBox) { Text = "Sell", Width = 10, Height = 3, Top = 1, Left = 28, Visible = true };
            showReserved1 = new Button(actionBox) { Text = "Story Info", Width = 10, Height = 3, Top = 5, Left = 4, Visible = true };
            showReserved2 = new Button(actionBox) { Text = "Retire", Width = 10, Height = 3, Top = 5, Left = 16, Visible = true };
            showSaveButton = new Button(actionBox) { Text = "Quit", Width = 10, Height = 3, Top = 5, Left = 28, Visible = true };
        }

        private static StatusListBox CurrentStatusBox(RootWindow root)
        {
            var displayMainstatus = new DisplayMainStatus(root) { Text = "SPACE HAWKER", Width = 43, Height = 9, Top = 2, Left = 104, Border = BorderStyle.Thick };

            var status = new StatusListBox(displayMainstatus) { Top = 1, Left = 0, Width = 43, Height = 8, Border = BorderStyle.Thin, Visible = true };
            return status;
        }

        private static DialogListBox GameDialogBox(RootWindow root)
        {
            var displayGameDialog = new DisplayGameDialog(root) { Text = "Game Dialog", Width = 98, Height = 10, Top = 40, Left = 2, Border = BorderStyle.Thin };
            var dialogList = new DialogListBox(displayGameDialog) { Top = 1, Left = 0, Width = 98, Height = 8, Border = BorderStyle.Thin, Visible = true };
            return dialogList;
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
