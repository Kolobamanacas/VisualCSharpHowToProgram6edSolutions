// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Exercise 18 (03.24) Odd or Even.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class OddOrEven
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        // Declare variable of integer type to store the number user would input in computer's memory.
        int number;

        // Ask user to enter a number.
        Console.Write("Please enter a number to find out whether it odd or even: ");
        // Get line of text from user's input, cast it to ineger type and assign the value to the variable number.
        number = int.Parse(Console.ReadLine());

        // Write additional empty line for clearer output view.
        Console.WriteLine();

        /* Any odd integer will always leave a reminder after its division by 2. For example if one performs an integer division and wants to get an integer result after division the expression 7 / 2 will return 3 because 6 / 2 = 3. But we have number 1 as an integer reminder of the 7 / 2 expression. One can't get integer result of 1 / 2 expression. That is how reminder operator works. It determines the reminder after one number is devided by another. So 7 % 2 will return 1 because the reminder after integer division of 7 by 2 is 1. 7 % 2 = 1.
        Contrwise, any even number will always return 0 as a reminder of division by 2. These features help easily determine whether any number is odd or even. */

        // If the reminder of a number devided by 2 is not equal to 0 then this number is odd.
        if (number % 2 != 0)
        {
            Console.WriteLine($"The number {number} is odd.");
        }
        // Else if the reminder of a number devided by 2 is equal to 0 then this number is even.
        if (number % 2 == 0)
        {
            Console.WriteLine($"The number {number} is even.");
        }
    } // Exit Main's method body.
} // Exit class body.