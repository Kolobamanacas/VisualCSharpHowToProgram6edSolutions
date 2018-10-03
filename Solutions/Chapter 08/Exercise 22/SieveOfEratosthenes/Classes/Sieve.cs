// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 22 (08.27) Sieve of Eratosthenes.

/* As we go further in developing we use more and more fatures of C#. Here we start to use namespaces. It is a convinient tool to organize
 * your code. You can read about namespaces using following links:
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/namespace
 * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/namespaces/using-namespaces */

using System;

namespace SieveOfEratosthenes.Classes
{
    class Sieve
    {
        #region Private fields

        // An array used to eventually store "true" for indexes of prime numbers and "false" for all the rest.
        private static bool[] numbers;

        #endregion

        #region Private methods

        /// <summary>
        /// Marks false all positions in "numbers[]" array which index number is composed of given parameter integer.
        /// </summary>
        private static void MarkFollowingCompositeNumbers(int number)
        {
            int factor = 2;

            while (number * factor < numbers.Length)
            {
                numbers[number * factor] = false;
                ++factor;
            }
        }

        #endregion

        #region Public methods

        public static void Main()
        {
            // Print wellcome information and get the number upper bound from a user.
            Console.WriteLine("Wellcome to Sieve of Eratosthenes app.");
            Console.WriteLine("The app prints all prime numbers in range from 2 to the number you choose.");
            Console.Write("Please enter the upper bound for a range (a number between 3 and 2 000 000 000): ");
            int upperLimit = int.Parse(Console.ReadLine());

            while (upperLimit <= 2 || upperLimit > 2000000000)
            {
                Console.WriteLine("The number should be more than 2 and less than 2 000 000 000.");
                Console.Write("Please enter the upper bound for a range: ");
                upperLimit = int.Parse(Console.ReadLine());
            }

            // Initialize the array with a number, provided by a user + 1 to have, for example 3 as the last index if user has entered 3.
            numbers = new bool[upperLimit + 1];

            // Initialize all values in the array to true;
            for (int number = 0; number < numbers.Length; ++number)
            {
                numbers[number] = true;
            }

            // Counter used to store number of found prime numbers, which is used to add newline character every 10 prime numbers found.
            int primeNumbersFound = 0;
            Console.WriteLine();
            Console.WriteLine($"Here are all prime numbers in range from 0 to {upperLimit}:");

            // Check all indexes of "numbers[]" and for all indexes which value in the arrays is true
            // call "MarkFollowingCompositeNumbers()" method.
            for (int number = 2; number < numbers.Length; ++number)
            {
                if (numbers[number] == true)
                {
                    MarkFollowingCompositeNumbers(number);
                    ++primeNumbersFound;

                    // This section looks cumbersome, but it helps keep the output a bit more adjusted.
                    if (number < 10)
                    {
                        Console.Write("        ");
                    }
                    else if (number < 100)
                    {
                        Console.Write("       ");
                    }
                    else if (number < 1000)
                    {
                        Console.Write("      ");
                    }
                    else if (number < 10000)
                    {
                        Console.Write("     ");
                    }
                    else if (number < 100000)
                    {
                        Console.Write("    ");
                    }
                    else if (number < 1000000)
                    {
                        Console.Write("   ");
                    }
                    else if (number < 10000000)
                    {
                        Console.Write("  ");
                    }
                    else if (number < 100000000)
                    {
                        Console.Write(" ");
                    }

                    // Print a prime number itsefl.
                    Console.Write($"  {number}");

                    if (primeNumbersFound % 10 == 0)
                    {
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }

        #endregion
    }
}
