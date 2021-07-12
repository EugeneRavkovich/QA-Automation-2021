using System;

namespace CarFleet
{
    static class Utility
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("This is a program for car fleet managment\n" +
                "********************************************************************************\n" +
                "Available commands:\n" +
                "================================================================================\n" +
                "add: add a car to the fleet\n" +
                "--------------------------------------------------------------------------------\n" +
                "add - brand - model - quantity - cost of one unit\n" +
                "Example: add subaru wrx 1 12500\n" +
                "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                "count all: count the total number of cars\n" +
                "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                "count brands: count the total number of car brands\n" +
                "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                "average price: calculate the average price of all cars\n" +
                "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                "average price brand: calculate the average price of all cars of a specified brand\n" +
                "--------------------------------------------------------------------------------\n" +
                "average price brand - car brand\n" +
                "Example: average price brand subaru\n" +
                "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n");
        }

    }
}
