// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 18 (07.24) Perfect Numbers.

using System;

class PerfectNumbers
{
    static void Main()
    {
        Console.WriteLine("Here are all perfect numbers in a 1 to 1000 range.");

        // Check all numbers from 1 to 1000.
        for (int number = 1; number <= 1000; ++number)
        {
            // Use method "IsPerfect()" to determine whether a number is perfect.
            if (IsPerfect(number))
            {
                // If the number is perfect - print all it's factors using the method "PrintFactors()".
                PrintFactors(number);
            }
        }
    }

    /* Some programmers think that bool method should be named in a Is*something* way. This naming convention helps code to be self-explaining. For exaple if you see "IsPerfect()" method you would immidiately know that it checks whether a number is perfect. It makes some sense be cause a number could be whether perfect (in which case the method returns "true") or not perfect (method returns "false"). */
    static bool IsPerfect(int value)
    {
        int sum = 0;

        for (int number = 1; number < value; ++number)
        {
            if (value % number == 0)
            {
                sum += number;
            }
        }

        if (sum == value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /* I could add printing statements inside the "IsPerfect()" method, but this would lead to complexity. The code is easier to read and understand when every method performs a single simple task. This method prints all factors and a sum of given perfect number. */
    static void PrintFactors(int value)
    {
        Console.Write($"{value} is a perfect number. The sum of it's factors is: 1");
        int sum = 1;

        for (int number = 2; number < value; ++number)
        {
            if (value % number == 0)
            {
                sum += number;
                Console.Write($" + {number}");
            }
        }

        Console.Write($" = {sum}");
        Console.WriteLine();
    }
}