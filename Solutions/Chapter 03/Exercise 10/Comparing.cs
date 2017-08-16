// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Exercise 10 (03.16) Comparing Integers.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class Comparing
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        // Declare variables of integer type to store two operands.
        int operand1;
        int operand2;

        // Ask user to enter first operand.
        Console.Write("Please enter the first operand: ");
        // Get line of text from user's input, cast it to ineger type and assign the value to the variable operand1.
        operand1 = int.Parse(Console.ReadLine());
        // Ask user to enter second operand.
        Console.Write("Please enter the second operand: ");
        // Get line of text from user's input, cast it to ineger type and assign the value to the variable operand2.
        operand2 = int.Parse(Console.ReadLine());

        /* I asume that we are completely new to programming and "C# How to Program 6th edition" is the first textbook we saw about programming and as soon as we don't know about IF-ELSE construction yet, we need to use three different IF statements to accomplish the task. */

        /* We are comparing operands 1 and 2. If operand1's value stored in memory is larger than value of operand2, then statements in the immediately following curly braces execute. In this case we are printing message on a screen. If operand1 is lower than operand2 or if they are equal, the whole part of code inside the following curly braces is ignored. */
        if (operand1 > operand2)
        {
            Console.WriteLine($"{operand1} is larger.");
        }
        /* If operand1 is lower than operand2 - print corresponding message on a screen. Otherwise ignore all the code inside the following curly braces. */
        if (operand1 < operand2)
        {
            Console.WriteLine($"{operand2} is larger.");
        }
        /* If numbers are equal - print corresponding message on a screen. Otherwise ignore all the code inside the following curly braces. */
        if (operand1 == operand2)
        {
            Console.WriteLine("These numbers are equal.");
        }
    } // Exit Main's method body.
} // Exit class body.