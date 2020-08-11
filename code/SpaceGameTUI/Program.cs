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
            Location oldLocation = new Location(1, 1);
            Location newLocation = new Location();
            int warpSpeed;
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
            var displayMap = MapBoxInitialize(root, planets);  //Map and starfield
            StatusListBox status = CurrentStatusBox(root);  //Status box "Galactic Hawker" box
            DialogListBox dialogList = GameDialogBox(root); //Game Dialog Box

            //Creates the box for the Action buttons
            Button showTravelButton, showBuyButton, showSellButton, showStoryButton, showRetireButton, showQuitButton, warpButton;
            ActionButtonBox(root, out showTravelButton, out showBuyButton, out showSellButton, out showStoryButton, out showRetireButton, out showQuitButton);

            DisplayPlanetList displayPlanetList;
            ListBox planetList;
            PlanetListBox(root, out displayPlanetList, out planetList);

            ListBox inventoryList = InventoryListBox(root);
            PopulatePlanetListForTravel(planets, planetList);

            var warpSpeedBox = new DisplayMainStatus(displayMap) { Text = "Actions", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            warpButton = new Button(warpSpeedBox) { Text = "Travel", Width = 10, Height = 3, Top = 1, Left = 4, Visible = true, Enabled = true };


            //button2.Clicked += (s, e) => { dialog.Hide(); dialog2.Show(); };
            //button3.Clicked += (s, e) => { dialog2.Hide(); dialog.Show(); };



            // Start the business of what happens when they use enters stuff

            //TRAVEL BUTTON SELECTION
            showTravelButton.Clicked += (s, e) => { planetList.Show(); planetList.SetFocus(); };
            string planetName;
            List<string> statusitems;
            PrepWorkForTravel(out oldLocation, planets, ship, player, status, planetList, out planetName, out statusitems);

            planetList.Clicked += (s, e) =>
            {
                //TODO: Need to check that you have enough fuel and time to travel there
                //TODO: Need to get warp speed choice from user
                //TODO: Need to show user the time and fuel it will take to get to a planet

                int warpSpeed = 8;
                newLocation = planets[planetList.SelectedIndex].location;

                warpSpeedBox.Show();

                warpSpeed = GetWarpSpeed(oldLocation, newLocation, ship, player);


                warpSpeedBox.Hide();


                TravelDataToDialogBox(oldLocation, newLocation, warpSpeed, planets, ship, player, dialogList, planetList);

                SpaceTravel.TravelToNewPlanet(oldLocation, newLocation, ship, player, warpSpeed);

                planetName = planets[planetList.SelectedIndex].name;

                status.Items.Clear();

                statusitems = CurrentInfo.Update(player, ship, planets, planetName);
                oldLocation = ship.location;

                foreach (var item in statusitems)
                {
                    status.Items.Add(item);
                }
                root.Run();
            };

            // PURCHASE SECTION
            showBuyButton.Clicked += (s, e) => { };
            //      var showBuyOptions = new DisplayShipInventory(displayPlanetList) { Text = "Inventory", Width = 43, Height = 8, Top = 1, Left = 0, Border = BorderStyle.Thin, Visible = false };

            // SELLING SECTION
            showSellButton.Clicked += (s, e) => { };
            //       showSellButton.Clicked += (s, e) => { planetList.Hide(); inventoryList.Show(); inventoryList.SetFocus(); };


            //STORY SECTION
            showStoryButton.Clicked += (s, e) => { };

            //USER WANTS TO LIVE THE GOOD LIFE AND RETIRE
            showRetireButton.Clicked += (s, e) => { };

            //USER WANTS TO QUIT
            showQuitButton.Clicked += (s, e) => { };


            //    void getindex(int index)
            //    {
            //        ship.location = planets[index].location;
            //    }

            root.Run();
        }

        private static int GetWarpSpeed(Location oldLocation, Location newLocation, Ship ship, Player player)
        {
            int warpSpeed = 7;
            return warpSpeed;
        }

        private static void PrepWorkForTravel(out Location oldLocation, List<Planet> planets, Ship ship, Player player, StatusListBox status, ListBox planetList, out string planetName, out List<string> statusitems)
        {
            planetName = planets[planetList.SelectedIndex].name;
            oldLocation = ship.location;
            statusitems = CurrentInfo.Update(player, ship, planets, planetName);
            foreach (var item in statusitems)
            {
                status.Items.Add(item);
            }
        }

        private static void TravelDataToDialogBox(Location oldLocation, Location newLocation, int warpSpeed, List<Planet> planets, Ship ship, Player player, DialogListBox dialogList, ListBox planetList)
        {
            dialogList.Items.Clear();
            dialogList.Items.Add("You traveled to " + planets[planetList.SelectedIndex].name);
            double tempTime, tempFuel, tempDistance = 42.9;
            tempDistance = SpaceTravel.DistanceCalculation(oldLocation, newLocation);
            (tempTime, tempFuel) = SpaceTravel.WarpSpeedCalcuation(tempDistance, warpSpeed);
            dialogList.Items.Add("Distance was " + tempDistance + " lightyears");
            dialogList.Items.Add("You used " + tempFuel + " fuelies (the official fuel of NASCAR)");
            dialogList.Items.Add("And it took " + tempTime + " years.");
        }

        private static void PopulatePlanetListForTravel(List<Planet> planets, ListBox planetList)
        {
            foreach (var planet in planets)
            {
                string textForPlanet = planet.name + " location: " + Location.ToString(planet.location);
                planetList.Items.Add(textForPlanet);
            }
        }

        private static DisplayMap MapBoxInitialize(RootWindow root, List<Planet> planets)
        {
            var displayMap = new DisplayMap(root) { Text = "MAP", Width = 98, Height = 35, Top = 2, Left = 2, Border = BorderStyle.Thin };
            CreateStarField(displayMap);
            PutPlanetsOnMap(planets, displayMap);
            return displayMap;
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

        private static void ActionButtonBox(RootWindow root, out Button showTravelButton, out Button showBuyButton, out Button showSellButton, out Button showStoryButton, out Button showRetireButton, out Button showQuitButton)
        {
            var actionBox = new DisplayPlanetList(root) { Text = "Actions", Width = 43, Height = 10, Top = 14, Left = 104, Border = BorderStyle.Thick };
            showTravelButton = new Button(actionBox) { Text = "Travel", Width = 10, Height = 3, Top = 1, Left = 4, Visible = true };
            showBuyButton = new Button(actionBox) { Text = "Buy", Width = 10, Height = 3, Top = 1, Left = 16, Visible = true };
            showSellButton = new Button(actionBox) { Text = "Sell", Width = 10, Height = 3, Top = 1, Left = 28, Visible = true };
            showStoryButton = new Button(actionBox) { Text = "Story Info", Width = 10, Height = 3, Top = 5, Left = 4, Visible = true };
            showRetireButton = new Button(actionBox) { Text = "Retire", Width = 10, Height = 3, Top = 5, Left = 16, Visible = true };
            showQuitButton = new Button(actionBox) { Text = "Quit", Width = 10, Height = 3, Top = 5, Left = 28, Visible = true };
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
