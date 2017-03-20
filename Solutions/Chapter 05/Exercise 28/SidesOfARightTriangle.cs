// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 28(21) (05.37) Sides of a Right Triangle.

using System;

class SidesOfARightTriangle
{
    static void Main()
    {
        /* The task is pretty similar to the previous one, but this time we need the Pythagoras's Theorem to solve it. The theorem states that the square of the hypotenuse (the side opposite the right angle) is equal to the sum of the squares of the other two sides. This means that all we need is to check this equality statement and if it's true - provided sides cauld represend a right triangle. The only thing we need to know before tha check is which side is a hypotenuse. The hypotenuse itself should be the largest side of a right triangle, so finding the largest number would reveal a hypotenuse. */
        
        // Read numbers from a user.
        Console.WriteLine("Please enter three numbers to determine whether they represent sides of a right triangle. Separate every number with \"Enter\" button:");
        int sideA = int.Parse(Console.ReadLine());
        int sideB = int.Parse(Console.ReadLine());
        int sideC = int.Parse(Console.ReadLine());
        
        /* Lets write the largest number to the "sideA" local variable to be sure that it is a potential hypotenuse. If the "sideB" is the largest. */
        if (sideB > sideA)
        {
            if (sideB > sideC)
            {
                // Switch values of sides A and B.
                int sideTemp = sideA;
                sideA = sideB;
                sideB = sideTemp;
            }
        }
        else if (sideC > sideA)
        {
            if (sideC > sideB)
            {
                // Else if the "sideC" is the largest - switch values of sides A and C.
                int sideTemp = sideA;
                sideA = sideC;
                sideC = sideTemp;
            }
        }
        /* We don't check whether the "sideA" is the largest side cause we assume that it is already the one. And even if it's not, the following equallity check would work correctly. */
        
        /* Now when the "sideA" is hypotenuse for sure, we can simply check the Pythagoras's Theorem equality. */
        if ((sideA * sideA) == (sideB * sideB + sideC * sideC))
        {
            Console.WriteLine($"The numbers {sideA}, {sideB} and {sideC} could represent right triangle sides.");
        }
        else
        {
            Console.WriteLine($"The numbers {sideA}, {sideB} and {sideC} could not represent right triangle sides.");
        }
    }
}