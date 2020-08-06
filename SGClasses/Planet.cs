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

            Location temp = new Location(1, 1);


            var earth = new Planet("Earth", temp);
            temp.x = 13;
            temp.y = 8;
            var planet2 = new Planet("Planet2", temp);
            temp.x = 25;
            temp.y = 9;
            var planet3 = new Planet("Planet3", temp);
            temp.x = 9;
            temp.y = 20;
            var planet4 = new Planet("Planet4", temp);
            temp.x = 17;
            temp.y = 24;
            var planet5 = new Planet("Planet5", temp);
            temp.x = 47;
            temp.y = 27;
            var planet6 = new Planet("Planet6", temp);

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
