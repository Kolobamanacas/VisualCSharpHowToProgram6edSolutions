// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 12 (08.17) Dice Rolling.

using System;

class DiceRolling
{
    // Private static field which holds an object of class Random to be used for random number generation.
    private static Random randomNumbers = new Random();
    
    static void Main()
    {
        // Constant local variable of type int to store number of elements in the following "sumValuesCount" array.
        const int numberOfElements = 11;
        /* A local variable for one dimentional array that would store the same number of int elements as "numberOfElements" stores.
        All possible values of a sum of two dices (2 to 12) could be stored in cells with indeces from 0 to 10 if subtracted by 2. So we would store results for sum result "2" into a cell with index "0", reulst "3" in a cell with index "1" and so on until result "12" in cell with index "10". */
        int[] sumValuesCount = new int[numberOfElements];

        // For 36000 times.
        for (int counter = 0; counter < 36000; ++counter)
        {
            /* Call a "RandomInteger()" method to get a random integer as a result, then sum it with a result returned by the same method call and then subtract "2" from the sum to get an index number, which in turn is used to determine an index of a position of a value in the "sumValuesCount" array to increment. */
            ++sumValuesCount[(RandomInteger() + RandomInteger()) - 2];
        }
        
        // Print a header for the resulting statistic table.
        Console.WriteLine($"Sum   Frequency");

        // For the number of elements in the "sumValuesCount" array times (i.e. for 11 times).
        for (int index = 0; index < sumValuesCount.Length; ++index)
        {
            /* Print all possible values in the first column, and the number of appropriate results got from a sum of two dice rolls in the second. */
            Console.WriteLine($"{index + 2, 3}   {sumValuesCount[index], 9}");
        }
    }

    // Static public method that takes no arguments and returns random number from 2 to 12 inclusive.
    public static int RandomInteger() => randomNumbers.Next(1, 7);
}