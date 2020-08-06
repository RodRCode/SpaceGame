using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    public class SpaceTravel
    {
        //input current location coordinates and destination coordinates. Also maybe input the names of origin and destination 
        // after calculating distance traveled, calculate time taken and fuel consumed. we need to figure out a formula for speed consuption.

        public static double DistanceCalculation (Location location1, Location location2)
        {
            double distance = 0.0;
            int x = location1.x - location2.x;
            int y = location1.y - location2.y;

            x = 4;
            y = 5;

            distance = Math.Sqrt((x * x) + (y * y));

            Console.WriteLine(distance);

            return distance;
        }

        public static double WarpSpeedCalcuation (double distance, int warpSpeed)
        {
            double time = 0.0;
            double fuel = 0.0;
            int warpSpeed = 5.0;
            double distance = 20;

            time = ((warpSpeed) ^ (10 * 3)) + ((10 - warpSpeed) ^ ((-11) / 3));
            Console.WriteLine(time);
        }


    }
}
