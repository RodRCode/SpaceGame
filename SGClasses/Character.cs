using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{


    public class Character
    {
       
        // Character character = new Character(name, type, age, money);

        public readonly string Name;
        public readonly int CharacterType;
        public readonly double Age;
        public readonly double Money;
        public Character(string name, int characterType, double age, double money)
        {
            Name = name;
            CharacterType = characterType;
            Age = age;
            Money = money;
        }

    }
}