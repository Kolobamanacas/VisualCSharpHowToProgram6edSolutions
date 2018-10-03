// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 13 (08.18) Game of Craps.

using System;

class GameOfCraps
{
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
    // Private static field to store total numbers of games played.
    private const int GamesPlayedTotal = 1000000;
    // Private static field to store total numbers of rolls made in all games.
    private static int numberOfRollsAllGames = 0;
    // Private static field to store total numbers of wins.
    private static int totalNumberOfWins = 0;
    // Private static field to store total numbers of losses.
    private static int totalNumberOfLosses = 0;
    /* Let's store wins and losses statistic in one two-dimentional array with the first column is for wins and the second if for losses.
    The first 20 rows would represent wins and losses for the games won and lost on the first 20 rolls accordingly.
    For example the first row would store number of games won and lost on the first roll.
    The 21th row would store data for games won and lost after the twenteieth roll. */
    private static int[,] winsAndLosses = new int[20, 2];

    static void Main()
    {
        // Local variable "numberOfRollsOneGame" would hold a number or die were rolled in each game.
        int numberOfRollsOneGame = 0;
        // gameStatus can contain Continue, Won or Lost.
        Status gameStatus = Status.Continue;
        // Point if no win or loss on first roll.
        int myPoint = 0;
        // Local variable to store randomly generated sum of dice.
        int sumOfDice = 0;

        for (int gameNumber = 1; gameNumber <= GamesPlayedTotal; ++gameNumber)
        {
            // Set the number of rolls of the current game to 0;
            numberOfRollsOneGame = 0;
            // Reset the game status, and my point.
            gameStatus = Status.Continue;
            myPoint = 0;
            // First roll of the dice for the current game..
            sumOfDice = RollDice(ref numberOfRollsOneGame);

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
                    break;
            }

            // While game is not complete.
            // Game not Won or Lost.
            while (gameStatus == Status.Continue)
            {
                // Roll dice again.
                sumOfDice = RollDice(ref numberOfRollsOneGame);

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

            // Call the method "UpdateWinsAndLosses()" providing concluding status and number of rolls made for the current game.
            UpdateWinsAndLosses(gameStatus, numberOfRollsOneGame);
        }

        // Print all the output statistic.
        Console.WriteLine($"Statistic for Game of Craps.");
        Console.WriteLine($"Total games played: {GamesPlayedTotal}");
        Console.WriteLine($"Total number of rolls for all games: {numberOfRollsAllGames}");
        Console.WriteLine($"Avarege length of one game (in rolls): {numberOfRollsAllGames / GamesPlayedTotal}");
        Console.WriteLine($"Total number of wins: {totalNumberOfWins}");
        Console.WriteLine($"Total number of losses: {totalNumberOfLosses}");
        // 
        Console.WriteLine($"Approximate chance to win: {(int)(((double)totalNumberOfWins / (double)GamesPlayedTotal) * 100)}%");
        Console.WriteLine();
        Console.WriteLine("Rolls     Wins     Losses");
        
        for (int row = 0; row < (winsAndLosses.GetLength(0) - 1); ++row)
        {
            Console.WriteLine($"{(row + 1), 5}   {winsAndLosses[row, 0], 6}   {winsAndLosses[row, 1], 8}");
        }
        
        Console.WriteLine($" >=20   {winsAndLosses[19, 0], 6}   {winsAndLosses[19, 1], 8}");
    }

    // Roll dice, calculate sum and display results.
    static int RollDice(ref int numberOfRollsOneGame)
    {
        // Count every roll of dice for the current game and for all games played.
        ++numberOfRollsOneGame;
        ++numberOfRollsAllGames;
        // Pick random die values.
        // First die roll.
        int die1 = randomNumbers.Next(1, 7);
        // Second die roll.
        int die2 = randomNumbers.Next(1, 7);
        // Return sum of die values.
        return die1 + die2;
    }

    // 
    static void UpdateWinsAndLosses(Status gameStatus, int numberOfRollsOneGame)
    {
        int rollIndex = numberOfRollsOneGame <= 19
            ? (numberOfRollsOneGame - 1)
            : 19;
        
        if (gameStatus == Status.Won)
        {
            ++winsAndLosses[rollIndex, 0];
            ++totalNumberOfWins;
        }
        else
        {
            ++winsAndLosses[rollIndex, 1];
            ++totalNumberOfLosses;
        }
    }
}