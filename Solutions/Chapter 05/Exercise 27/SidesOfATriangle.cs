// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 27(20) (05.36) Sides of a Triangle.

using System;

class SidesOfATriangle
{
    static void Main()
    {
        /* This time we have no hint. But that's not a problem as soon as we have google in our pocket. So in case you forgot (the same as I did), I will remind you: to determine whether three side lengths could represent a triangle the Triangle Inequality Theorem could be used. It states that the sum of two side lengths of a triangle is always greater than the third side. If this is true for all three combinations of added side lengths, then you will have a triangle. So all we need is to read sides and check three inequality combinations. This task should be easy and if its not - feel free to contact me for an extra explanation. */
        
        // Ask user to input all three sides.
        Console.WriteLine("Please enter three numbers to determine whether they represent sides of a triangle. Separate every number with \"Enter\" button:");
        int sideA = int.Parse(Console.ReadLine());
        int sideB = int.Parse(Console.ReadLine());
        int sideC = int.Parse(Console.ReadLine());
        
        // If all combinations of sides inequality are true.
        if (sideA + sideB > sideC)
        {
            if (sideA + sideC > sideB)
            {
                if (sideB + sideC > sideA)
                {
                    // Print a confirmation of possibility to use provided numbers as triangle sides.
                    Console.WriteLine($"The numbers {sideA}, {sideB} and {sideC} could represent triangle sides.");
                }
            }
        }
        else
        {
            // If at least one of tested inequality statements is false, print a message that disapprove such pssibility.
            Console.WriteLine($"The numbers {sideA}, {sideB} and {sideC} could not represent triangle sides.");
        }
    }
}