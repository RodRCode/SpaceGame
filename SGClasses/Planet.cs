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
            var planet2 = new Planet("Velan", Location.randLocation(5, 20, 5, 15), "Home of the Gray Lensman Worsel, a Velantian dragon.  Known to spend his time sinuously wrapped around the support bars inside his warship contemplating the \"Whichness of the Why\". Worsel is the mightiest of friends and the deadliest of foes.  His stalked eyes and armored skin are the hope of the downtrodden and the bane of evildoers across the universe.  The enemy of the Velantians are the despotic Delgonian Overlords who feast on life energy.  The Overlords tastiest meal is the life force of a Velantian.  After Worsel comes into contact with Kimball, they together route the Overlords from Velan freeing the Velantians from their evil grip.  The universe of possibilities is then opened to Worsel and his race.  They become fast allies and combine their abilities to fight the influence of the Boskone Empire with the assistance of the Arisians who created the Lens for the Galactic Patrol.");
            var planet3 = new Planet("Rigel", Location.randLocation(45,98, 3, 24), "Rigel, home of the stout Gray Lensman Tregonsee.  The Rigelians are a barrel bodied, headless race (their brains are safely ensconced in the middle of their bodies) with multiple tentacles and no eyes.  Even though they don't have \"sight\" they have instead a \"sense of perception\" that allows them to literally view things from inside, outside, and all around.  They don't have a \"front\" or \"rear\" because their sense of perception allows them to see in all 129,000 degrees (360*360) around their body and even into the center of the world.  They can \"see\" as far as their mind has the power to explore.  They are among the most skilled Engineers and Surgeons to found anywhere.  It is easy to diagnose an engine fault when your mind can explore the very innards of the machine without every opening the hood.  Tregonsee is probably not home now, he is likely out guarding the planet Trenco.  His is able to use his sense of perception in Trenco's vision bending atmosphere. He guards it from those that would harvest the local lifeforms for the powerful drug Thionite that permeates the \"vegetation\"");
            var planet4 = new Planet("Eddore", Location.randLocation(4, 44, 26, 47), "Eddore,  home to the Eddorians, a race of beings so foul and noxious as to be incomprehensible to the mind of man.  They are concentrated on never-ending conquest, always attempting to satisfy their insatiable lust for power.  They don't \"breed\", instead their capriciousness grows until one form can no longer contain it.  They then split like a gargantuan amoeba into two beings, both with a renewed desire to conquer and an a insatiable drive for power.  Yeah, going here is NOT a great idea, but, you do you.");
            var planet5 = new Planet("Palain", Location.randLocation(46, 80, 26, 35), "Palain, home to the Gray Lensman Nadreck the so-called Z-Lensman because his is a cold race was borne on a planet in the outer reaches of its solar system.  His cryogenically enhanced ship and suit keep his body at a comfortable -350 Fahrenheit.  No three-dimensional creature has ever seen or ever will see in entirety any member of any of the frigid-blooded, poison-breathing races. Since life as we know it (organic, three-dimensional life) is based upon liquid water and gaseous oxygen.  Such life did not, and could not, develop upon planets whose temperatures are only a few degrees above absolute zero. Many, perhaps most, of these ultra-frigid planets have an atmosphere of sorts; some have no atmosphere at all. Nevertheless, with or without atmosphere and completely without oxygen and water, life, highly intelligent life, did develop upon millions and millions of such worlds. That life is not, however, strictly three-dimensional. Of necessity, even in the lowest forms, it possesses an extension into the hyper-dimension; and it is this metabolic extension alone which makes it possible for life to exist under such extreme conditions.  This extension into the hyper dimensions makes it impossible for any human being to see anything of a Palainian except the fluid, amorphous, ever-changing thing which is his three-dimensional aspect of the moment; makes any attempt at description these races completely futile.  Bring your thermal underwear.");
            var planet6 = new Planet("Arisia", new Location(98,48), "Arisia, home to the enigmatic Arisians, one of the two oldest races in the universe, they were ancient old long before earth cooled around its star.  They have been locked in a perpetual fight with the Eddorians, literally a fight of good vs evil.  They do not tolerate weak minded fools who would stray them from their path of stewardship of all life in the universe.  Monstrously intelligent, seemingly all powerful, they are still not strong enough to destroy the Eddorians once and for all.  Billions of years ago they foresaw the need to create a force of justice and collective good, and thus they manipulated the very fabric of reality over eons of eons to create the Galactic Patrol to counter the Powerful Boskone criminal empire backed by the Eddorians.  Arisia is not a place for the faint of heart or low of fuel to attempt to visit.  Although they created the mighty Lens of the Galactic Patrol, they do not tolerate fools.  The Lens is a telepathic jewel in the shape of a lens that is uniquely matched to the ego of its wearer and death of all others who attempt to touch it when it is not in contact with its guardian.  Beware and be warned. ");
            var planet7 = new Planet("Alpha Proxima", new Location(4, 1), "Obligatory planet from the Requirements, sure, why not visit?  I hear they have sale on shoes today.");

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
