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

        public Planet(string name, Location location, List<Item> itemList, string planetInfo)
        {
            this.name = name;
            this.location = location;
            this.itemList = itemList;
            this.planetInfo = planetInfo;
        }
        public static List<Planet> PopulatePlanets()
        {
            List<Planet> PlanetList = new List<Planet>();
            
            var earth = new Planet("Earth", new Location(1, 1), Item.earthItemList(),
                "\n\nEarth.  Mostly Harmless.  Also home to the Galactic Patrol and the Gray \n" +
                "Lensman Kimball Kinnison!\n\nHit Enter to Read about Alpha Proxima!");

            var alphaProxima = new Planet("Alpha Proxima", new Location(6, 5), Item.alphaProximaItemList(),
                "\n\nAlpha Proxima. The Obligatory planet from the Requirements, sure, why not visit?  \n" +
                "I hear they have a sale on shoes today.\n\nHit Enter to Read about Velan");

            //velan new Location,(5, 15)

            var velan = new Planet("Velan", Location.randLocation(10, 43, 10, 20), Item.velanItemList(), "" +
                "\n\nVelan, home of the Gray Lensman Worsel, a Velantian dragon.  Known to spend his time \n" +
                "sinuously wrapped around the support bars inside his warship contemplating the \"Whichness \n" +
                "of the Why\". Worsel is the mightiest of friends and the deadliest of foes.  His stalked \n" +
                "eyes and armored skin are the hope of the downtrodden and the bane of evildoers across the \n" +
                "universe.  The enemy of the Velantians are the despotic Delgonian Overlords who feast on \n" +
                "life energy.  The Overlord's tastiest meal is the life force of a Velantian.  After Worsel \n" +
                "comes into contact with Kimball, they together route the Overlords from Velan freeing the \n" +
                "Velantians from their evil grip.  The universe of possibilities is then opened to Worsel \n" +
                "and his race.  They become fast allies and combine their abilities to fight the influence \n" +
                "of the Boskone Empire with the assistance of the Arisians who created the Lens for the \n" +
                "Galactic Patrol.\n\nHit Enter to Read about Rigel!");

            //rigel new Location (45,3)

            var rigel = new Planet("Rigel", Location.randLocation(48, 86, 2, 22), Item.rigelItemList(),
                "\n\nRigel, home of the stout Gray Lensman Tregonsee.  The Rigelians are a barrel bodied, \n" +
                "headless race (their brains are safely ensconced in the middle of their bodies) with \n" +
                "multiple tentacles and no eyes.  Even though they don't have \"sight\" they have instead \n" +
                "a \"sense of perception\" that allows them to literally view things from inside, outside, \n" +
                "and all around.  They don't have a \"front\" or \"rear\" because their sense of perception \n" +
                "allows them to see in all 129,000 degrees (360*360) around their body and even into the \n" +
                "center of the world.  They can \"see\" as far as their mind has the power to explore.  \n\n" +
                "They are among the most skilled Engineers and Surgeons to found anywhere.  It is easy to \n" +
                "diagnose an engine fault when your mind can explore the very innards of the machine without \n" +
                "every opening the hood.  Tregonsee is probably not home now, he is likely out guarding the \n" +
                "planet Trenco.  His is able to use his sense of perception in Trenco's vision bending \n" +
                "atmosphere. He guards it from those that would harvest the local lifeforms for the powerful \n" +
                "drug Thionite that permeates the \"vegetation\"\n\nHit Enter to Read about Eddore!");

            // eddore new Location(4,47)
            var eddore = new Planet("Eddore", Location.randLocation(2, 20, 23, 33), Item.eddoreItemList(),
                "\n\nEddore,  home to the Eddorians, a race of beings so foul and noxious as to be incomprehensible \n" +
                "to the mind of man.  They are concentrated on never-ending conquest, always attempting to \n" +
                "satisfy their insatiable lust for power.  They don't \"breed\", instead their capriciousness \n" +
                "grows until one form can no longer contain it.  They then split like a gargantuan amoeba into \n" +
                "two beings, both with a renewed desire to conquer and an a insatiable drive for power.  \n\n" +
                "Yeah, going here is NOT a great idea, but, you do you.\n\nHit Enter to Read about Palain!");

            //palain new Location(57,26)
            var palain = new Planet("Palain", Location.randLocation(50, 70, 23, 35), Item.palainItemList(),
                "\n\nPalain, home to the Gray Lensman Nadreck the so-called Z-Lensman because his is a cold \n" +
                "race borne on a planet in the outer reaches of its solar system.  His cryogenically enhanced \n" +
                "ship and suit keep his body at a comfortable -350 Fahrenheit.  No three-dimensional creature \n" +
                "has ever seen or ever will see in entirety any member of any of the frigid-blooded, poison-\n" +
                "breathing races since life as we know it (organic, three-dimensional life) is based upon \n" +
                "liquid water and gaseous oxygen.  Such life did not, and could not, develop upon planets whose \n" +
                "temperatures are only a few degrees above absolute zero. Many, perhaps most, of these \n" +
                "ultra-frigid planets have an atmosphere of sorts; some have no atmosphere at all. Nevertheless, \n" +
                "with or without atmosphere and completely without oxygen and water, life, highly intelligent \n" +
                "life, did develop upon millions and millions of such worlds. That life is not, however, strictly \n" +
                "three-dimensional. Life on the outer planets possesses an extension into the hyper-dimension; \n" +
                "and it is this metabolic extension alone which makes it possible for life to exist under such \n" +
                "extreme conditions.  This extension into the hyper dimensions makes it impossible for any human \n" +
                "being to see anything of a Palainian except the fluid, amorphous, ever-changing thing which is \n" +
                "his three-dimensional aspect of the moment; makes any attempt at description these races completely \n" +
                "futile.  \n\nBring your thermal underwear.\n\nHit Enter to Read about Arisia!");

            var arisia = new Planet("Arisia", new Location(86, 33), Item.arisiaItemList(),
                "\n\nArisia, home to the enigmatic Arisians, one of the two oldest races in the universe, \n" +
                "they were anciently old long before earth cooled around its star.  They have been locked \n" +
                "in a perpetual fight with the Eddorians, literally a fight of good vs evil.  They do not \n" +
                "tolerate weak minded fools who would stray them from their path of stewardship of all life \n" +
                "in the universe.  Monstrously intelligent, seemingly all powerful, they are still not strong \n" +
                "enough to destroy the Eddorians once and for all.  Billions of years ago they foresaw the \n" +
                "need to create a force of justice and collective good, and thus they manipulated the very \n" +
                "fabric of reality over eons of eons to create the Galactic Patrol to counter the Powerful \n" +
                "Boskone Empire backed by the Eddorians.  Arisia is not a place for the faint of heart or \n" +
                "low of fuel to attempt to visit.  Although they created the mighty Lens of the Galactic Patrol, \n" +
                "they do not tolerate fools.  The Lens is a telepathic jewel in the shape of a lens that is \n" +
                "uniquely matched to the ego of its wearer and death of all others who attempt to touch it \n" +
                "when it is not in contact with its guardian.  Beware and be warned.\n\nHit Enter TWICE to return to the game and may your travels have clear ether!!");

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
            backstory = "Billions of years ago, when the universe was still young, there were no other lifeforms \n" +
                "aside from the ancient Arisians, and few planets besides the Arisians' native world. The \n" +
                "peaceful Arisians have foregone physical skills in order to develop contemplative mental power." +
                "\n\nBut they were not alone for long.  The Eddorians, a dictatorial, power-hungry race, come \n" +
                "into our universe from an alien space-time continuum after observing that the Milky Way Galaxy \n" +
                "and a sister galaxy (the Second Galaxy) are passing through each other. This will result in the \n" +
                "formation of billions of planets and the development of life upon some of them. Dominance over \n" +
                "these life forms would offer the Eddorians an opportunity to satisfy their lust for power and \n" +
                "control.\n\n" +
                "Although the Eddorians have developed mental powers almost equal to those of the Arisians, they \n" +
                "rely instead for the most part on physical power, which came to be exercised on their behalf by \n" +
                "a hierarchy of underling races. They see the many races in the universe, with which the Arisians \n" +
                "were intending to build a peaceful civilization, as fodder for their power-drive.\n\n" +
                "The Arisians detect the Eddorians' invasion of our universe and realize that they are too evenly \n" +
                "matched for either to destroy the other without being destroyed themselves. The Eddorians do not \n" +
                "detect the Arisians.  The Arisians begin a covert breeding program on every world that can produce \n" +
                "intelligent life, with particular emphasis on the four planets Earth, Velantia, Rigel, and Palain, \n" +
                "in the hope of creating a race that is capable of destroying the Eddorians.\n\n" +
                "Once the races grow old enough and mature enough to develop space flight, the Arisians become \n" +
                "instrumental in the creation of THE GALACTIC PATROL and the all important \"Lens of Arisia\" \n" +
                "to counter the corruption and vile influence of Eddore through its surrogate organization BOSKONE.  \n" +
                "The Lens gives its wearer a variety of mental capabilities, including those needed to enforce the \n" +
                "law on alien planets, and to bridge the communication gap between different life-forms. It can \n" +
                "provide mind-reading and telepathic abilities. It cannot be worn by anyone other than its owner, \n" +
                "will kill any other wearer, and even a brief touch is extremely painful.\n\n" +
                "Your ship has onboard a ship with a Bergenholm.  The Bergenholm renders your ship inertialess \n" +
                "which allows it to fly faster than the speed of light without violating General Relativity.  \n\n" +
                "One side effect of your ship becoming inertialess is that when traveling you need to continue to \n" +
                "expend energy or your ship will literally stop dead in space.  Even in the vastness of the universe, \n" +
                "space is not completely empty.  A stray hydrogen atom here, a wayward iron atom there.  When you \n" +
                "are traveling past the speed of light, those atoms add up.  The only limit to your speed is the \n" +
                "density space your ship travels through as friction slows your ship.  The harder you push, the \n" +
                "faster you travel and more fuel that you burn.  Want to get there faster?  Sure!  But it will \n" +
                "cost you LOTS more fuel.\n\nHit ENTER to continue to the Game!";
            return (backstory);
        }
    }
     
}
