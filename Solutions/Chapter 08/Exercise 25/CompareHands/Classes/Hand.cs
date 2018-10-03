// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 25 (08.30) Card Shuffling and Dealing

using System;
using System.Collections.Generic;

namespace CompareHands.Classes
{
    class Hand
    {
        #region Constructors

        public Hand(Card[] cards)
        {
            // Store five cards in a hand.
            this.Cards = cards;
            // Check which rank a hand has and store it in a property.
            DefineRank();
        }

        #endregion

        #region Private properties

        // A hand of 5 cards.
        private Card[] Cards { get;  set; }

        #endregion

        #region Public properties

        // Rank of a hand: 0 - no rank, 1 - a pair, 2 - two pairs, 3 - three of a kind,
        // 4 - a straight, 5 - a flush, 6 - a full house, 7 - four of a kind.
        public int RankNumber { get; private set; }
        // Name of a rank.
        public string RankName { get; private set; }

        #endregion

        #region Private methods

        /// <summary>
        /// Called with constructor. Finds wether a hand has a rank and writes it's name to "RankNumber" and "RankName" properties.
        /// </summary>
        private void DefineRank()
        {
            /* Here again I use a feature from later chapters, but it helps us a lot with our task. A dictionary stores pairs of values of
             * different types (like "int", "string", "bool", etc.). The first value of a pair is called a "key" and the second one is a
             * "value". You can store many of these pairs within a dictionary, but every "key" value must be unique, i.e. you can't store
             * two pairs with the same value in the "key". We would use card's face as a key and count number of each face as a value. You
             * can read about dictionaries here:
             * https://msdn.microsoft.com/en-us/library/xfhwa508(v=vs.110).aspx */
            Dictionary<string, int> combinations = new Dictionary<string, int>();

            // Add all cards from "hand" array to "combinations" dictionary.
            foreach (Card card in Cards)
            {
                if (!combinations.ContainsKey(card.Face))
                {
                    // If there is no a card with certain face in a dictionary yet, then add it with "1" as a value.
                    combinations.Add(card.Face, 1);
                }
                else
                {
                    // Otherwise increment the value of existing record.
                    combinations[card.Face] = combinations[card.Face] + 1;
                }
            }

            // If there four of a kind, print it and quit.
            if (combinations.ContainsValue(4))
            {
                RankNumber = 7;
                RankName = "four of a kind";
                return;
            }

            // If there three cards one face and two cards of another face.
            if (combinations.ContainsValue(3)
                && combinations.ContainsValue(2))
            {
                RankNumber = 6;
                RankName = "a full house";
                return;
            }

            // To know whether there a flush, compare a suit of 0'th card to all the rest cards.
            bool handContainsFlush = true;

            // If at least two cards have different suits, set "handContainsFlush" to false and break the loop.
            for (int cardNumber = 1; cardNumber < Cards.Length; ++cardNumber)
            {
                if (Cards[0].Suit != Cards[cardNumber].Suit)
                {
                    handContainsFlush = false;
                    break;
                }
            }

            // If there is a flush.
            if (handContainsFlush)
            {
                RankNumber = 5;
                RankName = "a flush";
                return;
            }

            // If there are 5 pairs in the "combinations" dictionary it means that there is no card with the same face in the "hand".
            if (combinations.Count == 5)
            {
                // Find a card with highest face.
                int highestFaceIndex = 0;

                // Search from the highest to lowest face in the "combinations" and when we found the first one, write it's index to
                // "highestFaceIndex" and break the loop.
                for (int faceIndex = (DeckOfCards.Faces.Length - 1); faceIndex >= 0; --faceIndex)
                {
                    if (combinations.ContainsKey(DeckOfCards.Faces[faceIndex]))
                    {
                        highestFaceIndex = faceIndex;
                        break;
                    }
                }

                // If there are 4 other cards with sequential ranks of faces it's a straight.
                if (combinations.ContainsKey(DeckOfCards.Faces[highestFaceIndex - 1])
                    && combinations.ContainsKey(DeckOfCards.Faces[highestFaceIndex - 2])
                    && combinations.ContainsKey(DeckOfCards.Faces[highestFaceIndex - 3])
                    && combinations.ContainsKey(DeckOfCards.Faces[highestFaceIndex - 4]))
                {
                    RankNumber = 4;
                    RankName = "a straight";
                    return;
                }

                // Check for one more case of a straight when an Ace is going after a King and a hand contains:
                // Ace, King, Queen, Jack and Ten.
                if (combinations.ContainsKey(DeckOfCards.Faces[0])
                    && combinations.ContainsKey(DeckOfCards.Faces[DeckOfCards.Faces.Length - 1])
                    && combinations.ContainsKey(DeckOfCards.Faces[DeckOfCards.Faces.Length - 2])
                    && combinations.ContainsKey(DeckOfCards.Faces[DeckOfCards.Faces.Length - 3])
                    && combinations.ContainsKey(DeckOfCards.Faces[DeckOfCards.Faces.Length - 4]))
                {
                    RankNumber = 4;
                    RankName = "a straight";
                    return;
                }

            }

            // If there three of a kind, print it and quit.
            if (combinations.ContainsValue(3))
            {
                RankNumber = 3;
                RankName = "three of a kind";
                return;
            }

            // Check for two pairs. Temprorary store the first pair's face. "Empty" is actually a read-only field of C#'s string class.
            // It is convinient and more precise way to represent an empty string comared to two quotation marks. You can read more here:
            // https://msdn.microsoft.com/en-us/library/system.string.empty(v=vs.110).aspx
            string firstPairFace = string.Empty;

            // Find the first pair and break the loop as soon as we found it.
            foreach (KeyValuePair<string, int> combination in combinations)
            {
                if (combination.Value == 2)
                {
                    firstPairFace = combination.Key;
                    break;
                }
            }

            // If there another pair but with different face, it's two pairs.
            foreach (KeyValuePair<string, int> combination in combinations)
            {
                if (combination.Value == 2
                    && combination.Key != firstPairFace)
                {
                    RankNumber = 2;
                    RankName = "two pairs";
                    return;
                }
            }

            // If there at least one pair, then it is already stored in "firstPairFace". So if it's not empty, we have a pair.
            if (firstPairFace != string.Empty)
            {
                RankNumber = 1;
                RankName = "a pair";
                return;
            }

            RankNumber = 0;
            RankName = "no rank";
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Prints a rank and all cards of a hand.
        /// </summary>
        public void PrintCards()
        {
            Console.WriteLine("Cards of a hand:");

            foreach (Card card in Cards)
            {
                Console.Write($"{card, -19}");
            }

            Console.WriteLine();
        }

        #endregion
    }
}