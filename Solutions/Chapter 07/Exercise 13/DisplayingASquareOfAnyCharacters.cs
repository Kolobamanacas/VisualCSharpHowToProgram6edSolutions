// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 13 (07.19) Displaying a Square of Any Characters.

using System;

class DisplayingASquareOfAnyCharacters
{
    static void Main()
    {
        Console.WriteLine("The app prints a square of given characters with given side length.");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;

        // Ask user for the next square size and fill character until he/she answers "no" to the "ToProceed" question.
        while (toProceed)
        {
            // Ask a user to enter a number.
            Console.Write("Please enter the size of a square: ");
            int number = int.Parse(Console.ReadLine());
            // Ask a user to enter a fill character.
            Console.Write("Please enter a character to print a square with: ");
            char fillCharacter = char.Parse(Console.ReadLine());
            /* Call a static method "SquareOfGivenCharacters()" with "number" as mandatory argument and "fillCharacter" as optional. */
            SquareOfGivenCharacters(number, fillCharacter);

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

    /* Static method "SquareOfGivenCharacters()" takes one integer number and one char as arguments and use the number to print a square of given characters with every side equals to the given number. The method doesn't return any value as it's return type is void. */
    static void SquareOfGivenCharacters(int number, char fillCharacter = '*')
    {
        Console.WriteLine($"Here is a square with side size {number}:");

        int rowLength = number;

        while (number > 0)
        {
            for (int row = rowLength; row > 0; --row)
            {
                Console.Write(fillCharacter);
            }

            Console.WriteLine();
            --number;
        }
    }
}