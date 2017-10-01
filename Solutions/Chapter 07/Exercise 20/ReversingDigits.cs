// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 20 (07.26) Reversing Digits.

using System;

class ReversingDigits
{
    static void Main()
    {
        // Print a wellcome message.
        Console.WriteLine("The app reverses given integer number.");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;

        while (toProceed == true)
        {
            // Ask a user to enter a number.
            Console.Write("Please enter an integer: ");
            int number = int.Parse(Console.ReadLine());
            // Print the resulting reversed number.
            Console.Write($"The reversed number of {number} is: ");
            // Call method "PrintReversedInteger()" to print the reversed number.
            PrintReversedInteger(number);

            Console.WriteLine();
            // Ask a user whether he/she wants to proceed.
            toProceed = ToProceed();
        }
    }

    /* "ToProceed()" method asks a user whether he/she wants to enter additional number. If a user enters "yes" then the method returns the value of "true" and otherwise it returns "false". */
    static bool ToProceed()
    {
        Console.Write("Do you want to enter additional number (\"yes\" or \"no\"): ");
        string answer = Console.ReadLine();

        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write("Do you want to enter additional number (\"yes\" or \"no\"): ");
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

    /* Here is another recursion example. The static method "PrintReversedInteger()" takes one integer as an argument and returns no value. Here the base case executes only once when the number become less than 10. In all other cases we print the rightmost digit of given number, then "cut it off" from the given number and pass this cut number to another method's self-call. */
    static void PrintReversedInteger(int number)
    {
        if (number / 10 == 0)
        {
            Console.Write(number);
        }
        else
        {
            Console.Write(number % 10);
            PrintReversedInteger(number / 10);
        }
    }
}