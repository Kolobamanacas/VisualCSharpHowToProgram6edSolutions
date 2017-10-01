// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 11 (07.17) Even or Odd.

using System;

class EvenOrOdd
{
    static void Main()
    {
        Console.WriteLine("The app checks whether the integer number is even or odd.");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;

        // Ask user for the next number until he/she answers "no" to the "ToProceed" question.
        while (toProceed)
        {
            // Read a number from a user and store it in local variable "number".
            Console.Write("Please enter an integer number: ");
            int number = int.Parse(Console.ReadLine());
            
            /* Execute static method "IsEven()" with "number" as parameter. If the "number" is even, the method would return "true" and an expression inside of "if()" statement's body would be executed. Otherwise an expression iside of "else" statement's body would be executed. */
            if (IsEven(number))
            {
                Console.WriteLine($"{number} is even.");
            }
            else
            {
                Console.WriteLine($"{number} is odd.");
            }

            Console.WriteLine();
            // Check whether a user wants to continue.
            toProceed = ToProceed();
        }
    }

    /* "ToProceed()" method asks a user whether he/she wants to enter additional number. If a user enters "yes" then the method returns the value of "true" and otherwise it returns "false". */
    static bool ToProceed()
    {
        Console.Write("Do you want to check the next number (\"yes\" or \"no\"): ");
        string answer = Console.ReadLine();

        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write("Do you want to check the next numbers (\"yes\" or \"no\"): ");
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

    /* Static expression-bodied method "IsEven()" takes one integer number as argument and returns "true" if this number is even, and false if it is odd. */
    static bool IsEven(int number) => (number % 2) == 0;
}