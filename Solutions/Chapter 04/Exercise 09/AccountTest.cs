// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Exercise 09 (04.13) Removing Duplicated Code in Method Main.

using System;
using System.Globalization;

class AccountTest
{
    static void Main()
    {
        Account account1 = new Account("Jane Green", 50.00m);
        Account account2 = new Account("John Blue", -7.53m);
        
        // Again I want the dot to be a decimal mark, so I create an object of class CultureInfo that would contain en-US regional settings.
        CultureInfo cultureEnUs = new CultureInfo("en-US");
        
        // I also don't want to have a headache with possible encoding issues so I set system encoding as UTF-8.
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Display initial balance of each object
        DisplayAccount(account1, cultureEnUs);
        DisplayAccount(account2, cultureEnUs);

        // prompt for then read input
        Console.Write("\nEnter deposit amount for account1: "); 
        decimal depositAmount = decimal.Parse(Console.ReadLine());
        Console.WriteLine(
            $"adding {depositAmount:C} to account1 balance\n");
        account1.Deposit(depositAmount); // add to account1's balance

        // display balances
        DisplayAccount(account1, cultureEnUs);
        DisplayAccount(account2, cultureEnUs);

        // prompt for then read input
        Console.Write("\nEnter deposit amount for account2: ");
        depositAmount = decimal.Parse(Console.ReadLine());
        Console.WriteLine(
            $"adding {depositAmount:C} to account2 balance\n");
        account2.Deposit(depositAmount); // add to account2's balance

        // display balances
        DisplayAccount(account1, cultureEnUs);
        DisplayAccount(account2, cultureEnUs);
    }

    /* Create a method that would display a balance of an object. An object passed to the method during method call works like a parameter. Depending on object passed the method would display different balances. We also pass regional settings object so the method would know how exaclty print balances. */
    static void DisplayAccount(Account accountToDisplay, CultureInfo cultureToUse)
    {
        Console.WriteLine($"{accountToDisplay.Name}'s balance: {(accountToDisplay.Balance).ToString("c", cultureToUse)}");
    }
}

