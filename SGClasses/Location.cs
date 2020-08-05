using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    public class Location
    {
        public static int x;
        public static int y;

        public Location (int x, int y)
        {
            this.x = x;               
        }

        public Location()
        {

        }

        public Location()
        {



        }


















        

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return X + "," + Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Location))
            {
                return false;
            }

            Location that = obj as Location;

            return this.X == that.X && this.Y == that.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * 31 + Y.GetHashCode();
        }

        public int DistanceTo(int x, int y)
        {
            return (int)Math.Sqrt(Math.Pow(X - x, 2) + Math.Pow(Y - y, 2));
        }

        public int DistanceTo(Location point)
        {
            return DistanceTo(point.X, point.Y);
        }
    }
}
