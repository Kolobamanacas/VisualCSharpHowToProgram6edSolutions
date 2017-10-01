// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 23 (07.29) Coin Tossing.

using System;

class CoinTossing
{
    private static Random randomNumbers = new Random();

    static void Main()
    {
        // Print wellcome message.
        Console.WriteLine("The app simulates a coin toss process.");
        // Local variables to store the number heads and tails results.
        int headsCount = 0;
        int tailsCount = 0;
        // Print current values for user to be sure that they are both equal to 0.
        Console.WriteLine($"The number of heads is: {headsCount}");
        Console.WriteLine($"The number of tails is: {tailsCount}");
        // Ask a user whether he/she wants to proceed.
        bool toProceed = ToProceed();

        // While user entering "yes" to the ToProceed question.
        while (toProceed)
        {
            if (Flip() == true)
            {
                // If "Flip()" returns true increment heads.
                ++headsCount;
            }
            else
            {
                // Otherwise increment tails.
                ++tailsCount;
            }
            
            // Print current values of "headsCount" and "tailsCount".
            Console.WriteLine($"The number of heads is: {headsCount}");
            Console.WriteLine($"The number of tails is: {tailsCount}");

            Console.WriteLine();
            // Ask a user whether he/she wants to toss another coin.
            toProceed = ToProceed();
        }
    }

    /* "ToProceed()" method asks a user whether he/she wants to toss another coin. If a user enters "yes" then the method returns the value of "true" and otherwise it returns "false". */
    static bool ToProceed()
    {
        Console.Write("Toss a coin one more time? (\"yes\" or \"no\"): ");
        string answer = Console.ReadLine();

        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write("Toss a coin one more time? (\"yes\" or \"no\"): ");
            answer = Console.ReadLine();
        }

        if (answer == "yes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // The method randomly returns "true" and "false".
    private static bool Flip()
    {
        // The method "Next()" of class "Random" called through it's object "randomNumbers" returns 0 or 1 randomly.
        if (randomNumbers.Next(2) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}