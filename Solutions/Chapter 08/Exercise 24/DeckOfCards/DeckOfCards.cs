// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 24 (08.29) Card Shuffling and Dealing

using System;
// Add this to be able to use "Dictionary". See comments below.
using System.Collections.Generic;

class DeckOfCards
{
    #region Constants

    private const int NumberOfCardsInDeck = 52;
    private const int NumberOfCardsInHand = 5;
    // "Faces" and "Suits" arrays are changed to readonly fields to be able to check whether a "hand" have a straight combination.
    private readonly string[] Faces;
    private readonly string[] Suits;

    #endregion

    #region Private fields

    // Create one Random object to share among DeckOfCards objects.
    private static Random randomNumbers = new Random();
    private Card[] deck = new Card[NumberOfCardsInDeck];
    private Card[] hand = new Card[NumberOfCardsInHand];

    #endregion

    #region Constructors

    // Constructor fills deck of Cards.
    public DeckOfCards()
    {
        Faces = new string[] {"Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
        Suits = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };

        // Populate deck with Card objects.
        for (var count = 0; count < deck.Length; ++count)
        {
            deck[count] = new Card(Faces[count % 13], Suits[count / 13]);
        }
    }

    #endregion

    #region Public methods

    // Shuffle deck of Cards with one-pass algorithm.
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

    // Deal one Card.
    public void PrintDeck()
    {
        for (int cardNumber = 0; cardNumber < deck.Length; ++cardNumber)
        {
            Console.Write($"{deck[cardNumber], -19}");

            if ((cardNumber + 1) % 4 == 0)
            {
                Console.WriteLine();
            }
        }
    }

    /// <summary>
    /// Moves first five cards from a deck to a hand and prints a hand.
    /// </summary>
    public void DealAndPrintHand()
    {
        // This statement writes first five elements of "deck" array to the "hand" array.
        Array.Copy(deck, 0, hand, 0, NumberOfCardsInHand);
        // Create a temporary copy of the "deck" array.
        Card[] tempArray = deck;
        // Diminish number of cards in "deck" by resizing it to a smaller array.
        deck = new Card[NumberOfCardsInDeck - NumberOfCardsInHand];
        // Copy all except the first five cards from "tempArray" to "deck".
        Array.Copy(tempArray, NumberOfCardsInHand, deck, 0, deck.Length);

        for (int cardNumber = 0; cardNumber < hand.Length; ++cardNumber)
        {
            Console.Write($"{hand[cardNumber], -19}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Prints the highest rank the dealed hand has.
    /// </summary>
    /// <returns>Returns a string with a name of a rank.</returns>
    public string PrintRank()
    {
        /* Here again I use a feature from later chapters, but it helps us a lot with our task. A dictionary stores pairs of values of
         * different types (like "int", "string", "bool", etc.). The first value of a pair is called a "key" and the second one is a
         * "value". You can store many of these pairs within a dictionary, but every "key" value must be unique, i.e. you can't store two
         * pairs with the same value in the "key". We would use card's face as a key and count number of each face as a value. You can
         * read about dictionaries here:
         * https://msdn.microsoft.com/en-us/library/xfhwa508(v=vs.110).aspx */
        Dictionary<string, int> combinations = new Dictionary<string, int>();

        // Add all cards from "hand" array to "combinations" dictionary.
        foreach (Card card in hand)
        {
            if (!combinations.ContainsKey(card.Face))
            {
                // If there is no a card with certain face in a dictionary then add it with "1" as a value.
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
            return "four of a kind";
        }

        // If there three cards one face and two cards of another face.
        if (combinations.ContainsValue(3)
            && combinations.ContainsValue(2))
        {
            return "a full house";
        }

        // To know whether there a flush, compare a suit of 0'th card to all the rest cards.
        bool handContainsFlush = true;

        // If at least two cards have different suits, set "handContainsFlush" to false and break the loop.
        for (int cardNumber = 1; cardNumber < hand.Length; ++cardNumber)
        {
            if (hand[0].Suit != hand[cardNumber].Suit)
            {
                handContainsFlush = false;
                break;
            }
        }

        // If there is a flush.
        if (handContainsFlush)
        {
            return "a flush";
        }

        // If there are 5 pairs in the "combinations" dictionary it means that there is no card with the same face in the "hand".
        if (combinations.Count == 5)
        {
            // Find a card with highest face.
            int highestFaceIndex = 0;

            // Search from the highest to lowest face in the "combinations" and when we found the first one, write it's index to
            // "highestFaceIndex" and break the loop.
            for (int faceIndex = (Faces.Length - 1); faceIndex >= 0; --faceIndex)
            {
                if (combinations.ContainsKey(Faces[faceIndex]))
                {
                    highestFaceIndex = faceIndex;
                    break;
                }
            }

            // If there are 4 other cards with sequential ranks of faces it's a straight.
            if (combinations.ContainsKey(Faces[highestFaceIndex - 1])
                && combinations.ContainsKey(Faces[highestFaceIndex - 2])
                && combinations.ContainsKey(Faces[highestFaceIndex - 3])
                && combinations.ContainsKey(Faces[highestFaceIndex - 4]))
            {
                return "a straight";
            }

            // Check for one more case of a straight when an Ace is going after a King and a hand contains: Ace, King, Queen, Jack and Ten.
            if (combinations.ContainsKey(Faces[0])
                && combinations.ContainsKey(Faces[Faces.Length - 1])
                && combinations.ContainsKey(Faces[Faces.Length - 2])
                && combinations.ContainsKey(Faces[Faces.Length - 3])
                && combinations.ContainsKey(Faces[Faces.Length - 4]))
            {
                return "a straight";
            }

        }

        // If there three of a kind, print it and quit.
        if (combinations.ContainsValue(3))
        {
            return "three of a kind";
        }

        // Check for two pairs. Temprorary store the first pair's face. "Empty" is actually a read-only field of C#'s string class.
        // It is convinient and more precise way to represent an empty string comared to two quotation marks. You can read about it here:
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
                return "two paris";
            }
        }

        // If there at least one pair, then it is already stored in "firstPairFace". So if it's not empty, we have a pair.
        if (firstPairFace != string.Empty)
        {
            return "a pair";
        }

        return "no rank";
    }

    #endregion
}