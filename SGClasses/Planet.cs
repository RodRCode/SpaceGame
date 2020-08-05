using System;
using System.Collections.Generic;

namespace SGClasses
{
    public class Planet
    {
        //public readonly string Name;
        //earth is at 1, 1(top left)

        public readonly int x;
        public readonly int y;
        public readonly string name;

        public Planet(string name, int x, int y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }
        public static List<Planet> PopulatePlanets()
        {
            List<Planet> PlanetList = new List<Planet>();
            
            var earth = new Planet("Earth", 1, 1);
            var planet2 = new Planet("Planet2", 13, 8);
            var planet3 = new Planet("Planet3", 25, 9);
            var planet4 = new Planet("Planet4", 9, 20);
            var planet5 = new Planet("Planet5", 17, 24);
            var planet6 = new Planet("Planet6", 47, 27);

            PlanetList.Add(earth);
            PlanetList.Add(planet2);
            PlanetList.Add(planet3);
            PlanetList.Add(planet4);
            PlanetList.Add(planet5);
            PlanetList.Add(planet6);

            return PlanetList;
        }

    }
     
}
