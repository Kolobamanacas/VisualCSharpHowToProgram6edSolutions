// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 27 (07.33) Craps Game Modification.

using System;
using System.Globalization;

class Craps
{
    // Initialize a static field as a new object of class "CultureInfo" to use it during input to get dot as decimal mark.
    private static CultureInfo cultureEnUs = new CultureInfo("en-US");

    // Create random-number generator for use in method RollDice.
    private static Random randomNumbers = new Random();

    // Enumeration with constants that represent the game status.
    private enum Status {Continue, Won, Lost}

    // Enumeration with constants that represent common rolls of the dice.
    private enum DiceNames
    {
        SnakeEyes = 2,
        Trey = 3,
        Seven = 7,
        YoLeven = 11,
        BoxCars = 12
    }

    // Plays one game of craps.
    static void Main()
    {
        // gameStatus can contain Continue, Won or Lost.
        Status gameStatus = Status.Continue;
        // Point if no win or loss on first roll.
        int myPoint = 0;
        // Initializing a local variable "balance" to 1000.
        decimal balance = (decimal)1000;
        // Print current balance.
        Console.WriteLine($"Your balance is {balance.ToString(cultureEnUs)}");
        // Call method "GetWager()" to ask a user to enter a wager, check rorrectness and return it as a decimal value.
        decimal wager = GetWager(balance);
        // First roll of the dice.
        int sumOfDice = RollDice();

        // Determine game status and point based on first roll.
        switch ((DiceNames)sumOfDice)
        {
            // Win with 7 on first roll.
            case DiceNames.Seven:
            // Win with 11 on first roll.
            case DiceNames.YoLeven:
                gameStatus = Status.Won;
                break;
            // Lose with 2 on first roll.
            case DiceNames.SnakeEyes:
            // Lose with 3 on first roll.
            case DiceNames.Trey:
            // Lose with 12 on first roll.
            case DiceNames.BoxCars:
                gameStatus = Status.Lost;
                break;
            // Did not win or lose, so remember point.
            default:
                // Game is not over.
                gameStatus = Status.Continue;
                // Remember the point.
                myPoint = sumOfDice;
                Console.WriteLine($"Point is {myPoint}");
                break;
        }

        // While game is not complete.
        // Game not Won or Lost.
        while (gameStatus == Status.Continue)
        {
            // Roll dice again.
            sumOfDice = RollDice();

            // Determine game status.
            // Win by making point.
            if (sumOfDice == myPoint)
            {
                gameStatus = Status.Won;
            }
            else
            {
                // Lose by rolling 7 before point.
                if (sumOfDice == (int)DiceNames.Seven)
                {
                    gameStatus = Status.Lost;
                }
            }
        }

        // Display won or lost message.
        if (gameStatus == Status.Won)
        {
            balance += wager;
            Console.WriteLine("Player wins");
        }
        else
        {
            balance -= wager;
            Console.WriteLine("Player loses");
        }
        
        Console.WriteLine($"The new balance is: {balance.ToString(cultureEnUs)}");
    }

    // Roll dice, calculate sum and display results.
    static int RollDice()
    {
        // Pick random die values.
        // First die roll.
        int die1 = randomNumbers.Next(1, 7);
        // Second die roll.
        int die2 = randomNumbers.Next(1, 7);
        // Sum of die values.
        int sum = die1 + die2;

        // Display results of this roll.
        Console.WriteLine($"Player rolled {die1} + {die2} = {sum}");
        // Return sum of dice.
        return sum;
    }

    /* Private static method "GetWager()" gets a balance as an argument, gets a wager from a user and return this wager as a decimal value when it meets conditions: 0 < wager <= balance. */
    private static decimal GetWager(decimal balance)
    {
        decimal wager = -1;

        while (wager <= 0 || wager > balance)
        {
            Console.Write("Make a wager: ");
            wager = decimal.Parse(Console.ReadLine(), cultureEnUs);
            
            if (wager <= 0)
            {
                Console.WriteLine($"Your wager should be more than 0 and less or equal to your balance ({balance}).");
            }
            if (wager > balance)
            {
                Console.WriteLine($"You can't wager more than your balance ({balance}) allows.");
            }
        }

        return wager;
    }
}