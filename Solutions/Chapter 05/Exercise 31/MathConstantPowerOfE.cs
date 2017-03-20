// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 31(24) (05.40) Infinite Series: e^x.

/* Here we again use the factorial class created in the previous exercise. All we need to change is to replace 1 to a number which we would rise to different powers. We could use a method Math.Pow() mentioned in the exercise, but our knowledge level is enough to create our own rising-to-power code. */

using System;

class MathConstantE
{
    static void Main()
    {
        double e = 1;
        int counter = 1;
        // We would use it to know how many times to multiply "x" by itselft to get a proper power.
        int power = 1;

        // Ask a user to enter a number to use it as a power for e till the end of the app's runtime.
        Console.Write("Please enter a number to rise constant e to it's power: ");
        int x = int.Parse(Console.ReadLine());
        // A local variable to store "x's" powee
        int xPowered = x;

        // As soon as we are limited with maximum number integers and doubles can store, let's use 10 loops's precision.
        while (counter <= 10)
        {
            /* This loop would be executed once for every "counter's" value except the first one, where both "power" and "counter" equal to 1. When counter would be equal to 2, the loop would be executing once providing xPowered * x result stored in "xPowered", which is the second power of "x" - just what we need to the further calculations on the step. */
            while (power < counter)
            {
                xPowered *= x;
                ++power;
            }

            /* GetFactorial method returns an integer, so we need to cast in to double before use as divider for 1. */
            e += xPowered / (double)Factorials.GetFactorial(counter);
            ++counter;
        }

        Console.WriteLine($"The e constant provided by Math.E is:   {Math.Pow(Math.E, x)}");
        Console.WriteLine($"The e constant provided by thie app is: {e}");
    }
}