using System;

namespace SGClasses
{
    public class Ship
    {
        // TODO Type of ship, Name, Total Capacity, Speed, Fuel Level, Offence, Defence, Shield, Cargo hold?
        
        public readonly int ShipType;
        public readonly string ShipName;
        public readonly double TotalCapacity;
        public readonly double Speed;
        public readonly double FuelLevel;
        public readonly double Offence;
        public readonly double Defense;
        public readonly double Shield;
        public Ship (int shiptype, string shipname, double totalCapacity, double speed, double fuelLevel, double offence, double defense, double shield)
        {
        ShipType = shiptype;
        ShipName = shipname;
        TotalCapacity = totalCapacity;
        Speed = speed;
        FuelLevel = fuelLevel;
        Offence = offence;
        Defense = defense;
        Shield = shield;
    }

    }
}
