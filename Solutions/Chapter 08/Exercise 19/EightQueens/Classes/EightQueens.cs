// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 19 (08.24) Eight Queens.

using System;

class EightQueens
{
    static void Main()
    {
        Queen amidala = new Queen();

        while (amidala.SafePointExists())
        {
            Console.Clear();
            amidala.PrintAllBoards();
            amidala.MakeMove();
        }

        Console.Clear();
        amidala.PrintAllBoards();

        string result = amidala.MovesMade >= 8
            ? "Congratulations, you won!"
            : "Sorry, you lose.";

        Console.WriteLine(result);
        Console.WriteLine("Game over. Press any key to exit.");
        Console.ReadKey();
    }
}