// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 30(23) (05.39) Infinite Series: Mathematical Constant e.

/* In this exercise we need to use a factorial class created in the previous exercise. We change it the way it would get a number as an argument and return a factorial of this number. */

using System;

class MathConstantE
{
    static void Main()
    {
        double e = 1;
        int counter = 1;

        // As soon as we are limited with maximum number integers and doubles can store, let's use 10 loops's precision.
        while (counter <= 10)
        {
            // GetFactorial method returns an integer, so we need to cast in to double before use as divider for 1.
            e += 1 / (double)Factorials.GetFactorial(counter);
            ++counter;
        }

        Console.WriteLine($"The e constant provided by Math.E is:   {Math.E}");
        Console.WriteLine($"The e constant provided by thie app is: {e}");
    }
}