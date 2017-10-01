// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 21 (07.27) Greatest Common Divisor.

using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        // Print a wellcome message.
        Console.WriteLine("The app shows the greatest common divisor of two integers.");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;

        // While user entering "yes" to the ToProceed question.
        while (toProceed == true)
        {
            // Ask a user to enter values.
            Console.Write("Enter the first number: ");
            int number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int number2 = int.Parse(Console.ReadLine());
            // Find the lowest number and write it to local variable "number1" leaving the rest value in the "number2".
            WriteMinimumToTheFirst(ref number1, ref number2);
            Console.WriteLine($"The greatest common divisor of {number1} and {number2} is: {Gcd(number1, number2)}");

            Console.WriteLine();
            // Ask a user whether he/she wants to proceed.
            toProceed = ToProceed();
        }
    }

    /* "ToProceed()" method asks a user whether he/she wants to enter additional numbers pair. If a user enters "yes" then the method returns the value of "true" and otherwise it returns "false". */
    static bool ToProceed()
    {
        Console.Write("Do you want to enter additional numbers pair (\"yes\" or \"no\"): ");
        string answer = Console.ReadLine();

        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write("Do you want to enter additional numbers pair (\"yes\" or \"no\"): ");
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

    /* Static method that takes to arguments by reference, determines which one is less and writes it to the first argument. Leaving the rest number in the second argument. As soon as the method takes arguments by reference it changes their values directly. */
    static void WriteMinimumToTheFirst(ref int number1, ref int number2)
    {
        int tempNumber;

        if (number1 > number2)
        {
            tempNumber = number2;
            number2 = number1;
            number1 = tempNumber;
        }
    }

    /* Static method "Gcd()" takes two integer numbers as arguments and returns their greatest common divisor if it is exists and "1" otherwise. */
    static int Gcd(int number1, int number2)
    {
        int gcd = 1;

        /* We make sure that "number1" is less than "number2" to avoid unnecessary calculations. Gcd cannot be greater than the lowest number of two given. So, for every number from the lowest given number to 1. */
        for (int divisor = number1; divisor > 0; --divisor)
        {
            /* If there is a greatest common divisor write it's value to "gcd" and user "break" to exit the for loop. */
            if (number1 % divisor == 0 && number2 % divisor == 0)
            {
                gcd = divisor;
                break;
            }
        }

        // Return found gcd or "1" if it doesn't exist.
        return gcd;
    }
}