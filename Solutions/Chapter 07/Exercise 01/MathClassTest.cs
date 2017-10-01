// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 01 (07.07).

using System;
using System.Globalization;

class MathClassTest
{
    static void Main()
    {
        // Initialize a local variable as a new object of class "CultureInfo" to use it during output to get dot as decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");

        // Print all the statements to check values.
        Console.WriteLine($"The value of Math.Abs(7.5) is: {Math.Abs(7.5).ToString(cultureEnUs)}");
        Console.WriteLine($"The value of Math.Floor(7.5) is: {Math.Floor(7.5).ToString(cultureEnUs)}");
        Console.WriteLine($"The value of Math.Abs(0.0) is: {Math.Abs(0.0).ToString(cultureEnUs)}");
        Console.WriteLine($"The value of Math.Ceiling(0.0) is: {Math.Ceiling(0.0).ToString(cultureEnUs)}");
        Console.WriteLine($"The value of Math.Abs(-6.4) is: {Math.Abs(-6.4).ToString(cultureEnUs)}");
        Console.WriteLine($"The value of Math.Ceiling(-6.4) is: {Math.Ceiling(-6.4).ToString(cultureEnUs)}");
        Console.WriteLine("The value of Math.Ceiling(-Math.Abs(-8 + Math.Floor(-5.5))) is: "
            + $"{Math.Ceiling(-Math.Abs(-8 + Math.Floor(-5.5))).ToString(cultureEnUs)}");
    }
}