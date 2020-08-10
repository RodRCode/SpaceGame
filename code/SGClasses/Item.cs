using System;
using System.Collections.Generic;

namespace SGClasses
{
    public class Item
    {

        public readonly string name;
        public readonly int quantity;
        private double value;


        public Item(string name, int quantity, double value)
        {
            this.name = name;
            this.quantity = quantity;
            this.value = value;
        }



    }
     
}
