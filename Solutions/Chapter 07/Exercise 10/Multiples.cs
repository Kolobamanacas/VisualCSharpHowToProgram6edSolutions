// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 10 (07.16) Multiples.

using System;

class Multiples
{
    static void Main()
    {
        Console.WriteLine("Wellcome to multiples checker.");
        Console.WriteLine("Enter two integer numbers to check whether the second number is a multiple of the first.");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;

        // Ask user for the next numbers pair until he/she answers "no" to the "ToProceed" question.
        while (toProceed)
        {
            /* Read two integers from a user. */
            Console.Write("Please enter the first number: ");
            int number1 = int.Parse(Console.ReadLine());
            Console.Write("Please enter the second number: ");
            int number2 = int.Parse(Console.ReadLine());

            /* Here we use compound string. The first and the third parts of string are the same, but the the second is added only when static method "Multiple()" returns "false". We use "!" operator to "invert" the value returned by "Multiple()". Normally it returns "true" if the second number is a multiple of the first one and "true" otherwise, but by reversing we literally say: "enter the if()'s body only when the second number is number is not multiple of the first one". */
            Console.Write($"The number {number2} is ");
            if (!Multiple(number1, number2))
            {
                Console.Write("not ");
            }
            Console.WriteLine($"a multiple of {number1}.");

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

    /* Expression-bodied method "Multiple()" takes two numbers of type integer as arguments and returns true if the second number is a multiple of the first. It also returns false otherwise. It uses the reminder operator, to determine the result. If one number is a multiple of another, the reminder after their division would always be 0. */
    static bool Multiple(int number1, int number2) => number2 % number1 == 0;
}