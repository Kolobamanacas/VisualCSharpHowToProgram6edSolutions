// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 25 (08.30) Card Shuffling and Dealing

using System;
// Add this to be able to use "Dictionary". See comments below.
using System.Collections.Generic;

namespace CompareHands.Classes
{
    class DeckOfCards
    {
        #region Constants

        private const int NumberOfCardsInDeck = 52;
        private const int NumberOfCardsInHand = 5;
        // "Faces" and "Suits" arrays are changed to readonly fields to be able to check whether a "hand" have a straight combination.
        public static readonly string[] Faces = new string[]
            { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        public static readonly string[] Suits = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };

        #endregion

        #region Private fields

        // Create one Random object to share among DeckOfCards objects.
        private static Random randomNumbers = new Random();
        private Card[] deck = new Card[NumberOfCardsInDeck];
        // An arrays with all dealed hands.
        private Hand[] hands;

        #endregion

        #region Constructors

        // Constructor fills deck of Cards.
        public DeckOfCards()
        {
            // Populate deck with Card objects.
            for (var count = 0; count < deck.Length; ++count)
            {
                deck[count] = new Card(Faces[count % 13], Suits[count / 13]);
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Shuffle deck of Cards with one-pass algorithm.
        /// </summary>
        public void Shuffle()
        {
            // For each Card, pick another random Card and swap them.
            for (var first = 0; first < deck.Length; ++first)
            {
                // Select a random number between 0 and 51.
                var second = randomNumbers.Next(NumberOfCardsInDeck);

                // Swap current Card with randomly selected Card.
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }

        /// <summary>
        /// Creates given number of "Card" arrays and moves cards from the "deck" to these arrays, 5 per hand.
        /// </summary>
        /// <param name="numberOfHandsToDeal">Number of hands (i.e. "Card" arrays) to create and fill with cards.</param>
        public void DealHands(int numberOfHandsToDeal)
        {
            // Initialize "hands" array with provided by user number of hands to deal.
            hands = new Hand[numberOfHandsToDeal];

            // Create provided number of hands and move appropriate number of cards from "deck" to these hands.
            for (int handNumber = 0; handNumber < numberOfHandsToDeal; ++handNumber)
            {
                // TODO: SOmething wrong here. Debug.

                // Creating temporary array of 5 cards.
                Card[] cardsToDeal = new Card[NumberOfCardsInHand];
                // This statement writes first five elements of "deck" array to the "hand" array.
                Array.Copy(deck, 0, cardsToDeal, 0, NumberOfCardsInHand);
                // Create a temporary copy of the "deck" array.
                Card[] tempArray = deck;
                // Diminish number of cards in "deck" by resizing it to a smaller array.
                deck = new Card[NumberOfCardsInDeck - NumberOfCardsInHand];
                // Copy all except the first five cards from "tempArray" to "deck".
                Array.Copy(tempArray, NumberOfCardsInHand, deck, 0, (tempArray.Length - NumberOfCardsInHand));
                // Create new hand.
                Hand hand = new Hand(cardsToDeal);
                // Add the hand to the list of all hands.
                hands[handNumber] = hand;
            }
        }

        /// <summary>
        /// Prints all cards of all dealed hands.
        /// </summary>
        public void PrintHands()
        {
            for (int handNumber = 0; handNumber < hands.Length; ++handNumber)
            {
                Console.WriteLine($"Hand #{handNumber} has {hands[handNumber].RankName}");
                hands[handNumber].PrintCards();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Finds and prints a hand (or hands if there is there is a dead heat) with highest rank.
        /// </summary>
        public void PrintWinner()
        {
            // Create a temporary variable to hold the highest rank.
            int highestRankNumber = 0;
            string highestRankName = "no rank";
            int numberOfTheLastWinnerHand = 0;

            // Find the highest rank and remember which hand is the last in the list with this rank.
            for (int handNumber = 0; handNumber < hands.Length; ++handNumber)
            {
                if (hands[handNumber].RankNumber > highestRankNumber)
                {
                    highestRankNumber = hands[handNumber].RankNumber;
                    highestRankName = hands[handNumber].RankName;
                    numberOfTheLastWinnerHand = handNumber;
                }
            }

            // Count number of hands with highest rank.
            int numberOfHandsWithHighestRank = 0;

            foreach (Hand hand in hands)
            {
                if (hand.RankNumber == highestRankNumber)
                {
                    ++numberOfHandsWithHighestRank;
                }
            }

            // If it is a dead heat, print number of winners.
            if (numberOfHandsWithHighestRank > 1)
            {
                Console.WriteLine($"It's a dead heat. {numberOfHandsWithHighestRank} hands have {highestRankName}.");
                Console.WriteLine("The following hands are winners:");

                // Print winner hands.
                for (int handNumber = 0; handNumber < hands.Length; ++handNumber)
                {
                    if (hands[handNumber].RankNumber == highestRankNumber)
                    {
                        Console.Write($"  {handNumber}");
                    }
                }

                Console.WriteLine();
            }
            else
            {
                // If there is only one winner - print his number.
                Console.WriteLine($"A hand #{numberOfTheLastWinnerHand} is a winner. It has {highestRankName}.");
            }
        }
        
        #endregion
    }
}