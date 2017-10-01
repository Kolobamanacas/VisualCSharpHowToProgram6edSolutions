// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 14 (07.20) Circle Area.

using System;
using System.Globalization;

class CircleAreaCalculator
{
    static void Main()
    {
        // Initialize a local variable as a new object of class "CultureInfo" to use it during output to get dot as decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");
        Console.WriteLine("The app calculates an area of a circle.");
        Console.Write("Please enter circle's radius: ");
        double radius = double.Parse(Console.ReadLine(), cultureEnUs);
        Console.WriteLine($"The area of a circle with radius {radius.ToString(cultureEnUs)} is "
            + $"{CircleArea(radius).ToString(cultureEnUs)}");
        Console.WriteLine("Exit from application.");
    }

    /* Expression-bodied static method "CircleArea" takes one argument as a double value of circle's radius and together with a public field "PI" of class "Math" use it to calculate an area of a cirle with given radius. */
    static double CircleArea(double radius) => radius * radius * Math.PI;
}