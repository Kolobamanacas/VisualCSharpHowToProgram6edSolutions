// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 20 (06.24) Modified Diamond Program.

/* I decide to use one for loop to count number of rows and use 5 additional loops to print spaces and asterisks of upper part of a diamod, middle line of asterisks and spaces and asterisks of bottom part. */

using System;

class ResizableDiamond
{
    static void Main()
    {
        // Variable of type integer to store height of a diamond.
        int diamondHeight = 0;

        // Print wellcome message.
        Console.Write("Please enter an odd integer in a range of 1-19 to print a diamond of appropriate height: ");
        // Get diamond's height from user and store it in a "diamondHeight" variable.
        diamondHeight = int.Parse(Console.ReadLine());

        /* It is always a good practice to prevent incorrect input. So if a value entered by a user is out of range or not odd, loop an error message and input prompt until a user input correct height. */
        while (diamondHeight < 1
            || diamondHeight > 19
            || diamondHeight % 2 == 0)
        {
            Console.Write("You've entered incorrect height. Height should be any odd number within 1 to 19 range. Please enter correct height: ");
            diamondHeight = int.Parse(Console.ReadLine());
        }

        // A little header before printing a diamond itself.
        Console.WriteLine("Here is your nice diamond:");

        // The outermost loop that counts rows from 1 to a number entered by a user.
        for (int row = 1; row <= diamondHeight; ++row)
        {
            /* As an example, in a diamond with 7 total rows, there are 3 rows in the upper part, 1 row is a middle line and 3 rows in a bottom part. In the upper part of a diamond (not including it's middle line), at the first row spaces should be printed the same amount of times as number of rows should exist from first row till the middle line of a diamond. And number of spaces is decremented every row till the middle line. For example for the diamond with total 9 rows, spaces should be printed from 4 in the first row till 1 in the fourth row. Integer division returns the whole part or result without it's fractional part. This property is convenient for us as for a diamond with odd number of rows, divisioun by 2 would always return the number of rows of it's upper (or bottom) part. Using this we initialize "space" with current row number and user (diamondHeight / 2) as loop continuation condition. */
            for (int space = row; space <= (diamondHeight / 2); ++space)
            {
                Console.Write(" ");
            }
            /* Here the following property of numbers is used: (n * 2 - 1), where "n" is a positive integer starting from 1 and incremented by 1, would return the whole set of positive odd numbers. For "asterisk" of the upper part we need to check two conditions to print them correctly. The first condition "asterisk <= ((row * 2) - 1)" allows to print odd number of asterisks on the basis of current "row" number. The second one makes sure that we print asterisks only for the upper part of a diamond. */
            for (int asterisk = 1; asterisk <= ((row * 2) - 1) && row <= (diamondHeight / 2); ++asterisk)
            {
                Console.Write("*");
            }
            /* As you probably noticed, sometimes it is convenient to use multiple condition check statements within for loop header. The middle line of a diamond always contains the same number of asterisks as a number of rows a diamond has. Expression "((diamondHeight / 2) + 1)" returns the number of row of a middle line. So we initialize "middleAsterisk" with 1, print asterisks the same number of times as the "diamondHeight" and do it only for the middle line row. */
            for (int middleAsterisk = 1;
                middleAsterisk <= diamondHeight && row == ((diamondHeight / 2) + 1);
                ++middleAsterisk)
            {
                Console.Write("*");
            }
            /* We almost done. :) "((diamondHeight / 2) + 2)" returns the first row number of the bottom part right after the middle line. This gives us the possibility to print the same number of spaces as a row would have if we start cound from the beginning of the bottom part. */
            for (int space = ((diamondHeight / 2) + 2); space <= row; ++space)
            {
                Console.Write(" ");
            }
            /* And at last the final part. I am 146% sure that there is a way to make it in more elegant way, but I spent two days with thing and decide to leave it as is. It least it works correctly. The second condition is easy to understand - it makes sure that we check only rows of the bottom part, so let's make a deeper look at the first condition. Expression "(diamondHeight - row + 1)" returns a number that is greater than a distance between a diamond's height and current row by 1. As soon as row is incremented by 1 every loop, we get the sequence of decremented integers. Multiplying numbers from this sequence by 2 and subtracted by 1 leaves decremented sequence of odd numbers till 1. That's it! */
            for (int asterisk = 1;
                asterisk <= (((diamondHeight - row + 1) * 2) - 1) && row >= ((diamondHeight / 2) + 2);
                ++asterisk)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}