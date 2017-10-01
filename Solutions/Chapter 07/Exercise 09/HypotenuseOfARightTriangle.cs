// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 09 (07.15) Hypotenuse of a Right Triangle.

using System;
using System.Globalization;

class HypotenuseOfARightTriangle
{
    static void Main()
    {
        Console.WriteLine("Wellcome to Hypotenuse calculator.");
        // Initialize a local variable as a new object of class "CultureInfo" to use it during output to get dot as decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;

        // Ask user for the next numbers pair until he/she answers "no" to the "ToProceed" question.
        while (toProceed)
        {
            /* Read sides from a user. Method "Parse()" get two argument: methor "ReadLine()" of static class "Console" and an object "cultureEnUS" of class "CultureInfo". The first argument gives "Parse()" a string to parse and the second tells how to parse this string (i.e. to use dot and not comma as a decimal mark). */
            Console.Write("Please enter the first side: ");
            double side1 = double.Parse(Console.ReadLine(), cultureEnUs);
            Console.Write("Please enter the second side: ");
            double side2 = double.Parse(Console.ReadLine(), cultureEnUs);
            /* Print results with calling static method "Hypotenuse()" that returns sqare root of sum of product of the first number with itselft and product of the second number by itselft. */
            Console.WriteLine($"The hypotenuse of right triangle with "
                + $"side1 == {side1.ToString(cultureEnUs)} and side2 == {side2.ToString(cultureEnUs)} is: "
                + $"{Hypotenuse(side1, side2).ToString(cultureEnUs)}.");
            Console.WriteLine();
            // Check whether a user wants to continue.
            toProceed = ToProceed();
        }
    }

    /* "ToProceed()" method asks a user whether he/she wants to enter additional numbers pair. If a user enters "yes" then the method returns the value of "true" and otherwise it returns "false". */
    static bool ToProceed()
    {
        Console.Write("Do you want to enter the next numbers pair (\"yes\" or \"no\"): ");
        string answer = Console.ReadLine();

        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write("Do you want to enter the next numbers pair (\"yes\" or \"no\"): ");
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

    // Expression-bodied method "Hypotenuse()" takes two numbers of type double and using method "Sqrt()" of static class "Math" returns sqare root of sum of product of these numbers with themselves.
    static double Hypotenuse(double side1, double side2) =>
        Math.Sqrt(side1 * side1 + side2 * side2);
}