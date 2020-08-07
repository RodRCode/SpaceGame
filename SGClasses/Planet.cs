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
        private string planetInfo;

        public Planet(string name, Location location, string planetInfo = "Some interesting stuff happened")
        {
            this.name = name;
            this.location = location;
        }
        public static List<Planet> PopulatePlanets()
        {
            List<Planet> PlanetList = new List<Planet>();
                        
            var earth = new Planet("Earth", new Location(1,1), "Mostly Harmless.  Also home to the Galactic Patrol and the Gray Lensman Kimball Kinnison!");
            var planet2 = new Planet("Velan", Location.randLocation(5, 20, 5, 15), "Home of the Gray Lensman Worsel, a Velantian dragon.  Known to spend his time sinuously wrapped around the support bars inside his warship contemplating the \"Whichness of the Why\". Worsel is the mightiest of friends and the deadliest of foes.  His stalked eyes and armored skin are the hope of the downtrodden and the bane of evildoers across the universe.  The enemy of the Velantians are the despotic Delgonian Overlords who feast on life energy.  The Overlords tastiest meal is the life force of a Velantian.  After Worsel comes into contact with Kimball, they together route the Overlords from Velan freeing the Velantians from their evil grip.  The universe of possibilities is then opened to Worsel and his race.  They become fast allies and combine their abilities to fight the influence of the evil Eddorians with the assistance of the Arisians who created the Lens for the Galactic Patrol.");
            var planet3 = new Planet("Rigel", Location.randLocation(45,98, 3, 24));
            var planet4 = new Planet("Eddore", Location.randLocation(4, 44, 26, 47));
            var planet5 = new Planet("Palain", Location.randLocation(46, 80, 26, 35));
            var planet6 = new Planet("Arisia", new Location(98,48), "Arisia, home to the enigmatic Arisians, one of the two oldest races in the universe, they were ancient old long before earth cooled around its star.  They have been locked in a perpetual fight with the Eddorians, literally a fight of good vs evil.  They do not tolerate weak minded fools who would stray them from their path of stewardship of all life in the universe.  Monstrously intelligent, seemingly all powerful, they are still not strong enough to destroy the Eddorians once and for all.  Billions of years ago they foresaw the need to create a force of justice and collective good, and thus they manipulated the very fabric of reality over eons of eons to create the Galactic Patrol to counter the Powerful Boskone criminal empire backed by the Eddorians.  Arisia is not a place for the faint of heart or low of fuel to attempt to visit.  Although they created the mighty Lens of the Galactic Patrol, they do not tolerate fools.  Beware and be warned.");
            var planet7 = new Planet("Alpha Proxima", new Location(4, 1), "Obligatory planet from the Requirements");

            PlanetList.Add(earth);
            PlanetList.Add(planet2);
            PlanetList.Add(planet3);
            PlanetList.Add(planet4);
            PlanetList.Add(planet5);
            PlanetList.Add(planet6);
            PlanetList.Add(planet7);

            return PlanetList;
        }

    }
     
}
