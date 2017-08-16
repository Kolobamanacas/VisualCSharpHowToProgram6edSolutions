// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 14 (06.18) Modified Compound-Interest Program.

/* The simple task to replace all data types with intergers for some reason took me a couple of hours of thinkig with no success. I've tried to consider the task literaly, which means to use integers everyware, including replacing "rate's" type with int. Unfortunately this approach didn't work as soon as 105 in a power of 10 results in int (and even double) capacity overflow. I decide to leave "rate" as double for now, but I will think it of in the future and probably would find the appropriate solution. */

using System;

class CompoundInterestWithIntegers
{
    static void Main()
    {
        // Initial amount before interest in cents instead of dollars.
        int principal = 100000;
        // Interest rate.
        double rate = 0.05;

        // Display headers.
        Console.WriteLine("Year   Amount on deposit");

        // Calculate amount on deposit for each of ten years.
        for (int year = 1; year <= 10; ++year)
        {
            // Calculate new amount for specified year using int for amount.
            int amount = (int)(principal * (Math.Pow(1 + rate, year)));

            /* I also didn't find a better way to display resulting amount with appropriate aligning, currency and decimal mark than to store it in a separate string variable. */
            string amountString = "$" + (amount / 100).ToString() + "." + (amount % 100).ToString("D2");

            // Display the year and the amount.
            Console.WriteLine($"{year, 4}{amountString, 20}");
        }
    }
}