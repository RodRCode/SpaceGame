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
            var ship = new Ship(shipLocation, Item.shipItemList());

            Console.WriteLine();
            Console.Write("Enter Your Name:  ");
            string name = "Zaphod Beeblebrox";
            //TODO           string name = Console.ReadLine();
            var player = new Player(name);

            // Application.Init();

            // Create the windows on the display
            var displayMap = MapBoxInitialize(root, planets);  //Map and starfield
            StatusListBox status = CurrentStatusBox(root);  //Status box "Galactic Hawker" box
            DialogListBox dialogList = GameDialogBox(root); //Game Dialog Box

            //Creates the box for the Action buttons
            // TODO figure out how to have the window close when the "done" button is selected

            Button showTravelButton, showBuyButton, showSellButton, showStoryButton, showRetireButton, showQuitButton, warpButton, returnFromSell, returnFromBuy, returnFromStory, returnFromRetire, returnFromQuit;
            ActionButtonBox(root, out showTravelButton, out showBuyButton, out showSellButton, out showStoryButton, out showRetireButton, out showQuitButton);

            DisplayPlanetList displayPlanetList;
            ListBox planetList;
            PlanetListBox(root, out displayPlanetList, out planetList);

            ListBox inventoryList = InventoryListBox(root);

            foreach (var item in ship.cargoList)
            {
                string textForInventory = item.name + " Qty: " + item.quantity + " wt: " + item.weight;
                inventoryList.Items.Add(textForInventory);
            }

            PopulatePlanetListForTravel(planets, planetList);

            //Create all the popup boxes
            DisplayMainStatus warpSpeedBox, buyBox, sellBox, storyBox, retireBox, quitBox;

            AllPopUpBoxes(displayMap, out warpButton, out returnFromSell, out returnFromBuy, out returnFromStory, out returnFromRetire, out returnFromQuit, out warpSpeedBox, out buyBox, out sellBox, out storyBox, out retireBox, out quitBox);

            ReturnInfoFromButtons(root, returnFromSell, returnFromBuy, returnFromStory, returnFromRetire, returnFromQuit, buyBox, sellBox, storyBox, retireBox, quitBox);

            // Start the business of what happens when they use enters stuff

            //TRAVEL BUTTON SELECTION
            showTravelButton.Clicked += (s, e) => { planetList.Show(); planetList.SetFocus(); };
            string planetName;
            List<string> statusitems;
            PrepWorkForTravel(out oldLocation, planets, ship, player, status, planetList, out planetName, out statusitems);

            planetList.Clicked += (s, e) =>
            {
                int warpSpeed = 8;
                bool travelYes = false;
                newLocation = planets[planetList.SelectedIndex].location;

                //         warpSpeedBox.Show();

                (warpSpeed, travelYes) = GetWarpSpeed(oldLocation, newLocation, ship, player, dialogList);

                warpSpeedBox.Hide();

                if (travelYes)
                {
                    TravelDataToDialogBox(oldLocation, newLocation, warpSpeed, planets, ship, player, dialogList, planetList);

                    SpaceTravel.TravelToNewPlanet(oldLocation, newLocation, ship, player, warpSpeed);

                    planetName = planets[planetList.SelectedIndex].name;
                }

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
            showBuyButton.Clicked += (s, e) =>
            {
                buyBox.Show();

                // Need a list of things you hit enter and it shows what you bought in the game dialog
            };
            // TODO create the purchase section
            // TODO: create the Transactions class

            // SELLING SECTION
            showSellButton.Clicked += (s, e) => { sellBox.Show(); };
            //       showSellButton.Clicked += (s, e) => { planetList.Hide(); inventoryList.Show(); inventoryList.SetFocus(); };

            //STORY SECTION
            showStoryButton.Clicked += (s, e) => { storyBox.Show(); };
            // TODO: Get the story to the user

            //USER WANTS TO LIVE THE GOOD LIFE AND RETIRE
            showRetireButton.Clicked += (s, e) => { retireBox.Show(); };
            // TODO: Have a way to exit the program and give the user a final screen/window

            //USER WANTS TO QUIT
            showQuitButton.Clicked += (s, e) => { quitBox.Show(); };
            // TODO: Have a way to exit the program and give the user a final goodbye

            root.Run();
        }

        private static void ReturnInfoFromButtons(RootWindow root, Button returnFromSell, Button returnFromBuy, Button returnFromStory, Button returnFromRetire, Button returnFromQuit, DisplayMainStatus buyBox, DisplayMainStatus sellBox, DisplayMainStatus storyBox, DisplayMainStatus retireBox, DisplayMainStatus quitBox)
        {
            returnFromBuy.Clicked += (s, e) => { buyBox.Hide(); root.Run(); };
            returnFromSell.Clicked += (s, e) => { sellBox.Hide(); root.Run(); };
            returnFromStory.Clicked += (s, e) => { storyBox.Hide(); root.Run(); };
            returnFromRetire.Clicked += (s, e) => { retireBox.Hide(); root.Run(); };
            returnFromQuit.Clicked += (s, e) => { quitBox.Hide(); root.Run(); };
        }

        private static void AllPopUpBoxes(DisplayMap displayMap, out Button warpButton, out Button returnFromSell, out Button returnFromBuy, out Button returnFromStory, out Button returnFromRetire, out Button returnFromQuit, out DisplayMainStatus warpSpeedBox, out DisplayMainStatus buyBox, out DisplayMainStatus sellBox, out DisplayMainStatus storyBox, out DisplayMainStatus retireBox, out DisplayMainStatus quitBox)
        {
            WarpSpeedPopBox(displayMap, out warpButton, out warpSpeedBox);
            BuyPopUpBox(displayMap, out returnFromBuy, out buyBox);
            SellPopUpBox(displayMap, out returnFromSell, out sellBox);
            StoryPopUpBox(displayMap, out returnFromStory, out storyBox);
            RetirePopUpBox(displayMap, out returnFromRetire, out retireBox);
            QuitPopUpBox(displayMap, out returnFromQuit, out quitBox);
        }

        private static void QuitPopUpBox(DisplayMap displayMap, out Button returnFromQuit, out DisplayMainStatus quitBox)
        {
            quitBox = new DisplayMainStatus(displayMap) { Text = "Quit", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            returnFromQuit = new Button(quitBox) { Text = "Quit", Width = 10, Height = 3, Top = 1, Left = 4, Visible = true, Enabled = true };
            Console.ReadLine();
        }

        private static void RetirePopUpBox(DisplayMap displayMap, out Button returnFromRetire, out DisplayMainStatus retireBox)
        {
            retireBox = new DisplayMainStatus(displayMap) { Text = "Retire", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            returnFromRetire = new Button(retireBox) { Text = "Retire", Width = 10, Height = 3, Top = 1, Left = 4, Visible = true, Enabled = true };
            Console.ReadLine();
        }

        private static void StoryPopUpBox(DisplayMap displayMap, out Button returnFromStory, out DisplayMainStatus storyBox)
        {
            storyBox = new DisplayMainStatus(displayMap) { Text = "Story", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            returnFromStory = new Button(storyBox) { Text = "Story", Width = 10, Height = 3, Top = 1, Left = 4, Visible = true, Enabled = true };
            Console.ReadLine();
        }

        private static void SellPopUpBox(DisplayMap displayMap, out Button returnFromSell, out DisplayMainStatus sellBox)
        {
            sellBox = new DisplayMainStatus(displayMap) { Text = "Sell", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            returnFromSell = new Button(sellBox) { Text = "Sell", Width = 10, Height = 3, Top = 1, Left = 4, Visible = true, Enabled = true };
            Console.ReadLine();
        }

        private static void BuyPopUpBox(DisplayMap displayMap, out Button returnFromBuy, out DisplayMainStatus buyBox)
        {
            buyBox = new DisplayMainStatus(displayMap) { Text = "Buy", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            returnFromBuy = new Button(buyBox) { Text = "Buy", Width = 10, Height = 3, Top = 1, Left = 4, Visible = true, Enabled = true };
            Console.ReadLine();
        }

        private static void WarpSpeedPopBox(DisplayMap displayMap, out Button warpButton, out DisplayMainStatus warpSpeedBox)
        {
            warpSpeedBox = new DisplayMainStatus(displayMap) { Text = "Warp Speed", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            warpButton = new Button(warpSpeedBox) { Text = "Travel", Width = 10, Height = 3, Top = 1, Left = 4, Visible = true, Enabled = true };
        }

        private static (int, bool) GetWarpSpeed(Location oldLocation, Location newLocation, Ship ship, Player player, DialogListBox dialogList)
        {
            //TODO list of warp speed and it shows you the list of calculations

            int warpSpeed = 7;
            bool done = false;
            bool travelYes = false;

            do
            {
                dialogList.Items.Clear();
                dialogList.Items.Add("Enter 'q' to exit the warp speed selection");
                dialogList.Items.Add("What is your warp speed of choice (1-9): ");
                var numChar = Console.ReadKey(true);
                var numString = numChar.KeyChar.ToString();
                if (numString == "q")
                {
                    done = true;
                    dialogList.Items.Clear();
                }
                else
                {
                    warpSpeed = int.Parse(numChar.KeyChar.ToString());
                    double tempTime, tempFuel, tempDistance = 42.9;
                    tempDistance = SpaceTravel.DistanceCalculation(oldLocation, newLocation);
                    (tempTime, tempFuel) = SpaceTravel.WarpSpeedCalcuation(tempDistance, warpSpeed);
                    dialogList.Items.Add("That is " + tempDistance + " lightyears away");
                    dialogList.Items.Add("You will use " + tempFuel + " fuelies to get there at Warp " + warpSpeed);
                    dialogList.Items.Add("And will take " + tempTime + " years.");
                    bool canTravel = travelCheck(tempTime, tempFuel, player, ship, dialogList);
                    string answer = "n";
                    if (canTravel)
                    {
                        dialogList.Items.Add("Do you want to go now? Y/N: ");
                        numChar = Console.ReadKey(true);
                        answer = numChar.KeyChar.ToString();
                    }

                    if (answer == "y")
                    {
                        done = true;
                        travelYes = true;
                    }
                    else
                    {
                        dialogList.Items.Add("Do you want to try a different Warp speed? Y/N: ");
                        numChar = Console.ReadKey(true);
                        answer = numChar.KeyChar.ToString();
                        if (answer == "n")
                        {
                            done = true;
                            travelYes = false;
                        }
                    }
                };

            } while (!done);

            return (warpSpeed, travelYes);
        }

        private static bool travelCheck(double tempTime, double tempFuel, Player player, Ship ship, DialogListBox dialogList)
        {
            if (((tempTime + player.Age) <= 70) && (tempFuel < ship.fuelLevel))
            {
                return (true);
            }
            else
            {
                if ((tempTime + player.Age) > 70)
                {
                    dialogList.Items.Add("Sorry, you are too old for that trip!  Use more Warp speed, or just retire!");
                }
                else
                {
                    dialogList.Items.Add("You don't have enough fuel to make the trip at that warp speed. Try something slower");
                }
                return (false);

            }
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
                // TODO add an if statement here to make the selected planet a spinner
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
