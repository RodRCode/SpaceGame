using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{


    public class Player
    {
       

        public string Name;
        public int CharacterType;
        public double Age;
        public double Money;
        
        public Player(string name = "Zaphod Beeblebrox", int characterType = 1, double age = 18, double money = 1000)
        {
            this.Name = name;
            this.CharacterType = characterType;
            this.Age = age;
            this.Money = money;
        }

    }
}