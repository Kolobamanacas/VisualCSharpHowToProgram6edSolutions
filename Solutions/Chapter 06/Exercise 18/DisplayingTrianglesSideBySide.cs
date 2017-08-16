// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 18 (06.22) Modified Triangle Program.

using System;

class DisplayingTrianglesSideBySide
{
    static void Main()
    {
        // This time we have only 10 rows for the whole output, so outermost loop for rows is the same for all triangles.
        for (int row = 1; row <= 10; ++row)
        {
            /* For every triangle for every row we need to print appropriate number of asterisks ("*") and spaces (" "). For clearity I also separate triangles from each other by two spaces. For the first triangle we need to print asterisks from 1 in the first row to 10 in the the last incrementing them by 1 for every row. It is easy to notice that number of asterisks in every row of the first triangle is the same as a number of this row. So we simply initialize "firstTriangleAsterisk" with 1 and use row itself as continuation condition. */
            for (int firstTriangleAsterisk = 1; firstTriangleAsterisk <= row; ++firstTriangleAsterisk)
            {
                Console.Write("*");
            }
            /* There should be 9 spaces in the first row and 0 in the last. We use "row" incremented by 1 to initialize "firstTriangleSpace" and 10 as continuation condition. */
            for (int firstTriangleSpace = row + 1; firstTriangleSpace <= 10; ++firstTriangleSpace)
            {
                Console.Write(" ");
            }
            
            // Add two spaces between any two triangles.
            Console.Write("  ");
            
            /* Total length of every row in the first triangle is 12: 10 symbols of asterisks and spaces mix and 2 additional spaces to visually separate triangles from each other. This means that we could print second and all the rest triangles without worring about start positions.  Read the following code carefully to understand how does it work. */
            for (int secondTriangleAsterisk = row; secondTriangleAsterisk <= 10; ++secondTriangleAsterisk)
            {
                Console.Write("*");
            }
            for (int secondTriangleSpcae = 2; secondTriangleSpcae <= row; ++secondTriangleSpcae)
            {
                Console.Write(" ");
            }

            Console.Write("  ");

            for (int secondTriangleSpcae = 2; secondTriangleSpcae <= row; ++secondTriangleSpcae)
            {
                Console.Write(" ");
            }
            for (int secondTriangleAsterisk = row; secondTriangleAsterisk <= 10; ++secondTriangleAsterisk)
            {
                Console.Write("*");
            }

            Console.Write("  ");

            for (int firstTriangleSpace = row + 1; firstTriangleSpace <= 10; ++firstTriangleSpace)
            {
                Console.Write(" ");
            }
            for (int firstTriangleAsterisk = 1; firstTriangleAsterisk <= row; ++firstTriangleAsterisk)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}