// Solution to exercises from "C# How to Program 6th edition".
// Chapter 3.
// Exercise 11 (03.17) Arithmetic, Smallest and Largest.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class ArithmeticSmallestLargest
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        // Declare variables of integer type to store three operands.
        int operand1;
        int operand2;
        int operand3;

        // Ask user to enter first operand.
        Console.Write("Please enter the first operand: ");
        // Get line of text from user's input, cast it to ineger type and assign the value to the variable operand1.
        operand1 = int.Parse(Console.ReadLine());
        // Ask user to enter second operand.
        Console.Write("Please enter the second operand: ");
        // Get line of text from user's input, cast it to ineger type and assign the value to the variable operand2.
        operand2 = int.Parse(Console.ReadLine());
        // Ask user to enter third operand.
        Console.Write("Please enter the third operand: ");
        // Get line of text from user's input, cast it to ineger type and assign the value to the variable operand3.
        operand3 = int.Parse(Console.ReadLine());

        /* Sum, avarage and product are easy ones as soon as we did something similar before. The only difference is changed number of operands. */

        // Write additional empty line for clearer output view.
        Console.WriteLine();

        // Display sum, avarage and product of operand1, operand2 and operand3.
        Console.WriteLine($"The sum of {operand1}, {operand2} and {operand3} is {operand1 + operand2 + operand3}.");
        Console.WriteLine($"The avarage of {operand1}, {operand2} and {operand3} is {(operand1 + operand2 + operand3) / 3}.");
        Console.WriteLine($"The product of {operand1}, {operand2} and {operand3} is {operand1 * operand2 * operand3}.");

        // Write additional empty line for clearer output view.
        Console.WriteLine();

        /* Again we are novices to programming and we unaware of logic operator AND. In that case the only way to find smallest and largest numbers I found is to use IF statements... inside of another IF statements. */

        // If the first operand is lagrer than second.
        if (operand1 > operand2)
        {
            // And the first operand is also larger than third, it means that it is the largest one.
            if (operand1 > operand3)
            {
                Console.WriteLine($"The largest number is {operand1}.");
            
                // And if operand2 is also less than operand3 it makes it the lowest one.
                if (operand2 < operand3)
                {
                    Console.WriteLine($"The lowest number is {operand2}.");
                }
                // But if operand3 is lower than operand2 then it is the lowest
                if (operand3 < operand2)
                {
                    Console.WriteLine($"The lowest number is {operand3}.");
                }
            } // If operand1 is not strict larger than operand3 then the whole inner IF block is ignored.
        } // If operand1 is not strict larger than operand2 then the whole IF block is ignored.

        // Use the same logic for all the rest possible cases.
        if (operand2 > operand1)
        {
            if (operand2 > operand3)
            {
                Console.WriteLine($"The largest number is {operand2}.");
            
                if (operand1 < operand3)
                {
                    Console.WriteLine($"The lowest number is {operand1}.");
                }
                if (operand3 < operand1)
                {
                    Console.WriteLine($"The lowest number is {operand3}.");
                }
            }
        }
        if (operand3 > operand1)
        {
            if (operand3 > operand2)
            {
                Console.WriteLine($"The largest number is {operand3}.");

                if (operand1 < operand2)
                {
                    Console.WriteLine($"The lowest number is {operand1}.");
                }
                if (operand2 < operand1)
                {
                    Console.WriteLine($"The lowest number is {operand2}.");
                }
            }
        }
        if (operand1 == operand2)
        {
            if (operand1 == operand3)
            {
                Console.WriteLine("All operands are equal.");
            }
            if (operand1 > operand3)
            {
                Console.WriteLine($"The largest number is {operand1}.");
                Console.WriteLine($"The lowest number is {operand3}.");
            }
            if (operand1 < operand3)
            {
                Console.WriteLine($"The lowest number is {operand1}.");
            }
        }
        if (operand1 == operand3)
        {
            if (operand1 > operand2)
            {
                Console.WriteLine($"The largest number is {operand1}.");
                Console.WriteLine($"The lowest number is {operand2}.");
            }
            if (operand1 < operand2)
            {
                Console.WriteLine($"The lowest number is {operand1}.");
            }
        }
        if (operand2 == operand3)
        {
            if (operand2 > operand1)
            {
                Console.WriteLine($"The largest number is {operand2}.");
                Console.WriteLine($"The lowest number is {operand1}.");
            }
            if (operand2 < operand1)
            {
                Console.WriteLine($"The lowest number is {operand2}.");
            }
        }

        /* This approach is very cumbersome and there definetly are simplier ways to solve largest and smallest numbers problem, but they require more language features which we still need to learn. For now we can just write the code as it is and try to check some possible number combinations by passing them through all the condition statements to understand how do they work. */
    } // Exit Main's method body.
} // Exit class body.