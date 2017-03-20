// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 12(05) (05.21) Find the Largest Number.

using System;

class FindTheLargestNumber
{
    static void Main()
    {
        // Print a welcome message.
        Console.WriteLine("The largest number finder.");
        Console.WriteLine();
        
        // Initialize variables.
        int counter = 1;
        int number = 0;
        int largest = 0;
        
        // Read the first number and write it as the largest one.
        Console.Write("Please enter the first number: ");
        largest = int.Parse(Console.ReadLine());
        
        // For nine times or while counter is less than or equal to 9.
        while (counter <= 9)
        {
            // Read the next number from a user.
            Console.Write("Please enter the next number: ");
            number = int.Parse(Console.ReadLine());
            
            /* If the number is larger than the current largest number - set this number as the new largest one. This will eventually leave the largest number in the "largest" local variable. */
            if (number > largest)
            {
                largest = number;
            }
            
            // Increment counter by one.
            ++counter;
        }
        
        // Print the largest number and farewell message.
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine();
        
        Console.WriteLine("Program is terminated.");
    }
}