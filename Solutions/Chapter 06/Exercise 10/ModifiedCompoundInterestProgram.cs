// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 10 (06.14) Modified Compound-Interest Program.

/* The task is to modify the app so instead of one table for 5% rate, get six tables for rates from 5% to 10%. This could be done with wrapping almost the whole app with for statement's body, and initialize rate inside of for's header and use it as a control variable instead of initializing it within body of the Main method. I also add regional settings parameter to make sure to get output numbers in appropriate format. */

using System;
using System.Globalization;

class Interest
{
    static void Main()
    {
        // An object of CultureInfo class to store regional settings. We need it to make dot a decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");

        // Initial amount before interest.
        decimal principal = 1000;

        // Interest rate is initialized within a for statement.
        for (double rate = 0.05; rate <= 0.10; rate += 0.01)
        {
            // Display headers.
            Console.WriteLine($"Table for rate = {rate.ToString(cultureEnUs)}");
            Console.WriteLine("Year   Amount on deposit");

            // Calculate amount on deposit for each of ten years.
            for (int year = 1; year <= 10; ++year)
            {
                // Calculate new amount for specified year.
                decimal amount = principal * ((decimal)Math.Pow(1.0 + rate, year));

                /* Display the year and the amount, taking regional settings into account. ToString method takes two arguments, both of which tell it how to format the resulting text. "C" - tells that output text is currency and cultureEnUs tells that US regional settings should be used. */
                Console.WriteLine($"{year,4}{((amount).ToString("C", cultureEnUs)),20}");
            }

            // Add additional empty line after every table.
            Console.WriteLine();
        }
    }
}