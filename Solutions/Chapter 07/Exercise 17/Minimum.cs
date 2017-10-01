// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 17 (07.23) Find the Minimum.

/* This exercise is a direct copy-paste from the textbook, so it shouldn't be too difficult. We put "Math.Min()" method with two numbers inside another "Math.Min()" method, giving third number as a second parameter. The innermost method would return a double value which would be used as a first parameter in outermost "Math.Min()" method. */

using System;
using System.Globalization;

class Minimum
{
    static void Main()
    {
        // Initialize a local variable as a new object of class "CultureInfo" to use it during input to get dot as decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");
        Console.WriteLine("The app determines the lowest number from three given.");
        Console.Write("Please enter number1: ");
        double number1 = double.Parse(Console.ReadLine(), cultureEnUs);
        Console.Write("Please enter number2: ");
        double number2 = double.Parse(Console.ReadLine(), cultureEnUs);
        Console.Write("Please enter number3: ");
        double number3 = double.Parse(Console.ReadLine(), cultureEnUs);
        Console.WriteLine("The lowest of the given numbers is "
            + $"{Minimum3(number1, number2, number3).ToString(cultureEnUs)}");
    }

    // Static method takes three double numbers as arguments and returns the lowest one as anouther double value.
    static double Minimum3(double number1, double number2, double number3) =>
        Math.Min(Math.Min(number1, number2), number3);
}