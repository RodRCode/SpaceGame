﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SGClasses
{
    public class SpaceTravel
    {
        // Handles all the messy bits of traveling around this great big universe

        // This is the "commit" version of space travel, it updates the player's age and ship location and fuel status.
        public static void TravelToNewPlanet(Location oldLocation, Location newLocation, Ship ship, Player player, int warpSpeed)
        {
            double distance = DistanceCalculation(oldLocation, newLocation);
            (double time, double fuel) = WarpSpeedCalcuation(distance, warpSpeed);
            player.Age += time;
            ship.fuelLevel -= fuel;
            ship.location = newLocation;
        }

        //This is the method to call so the player can see what the effect of the travel will be between two locations, it returns the time and fuel that will be needed to go between two locations at a given warpspeed
        public static (double testAge, double testFuel) TestTravelToNewPlanet(Location oldLocation, Location newLocation, Ship ship, Player player, int warpSpeed)
        {
            double distance = DistanceCalculation(oldLocation, newLocation);
            (double time, double fuel) = WarpSpeedCalcuation(distance, warpSpeed);
            double testAge = player.Age + time;
            double testFuel = ship.fuelLevel - fuel;
            return (testAge, testFuel);
        }

        // Given two locations, it returns the straight line distance between them
        private static double DistanceCalculation(Location oldLocation, Location newLocation)
        {
            int x = oldLocation.x - newLocation.x;
            int y = oldLocation.y - newLocation.y;
            double distance = Math.Sqrt((x * x) + (y * y));
            return distance;
        }

        // Recieves the distance, and the warp speed you want to use, and returns the time and fuel needed to travel
        private static (double, double) WarpSpeedCalcuation(double distance, int warpSpeed)
        {
            double warpFactor = ((Math.Pow(warpSpeed, (10 / 3)) + Math.Pow((10 - warpSpeed), (-11 / 3))));
            double fuel = distance * warpFactor;
            double time = 1 / warpFactor;
            return (time, fuel);
        }
    }
}
