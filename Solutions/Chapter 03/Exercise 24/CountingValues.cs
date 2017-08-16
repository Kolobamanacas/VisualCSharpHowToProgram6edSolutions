// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Exercise 24 (03.30) Counting Negative, Positive and Zero values.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class CountingValues
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        /* The spicification didn't say that we need to store input numbers somewhere. That means that all we need to store in memory is result numbers of values of every type. */
        
        // Create three variables of integer type to store results and one variable to temporary store an input value.
        int negativeValues;
        int positiveValues;
        int zeroValues;
        int input;
        
        // Ask user to input first number.
        Console.Write("Please enter the first value: ");
        // Write a value input by user to the input variable.
        input = int.Parse(Console.ReadLine());
        
        /* Consider three possible results: an input value could be negative, positive or zero. Depending on the result we would add 1 to appropriate value counter variable. */
        if (input < 0)
        {
            negativeValues = negativeValues + 1;
        }
        if (input > 0)
        {
            positiveValues = positiveValues + 1;
        }
        if (input == 0)
        {
            zeroValues = zeroValues + 1;
        }
        
        /* Repeat message, input and assigning steps four more times to get total statistic for 5 numbers. Notice that assigning a new value to the input variable replaces its previous value. */
        Console.Write("Please enter the second value: ");
        
        input = int.Parse(Console.ReadLine());
        
        if (input < 0)
        {
            negativeValues = negativeValues + 1;
        }
        if (input > 0)
        {
            positiveValues = positiveValues + 1;
        }
        if (input == 0)
        {
            zeroValues = zeroValues + 1;
        }
        
        Console.Write("Please enter the third value: ");
        
        input = int.Parse(Console.ReadLine());
        
        if (input < 0)
        {
            negativeValues = negativeValues + 1;
        }
        if (input > 0)
        {
            positiveValues = positiveValues + 1;
        }
        if (input == 0)
        {
            zeroValues = zeroValues + 1;
        }
        
        Console.Write("Please enter the fourth value: ");
        
        input = int.Parse(Console.ReadLine());
        
        if (input < 0)
        {
            negativeValues = negativeValues + 1;
        }
        if (input > 0)
        {
            positiveValues = positiveValues + 1;
        }
        if (input == 0)
        {
            zeroValues = zeroValues + 1;
        }
        
        Console.Write("Please enter the fifth value: ");
        
        input = int.Parse(Console.ReadLine());
        
        if (input < 0)
        {
            negativeValues = negativeValues + 1;
        }
        if (input > 0)
        {
            positiveValues = positiveValues + 1;
        }
        if (input == 0)
        {
            zeroValues = zeroValues + 1;
        }
        
        // Write additional empty line for clearer output view.
        Console.WriteLine();
        
        // We are ready do display resulting statistic.
        Console.WriteLine($"The number of negative numbers is {negativeValues}.");
        Console.WriteLine($"The number of positive numbers is {positiveValues}.");
        Console.WriteLine($"The number of numbers equals to zero is {zeroValues}.");
        
    } // Exit Main's method body.
} // Exit class body.