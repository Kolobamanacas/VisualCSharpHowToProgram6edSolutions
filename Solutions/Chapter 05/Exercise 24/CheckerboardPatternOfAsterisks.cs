// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 24(17) (05.33) Checkerboard Pattern of Asterisks.

using System;

class CheckerboardPatternOfAsterisks
{
    static void Main()
    {
        /* We already did similar exercise before, so it should be easy to do. Check the code or contact me if you have some troubles with it. */
        
        int row = 1;
        int column = 1;
        
        while (column <= 8)
        {
            row = 1;
            
            // For the even lines add additional space before row.
            if (column % 2 == 0)
            {
                Console.Write(" ");
            }
            
            while (row <= 8)
            {
                Console.Write("* ");
                
                ++row;
            }
            
            Console.WriteLine();
            
            ++column;
        }
    }
}