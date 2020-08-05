using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    // Map map = new Map(8, 5);
    //start space map at 70 x 30 light years
    //grahical version will have status display at right that is 20 wide.

    class Map
    {
        // Map map = new Map(x, y); 
        // How do we call/use this class and method to create the graphical representation of it. 

        public readonly int Width;
        public readonly int Height;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool OnMap(Location point)
        {
            return point.X >= 0 && point.X < Width &&
                   point.Y >= 0 && point.Y < Height;
        }

      
    }
}