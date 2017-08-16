// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 23 (06.27) Structured Equivalent of continue statement.

/* The task is to implement the same logic (to have the same output) but without "continue" statement. We could change the continuation test for count inside a for loop to inequality to 5 and replace continue statement inside a body of "if" with printing statement. */

using System;

class ContinueEquivalent
{
    static void Main()
    {
        // Loop 10 times.
        for (int count = 1; count <= 10; ++count)
        {
            // If count is not 5.
            if (count != 5)
            {
                // Print a number.
                Console.Write($"{count} ");
            }

        }

        Console.WriteLine("\nUsed comparison ot a count to 5 to skip displaying 5.");
    }
}