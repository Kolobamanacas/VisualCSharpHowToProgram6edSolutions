// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 10(03) (05.19) Sales-Commission Calculator.

using System;
// Add System.Globalization namespace to be able to use CultureInfo class.
using System.Globalization;

class SalesCommissionCalculator
{
    static void Main()
    {
        // Declare local variables.
        int grossSales = 0;
        int fixedSalary = 200;
        // Create new object of class CultureInfo.
        CultureInfo enUS = new CultureInfo("en-US");
        
        // Write a welcome message.
        Console.WriteLine("Sales-Commission Calculator.");
        
        Console.WriteLine();
        
        // Read a price for the first item sold (could be a sentinel).
        Console.Write("Please enter a sold price of the first item (-1 to exit): ");
        int price = int.Parse(Console.ReadLine(), enUS);
        
        // If the price is a sentinel value, print corresponding message.
        if (price == -1)
        {
            Console.WriteLine("No information was provided.");
        }
        
        // While price is not equal to the sentinel value.
        while (price != -1)
        {
            // Add the price of an item to gross sales of a salesman.
            grossSales += price;
            
            // Read a price for the next item sold (could be a sentinel).
            Console.Write("Please enter a sold price of the next item (-1 to exit): ");
            price = int.Parse(Console.ReadLine(), enUS);
            
            // If no more prices were provided (a sentinel value was entered), print salesperson's earnings.
            if (price == -1)
            {
                Console.WriteLine($"Salesperson's earnings are: {(fixedSalary + (grossSales * 0.09)):F}");
            }
        }
        
        // Print a farewell message.
        Console.WriteLine("Sentinel value (-1) is entered. Program is terminated.");
    }
}