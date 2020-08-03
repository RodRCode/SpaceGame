#### Rod Game ideas

These are some of the ideas I have come up with for the Game

##### Good ending:
- You build the stargate network between all the available planets

##### Bad ending:
- You get killed by pirates or whatnot
- You die between planets because you ran out of fuel, or you run out of money and can't sell enough of anything to buy a ship and/or fuel to do trading
- You pick up space dysentery and die 

##### Neutral Ending:
- You age out

##### Ideas for things to happen in the Game
- Pirates, either attack you, or you come across them attacking someone else and you jump in to fight them, and if you are successful the people you helped save give you some of their cargo
- By the same token, if you are engaged in a fight with pirates, someone else may randomly come in and help you out, but you will be giving up some of your cargo ... will be interesting to see what happens if you don't give them enough stuff for their help... do they just attack and take what they want then?
- If you help people out then you get **karma points** If you end up with negative karma, then that means you are going around being a pirate raiding ships or whoever.  So, for instance, you come across pirates attacking a ship, if you help the pirates then you get negative karma and a share of the cargo.  If you do that then you might also have the option of attacking the pirates and then taking what they have as well, and thereby giving your more **pirate karma** instead of **alliance karma**
- We can also add in alien races, different races will have different attributes.  One species is warlike and mean, others can be peaceful and willing to trade in the middle of space.  The different species also have base types of ships
- Ships have different levels of difficulty call it "easy" "medium" and "hard".  If you run into an easy version of a ship then it will be simple to defeat, but not a lot of cargo.  As you beat up harder ships you get better/more cargo


##### Things to trade (will have to come up with relative values to attach to each of these of course)
- Food
- Medical Supplies
- Fuel
- Munitions
- Raw metal materials (you might be able to pick those up from asteroids you come across)
- Diplomatic pouches
- Livestock
- Settlers / Passengers


##### Ship qualities
- Size
- Defense
- Offense
- Maneuverability in a fight (how many squares you can travel in a move)
- Cargo capacity
- Max sizes/capacities for the different categories say each one goes between 1 and 100, 100 maxes your ship in that category (except for Maneuverability, that should max out at something less, like 4 or 5)
- Generator/Reactors - the bigger the reactor, the more powerful lasers you can get

##### Weapons
- Lasers or some other weapon that attacks at the speed of light
- Missles they take a little time to get to their target based on the speed/quality of the missile
-







### Requirements from Elliot:

##### Requirements
- Start on Earth
- Have at least 5 planets to which the player can travel
- Player at start of game should be 18 years old and have a ship (or ability to gain a ship) and a small amount of starting currency (credits)
- Game ends when the player reaches the game goal or ages to 60yo
- Primary goal of the game is amass wealth by trading goods and services among planets
- You write the story
- Your game should have a "good", "bad" ending, optionally a separate "age out" ending
- Your game should have a compelling story User interface should be a TUI built as a console application
- Travel between planets should follow a standard "warp speed" calculation (I will provide)
- Planets should be arranged on a 2D X/Y coordinate system, s.t. distances between planets are provided by the pythagorean theorem
- Earth should be at the origin (x = 0, y = 0)
- One of the remaining 4 (minimum) planets should be alpha proxima 1 (x = ~4.7, y = 0)
- Travel between planets should occur at a user-defined speed specified in warp units, potentially limited by ship speed or other conditions
- Ships have a specified capacity which can not be exceeded

##### Stretch goals
- Space piracy & other random events
- Conditions which allow faster than normal travel (ship upgrades, natural phenomena [wormhole], stargate, etc.)
- Ships consume fuel when travelling
- Ship flying mini game (asteroid field)

##### Warp Equation
- Given Warp speed (W) with non-inclusive bounds of 0 and 10, velocity in multiples of the speed of light = W(10/3)  + (10 − W)(-11/3).

Thus, if you want to travel to a location 1 light year away in one day, you need a warp factor which equates to a velocity of 365.25 times the speed of light.
