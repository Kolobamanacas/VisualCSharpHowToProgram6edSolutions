// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 12 (07.18) Displaying a Square of Asterisks.

using System;

class DisplayingASquareOfAsterisks
{
    static void Main()
    {
        Console.WriteLine("The app prints a square of asterisks with given side length.");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;

        // Ask user for the next square size until he/she answers "no" to the "ToProceed" question.
        while (toProceed)
        {
            // Ask a user to enter a number.
            Console.Write("Please enter the size of a square: ");
            /* Nothing prevents us to put "int.Parse(Console.ReadLine())" constructions inside a method's parameters list. In such a case the system would read the string of characters from a user with "ReadLine()" method of class "Console", then would parse it to "int" with a static "Parse()" method and then would give the result to the method "SauareOfAsterisks()" as a parameter. */
            SquareOfAsterisks(int.Parse(Console.ReadLine()));

            Console.WriteLine();
            // Check whether a user wants to continue.
            toProceed = ToProceed();
        }
    }

    /* "ToProceed()" method asks a user whether he/she wants to print another square. If a user enters "yes" then the method returns the value of "true" and otherwise it returns "false". */
    static bool ToProceed()
    {
        Console.Write("Do you want to print another square (\"yes\" or \"no\"): ");
        string answer = Console.ReadLine();

        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write("Do you want to print another square (\"yes\" or \"no\"): ");
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

    /* Static method "SquareOfAsterisks()" takes one integer number as an argument and use it to print a square with every side equals to the given number. The method doesn't return any value as it's return type is void. */
    static void SquareOfAsterisks(int number)
    {
        Console.WriteLine($"Here is a square with side size {number}:");

        int rowLength = number;

        while (number > 0)
        {
            for (int row = rowLength; row > 0; --row)
            {
                Console.Write("*");
            }

            Console.WriteLine();
            --number;
        }
    }
}