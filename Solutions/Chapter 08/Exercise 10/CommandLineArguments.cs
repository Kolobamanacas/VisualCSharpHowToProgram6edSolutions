// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 10 (08.15) Command-Line Arguments.

using System;

class CommandLineArguments
{
    static void Main(string[] args)
    {
        /* Initialize local variable arraySize with number provided as command-line argument, or with 10 in no arguments were provided. */
        int arraySize = args.Length != 0
            ? int.Parse(args[0])
            : 10;

        // Create the space for array and initialize to default zeros.
        // Array contains the same number of int elements as the value of "arraySize".
        int[] array = new int[arraySize];

        // Headings.
        Console.WriteLine($"{"Index"}{"Value",8}");

        // Output each array element's value.
        for (int counter = 0; counter < array.Length; ++counter)
        {
            Console.WriteLine($"{counter,5}{array[counter],8}");
        }
    }
}