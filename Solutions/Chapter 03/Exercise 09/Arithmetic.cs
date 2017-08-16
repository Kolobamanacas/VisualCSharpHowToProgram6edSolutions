// Solution to exercises from "C# How to Program 6th edition".
// Chapter 3.
// Exercise 09 (03.15) Arithmetic.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class Arithmetic
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

        // Displaying sum, product, difference and quotient (division) of operand1 and operand2.
        Console.WriteLine($"The sum of {operand1} and {operand2} is {operand1 + operand2}");
        Console.WriteLine($"The product of {operand1} and {operand2} is {operand1 * operand2}");
        Console.WriteLine($"The difference of {operand1} and {operand2} is {operand1 - operand2}");
        Console.WriteLine($"The quotient of {operand1} and {operand2} is {operand1 / operand2}");
    } // Exit Main's method body.
} // Exit class body.