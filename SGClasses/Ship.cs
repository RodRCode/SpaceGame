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
        public Ship (int shipType, string shipName, double totalCapacity, double speed, double fuelLevel, double offence, double defense, double shield)
        {
        this.shipType = shipType;
        this.shipName = shipName;
        this.totalCapacity = totalCapacity;
        this.speed = speed;
        this.fuelLevel = fuelLevel;
        this.offence = offence;
        this.defense = defense;
        this.shield = shield;
        }

    }
}
