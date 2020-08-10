using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    public class CurrentInfo
    {

        public static List<string> Update (Player player)
        {
            List<string> StatusList = new List<string>();

            StatusList.Add($"Name: {player.Name}" );
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
