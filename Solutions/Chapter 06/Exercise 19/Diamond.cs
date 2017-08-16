// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 19 (06.23) Displaying a Diamond.

/* The task sounds trivial, yet after a deeper look you would understand that it could take some time. I didn't find a way to complete the task with using output statements less than two time for each. If you know the way, it would be great if you share this knowledge.
I use two "for" statements to print upper and bottom part of a diamond respectively. To print spaces at every loop of outermost loop I initialize "space" with current value "row" and increment and print spaces until "space" is less or equals 4. To pring asterisks the ((row * 2) - 1) is implemented. This tricky expression let us get a sequenca of odd numbers using the sequance of integers. The second outermost loop uses similar logic. Hope you got it. */

using System;

class Diamond
{
    static void Main()
    {
        for (int row = 1; row <= 5; ++row)
        {
            for (int space = row; space <= 4; ++space)
            {
                Console.Write(" ");
            }
            for (int asterisk = 1; asterisk <= ((row * 2) - 1); ++asterisk)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        for (int row = 1; row <= 4; ++row)
        {
            for (int space = 1; space <= row; ++space)
            {
                Console.Write(" ");
            }
            for (int asterisk = ((row * 2) - 1); asterisk <= 7; ++asterisk)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}