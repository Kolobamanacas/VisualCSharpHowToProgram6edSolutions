// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 24 (08.29) Card Shuffling and Dealing

using System;

class DeckOfCardsTest
{
    // Execute app.
    static void Main()
    {
        Console.WriteLine("Wellcome to Card Dealing app.");
        Console.WriteLine();

        var myDeckOfCards = new DeckOfCards();
        // Place Cards in random order.
        myDeckOfCards.Shuffle();
        Console.WriteLine("The order of cards if the deck before dealing a hand:");
        // Print all cards that currently in deck.
        myDeckOfCards.PrintDeck();
        Console.WriteLine();
        Console.WriteLine("Here is your hand:");
        // Deal and print a hand.
        myDeckOfCards.DealAndPrintHand();
        // Print a rand of the hand.
        Console.WriteLine($"You have {myDeckOfCards.PrintRank()} in your hand.");

        Console.WriteLine();
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}