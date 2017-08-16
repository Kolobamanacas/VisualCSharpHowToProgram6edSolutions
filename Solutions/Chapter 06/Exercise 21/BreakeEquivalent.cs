// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 21 (06.25) Structured Equivalent of break Statement.

/* To have the same output as an application had before we need to use separate variables to have a number of counts after a counter is changed to fail the loop continuation test. We also shouldn't print a number if current count equals to 5. */

using System;

class BreakeEquivalent
{
    static void Main()
    {
        // A variable to use as a counter of actually performed loops.
        int performedLoops = 0;

        // Loop 10 times.
        for (int count = 1; count <= 10; ++count)
        {
            // Increment counter for it matches current count's value.
            ++performedLoops;

            // If count is not equal to 5.
            if (count != 5)
            {
                Console.Write($"{performedLoops} ");
            }
            // If count is 5.
            else
            {
                // Terminate loop by by falling the loop continuation test.
                count = 11;
            }
        }

        Console.WriteLine($"\nBroke out of loop at count = {performedLoops}");
    }
}