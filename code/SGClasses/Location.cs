using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    public class Location
    {
      
        public int x;
        public int y;
        public string name;
        

        public Location(int x=0, int y=0, string name = "default name")
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }

        public static string ToString(Location input)
        {
            var thisInput = input;
            string message = thisInput.x + ", " + thisInput.y;
            return(message);
        }

        public static Location randLocation(int x1, int x2, int y1, int y2)
        {
            var randomX = new Random();
            var randomY = new Random();

            int x = randomX.Next(x1, x2);
            int y = randomY.Next(y1, y2);

            var randomLocation = new Location(x, y);

            return randomLocation;
        }

        //public override string ToString()
        //{
        //    return X + "," + Y;
        //}
        //
        //    public override bool Equals(object obj)
        //    {
        //        if (!(obj is Location))
        //        {
        //            return false;
        //        }
        //
        //        Location that = obj as Location;
        //
        //        return this.X == that.X && this.Y == that.Y;
        //    }
        //
        //    public override int GetHashCode()
        //    {
        //        return X.GetHashCode() * 31 + Y.GetHashCode();
        //    }
        //
        //    public int DistanceTo(int x, int y)
        //    {
        //        return (int)Math.Sqrt(Math.Pow(X - x, 2) + Math.Pow(Y - y, 2));
        //    }
        //
        //    public int DistanceTo(Location point)
        //    {
        //        return DistanceTo(point.X, point.Y);
        //    }
    }
}
