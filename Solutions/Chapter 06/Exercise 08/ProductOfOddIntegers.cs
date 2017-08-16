// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 08 (06.12) Product of Odd Integers.

using System;

class ProductOfOddIntegers
{
    static void Main()
    {
        // Initialize a local variable for the resulting product.
        int product = 1;

        // Multiple 1 by 3 by 5 and 7 and write the result to product local variable.
        for (int number = 1; number <= 7; number += 2)
        {
            product *= number;
        }

        // Print the resulting product.
        Console.WriteLine($"The product of odd integers from 1 to 7 is: {product}");
    }
}