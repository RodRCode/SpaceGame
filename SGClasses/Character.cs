using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{


    public class Player
    {
       

        public readonly string Name;
        public readonly int CharacterType;
        public readonly double Age;
        public readonly double Money;
        
        public Player(string name, int characterType = 1, double age = 18, double money = 1000)
        {
            this.Name = name;
            this.CharacterType = characterType;
            this.Age = age;
            this.Money = money;
        }

    }
}