// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 12 (06.16) Displaying a Bar Chart.

using System;

class BarCharts
{
    static void Main()
    {
        // Print a wellcome message.
        Console.WriteLine("The bar chart printer.");
        
        // Three variables of type int to store numbers. Bar charts would be printed using them.
        int number1 = 0;
        int number2 = 0;
        int number3 = 0;

        // While a user doesn't enter the right number (from 1 to 30) continue to prompt him to enter it correctly.
        Console.Write("Please enter the first number (from 1 to 30): ");
        do
        {
            number1 = int.Parse(Console.ReadLine());

            if (number1 <= 0 || number1 > 30)
            {
                Console.Write("The number you've entered is not in 1 to 30 range. Please enter the valid number: ");
            }
        } while (number1 <= 0 || number1 > 30);

        Console.Write("Please enter the second number (from 1 to 30): ");
        do
        {
            number2 = int.Parse(Console.ReadLine());

            if (number2 <= 0 || number2 > 30)
            {
                Console.Write("The number you've entered is not in 1 to 30 range. Please enter the valid number: ");
            }
        } while (number2 <= 0 || number2 > 30);

        Console.Write("Please enter the third number (from 1 to 30): ");
        do
        {
            number3 = int.Parse(Console.ReadLine());

            if (number3 <= 0 || number3 > 30)
            {
                Console.Write("The number you've entered is not in 1 to 30 range. Please enter the valid number: ");
            }
        } while (number3 <= 0 || number3 > 30);

        Console.WriteLine();

        /* Use the values held in the variables as loop continuation condition
        and for every number print the same number of asterisks as a variable holds. */

        Console.WriteLine("Bar charts for numbers:");
        Console.Write("1: ");
        for (int bar = 1; bar <= number1; ++bar)
        {
            Console.Write("*");
        }
        Console.WriteLine();
        Console.Write("2: ");
        for (int bar = 1; bar <= number2; ++bar)
        {
            Console.Write("*");
        }
        Console.WriteLine();
        Console.Write("3: ");
        for (int bar = 1; bar <= number3; ++bar)
        {
            Console.Write("*");
        }
    }
}