// Solution to exercises from "C# How to Program 6th edition".
// Chapter 05.
// Exercise 09(02) (05.18) Credit-Limit Calculator.

using System;

class CreditLimitCalculator
{
    static void Main()
    {
        // Welcome message.
        Console.WriteLine("Credit-limit calculator.");
        
        Console.WriteLine();
        Console.WriteLine();
        
        // Read an account number of the first customer (could be a sentinel).
        Console.Write("Please enter an account number for the first customer (-1 to exit): ");
        int accountNumber = int.Parse(Console.ReadLine());
        
        // If entered value is a sentinel, print corresponding messege.
        if (accountNumber == -1)
        {
            Console.WriteLine("No information was provided.");
        }
        
        // While user enters correct account numbers.
        while (accountNumber != -1)
        {
            // Read begginig balance.
            Console.Write("Please enter the balance at the beginning of the month: ");
            int beginningBalance = int.Parse(Console.ReadLine());
            
            // Read charges for current customer for current month.
            Console.Write("Please enter the amount of money charged for items this month: ");
            int charges = int.Parse(Console.ReadLine());
            
            // Read credits for current customer for current month.
            Console.Write("Please enter the amount of money lended as credits this month: ");
            int credits = int.Parse(Console.ReadLine());
            
            // Read a credit limit for current customer for current month.
            Console.Write("Please enter a credit limit for the account: ");
            int creditLimit = int.Parse(Console.ReadLine());
            
            // Print the new balance using given formula.
            Console.WriteLine($"The new balance is: {beginningBalance + charges - credits}");
            
            // If the credit limit is exceeded, print corresponding message.
            if ((beginningBalance + charges - credits) < creditLimit)
            {
                Console.WriteLine("Credit limit exceeded.");
            }
            
            Console.WriteLine();
            Console.WriteLine();
            
            // Read an account number of the next customer (could be a sentinel).
            Console.Write("Please enter an account number for the next customer (-1 to exit): ");
            accountNumber = int.Parse(Console.ReadLine());
        }
        
        // Print a farewell message.
        Console.WriteLine("Sentinel value (-1) is entered. Program is terminated.");
    }
}