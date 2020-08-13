using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    public class CurrentInfo
    {

        public static List<string> Update (Player player, Ship ship, List<Planet> planets)
        {
            List<string> StatusList = new List<string>();

            StatusList.Add($"Name: {player.Name}" );
            StatusList.Add($"Charcter Type: {player.CharacterType}");
            StatusList.Add($"Age: {player.Age:f1}");
            StatusList.Add($"Money: {player.Money:f1}");
            StatusList.Add($"Ship Name: {ship.shipName}");
            StatusList.Add($"Ship Location: {ship.planetName}");
            StatusList.Add($"Fuel: {ship.fuelLevel:f1}");
            StatusList.Add($"Location: {ship.location.x}, {ship.location.y}");
            StatusList.Add($"Weight Capacity: {ship.totalCapacity}");
            return StatusList;
        }
     //   new CurrentInfo(displayMainstatus) { Text = "Name: " + player.Name, Top = 1, Left = 4 };
     //   new CurrentInfo(displayMainstatus) { Text = "Charcter Type: " + player.CharacterType, Top = 2, Left = 4 };
     //   new CurrentInfo(displayMainstatus) { Text = "AGE: " + player.Age, Top = 3, Left = 4 };
     //   new CurrentInfo(displayMainstatus) { Text = "Money: " + player.Money, Top = 4, Left = 4 };
     //   new CurrentInfo(displayMainstatus) { Text = "Ship Name: " + ship.shipName, Top = 6, Left = 4 };
     //   new CurrentInfo(displayMainstatus) { Text = "Ship Location:" + " Earth " + ship.location.x + " , " + ship.location.y, Top = 7, Left = 4 };
     //   new CurrentInfo(displayMainstatus) { Text = "Fuel: " + ship.fuelLevel, Top = 8, Left = 4 };



    }
}
