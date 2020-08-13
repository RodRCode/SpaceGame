using System;
using System.Collections.Generic;
using System.Text;
using SGClasses;
using CLRCLI;
using CLRCLI.Widgets;
using System.Runtime.InteropServices;
using System.Threading;

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
            var root = new RootWindow();
            var planets = Planet.PopulatePlanets();

            // Declare the first few notes of the song, "Mary Had A Little Lamb".

            Console.SetWindowSize(consoleWidth, consoleHeight);

            Location shipLocation = new Location(1, 1);
            var ship = new Ship(shipLocation, Item.shipItemList());



            Console.WriteLine();
            Console.Write("Enter Your Name:  ");
            string name = "Zaphod Beeblebrox";

            Console.Clear();
            Console.WriteLine(Planet.Backstory());

            name = ForAQuickIntroCommentMeOut();

            var player = new Player(name);

            // Application.Init();

            // Create the windows on the display
            var displayMap = MapBoxInitialize(root, planets);  //Map and starfield
            StatusListBox status = CurrentStatusBox(root);  //Status box "Galactic Hawker" box
            DialogListBox dialogList = GameDialogBox(root); //Game Dialog Box

            //Creates the box for the Action buttons

            Button showTravelButton, showBuyButton, showSellButton, showStoryButton, showRetireButton, showQuitButton, warpButton, returnFromSell, returnFromBuy, returnFromStory, returnFromRetire, returnFromQuit;

            ActionButtonBox(root, out showTravelButton, out showBuyButton, out showSellButton, out showStoryButton, out showRetireButton, out showQuitButton);

            DisplayPlanetList displayPlanetList;
            ListBox planetList;
            PlanetListBox(root, out displayPlanetList, out planetList);

            ListBox inventoryList = InventoryListBox(root);

            UpdateInventoryList(ship, inventoryList);

            PopulatePlanetListForTravel(planets, planetList);

            //Create all the popup boxes
            DisplayMainStatus warpSpeedBox, buyBox, sellBox, storyBox, retireBox, quitBox;


            AllPopUpBoxes(displayMap, out warpButton, out returnFromSell, out returnFromBuy, out returnFromStory, out returnFromRetire, out returnFromQuit, out warpSpeedBox, out buyBox, out sellBox, out storyBox, out retireBox, out quitBox);

            ConsoleColor colorRed = (ConsoleColor)4;
            ConsoleColor colorBlue = (ConsoleColor)1;

            Spinner spinny = new Spinner(displayMap) { Top = 0, Left = 1, Spinning = true, Visible = true, Foreground = colorRed };
            TinySpinner tinyspin = new TinySpinner(displayMap) { Top = 1, Left = 2, Spinning = true, Visible = true, Background = colorBlue };

            ReturnInfoFromButtons(root, returnFromSell, returnFromBuy, returnFromStory, returnFromRetire, returnFromQuit, buyBox, sellBox, storyBox, retireBox, quitBox, tinyspin, spinny);

            // Start the business of what happens when they use enters stuff

            //TRAVEL BUTTON SELECTION
            showTravelButton.Clicked += (s, e) =>
            {
                //   showTravelButton.Hide();


                planetList.Show(); planetList.SetFocus();
            };
            string planetName;
            List<string> statusitems;
            PrepWorkForTravel(out oldLocation, planets, ship, player, status, planetList, out planetName, out statusitems);

            planetList.Clicked += (s, e) =>
            {
                int warpSpeed = 8;
                bool travelYes = false;
                newLocation = planets[planetList.SelectedIndex].location;

                (warpSpeed, travelYes) = GetWarpSpeed(oldLocation, newLocation, ship, player, dialogList);

                warpSpeedBox.Hide();

                if (travelYes)
                {
                    TravelDataToDialogBox(oldLocation, newLocation, warpSpeed, planets, ship, player, dialogList, planetList);

                    SpaceTravel.TravelToNewPlanet(oldLocation, newLocation, ship, player, warpSpeed);

                    Random getAttacked = new Random();
                    int randomEvent = getAttacked.Next(0, 50);
                    if (randomEvent == 19)
                    {
                        TurnOffSpinners(spinny, tinyspin);
                        KilledByPirates(ship, player);
                    }
                    if (randomEvent == 42)
                    {
                        TurnOffSpinners(spinny, tinyspin);
                        KilledByTribbles(ship, player);
                    }

                    spinny.Top = newLocation.y - 1;
                    spinny.Left = newLocation.x;
                    tinyspin.Top = newLocation.y;
                    tinyspin.Left = newLocation.x + 1;

                    ship.planetName = planets[planetList.SelectedIndex].name;
                }

                status.Items.Clear();

                statusitems = CurrentInfo.Update(player, ship, planets);
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
                TurnOffSpinners(spinny, tinyspin);
                buyBox.Show();

                ListBox buyList;
                buyList = new ListBox(buyBox) { Top = 1, Left = 1, Width = 43, Height = 8, Border = BorderStyle.Thin, Visible = true };

                string currentShipPlanetName = ship.planetName;
                var currentIndex = planets.FindIndex(x => x.name.Contains(currentShipPlanetName));

                buyList.Items.Clear();
                CreateAndPopulateBuyList(planets, buyList, currentIndex);

                buyList.SetFocus();
                buyList.Clicked += (s, e) =>
                {
                    int currentItem;
                    currentItem = buyList.SelectedIndex;
                    var currentPlanet = planets[currentIndex];
                    double cost = currentPlanet.itemList[currentItem].planetCostFactor * currentPlanet.itemList[currentItem].value;
                    var currentItemName = currentPlanet.itemList[currentItem].name;
                    double weight = currentPlanet.itemList[currentItem].weight;
                    double newCapacity = ship.totalCapacity - weight;

                    if (currentItemName == "Fuel              ") // special case for fuel
                    {
                        cost = 1;
                        if (EnoughMoney(player, cost))
                        {
                            dialogList.Items.Clear();
                            dialogList.Items.Add("You bought some " + currentItemName);
                            ship.fuelLevel += 100; ;
                            player.Money--;
                        }
                        else
                        {
                            dialogList.Items.Clear();
                            dialogList.Items.Add("You don't have enough money to buy that!");
                        }
                    }
                    else
                if (newCapacity >= 0)
                    {
                        {
                            if (EnoughMoney(player, cost))
                            {
                                var shipItemIndex = ship.cargoList.FindIndex(x => x.name.Contains(currentItemName));

                                if (shipItemIndex >= 0)
                                {
                                    ship.cargoList[shipItemIndex].quantity++;
                                    ship.totalCapacity -= weight;
                                    dialogList.Items.Clear();
                                    dialogList.Items.Add("You bought some " + currentItemName);
                                    UpdateInventoryList(ship, inventoryList);
                                    player.Money -= cost;
                                }
                            }
                            else
                            {
                                dialogList.Items.Clear();
                                dialogList.Items.Add("You don't have enough money to buy that!");
                            }
                        }
                    }
                    else
                    {
                        dialogList.Items.Clear();
                        dialogList.Items.Add("Your ship doesn't have the capacity to hold that too!");
                    }
                    statusitems = UpdateStatusBox(planets, ship, player, status);
                };
            };

            // SELLING SECTION
            showSellButton.Clicked += (s, e) =>
            {
                TurnOffSpinners(spinny, tinyspin);
                sellBox.Show();

                ListBox sellList;
                sellList = new ListBox(sellBox) { Top = 1, Left = 1, Width = 43, Height = 8, Border = BorderStyle.Thin, Visible = true };

                string currentShipPlanetName = ship.planetName;
                var currentIndex = planets.FindIndex(x => x.name.Contains(currentShipPlanetName));

                sellList.Items.Clear();
                CreateAndPopulateSellList(planets, sellList, currentIndex);

                sellList.SetFocus();
                sellList.Clicked += (s, e) =>
                {
                    int currentItem;
                    currentItem = sellList.SelectedIndex;
                    var currentPlanet = planets[currentIndex];
                    double sellPrice = currentPlanet.itemList[currentItem].planetCostFactor * currentPlanet.itemList[currentItem].value;
                    var currentItemName = currentPlanet.itemList[currentItem].name;
                    double weight = currentPlanet.itemList[currentItem].weight;
                    double newCapacity = ship.totalCapacity - weight;

                    if (currentItemName == "Fuel              ") // special case for fuel
                    {
                        if (ship.fuelLevel > 0)
                        {
                            sellPrice = 1;
                            dialogList.Items.Clear();
                            dialogList.Items.Add("You sold some " + currentItemName);
                            ship.fuelLevel -= 100; ;
                            player.Money++;
                            if (player.Money > 100000)
                            {
                                TheRichEnding(ship, player);
                            }
                        }
                        else
                        {
                            dialogList.Items.Clear();
                            dialogList.Items.Add("You don't have any " + currentItemName + " go buy some!");
                        }
                    }
                    else
                    {

                        var shipItemIndex = ship.cargoList.FindIndex(x => x.name.Contains(currentItemName));

                        if (shipItemIndex >= 0)
                        {
                            if (ship.cargoList[shipItemIndex].quantity > 0)
                            {
                                ship.cargoList[shipItemIndex].quantity--;
                                ship.totalCapacity += weight;
                                dialogList.Items.Clear();
                                dialogList.Items.Add("You sold some " + currentItemName);
                                UpdateInventoryList(ship, inventoryList);
                                player.Money += sellPrice;

                                if (player.Money > 100000)
                                {
                                    TheRichEnding(ship, player);
                                }
                            }
                            else
                            {
                                dialogList.Items.Clear();
                                dialogList.Items.Add("You don't have any " + currentItemName + " go buy some!");
                            }
                        }
                        else
                        {
                            dialogList.Items.Clear();
                            dialogList.Items.Add("That is some kind of error that shouldn't have happened!  Weird!!!");
                        }

                    }
                    statusitems = UpdateStatusBox(planets, ship, player, status);
                };
            };

            //STORY SECTION
            showStoryButton.Clicked += (s, e) =>
            {
                TurnOffSpinners(spinny, tinyspin);

                storyBox.Show();

                ReadPlanetInfoToTheConsole(planets);
            };

            //USER WANTS TO LIVE THE GOOD LIFE AND RETIRE
            showRetireButton.Clicked += (s, e) =>
            {
                TurnOffSpinners(spinny, tinyspin);

                UserMadeAGreatChoiceAndRetired(ship, player);

                Environment.Exit(42);
                // retireBox.Show();
            };

            //USER WANTS TO QUIT
            showQuitButton.Clicked += (s, e) =>
            {
                TurnOffSpinners(spinny, tinyspin);

                UserDecidedToQuit();

                // quitBox.Show();
                Environment.Exit(90210);
            };

            root.Run();
        }

        private static void KilledByTribbles(Ship ship, Player player)
        {
            Console.Clear();
            Console.ResetColor();
            Console.Clear();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            Console.WriteLine($"\n\n\n\n\nWell, {player.Name} you remember those Black Market goods you picked up?");
            Console.WriteLine($"\nTurns out you were transporting Tribbles.  Cute and cuddly and hating Klingons, but voracious");
            Console.WriteLine($"and extremly prolific reproducers.  The {ship.shipName} couldn't hold them all and the hull");
            Console.WriteLine($"ripped like a rotten tomato.  Here you float in the vastness of the void at Age {player.Age:f0}.\n");
            Console.WriteLine($"\n\nMaybe don't take questionable cargo in your future lives");
            Console.WriteLine($"\n\n\nYou had a \"meh\" life {player.Name}.  Next time don't push your luck.\n\n\n\n\nPlease play again.");
            Console.WriteLine("\n\n\n\n\nThis has been a Jay and Rod production.\n\n\nHit enter to exit\n\n");
            StarWars();
            Console.ReadLine();
            Environment.Exit(215);
        }

        private static string ForAQuickIntroCommentMeOut()
        {
            string name;
            Note[] Mary = PlayMaryHadALittleLamb();
            Play(Mary);
            StarWars();

            Console.ReadLine();

            Console.Clear();
            Console.Write("\n\nWhat is the name of our most resent cannonfodder.... er, recruit? ");

            name = Console.ReadLine();
            return name;
        }

        private static void KilledByPirates(Ship ship, Player player)
        {
            Console.Clear();
            Console.ResetColor();
            Console.Clear();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            Console.WriteLine($"\n\n\n\n\nWell, {player.Name} your ship was attacked by the Dread Pirate Roberts who never leaves captives alive.");
            Console.WriteLine($"\nAnd that is exactly what happened here.  He took your {player.Money:f0} credits, ransacked the");
            Console.WriteLine($"{ship.shipName} and thought about marooning your on {ship.planetName}, but thought better of it and");
            Console.WriteLine($"simply threw you out the airlock at the tender age of {player.Age:f0}.\n");
            Console.WriteLine($"Lets be real, you only had about {70 - player.Age:f0} years left in you anyway.");
            Console.WriteLine($"\n\n\nYou had a \"meh\" life {player.Name}.  Next time don't push your luck.\n\n\n\n\nPlease play again.");
            Console.WriteLine("\n\n\n\n\nThis has been a Jay and Rod production.\n\n\nHit enter to exit\n\n");
            StarWars();
            Console.ReadLine();
            Environment.Exit(666);
        }

        private static void TheRichEnding(Ship ship, Player player)
        {
            Console.Clear();
            Console.ResetColor();
            Console.Clear();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            string lyric = "\n\n\nAnd you may find yourself\nLiving in a shotgun shack\nAnd you may find yourself\nIn another part of the world\nAnd you may find yourself\nBehind the wheel of a large automobile\nAnd you may find yourself in a beautiful house\nWith a beautiful wife\nAnd you may ask yourself, well\nHow did I get here ?\n\n";
            Console.WriteLine(lyric);
            Console.WriteLine($"Well, {player.Name} you got here because you were a MAGNIFICENT trader!  You got over {player.Money:f0} credits");
            Console.WriteLine($"and decided it was time to sell the {ship.shipName} and settle down on {ship.planetName}");
            Console.WriteLine($"\nSit back, relax, play some Tetris, you earned it at the ripe old age of {player.Age:f0}.");
            Console.WriteLine($"Lets be real, you only had about {70 - player.Age:f0} years left in you anyway.");
            Console.WriteLine($"\n\n\nYou had a mostly good life {player.Name}.  Congrats!\n\n\n\n\nPlease play again.");
            Console.WriteLine("\n\n\n\n\nThis has been a Jay and Rod production.\n\n\nHit enter to exit\n\n");
            PlayTetrisSong();
            Console.ReadLine();
            Environment.Exit(8675309);
        }

        private static void ReadPlanetInfoToTheConsole(List<Planet> planets)
        {
            Console.Clear();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            string textFromPlanet = "";
            Console.WriteLine(textFromPlanet);

            for (int i = 0; i < 7; i++)
            {
                textFromPlanet = planets[i].planetInfo;
                Console.Clear();
                Console.WriteLine(textFromPlanet);
                Console.ReadLine();
            }
        }

        private static void UserMadeAGreatChoiceAndRetired(Ship ship, Player player)
        {
            Console.Clear();
            Console.ResetColor();
            Console.Clear();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("\n\n\n\nLooking around at the Universe you have suddenly wondered WHY you have done all this.\n");
            Console.WriteLine("You have lost so much time just wandering between planets in the dark nothingness that is the long cold");
            Console.WriteLine("void between the lonely stars.  Maybe there is something more, something deeper that you want.");
            Console.WriteLine($"\n\nYou find a nice place on {ship.planetName} that you manage to buy with your earnings");
            Console.WriteLine($"\"{player.Money:f0} Galactic Patrol credits for this place isn't too bad\" you think to yourself.");
            Console.WriteLine("You take it easy, catch up on the space videos you have missed while working and play some O.G. Mario.");
            Console.WriteLine($"\n\nAfter some time (not too long, you decided to retire at {player.Age:f0} after all) you find someone");
            Console.WriteLine("who puts up with your hardbitten space louse ways.  You move in together, and eventually you both grow old together");
            Console.WriteLine($"and after {70 - player.Age:f0} years you pass away peacefully in your sleep.  Not screaming in terror like your passengers.");
            Console.WriteLine($"\n\n\nYou had a mostly good life {player.Name}.  Congrats!\n\n\n\n\nPlease play again.");
            Console.WriteLine("\n\n\n\n\nThis has been a Jay and Rod production.\n\n\nHit enter to exit\n\n");
            PlaySomeRetirementMusic();
            Console.ReadLine();
        }

        private static void UserDecidedToQuit()
        {
            Console.Clear();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\nTHANK YOU FOR PLAYING!\n\nI hope you try again soon!\n\n\n");
        }

        private static void TurnOnSpinners(Spinner spinny, TinySpinner tinyspin)
        {
            spinny.Visible = true;
            tinyspin.Visible = true;
        }

        private static void TurnOffSpinners(Spinner spinny, TinySpinner tinyspin)
        {
            spinny.Visible = false;
            tinyspin.Visible = false;
        }

        private static void CreateAndPopulateSellList(List<Planet> planets, ListBox sellList, int currentIndex)
        {
            foreach (var item in planets[currentIndex].itemList)
            {
                double cost = item.planetCostFactor * item.value;
                string textForInventory = item.name + " wt: " + item.weight + " cost: " + cost;
                sellList.Items.Add(textForInventory);
            }
        }

        private static bool EnoughMoney(Player player, double cost)
        {
            bool enoughMoney = false;
            if (cost < player.Money)
            { enoughMoney = true; }
            return enoughMoney;
        }

        private static void UpdateInventoryList(Ship ship, ListBox inventoryList)
        {
            inventoryList.Items.Clear();
            foreach (var item in ship.cargoList)
            {
                string textForInventory = item.name + " Qty: " + item.quantity + " wt: " + item.weight;
                inventoryList.Items.Add(textForInventory);
            }
        }

        private static List<string> UpdateStatusBox(List<Planet> planets, Ship ship, Player player, StatusListBox status)
        {
            List<string> statusitems = CurrentInfo.Update(player, ship, planets);
            status.Items.Clear();
            foreach (var item in statusitems)
            {
                status.Items.Add(item);
            }

            return statusitems;
        }

        private static void CreateAndPopulateBuyList(List<Planet> planets, ListBox buyList, int currentIndex)
        {
            foreach (var item in planets[currentIndex].itemList)
            {
                double cost = item.planetCostFactor * item.value;
                string textForInventory = item.name + " wt: " + item.weight + " cost: " + string.Format("{0:0.0}", cost);
                buyList.Items.Add(textForInventory);
            }
        }



        private static void ReturnInfoFromButtons(RootWindow root, Button returnFromSell, Button returnFromBuy, Button returnFromStory, Button returnFromRetire, Button returnFromQuit, DisplayMainStatus buyBox, DisplayMainStatus sellBox, DisplayMainStatus storyBox, DisplayMainStatus retireBox, DisplayMainStatus quitBox, TinySpinner tinyspin, Spinner spinny)
        {
            returnFromBuy.Clicked += (s, e) =>
            {
                buyBox.Hide();
                TurnOnSpinners(spinny, tinyspin);
                root.Run();
            };
            returnFromSell.Clicked += (s, e) =>
            {
                sellBox.Hide();
                TurnOnSpinners(spinny, tinyspin);
                root.Run();
            };
            returnFromStory.Clicked += (s, e) =>
            {
                storyBox.Hide();
                TurnOnSpinners(spinny, tinyspin);
                root.Run();
            };
            returnFromRetire.Clicked += (s, e) =>
            {
                retireBox.Hide();
                TurnOnSpinners(spinny, tinyspin);
                root.Run();
            };
            returnFromQuit.Clicked += (s, e) =>
            {
                quitBox.Hide();
                TurnOnSpinners(spinny, tinyspin);
                root.Run();
            };
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
            returnFromQuit = new Button(quitBox) { Text = "Exit", Width = 10, Height = 3, Top = 10, Left = 4, Visible = true };
        }

        private static void RetirePopUpBox(DisplayMap displayMap, out Button returnFromRetire, out DisplayMainStatus retireBox)
        {
            retireBox = new DisplayMainStatus(displayMap) { Text = "Retire", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            returnFromRetire = new Button(retireBox) { Text = "Exit", Width = 10, Height = 3, Top = 10, Left = 4, Visible = true };
        }

        private static void StoryPopUpBox(DisplayMap displayMap, out Button returnFromStory, out DisplayMainStatus storyBox)
        {
            storyBox = new DisplayMainStatus(displayMap) { Text = "Story", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            returnFromStory = new Button(storyBox) { Text = "Exit", Width = 10, Height = 3, Top = 10, Left = 4, Visible = true };

        }

        private static void SellPopUpBox(DisplayMap displayMap, out Button returnFromSell, out DisplayMainStatus sellBox)
        {
            sellBox = new DisplayMainStatus(displayMap) { Text = "Sell", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            returnFromSell = new Button(sellBox) { Text = "Exit", Width = 10, Height = 3, Top = 10, Left = 4, Visible = true };
        }

        private static void BuyPopUpBox(DisplayMap displayMap, out Button returnFromBuy, out DisplayMainStatus buyBox)
        {
            buyBox = new DisplayMainStatus(displayMap) { Text = "Buy", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            returnFromBuy = new Button(buyBox) { Text = "Exit", Width = 10, Height = 3, Top = 10, Left = 4, Visible = true };
        }

        private static void WarpSpeedPopBox(DisplayMap displayMap, out Button warpButton, out DisplayMainStatus warpSpeedBox)
        {
            warpSpeedBox = new DisplayMainStatus(displayMap) { Text = "Warp Speed", Width = 75, Height = 26, Top = 6, Left = 20, Border = BorderStyle.Thick, Visible = false };
            warpButton = new Button(warpSpeedBox) { Text = "Travel", Width = 10, Height = 3, Top = 1, Left = 4, Visible = true };
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

                string numString = CheckIfValidNumOrQ(dialogList);

                if (numString == "q")
                {
                    done = true;
                    dialogList.Items.Clear();
                }
                else
                {
                    warpSpeed = int.Parse(numString);
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
                        answer = CheckIfValidYorN(dialogList);
                    }

                    if (answer == "y")
                    {
                        done = true;
                        travelYes = true;
                    }
                    else
                    {
                        dialogList.Items.Add("Do you want to try a different Warp speed? y/n: ");
                        answer = CheckIfValidYorN(dialogList);
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

        private static string CheckIfValidYorN(DialogListBox dialogList)
        {
            ConsoleKeyInfo numChar;
            numChar = Console.ReadKey(true);
            string numString = "";
            try
            {
                numString = numChar.KeyChar.ToString();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                dialogList.Items.Add("That is not what we were looking for. Some");
                Console.ResetColor();
                return ("n");
            }
            return (numString);
        }

        private static string CheckIfValidNumOrQ(DialogListBox dialogList)
        {
            ConsoleKeyInfo numChar;
            numChar = Console.ReadKey(true);
            string numString = "";
            int numInt = 0;
            try
            {
                numString = numChar.KeyChar.ToString();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                dialogList.Items.Add("That is not what we were looking for.  Please enter a number 1 to 9 or the letter 'q'.");
                dialogList.Items.Add("Giving you default value of '1'");
                Console.ResetColor();
                return ("1");
            }
            if (numString == "q")
            {
                return (numString);
            }

            try
            {
                numInt = int.Parse(numString);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                dialogList.Items.Add("That is not what we were looking for.  Please enter a number 1 to 9 or the letter 'q'.");
                Console.ResetColor();
            }
            if (numInt > 0 && numInt < 10)
            {
                return (numString);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            dialogList.Items.Add("You set a wrong value, so your warp value is set to 1.");
            Console.ResetColor();
            return ("1");
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
            statusitems = CurrentInfo.Update(player, ship, planets);
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

            var status = new StatusListBox(displayMainstatus) { Top = 0, Left = 0, Width = 43, Height = 9, Border = BorderStyle.Thin, Visible = true };
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

        //Console.Beep() https://code.sololearn.com/cN9GCp8sxk8L/#cs
        private static void StarWars()
        {
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
        }

        // Got the Mario Console.Beep() music from https://hashtagakash.wordpress.com/2014/01/22/182/
        private static void PlaySomeRetirementMusic()
        {
            Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125); Thread.Sleep(375); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(375); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125); Thread.Sleep(1125); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125);
        }

        private static void PlayTetrisSong()
        {
            Console.Beep(1320, 500); Console.Beep(990, 250); Console.Beep(1056, 250); Console.Beep(1188, 250); Console.Beep(1320, 125); Console.Beep(1188, 125); Console.Beep(1056, 250); Console.Beep(990, 250); Console.Beep(880, 500); Console.Beep(880, 250); Console.Beep(1056, 250); Console.Beep(1320, 500); Console.Beep(1188, 250); Console.Beep(1056, 250); Console.Beep(990, 750); Console.Beep(1056, 250); Console.Beep(1188, 500); Console.Beep(1320, 500); Console.Beep(1056, 500); Console.Beep(880, 500); Console.Beep(880, 500); System.Threading.Thread.Sleep(250); Console.Beep(1188, 500); Console.Beep(1408, 250); Console.Beep(1760, 500); Console.Beep(1584, 250); Console.Beep(1408, 250); Console.Beep(1320, 750); Console.Beep(1056, 250); Console.Beep(1320, 500); Console.Beep(1188, 250); Console.Beep(1056, 250); Console.Beep(990, 500); Console.Beep(990, 250); Console.Beep(1056, 250); Console.Beep(1188, 500); Console.Beep(1320, 500); Console.Beep(1056, 500); Console.Beep(880, 500); Console.Beep(880, 500);
        }
        // Play the notes in a song.
        private static Note[] PlayMaryHadALittleLamb()
        {
            Note[] Mary =
            {
             new Note(Tone.B, Duration.QUARTER),
             new Note(Tone.A, Duration.QUARTER),
             new Note(Tone.GbelowC, Duration.QUARTER),
             new Note(Tone.A, Duration.QUARTER),
             new Note(Tone.B, Duration.QUARTER),
             new Note(Tone.B, Duration.QUARTER),
             new Note(Tone.B, Duration.HALF),
             new Note(Tone.A, Duration.QUARTER),
             new Note(Tone.A, Duration.QUARTER),
             new Note(Tone.A, Duration.HALF),
             new Note(Tone.B, Duration.QUARTER),
             new Note(Tone.D, Duration.QUARTER),
             new Note(Tone.D, Duration.HALF)
             };
            return (Mary);
        }
        protected static void Play(Note[] tune)
        {
            foreach (Note n in tune)
            {
                if (n.NoteTone == Tone.REST)
                    Thread.Sleep((int)n.NoteDuration);
                else
                    Console.Beep((int)n.NoteTone, (int)n.NoteDuration);
            }
        }

        // Define the frequencies of notes in an octave, as well as
        // silence (rest).
        protected enum Tone
        {
            REST = 0,
            GbelowC = 196,
            A = 220,
            Asharp = 233,
            B = 247,
            C = 262,
            Csharp = 277,
            D = 294,
            Dsharp = 311,
            E = 330,
            F = 349,
            Fsharp = 370,
            G = 392,
            Gsharp = 415,
        }

        // Define the duration of a note in units of milliseconds.
        protected enum Duration
        {
            WHOLE = 1600,
            HALF = WHOLE / 2,
            QUARTER = HALF / 2,
            EIGHTH = QUARTER / 2,
            SIXTEENTH = EIGHTH / 2,
        }

        // Define a note as a frequency (tone) and the amount of
        // time (duration) the note plays.
        protected struct Note
        {
            Tone toneVal;
            Duration durVal;

            // Define a constructor to create a specific note.
            public Note(Tone frequency, Duration time)
            {
                toneVal = frequency;
                durVal = time;
            }

            // Define properties to return the note's tone and duration.
            public Tone NoteTone { get { return toneVal; } }
            public Duration NoteDuration { get { return durVal; } }
        }
    }

}

