// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 25 (08.30) Card Shuffling and Dealing

using System;

namespace CompareHands.Classes
{
    class DeckOfCardsTest
    {
        #region Constants

        private const int MaxNumberOfHands = 10;

        #endregion

        #region Public methods

        // Execute app.
        public static void Main()
        {
            Console.WriteLine("Wellcome to Card Dealing and rank comparing app.");
            // Allow user to choose the number of hands to be dealed and compared.
            int numberOfHandsToDeal = 0;
            Console.Write($"Please enter the number of hands to deal (1 to {MaxNumberOfHands}): ");
            numberOfHandsToDeal = int.Parse(Console.ReadLine());

            while (numberOfHandsToDeal <= 0
                || numberOfHandsToDeal > MaxNumberOfHands)
            {
                Console.WriteLine($"The number of hands should be between 1 and {MaxNumberOfHands}.");
                Console.Write($"Please enter the number of hands to deal (1 to {MaxNumberOfHands}): ");
                numberOfHandsToDeal = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("");
            // Create an object of "DeckOfCards" class and pass the number of hands to deal.
            var myDeckOfCards = new DeckOfCards();
            // Place Cards in random order.
            myDeckOfCards.Shuffle();
            // Deal given number of hands.
            myDeckOfCards.DealHands(numberOfHandsToDeal);
            // Display contents of all hands and their ranks.
            myDeckOfCards.PrintHands();
            // Display information about winner or winners.
            myDeckOfCards.PrintWinner();

            Console.WriteLine();
            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }

        #endregion
    }
}