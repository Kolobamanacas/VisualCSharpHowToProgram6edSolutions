// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 08 (07.14) Exponentiation.

using System;

class Exponentiation
{
    static void Main()
    {
        Console.WriteLine("Wellcome to integer exponent calculator.");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;

        // Ask user for the next number until he/she answers "no" to the "ToProceed" question.
        while (toProceed)
        {
            // Read base from a user.
            Console.Write("Enter base as an integer: ");
            int baseNumber = int.Parse(Console.ReadLine());
            // Read exponent from a user.
            Console.Write("Enter exponent as a positive integer: ");
            int exponent = int.Parse(Console.ReadLine());
            // Print result. Call method IntegerPoser to calculate the power of "baseNumber" in a power of "exponent".
            Console.WriteLine($"{baseNumber} in a power of {exponent} is {IntegerPower(baseNumber, exponent)}.");
            // Ask a user whether he/she wants to proceed.
            toProceed = ToProceed();
        }
    }

    /* "ToProceed()" method asks a user whether he/she wants to enter additional number. If a user enters "yes" then the method returns the value of "true" and otherwise it returns "false". */
    static bool ToProceed()
    {
        Console.Write("Do you want to enter the next number (\"yes\" or \"no\"): ");
        string answer = Console.ReadLine();

        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write("Do you want to enter the next number (\"yes\" or \"no\"): ");
            answer = Console.ReadLine();
        }

        if (answer == "yes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // The "IntegerPoser()" method calculates the "exponent's" power of "baseNumber" and return it as an integer.
    static int IntegerPower(int baseNumber, int exponent)
    {
        int result = baseNumber;

        // If "exponent" equals to 0, then the result is always 1.
        if (exponent == 0)
        {
            return 1;
        }
        // If "exponent equals to 1, then the result is "baseNumber" itself.
        else if (exponent == 1)
        {
            return baseNumber;
        }
        // In all other cases multiply "baseNumber" by itself the number of "exponent" - 1.
        else
        {
            while (exponent > 1)
            {
                result *= baseNumber;
                --exponent;
            }

            return result;
        }
    }
}