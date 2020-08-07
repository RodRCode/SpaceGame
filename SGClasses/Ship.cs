using System;

namespace SGClasses
{
    public class Ship
    {
        // TODO Type of ship, Name, Total Capacity, Speed, Fuel Level, Offence, Defence, Shield, Cargo hold?

        public readonly int shipType;
        public readonly string shipName;
        public readonly double totalCapacity;
        public readonly double speed;
        public readonly double fuelLevel;
        public readonly double offence;
        public readonly double defense;
        public readonly double shield;
        public Location location;

        
        public Ship(Location location, int shipType = 1, string shipName = "My First Ship", double totalCapacity = 1000, double speed = 1, double fuelLevel = 100, double offence = 100, double defense = 100, double shield = 100)
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
        }



    }
}
