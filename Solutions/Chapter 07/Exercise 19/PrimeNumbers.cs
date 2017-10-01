// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 19 (07.25) Prime Numbers.

using System;

class PrimeNumbers
{
    static void Main()
    {
        // Local variable that counts number of prime number found.
        int primeCounter = 0;
        Console.WriteLine("There are all prime numbers from 1 t0 1000:");
        // For all numbers from 1 to 10000.
        for (int number = 1; number < 10000; ++number)
        {
            /* As soon as we need to call two almost identical methods and print a new line depending on their results, store these results in local variables to avoid second call of every method. */
            bool isPrimeSqrt = false;
            bool isPrimeHalf = false;

            // Call method "IsPrimeSqrt()" to check whether a number is prime.
            if (IsPrimeSqrt(number))
            {
                // If the number is prime, print it with two following spaces.
                Console.Write($"{number}  ");
                // Increment number of prime number found.
                ++primeCounter;
                isPrimeSqrt = true;
            }

            // Call method "IsPrimeHalf()" also to check whether a number is prime.
            if (IsPrimeHalf(number))
            {
                // If the number is prime, print it with two following spaces.
                Console.Write($"{number}  ");
                // Increment number of prime number found.
                ++primeCounter;
                isPrimeHalf = true;
            }

            // Every twenty numbers found print a newline character (just for the beauty).
            if (isPrimeSqrt || isPrimeHalf)
            {
                if (primeCounter % 20 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }

    /* Static method "IsPrimeSqrt()" takes one integer as an argument and returns true if the number is prime and false otherwise. */
    static bool IsPrimeSqrt(int number)
    {
        // Local variable that stores the result. Consider that given number is prime by default.
        bool isPrime = true;

        // Check all numbers from 2 to the square root of given number.
        for (int n = 2; n <= Math.Sqrt(number); ++n)
        {
            if (number % n == 0)
            {
                // If given number could be divided by n without reminder then it is not a prime number.
                // Set isPrime to "false".
                isPrime = false;
                // And break for loop to save some processor time and avoid unnecessary comparings.
                break;
            }
        }

        // Return the result.
        return isPrime;
    }

    /* This method is identical to "IsPrimeSqrt()". The only difference is that here we check all numbers up to (number / 2) instead of number's square root. */
    static bool IsPrimeHalf(int number)
    {
        // Local variable that stores the result. Consider that given number is prime by default.
        bool isPrime = true;

        // Check all numbers from 2 to the square root of given number.
        for (int n = 2; n <= (number / 2); ++n)
        {
            if (number % n == 0)
            {
                // If given number could be divided by n without reminder then it is not a prime number.
                // Set isPrime to "false".
                isPrime = false;
                // And break for loop to save some processor time and avoid unnecessary comparings.
                break;
            }
        }

        // Return the result.
        return isPrime;
    }
}