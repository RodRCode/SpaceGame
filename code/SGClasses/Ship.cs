using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    public class Ship
    {
        // TODO Type of ship, Name, Total Capacity, Speed, Fuel Level, Offence, Defence, Shield, Cargo hold?

        public int shipType;
        public string shipName;
        public double totalCapacity;
        public double speed;
        public double fuelLevel;
        public double offence;
        public double defense;
        public double shield;
        public Location location;
        public string planetName;

        
        public Ship(Location location, int shipType = 1, string shipName = "The Heart of Gold (II)", double totalCapacity = 1000, double speed = 1, double fuelLevel = 100, double offence = 100, double defense = 100, double shield = 100, string planetName = "Earth0")
        {
            this.shipType = shipType;
            this.shipName = shipName;
            this.totalCapacity = totalCapacity;
            this.speed = speed;
            this.fuelLevel = fuelLevel;
            this.offence = offence;
            this.defense = defense;
            this.shield = shield;
            this.location = location;
            this.planetName = planetName;
        }


        List<Item> ShipInventory = new List<Item>();


    }

}

