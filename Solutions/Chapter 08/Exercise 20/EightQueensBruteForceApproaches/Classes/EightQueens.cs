// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 20 (08.25) Eight Queens: Brute-Force Approaches.

using System;

class EightQueens
{
    #region Private Enums

    private enum GameMode
    {
        PlayRandomTillWin,
        FindAllWinCombinations
    };

    #endregion

    #region Private methods

    /// <summary>
    /// Randomly puts queens on a board until it finds the first successful combination.
    /// </summary>
    static void PlayGameRandomMode()
    {
        Console.WriteLine("Start game in random mode.");

        Queen nala = new Queen();
        Int64 numberOfGamesPlayed = 0;

        while (nala.MovesMade < 8
            && numberOfGamesPlayed < Int64.MaxValue - 1)
        {
            nala.ResetTables();
            nala.TryRandomCombination();
            ++numberOfGamesPlayed;

            // Show some activity every one million games.
            if (numberOfGamesPlayed % 1000000 == 0)
            {
                Console.WriteLine($"There are {numberOfGamesPlayed} games played.");
            }
        }

        if (nala.MovesMade == 8)
        {
            nala.PrintSuccessfulCombination();
        }
        else
        {
            Console.WriteLine($"The app was unable to solve the puzzle with {numberOfGamesPlayed} random games played.");
        }

    }

    /// <summary>
    /// Checks all possible combinations and prints the list of all found successful.
    /// </summary>
    static void PlayGameFindAllMode()
    {
        Queen aliciaTheRed = new Queen();
        aliciaTheRed.FindAndPrintAllSolutions();
    }

    #endregion

    #region Main

    static void Main()
    {
        ConsoleKey keyPressed = ConsoleKey.Spacebar;

        while (keyPressed != ConsoleKey.R
            && keyPressed != ConsoleKey.A)
        {
            Console.Clear();
            Console.WriteLine("Wellcome to Eight Queens game.");
            Console.WriteLine("Please choose a game mode by pressing one of the following buttons:");
            Console.WriteLine("  R - the app randomly puts queens on a board until it finds the first successful combination.");
            Console.WriteLine("  A - the app checks all possible combinations and prints the list of all successful.");
            keyPressed = Console.ReadKey(true).Key;
        }

        if (keyPressed == ConsoleKey.R)
        {
            PlayGameRandomMode();
        }
        else if (keyPressed == ConsoleKey.A)
        {
            PlayGameFindAllMode();
        }

        Console.WriteLine("Game over. Press any key to exit.");
        Console.ReadKey();
    }

    #endregion
}