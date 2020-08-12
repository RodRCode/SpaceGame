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
        public readonly string planetInfo;
        public List<Item> itemList;


        public Planet(string name, Location location, List<Item> itemList, string planetInfo = "Some interesting stuff happened")
        {
            this.name = name;
            this.location = location;
            this.itemList = itemList;
        }
        public static List<Planet> PopulatePlanets()
        {
            List<Planet> PlanetList = new List<Planet>();

            var earth = new Planet("Earth", new Location(1, 1), Item.earthItemList(), "Mostly Harmless.  Also home to the Galactic Patrol and the Gray Lensman Kimball Kinnison!");

            var alphaProxima = new Planet("Alpha Proxima", new Location(6, 5), Item.alphaProximaItemList(),"Obligatory planet from the Requirements, sure, why not visit?  I hear they have a sale on shoes today.");

            //velan new Location,(5, 15)

            var velan = new Planet("Velan", Location.randLocation(10, 43, 10, 20), Item.velanItemList(),"Home of the Gray Lensman Worsel, a Velantian dragon.  Known to spend his time sinuously wrapped around the support bars inside his warship contemplating the \"Whichness of the Why\". Worsel is the mightiest of friends and the deadliest of foes.  His stalked eyes and armored skin are the hope of the downtrodden and the bane of evildoers across the universe.  The enemy of the Velantians are the despotic Delgonian Overlords who feast on life energy.  The Overlord's tastiest meal is the life force of a Velantian.  After Worsel comes into contact with Kimball, they together route the Overlords from Velan freeing the Velantians from their evil grip.  The universe of possibilities is then opened to Worsel and his race.  They become fast allies and combine their abilities to fight the influence of the Boskone Empire with the assistance of the Arisians who created the Lens for the Galactic Patrol.");

            //rigel new Location (45,3)

            var rigel = new Planet("Rigel", Location.randLocation(48, 86, 2, 22), Item.rigelItemList(),"Rigel, home of the stout Gray Lensman Tregonsee.  The Rigelians are a barrel bodied, headless race (their brains are safely ensconced in the middle of their bodies) with multiple tentacles and no eyes.  Even though they don't have \"sight\" they have instead a \"sense of perception\" that allows them to literally view things from inside, outside, and all around.  They don't have a \"front\" or \"rear\" because their sense of perception allows them to see in all 129,000 degrees (360*360) around their body and even into the center of the world.  They can \"see\" as far as their mind has the power to explore.  They are among the most skilled Engineers and Surgeons to found anywhere.  It is easy to diagnose an engine fault when your mind can explore the very innards of the machine without every opening the hood.  Tregonsee is probably not home now, he is likely out guarding the planet Trenco.  His is able to use his sense of perception in Trenco's vision bending atmosphere. He guards it from those that would harvest the local lifeforms for the powerful drug Thionite that permeates the \"vegetation\"");

            // eddore new Location(4,47)
            var eddore = new Planet("Eddore", Location.randLocation(2, 20, 23, 33), Item.eddoreItemList(), "Eddore,  home to the Eddorians, a race of beings so foul and noxious as to be incomprehensible to the mind of man.  They are concentrated on never-ending conquest, always attempting to satisfy their insatiable lust for power.  They don't \"breed\", instead their capriciousness grows until one form can no longer contain it.  They then split like a gargantuan amoeba into two beings, both with a renewed desire to conquer and an a insatiable drive for power.  Yeah, going here is NOT a great idea, but, you do you.");

            //palain new Location(57,26)
            var palain = new Planet("Palain", Location.randLocation(50, 70, 23, 35), Item.palainItemList(),"Palain, home to the Gray Lensman Nadreck the so-called Z-Lensman because his is a cold race borne on a planet in the outer reaches of its solar system.  His cryogenically enhanced ship and suit keep his body at a comfortable -350 Fahrenheit.  No three-dimensional creature has ever seen or ever will see in entirety any member of any of the frigid-blooded, poison-breathing races since life as we know it (organic, three-dimensional life) is based upon liquid water and gaseous oxygen.  Such life did not, and could not, develop upon planets whose temperatures are only a few degrees above absolute zero. Many, perhaps most, of these ultra-frigid planets have an atmosphere of sorts; some have no atmosphere at all. Nevertheless, with or without atmosphere and completely without oxygen and water, life, highly intelligent life, did develop upon millions and millions of such worlds. That life is not, however, strictly three-dimensional. Life on the outer planets possesses an extension into the hyper-dimension; and it is this metabolic extension alone which makes it possible for life to exist under such extreme conditions.  This extension into the hyper dimensions makes it impossible for any human being to see anything of a Palainian except the fluid, amorphous, ever-changing thing which is his three-dimensional aspect of the moment; makes any attempt at description these races completely futile.  Bring your thermal underwear.");
            var arisia = new Planet("Arisia", new Location(86, 34), Item.arisiaItemList(),"Arisia, home to the enigmatic Arisians, one of the two oldest races in the universe, they were anciently old long before earth cooled around its star.  They have been locked in a perpetual fight with the Eddorians, literally a fight of good vs evil.  They do not tolerate weak minded fools who would stray them from their path of stewardship of all life in the universe.  Monstrously intelligent, seemingly all powerful, they are still not strong enough to destroy the Eddorians once and for all.  Billions of years ago they foresaw the need to create a force of justice and collective good, and thus they manipulated the very fabric of reality over eons of eons to create the Galactic Patrol to counter the Powerful Boskone Empire backed by the Eddorians.  Arisia is not a place for the faint of heart or low of fuel to attempt to visit.  Although they created the mighty Lens of the Galactic Patrol, they do not tolerate fools.  The Lens is a telepathic jewel in the shape of a lens that is uniquely matched to the ego of its wearer and death of all others who attempt to touch it when it is not in contact with its guardian.  Beware and be warned. ");

            PlanetList.Add(earth);
            PlanetList.Add(alphaProxima);
            PlanetList.Add(velan);
            PlanetList.Add(rigel);
            PlanetList.Add(eddore);
            PlanetList.Add(palain);
            PlanetList.Add(arisia);

            return PlanetList;
        }

        public static string Backstory()
        {
            string backstory;
            backstory = "Billions of years ago, when the universe was still young, there were no other lifeforms aside from the ancient Arisians, and few planets besides the Arisians' native world. The peaceful Arisians have foregone physical skills in order to develop contemplative mental power.\n\nBut they were not alone for long.  The Eddorians, a dictatorial, power-hungry race, come into our universe from an alien space-time continuum after observing that the Milky Way Galaxy and a sister galaxy (the Second Galaxy) are passing through each other. This will result in the formation of billions of planets and the development of life upon some of them. Dominance over these life forms would offer the Eddorians an opportunity to satisfy their lust for power and control.\n\nAlthough the Eddorians have developed mental powers almost equal to those of the Arisians, they rely instead for the most part on physical power, which came to be exercised on their behalf by a hierarchy of underling races. They see the many races in the universe, with which the Arisians were intending to build a peaceful civilization, as fodder for their power-drive.\n\nThe Arisians detect the Eddorians' invasion of our universe and realize that they are too evenly matched for either to destroy the other without being destroyed themselves. The Eddorians do not detect the Arisians.  The Arisians begin a covert breeding program on every world that can produce intelligent life, with particular emphasis on the four planets Earth, Velantia, Rigel, and Palain, in the hope of creating a race that is capable of destroying the Eddorians.\n\nOnce the races grow old enough and mature enough to develop space flight, the Arisians become instrumental in the creation of THE GALACTIC PATROL and the all important \"Lens of Arisia\" to counter the corruption and vile influence of Eddore through its surrogate organization BOSKONE.  The Lens gives its wearer a variety of mental capabilities, including those needed to enforce the law on alien planets, and to bridge the communication gap between different life-forms. It can provide mind-reading and telepathic abilities. It cannot be worn by anyone other than its owner, will kill any other wearer, and even a brief touch is extremely painful.\n\nYour ship has onboard a ship with a Bergenholm.  The Bergenholm renders your ship inertialess which allows it to fly faster than the speed of light without violating General Relativity.  One side effect of your ship becoming inertialess is that when traveling you need to continue to expend energy or your ship will literally stop dead in space.  Even in the vastness of the universe, space is not completely empty.  A stray hydrogen atom here, a wayward iron atom there.  When you are traveling past the speed of light, those atoms add up.  The only limit to your speed is the density space your ship travels through as friction slows your ship.  The harder you push, the faster you travel and more fuel that you burn.  Want to get there faster?  Sure!  But it will cost you LOTS more fuel.";
            return (backstory);
        }
    }
     
}
