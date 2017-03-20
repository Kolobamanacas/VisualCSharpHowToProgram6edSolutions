// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 21(14) (05.30) Square of Asterisks.

using System;

class SquareOfAsterisks
{
    static void Main()
    {
        // Ask user to input a square side size.
        Console.Write("Please enter the side of a square (1 to 20): ");
        int side = int.Parse(Console.ReadLine());
        
        Console.WriteLine();
        
        // If a user entered a number less than 1, consider it as 1.
        if (side < 1)
        {
            side = 1;
        }
        
        // If a user entered a number greater than 20, consider it as 20.
        if (side > 20)
        {
            side = 20;
        }
        
        // Create two counters that would count rows and columns of asterisks for the resulting sqare.
        int row = 1;
        int column = 1;
        
        /* The idea is to print several lines (or rows) of asterisks where the number of asterisks in a single row is equal to the number of rows. This number is hold in the "side"  local variable. We make two while loops. The innermost loop would just print asterisks in a row. The outermost loop would add a newline symbol to separate lines. Both loops counters start with 1, then increment their values by 1 every turn and finally stops when their values become larger than number hold inside the "side" local variable. */
        
        while (row <= side)
        {
            /* For the first glance it seems to be useless to set "column" local variable to 1 as soon as in the beginning it is already equals to 1, but when the second loop of "rows" occurs, the "column" would already contain the value larger than the "side" and the second loop would not be started. Thus we need to reset "column's" value to 1 every time we start a new row. */
            column = 1;
            
            while (column <= side)
            {
                Console.Write("*");
                ++column;
            }
            
            Console.WriteLine();
            ++row;
        }
    }
}