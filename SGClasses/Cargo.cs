using System;
using System.Collections.Generic;

namespace SGClasses
{
    public class Cargo  //TODO Create list of things to trade, create lookuptable for capacity, create what happens when a planet calls for list of items
        // Food, Medical Supplies, Fuel, Munitions, Raw materials, Diplomatic Pouches, Passengers
        // TODO create enum that has all the items that can be used
        // TODO create hard coded list of cargo and range values for each planet
        // Stretch TODO create a random cargo generator that checks to make sure something wasn't used already in the same list to populate cargo
        // Stretch TODO create cargo list for each planet that lists the ranges they will pay for something
    {
        //base cargo constructor

        public readonly string name;
        public readonly double capacity;
        public readonly int quantity;

        public Cargo(string name, double capacity, int quantity)
        {
            this.name = name;
            this.capacity = capacity;
            this.quantity = quantity;
        }

        public static List<Cargo> CargoItems()
        {
            List<Cargo> Items = new List<Cargo>();

            Cargo thing = new Cargo("something", 0.8, 50);
            Items.Add(thing);

            return Items;
        }
    }
}