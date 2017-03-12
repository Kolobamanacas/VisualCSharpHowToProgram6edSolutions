// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Making-a-Difference Exercise 02 (03.32) Car-pool Savings Calculator.

// Join System namespace to be able to use Console class.
using System;
// Joint System.Globalization namespace to be able to use CultureInfo. See comments below.
using System.Globalization;

// Declare a class to perform our task.
class CarpoolSavingsCalculator
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        // Declare variables of type double to store appropriate values in compute's memory.
        double milesPerDay;
        double costPerGallonInCents;
        double milesPerGallon;
        double parkingFeePerDayInCents;
        double tollsPerDayInCents;
        
        // Again we need CultureInfo object to store information about input formats like decimal mark to parse text to double numbers correctly. Please see an explanation in Make-a-Diff Exercise 03.31.
        CultureInfo cultureEnUs = new CultureInfo("en-US");
        
        // Ask user to enter the values for his/her car and store the assign the values to the vatiables.
        Console.Write("Please enter the number of miles you pass daily: ");
        // The frst argument of method Parse would become a string to parse and the second is object of regional standard information.
        milesPerDay = double.Parse(Console.ReadLine(), cultureEnUs);
        
        Console.Write("Please enter the cost of gallon of gasoline you use in cents: ");
        costPerGallonInCents = double.Parse(Console.ReadLine(), cultureEnUs);
        
        Console.Write("Please enter gasoline consumption of your car in miles per gallon: ");
        milesPerGallon = double.Parse(Console.ReadLine(), cultureEnUs);
        
        Console.Write("Please enter parking fees per day in cents (if you have no such, enter 0): ");
        parkingFeePerDayInCents = double.Parse(Console.ReadLine(), cultureEnUs);
        
        Console.Write("Please enter tolls per day in cents: ");
        tollsPerDayInCents = double.Parse(Console.ReadLine(), cultureEnUs);
        
        // Display additional empty line for clearer output view.
        Console.WriteLine();
        
        // Calculate and display the resulting costs of car usage per day.
        Console.Write("Your daily driving costs are: ");
        Console.Write($"{((milesPerDay / milesPerGallon) * costPerGallonInCents) + parkingFeePerDayInCents + tollsPerDayInCents}");
    } // Exit Main's method body.
} // Exit class body.