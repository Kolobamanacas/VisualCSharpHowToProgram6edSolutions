// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 07 (08.12) Duplicates Elimination.

using System;

class DuplicatesElimination
{
    static void Main()
    {
        // Print a wellcome message.
        Console.WriteLine("The app reads 5 numbers, then stores and prints unique values from the input.");
        // Declare an array of integers containing 5 elements with indices from 0 to 4 with array-creation expression.
        int[] numbers = new int[5];
        // Local integer variable "nextUniqueValueIndex" to store an index of a next place to write an unique value.
        int nextUniqueValueIndex = 0;
        // Local integer variable to temporary store a number got from a user.
        int inputNumber = 0;

        // We need to read totaly 5 values. So the outermost "for" loop is executed 5 times, one for every number got from a user.
        for (int numberCount = 0; numberCount < 5; ++numberCount)
        {
            // Read a number from a user. Make sure that the number is in appropraiate range (from 10 to 100 inclusive).
            do
            {
                // Print a prompt message.
                Console.Write("Enter the next number (10 to 100 inclusive): ");
                // Write a number entered by a user to the local variable "inputNumber".
                inputNumber = int.Parse(Console.ReadLine());

                // If a number entered by a user is not in the appropriate range, print a warinig message.
                if (inputNumber < 10 || inputNumber > 100)
                {
                    Console.WriteLine("The number should be more or equal to 10 and less or equal to 100.");
                }
            } while (inputNumber < 10 || inputNumber > 100);

            /* For savig CPU time compare new number not to all elements of an array but to a number of unique elements, using "nextUniqueValueIndex" variable in continuation test condition. */
            for (int index = 0; index <= nextUniqueValueIndex; ++index)
            {
                if (numbers[index] == inputNumber)
                {
                    // If a number got from a user equals to a number from an array, immediately brake, i.e. exit the "for" loop.
                    break;
                }
                else if (index == nextUniqueValueIndex)
                {
                    /* We get here only when "inputNumber" is not equal to any value from an array and when "index" equals to the "nextUniqueValueIndex", that is the index of a "place" in the array to store new unique value. When that's the case, write "inputNumber" to the array with it's index eqauls to "index". */
                    numbers[index] = inputNumber;
                    // Increment the value of "nextUniqueValueIndex" to know that there is one more unique number in the array.
                    ++nextUniqueValueIndex;
                    /* Without a break the incrementing of "nextUniqueValueIndex" would lead to the infinte loop as it used in loop continuation test expression. So we put a break here, meanin that the new unique value was witten to the last free place of the array and there is no need in any other loop. */
                    break;
                }
            }

            // Print a header of array's values output.
            Console.WriteLine("Current values in \"Numbers\" array:");

            /* Print all unique numbers in the array. We use "nextUniqueValueIndex" to get the index of the next place in the array right after the last unique value. This allows us to print only unique values and all the values of the array. The other way to implement this output is to use foreach statement and print a value only when it is not equal to "0", i.e. the default value. */
            for (int index = 0; index < nextUniqueValueIndex; ++index)
            {
                // Print a value with a given index from the array.
                Console.Write($"{numbers[index]}  ");
            }

            // Print a new line chracter.
            Console.WriteLine();
        }
    }
}