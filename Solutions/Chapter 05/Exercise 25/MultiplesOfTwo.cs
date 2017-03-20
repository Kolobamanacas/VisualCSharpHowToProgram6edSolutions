// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 25(18) (05.34) Multiples of 2.

using System;

class MultiplesOfTwo
{
    static void Main()
    {
        // Number to use as a base.
        int number = 1;
        // A counter for a loop.
        int counter = 1;
        
        // For 40 times.
        while (counter <= 40)
        {
            // Multiply number by 2.
            number *= 2;
            // Print the new number.
            Console.Write($"{number}, ");
            
            ++counter;
        }
        
        /* The output looks like the following:
        2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456, 536870912, 1073741824, -2147483648, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        
        This is happening because during the multiplying the "number" by 2 the "number's" value overflows the maximum possible number of the C# int type can hold, i.e. the largest number you can represent with 32 bits. */
    }
}