// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 07 (06.11) Find the Smallest Value.

using System;

class FindTheSmallestValue
{
    static void Main()
    {
        // Welcome message.
        Console.WriteLine("The Smallest Value Founder.");
        Console.WriteLine();

        // Read the number of values to compare from a user.
        Console.Write("Please enter the number of values you wish to compare: ");
        int numberOfValues = int.Parse(Console.ReadLine());

        /* If a user enters at least one number to compare, read the first number to compare, write it as the smallest one and decrement number of values left to compare. */
        if (numberOfValues > 0)
        {
            Console.Write("Enter the first number to compare: ");
            int userInput = int.Parse(Console.ReadLine());
            int smallestValue = userInput;
            --numberOfValues;
        }

        /* While there are numbers to compare, read the next number, then if it is less than current smallest one - write the number as new smallest value. Then decrement the number of values left to compare. */
        while (numberOfValues >= 1)
        {
            Console.Write("Enter the next number to compare: ");
            userInput = int.Parse(Console.ReadLine());
            
            if (userInput < smallestValue)
            {
                smallestValue = userInput;
            }

            --numberOfValues;
        }

        Console.WriteLine();

        // Print the resulting smallest value.
        Console.WriteLine($"The smallest number is: {smallestValue}");
    }
}