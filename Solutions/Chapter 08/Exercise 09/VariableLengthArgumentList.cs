// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 09 (08.14) Variable-Length Argument List.

using System;

class VariableLengthArgumentList
{
    static void Main()
    {
        // Print headers and call method "IntegersProduct" with different number of arguments.
        Console.WriteLine("Call to \"IntegersProduct\" with 0 arguments:\n"
            + $"{IntegersProduct()}");
        Console.WriteLine("Call to \"IntegersProduct\" with 2 arguments:\n"
            + $"4 * 7 = {IntegersProduct(4, 7)}");
        Console.WriteLine("Call to \"IntegersProduct\" with 5 arguments:\n"
            + $"4 * 7 * 1 * 0 * 12 = {IntegersProduct(4, 7, 1, 0, 12)}");
        Console.WriteLine("Call to \"IntegersProduct\" with 11 arguments:\n"
            + $"4 * 7 * 1 * 3 * 12 * 22 * 8 * 4 * 5 * 43 * 1 = {IntegersProduct(4, 7, 1, 3, 12, 22, 8, 4, 5, 43, 1)}");
    }

    /* Public static method "IntegersProduct" that takes non-fixed number of arguments as integers,
    then calculates and returns their product. */
    public static int IntegersProduct(params int[] numbers)
    {
        // If no arguments given, return 0;
        if (numbers.Length == 0)
        {
            return 0;
        }
        // In other cases, return the product of given numbers.
        else
        {
            // Local variable to store a product of all numbers given to the method as arguments.
            int product = 1;

            // For each of the value stored in the array "numbers" multiply the "product" local variable by this value.
            foreach (int value in numbers)
            {
                product *= value;
            }

            // Return resulting "product's" value.
            return product;
        }
    }
}