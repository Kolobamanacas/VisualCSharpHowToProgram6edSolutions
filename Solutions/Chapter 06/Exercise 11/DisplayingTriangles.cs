// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 11 (06.15) Displaying Triangles.

using System;

class DisplayingTriangles
{
    static void Main()
    {
        /* We have 4 scenarios and all of them are solved with two loops: outer and inner. Let's call a variable declared inside outer loops "row" as it would count number of rows to print (there always be 10 of them though). Let's also make "row" counter count from 1 to 10 for all four cases. As you guess correctly, a variable in an inner loop would be called column. For each row, a column would print asterisks on the basis of which row is the current. */

        /* Case 1. This is simple. On every row we print the same number of asterisks as a row number. One asterisk for the first row, two of the for the second row, etc. */
        for (int row = 1; row <= 10; ++row)
        {
            for(int column = 1; column <= row; ++column)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        /* Case 2. In the case we're doing it backwards comparing to case 1, starting from 10 asterisks for the first row and fining with 1 asterisk for the 10th row. */
        for (int row = 1; row <= 10; ++row)
        {
            for (int column = 10; column >= row; --column)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        /* Case 3. The 3rd case is a bit more complex. We need to print empty spaces before asterisks for every row except the first one. That is why we initialize a "spaceColumn" (sounds like "Cosmic", doesn't it?) variable with 2 instead of 1. Which leads to 0 spaces would be printed for the first row, followed by 10 asterisks; 1 space would be printed for the second row, followed by 9 asterisks, etc. */
        for (int row = 1; row <= 10; ++row)
        {
            for (int spaceColumn = 2; spaceColumn <= row; ++spaceColumn)
            {
                Console.Write(" ");
            }
            for (int asteriskColumn = 10; asteriskColumn >= row; --asteriskColumn)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        /* Case 4. The last case is a reversed version of the 3rd. For each row, spaces are printed from 9 to 0, and asterisks from 1 to 10. */
        for (int row = 1; row <= 10; ++ row)
        {
            for (int spaceColumn = 9; spaceColumn >= row; --spaceColumn)
            {
                Console.Write(" ");
            }
            for (int asteriskColumn = 1; asteriskColumn <= row; ++asteriskColumn)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}