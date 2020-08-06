﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    public class SpaceTravel
    {
        //receives two locations, then returns the distance between them
        public static double DistanceCalculation(Location location1, Location location2)
        {
            int x = location1.x - location2.x;
            int y = location1.y - location2.y;
            double distance = Math.Sqrt((x * x) + (y * y));
            return distance;
        }

        // Recieves the distance, and the warp speed you want to use, and returns the time and fuel needed to travel
        public static (double, double) WarpSpeedCalcuation(double distance, int warpSpeed)
        {
            double warpFactor = ((Math.Pow(warpSpeed, (10 / 3)) + Math.Pow((10 - warpSpeed), (-11 / 3))));
            double fuel = distance * warpFactor;
            double time = 1 / warpFactor;
            return (time, fuel);
        }
    }
}
