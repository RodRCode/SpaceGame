using System;
using System.Collections.Generic;

namespace SGClasses
{
    public class Item
    {
        public string name;
        public int quantity;
        public int weight;
        public double value;
        public double planetCostFactor;

        public Item(string name = "thing", int quantity = 1, int weight = 1, double value = 1.0, double planetCostFactor = 1.0)
        {
            this.name = name;
            this.quantity = quantity;
            this.weight = weight;
            this.value = value;
            this.planetCostFactor = planetCostFactor;
        }

        public static List<Item> earthItemList()
        {
            List<Item> earthItemList = new List<Item>();
            var water = new Item("Water", 1, 8, 1, 1);
            var iceCream = new Item("Freeze Dried Ice Cream", 1, 1, 4, 1);
            var cigars = new Item("Space Cigars", 1, 2, 3, 1);
            var blackMarket = new Item("Obvious Black Market Goods", 1, 30, 300, 1);
            var dysentery = new Item("Space Dysentery", 1, 2, 3, 1);
            var happiness = new Item("Happiness", 1, 2, 6, 1);
            earthItemList.Add(water);
            earthItemList.Add(iceCream);
            earthItemList.Add(cigars);
            earthItemList.Add(blackMarket);
            earthItemList.Add(dysentery);
            earthItemList.Add(happiness);

            return earthItemList;
        }

        public static List<Item> shipItemList()
        {
            List<Item> shipItemList = new List<Item>();
            var water = new Item("Water", 1, 8, 1, 1);
            var iceCream = new Item("Freeze Dried Ice Cream", 1, 1, 4, 1);
            var cigars = new Item("Space Cigars", 1, 2, 3, 1);
            var blackMarket = new Item("Obvious Black Market Goods", 1, 30, 300, 1);
            var dysentery = new Item("Space Dysentery", 1, 2, 3, 1);
            var happiness = new Item("Happiness", 1, 2, 6, 1);
            shipItemList.Add(water);
            shipItemList.Add(iceCream);
            shipItemList.Add(cigars);
            shipItemList.Add(blackMarket);
            shipItemList.Add(dysentery);
            shipItemList.Add(happiness);

            return shipItemList;
        }

        public static List<Item> alphaProximaItemList()
        {
            List<Item> alphaProximaItemList = new List<Item>();
            var water = new Item("Water", 1, 8, 1, 1);
            var iceCream = new Item("Freeze Dried Ice Cream", 1, 1, 4, 1);
            var cigars = new Item("Space Cigars", 1, 2, 3, 1);
            var blackMarket = new Item("Obvious Black Market Goods", 1, 30, 300, 1);
            var dysentery = new Item("Space Dysentery", 1, 2, 3, 1);
            var happiness = new Item("Happiness", 1, 2, 6, 1);
            alphaProximaItemList.Add(water);
            alphaProximaItemList.Add(iceCream);
            alphaProximaItemList.Add(cigars);
            alphaProximaItemList.Add(blackMarket);
            alphaProximaItemList.Add(dysentery);
            alphaProximaItemList.Add(happiness);

            return alphaProximaItemList;
        }

        public static List<Item> velanItemList()
        {
            List<Item> velanItemList = new List<Item>();
            var water = new Item("Water", 1, 8, 1, 1);
            var iceCream = new Item("Freeze Dried Ice Cream", 1, 1, 4, 1);
            var cigars = new Item("Space Cigars", 1, 2, 3, 1);
            var blackMarket = new Item("Obvious Black Market Goods", 1, 30, 300, 1);
            var dysentery = new Item("Space Dysentery", 1, 2, 3, 1);
            var happiness = new Item("Happiness", 1, 2, 6, 1);
            velanItemList.Add(water);
            velanItemList.Add(iceCream);
            velanItemList.Add(cigars);
            velanItemList.Add(blackMarket);
            velanItemList.Add(dysentery);
            velanItemList.Add(happiness);

            return velanItemList;
        }

        public static List<Item> rigelItemList()
        {
            List<Item> rigelItemList = new List<Item>();
            var water = new Item("Water", 1, 8, 1, 1);
            var iceCream = new Item("Freeze Dried Ice Cream", 1, 1, 4, 1);
            var cigars = new Item("Space Cigars", 1, 2, 3, 1);
            var blackMarket = new Item("Obvious Black Market Goods", 1, 30, 300, 1);
            var dysentery = new Item("Space Dysentery", 1, 2, 3, 1);
            var happiness = new Item("Happiness", 1, 2, 6, 1);
            rigelItemList.Add(water);
            rigelItemList.Add(iceCream);
            rigelItemList.Add(cigars);
            rigelItemList.Add(blackMarket);
            rigelItemList.Add(dysentery);
            rigelItemList.Add(happiness);

            return rigelItemList;
        }

        public static List<Item> eddoreItemList()
        {
            List<Item> eddoreItemList = new List<Item>();
            var water = new Item("Water", 1, 8, 1, 1);
            var iceCream = new Item("Freeze Dried Ice Cream", 1, 1, 4, 1);
            var cigars = new Item("Space Cigars", 1, 2, 3, 1);
            var blackMarket = new Item("Obvious Black Market Goods", 1, 30, 300, 1);
            var dysentery = new Item("Space Dysentery", 1, 2, 3, 1);
            var happiness = new Item("Happiness", 1, 2, 6, 1);
            eddoreItemList.Add(water);
            eddoreItemList.Add(iceCream);
            eddoreItemList.Add(cigars);
            eddoreItemList.Add(blackMarket);
            eddoreItemList.Add(dysentery);
            eddoreItemList.Add(happiness);

            return eddoreItemList;
        }

        public static List<Item> palainItemList()
        {
            List<Item> palainItemList = new List<Item>();
            var water = new Item("Water", 1, 8, 1, 1);
            var iceCream = new Item("Freeze Dried Ice Cream", 1, 1, 4, 1);
            var cigars = new Item("Space Cigars", 1, 2, 3, 1);
            var blackMarket = new Item("Obvious Black Market Goods", 1, 30, 300, 1);
            var dysentery = new Item("Space Dysentery", 1, 2, 3, 1);
            var happiness = new Item("Happiness", 1, 2, 6, 1);
            palainItemList.Add(water);
            palainItemList.Add(iceCream);
            palainItemList.Add(cigars);
            palainItemList.Add(blackMarket);
            palainItemList.Add(dysentery);
            palainItemList.Add(happiness);

            return palainItemList;
        }

        public static List<Item> arisiaItemList()
        {
            List<Item> arisiaItemList = new List<Item>();
            var water = new Item("Water", 1, 8, 1, 1);
            var iceCream = new Item("Freeze Dried Ice Cream", 1, 1, 4, 1);
            var cigars = new Item("Space Cigars", 1, 2, 3, 1);
            var blackMarket = new Item("Obvious Black Market Goods", 1, 30, 300, 1);
            var dysentery = new Item("Space Dysentery", 1, 2, 3, 1);
            var happiness = new Item("Happiness", 1, 2, 6, 1);
            arisiaItemList.Add(water);
            arisiaItemList.Add(iceCream);
            arisiaItemList.Add(cigars);
            arisiaItemList.Add(blackMarket);
            arisiaItemList.Add(dysentery);
            arisiaItemList.Add(happiness);

            return arisiaItemList;
        }

        public static int CalculateCapacity(List<Item> inputList)
        {
            int totalCapacity = 0;
            int tempCapacity = 0;

            foreach (var item in inputList)
            {
                tempCapacity = item.quantity * item.weight;
                totalCapacity += tempCapacity;
            }
            return totalCapacity;
        }
    }

}
