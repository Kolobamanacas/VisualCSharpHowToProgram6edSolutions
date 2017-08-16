// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Exercise 19 (03.25) Multiples.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class IsMultiples
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        // Declare and inicialize variables of integer type to store numbers user would input in computer's memory.
        int number1 = 0;
        int number2 = 0;

        // Ask user to enter the first number.
        Console.Write("Please enter the first number: ");
        // Get a line of text from user's input, cast it to integer type and assign the value to the variable number1.
        number1 = int.Parse(Console.ReadLine());
        // Ask user to enter the second number.
        Console.Write("Please enter the second number: ");
        // Get a line of text from user's input, cast it to integer type and assign the value to the variable number2.
        number2 = int.Parse(Console.ReadLine());

        // If number1 is multiple of number2 then a reminder after division of number1 by number2 would be always equal to 0.
        if (number1 % number2 == 0)
        {
            Console.WriteLine($"{number1} is multiple of {number2}.");
        }
        // Else if a reminder after division of number1 by number2 is not equal to 0 then number1 is not multiple of number2.
        if (number1 % number2 != 0)
        {
            Console.WriteLine($"{number1} is not multiple of {number2}");
        }
    }
}