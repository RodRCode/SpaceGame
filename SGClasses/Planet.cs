using System;
using System.Collections.Generic;

namespace SGClasses
{
    public class Planet
    {
        //public readonly string Name;
        //earth is at 1, 1(top left)

//        public readonly int x;
//        public readonly int y;
        public readonly string name;
        public readonly Location location;

        public Planet(string name, Location location)
        {
            this.name = name;
            this.location = location;
        }
        public static List<Planet> PopulatePlanets()
        {
            List<Planet> PlanetList = new List<Planet>();
                        
            var earth = new Planet("Earth", new Location(1,1));
            var planet2 = new Planet("Planet2", Location.randLocation(5, 20, 5, 15));
            var planet3 = new Planet("Planet3", Location.randLocation(45,98, 3, 24));
            var planet4 = new Planet("Planet4", Location.randLocation(4, 44, 26, 47));
            var planet5 = new Planet("Planet5", Location.randLocation(46, 80, 26, 35));
            var planet6 = new Planet("Planet6", new Location(98,48));

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
