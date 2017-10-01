// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 29 (07.35) Recursive Power Calculation.

using System;

class RecursivePowerCalculation
{
    static void Main()
    {
        // Print a wellcome message.
        Console.WriteLine("The app calculates a given power of a given number.");
        /* Ask a user to enter a base number. I user "long" instead of "int" because I want to have a possiblity to calculate a power for larger number. "long" uses 64 bit of memory to store every number, instead of 32 bit used by "int. */
        Console.Write("Enter a number: ");
        long baseNumber = long.Parse(Console.ReadLine());
        // Ask a user to enter an exponent.
        Console.Write("Enter a power to raise a number to: ");
        long exponent = long.Parse(Console.ReadLine());
        // Print the first part of a result output.
        Console.Write($"The {baseNumber} raised to {exponent}");

        /* It is nice to have the correct ending of numbers when we count them. Like 24'th, 70'th or 8'th have "th" at the end and 1st have "st". It is easy to implement checking the last digit of a number, which in turn easily calculated by getting the remainder after division of a number by 10. This switch statement prints different endings depending on the last digit in an "exponent's" value. */
        switch (exponent % 10)
        {
            case 1:
                Console.Write("'st ");
                break;
            case 2:
                Console.Write("'nd ");
                break;
            case 3:
                Console.Write("'rd ");
                break;
            default:
                Console.Write("'th ");
                break;
        }

        // Print the last part of a result output with calling the "Power()" method.
        Console.WriteLine($"power equals to: {Power(baseNumber, exponent)}");
    }

    /* Private static method "Power()" takes two arguments of type "long" and returns the first argument raised to the power of the second. It is states in the task that an exponent should be a positive number, so we don't consider another cases. The method uses recursion. The base case here is the case when an "exponent" becomes equal to 1. In this case the method returns the base number itself. In all other cases it multiplies given base number by the result of recursively called "Power()" method with "exponent" decremented by 1.*/
    private static long Power(long baseNumber, long exponent)
    {
        if (exponent == 1)
        {
            return baseNumber;
        }
        else
        {
            return baseNumber * Power(baseNumber, --exponent);
        }
    }
}