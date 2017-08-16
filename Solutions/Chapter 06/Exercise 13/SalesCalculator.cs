// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 13 (06.17) Calculating Sales.

using System;
using System.Globalization;

class SalesCalculator
{
    static void Main()
    {
        // An object of CultureInfo class to store regional settings. We need it to make dot a decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");

        // Wellcome messages and products info.
        Console.WriteLine("Total Sales Calculator.");
        Console.WriteLine("List of Product Prices:");
        Console.WriteLine("Product 1: $2.98");
        Console.WriteLine("Product 2: $4.50");
        Console.WriteLine("Product 3: $9.98");
        Console.WriteLine("Please enter a list of pairs of product number and quantity sold. Enter \"0\" for product number to finish.");
        Console.Write("Enter the first product number: ");

        // Decimal variables to store total retail value of all products sold.
        decimal product1Sold = 0;
        decimal product2Sold = 0;
        decimal product3Sold = 0;
        // Integer variable to tomporary store user's input.
        int productNumber = int.Parse(Console.ReadLine());

        /* The outermost while loop uses a "productNumber" as a sentinel-control value.
        A looping process ends as soon as "productNumber" become equal to 0. */
        while (productNumber != 0)
        {
            // This inner loop is a fool-proofing part. It prevents a user from inputing any value except 1, 2 or 3.
            while (productNumber < 1 || productNumber > 3)
            {
                Console.WriteLine("The product number could be 1, 2 or 3.");
                Console.Write("Please enter correct product number: ");
                productNumber = int.Parse(Console.ReadLine());
            }

            // Prompt user to enter the quantity.
            Console.Write("Enter the product quantity sold: ");
            int soldQuantity = int.Parse(Console.ReadLine());

            // This inner loop is also a fool-proofing mechanism. It prevents a user from inputing any value less than 1.
            while (soldQuantity < 1)
            {
                Console.WriteLine("The quantity should be a positive number greater than 0.");
                Console.Write("Please enter correct quantity: ");
                soldQuantity = int.Parse(Console.ReadLine());
            }

            /* Depending on a number a user has entered (1, 2 or 3) an appropriate total retail value variable would be updated. As soon as these variables are decimal type, we need to cast resulting calculations to decimal before adding them to these variables. */
            switch (productNumber)
            {
                case 1:
                    product1Sold += (decimal)(soldQuantity * 2.98);
                    break;
                case 2:
                    product2Sold += (decimal)(soldQuantity * 4.50);
                    break;
                case 3:
                    product3Sold += (decimal)(soldQuantity * 9.98);
                    break;
                default:
                    break;
            }

            Console.Write("Enter the next product number (\"0\" to end input): ");
            productNumber = int.Parse(Console.ReadLine());
        }
        
        Console.WriteLine();
        /* Display the statistics for all products sold. ToString method takes two arguments, both of which tell it how to format the resulting text. "C" - tells that output text is currency and cultureEnUs tells that US regional settings should be used. Number 10 after a value, converted to a string is used to indent these values to the right. */
        Console.WriteLine("Total retail value of all products sold:");
        Console.WriteLine($"Product 1: {((product1Sold).ToString("C", cultureEnUs)), 10}");
        Console.WriteLine($"Product 2: {((product2Sold).ToString("C", cultureEnUs)), 10}");
        Console.WriteLine($"Product 3: {((product3Sold).ToString("C", cultureEnUs)), 10}");
    }
}