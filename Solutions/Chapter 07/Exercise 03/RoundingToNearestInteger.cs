// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 03 (07.09) Rounding to Nearest Integer.

using System;
using System.Globalization;

class RoundingToNearestInteger
{
    static void Main()
    {
        // Initialize a local variable as a new object of class "CultureInfo" to use it during output to get dot as decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");
        Console.WriteLine("The app will round your rational numbers to nearest integers.");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;

        // Ask user for the next number until he/she answers "no" to the "ToProceed" question.
        while (toProceed)
        {
            Console.Write("Enter a rational number: ");
            // "cultureEnUS" as a second argument for "Parse()" method tells the method to interpret dot as a decimal mark.
            double rationalNumber = double.Parse(Console.ReadLine(), cultureEnUs);
            // Print the original number with the En-Us culture style.
            Console.WriteLine($"The original number is: {(rationalNumber).ToString(cultureEnUs)}");
            // Print rounded double value to the nearest integer.
            Console.WriteLine($"The nearest integer is: {Math.Floor(rationalNumber + 0.5)}");
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
}