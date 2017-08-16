// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 09 (06.13) Factorials.

using System;

class Factorials
{
    static void Main()
    {
        /* Berfore the start, let's answer to the last question of the exercise. Factorial is a fast growing progression and it is obvious that as soon as data types are strict limited with their size, the calculation of factorials using int data type (wich is limited with 32 bits) could lead to memory overflow. */

        // Initialize positiveInteger local variable which would store integers to calculate each number's factorial.
        int positiveInteger = 0;
        // Initialize factorial local variable which would store factorial for every number from 1 to 5 to be printed.
        int factorial = 1;

        /* We have two loops. The outermost loop would be executed 5 times with number local variable following values: 1, 2, 3, 4 and 5. Every turn the positiveInteger local variable would get the same value as the number, but then would be deminished by innermost loop which would calculate it's factorial and would write it to the factorial variable. The factorial number then would be printed at the end of outermost loop. */
        for (int number = 1; number <= 5; ++number)
        {
            positiveInteger = number;
            factorial = 1;
            
            while (positiveInteger >= 1)
            {
                factorial *= positiveInteger;
                --positiveInteger;
            }

            Console.Write($"{factorial}\t");
        }
    }
}