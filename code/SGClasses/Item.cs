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
            var water = new Item("Water             ", 1, 8, 1, 1.0);
            var iceCream = new Item("Ice Cream         ", 1, 1, 4, 1.0);
            var cigars = new Item("Space Cigars      ", 1, 2, 3, 1.0);
            var blackMarket = new Item("Black Market Goods", 1, 30, 300, 1.0);
            var dysentery = new Item("Space Dysentery   ", 1, 2, 3, 1.0);
            var happiness = new Item("Happiness         ", 1, 2, 6, 1.0);
            var fuel = new Item("Fuel              ", 1, 0, 1.0, 1.0);
            earthItemList.Add(water);
            earthItemList.Add(iceCream);
            earthItemList.Add(cigars);
            earthItemList.Add(blackMarket);
            earthItemList.Add(dysentery);
            earthItemList.Add(happiness);
            earthItemList.Add(fuel);

            return earthItemList;
        }

        public static List<Item> shipItemList()
        {
            List<Item> shipItemList = new List<Item>();
            var water = new Item("Water             ", 1, 8, 1, 1.0);
            var iceCream = new Item("Ice Cream         ", 1, 1, 4, 1.0);
            var cigars = new Item("Space Cigars      ", 1, 2, 3, 1.0);
            var blackMarket = new Item("Black Market Goods", 1, 30, 300, 1.0);
            var dysentery = new Item("Space Dysentery   ", 1, 2, 3, 1.0);
            var happiness = new Item("Happiness         ", 1, 2, 6, 1.0);
            var fuel = new Item("Fuel              ", 1, 0, 1.0, 1.0);
            shipItemList.Add(water);
            shipItemList.Add(iceCream);
            shipItemList.Add(cigars);
            shipItemList.Add(blackMarket);
            shipItemList.Add(dysentery);
            shipItemList.Add(happiness);
            shipItemList.Add(fuel);

            return shipItemList;
        }

        public static List<Item> alphaProximaItemList()
        {
            Random randoCost = new Random();
            List<Item> alphaProximaItemList = new List<Item>();
            var water = new Item("Water             ", 1, 8, 1, 3 * (double)randoCost.NextDouble());
            var blackMarket = new Item("Black Market Goods", 1, 30, 300, 3 * (double)randoCost.NextDouble());
            var dysentery = new Item("Space Dysentery   ", 1, 2, 3, 3 * (double)randoCost.NextDouble());
            var iceCream = new Item("Ice Cream         ", 1, 1, 4, 3 * (double)randoCost.NextDouble());
            var cigars = new Item("Space Cigars      ", 1, 2, 3, 3 * (double)randoCost.NextDouble());
            var happiness = new Item("Happiness         ", 1, 2, 6, 3 * (double)randoCost.NextDouble());
            var fuel = new Item("Fuel              ");
            alphaProximaItemList.Add(water);
            alphaProximaItemList.Add(iceCream);
            alphaProximaItemList.Add(cigars);
            alphaProximaItemList.Add(blackMarket);
            alphaProximaItemList.Add(dysentery);
            alphaProximaItemList.Add(happiness);
            alphaProximaItemList.Add(fuel);

            return alphaProximaItemList;
        }

        public static List<Item> velanItemList()
        {
            Random randoCost = new Random();
            List<Item> velanItemList = new List<Item>();
            var blackMarket = new Item("Black Market Goods", 1, 30, 300, 4 * (double)randoCost.NextDouble());
            var dysentery = new Item("Space Dysentery   ", 1, 2, 3, 4 * (double)randoCost.NextDouble());
            var happiness = new Item("Happiness         ", 1, 2, 6, 4 * (double)randoCost.NextDouble());
            var water = new Item("Water             ", 1, 8, 1, 4 * (double)randoCost.NextDouble());
            var iceCream = new Item("Ice Cream         ", 1, 1, 4, 4 * (double)randoCost.NextDouble());
            var cigars = new Item("Space Cigars      ", 1, 2, 3, 4 * (double)randoCost.NextDouble());
            var fuel = new Item("Fuel              ");
            velanItemList.Add(water);
            velanItemList.Add(iceCream);
            velanItemList.Add(cigars);
            velanItemList.Add(blackMarket);
            velanItemList.Add(dysentery);
            velanItemList.Add(happiness);
            velanItemList.Add(fuel);


            return velanItemList;
        }

        public static List<Item> rigelItemList()
        {
            Random randoCost = new Random();
            List<Item> rigelItemList = new List<Item>();
            var water = new Item("Water             ", 1, 8, 1, 5 * (double)randoCost.NextDouble());
            var iceCream = new Item("Ice Cream         ", 1, 1, 4, 5 * (double)randoCost.NextDouble());
            var cigars = new Item("Space Cigars      ", 1, 2, 3, 5 * (double)randoCost.NextDouble());
            var blackMarket = new Item("Black Market Goods", 1, 30, 300, 5 * (double)randoCost.NextDouble());
            var dysentery = new Item("Space Dysentery   ", 1, 2, 3, 5 * (double)randoCost.NextDouble());
            var happiness = new Item("Happiness         ", 1, 2, 6, 5 * (double)randoCost.NextDouble());
            var fuel = new Item("Fuel              ");
            rigelItemList.Add(water);
            rigelItemList.Add(iceCream);
            rigelItemList.Add(cigars);
            rigelItemList.Add(blackMarket);
            rigelItemList.Add(dysentery);
            rigelItemList.Add(happiness);
            rigelItemList.Add(fuel);

            return rigelItemList;
        }

        public static List<Item> eddoreItemList()
        {
            Random randoCost = new Random();
            List<Item> eddoreItemList = new List<Item>();
            var dysentery = new Item("Space Dysentery   ", 1, 2, 3, 6 * (double)randoCost.NextDouble());
            var fuel = new Item("Fuel              ");
            eddoreItemList.Add(dysentery);
            eddoreItemList.Add(fuel);

            return eddoreItemList;
        }

        public static List<Item> palainItemList()
        {
            Random randoCost = new Random();
            List<Item> palainItemList = new List<Item>();
            var iceCream = new Item("Ice Cream         ", 1, 1, 4, 7 * (double)randoCost.NextDouble());
            var happiness = new Item("Happiness         ", 1, 2, 6, 7 * (double)randoCost.NextDouble());
            var fuel = new Item("Fuel              ");
            var water = new Item("Water             ", 1, 8, 1, 7 * (double)randoCost.NextDouble());
            var cigars = new Item("Space Cigars      ", 1, 2, 3, 7 * (double)randoCost.NextDouble());
            var blackMarket = new Item("Black Market Goods", 1, 30, 300, 7 * (double)randoCost.NextDouble());
            var dysentery = new Item("Space Dysentery   ", 1, 2, 3, 7 * (double)randoCost.NextDouble());
            palainItemList.Add(water);
            palainItemList.Add(iceCream);
            palainItemList.Add(cigars);
            palainItemList.Add(blackMarket);
            palainItemList.Add(dysentery);
            palainItemList.Add(happiness);
            palainItemList.Add(fuel);

            return palainItemList;
        }

        public static List<Item> arisiaItemList()
        {
            Random randoCost = new Random();
            List<Item> arisiaItemList = new List<Item>();
            var happiness = new Item("Happiness         ", 1, 2, 6, 20 * (double)randoCost.NextDouble());
            var fuel = new Item("Fuel              ");
            var water = new Item("Water             ", 1, 8, 1, 20 * (double)randoCost.NextDouble());
            var iceCream = new Item("Ice Cream         ", 1, 1, 4, 20 * (double)randoCost.NextDouble());
            var cigars = new Item("Space Cigars      ", 1, 2, 3, 20 * (double)randoCost.NextDouble());
            var blackMarket = new Item("Black Market Goods", 1, 30, 300, 20 * (double)randoCost.NextDouble());
            var dysentery = new Item("Space Dysentery   ", 1, 2, 3, 20 * (double)randoCost.NextDouble());
            arisiaItemList.Add(water);
            arisiaItemList.Add(iceCream);
            arisiaItemList.Add(cigars);
            arisiaItemList.Add(blackMarket);
            arisiaItemList.Add(dysentery);
            arisiaItemList.Add(happiness);
            arisiaItemList.Add(fuel);


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
