// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 30 (07.36) Towers Of Hanoi.

/* Despite the solution for the Tower of Hanoi looks simple, it took me a lot of efforts in attempts to solve it, and I was not successful at the end, so I just googled the answer. For my opinion, the explanation of the algorithm, you would find in the textbook and on the most places on the web is insufficient. I think so because most of explanations discribe the recursive calls without discribing the way to move disks themselves. Probably it's done for a reason for people to think the problem of and personally find out the right solution. Anyway, if you are reading this, I guess you have some troubles with the exercise too. Hope you'll find what you are looking for. */

using System;

class TowersOfHanoi
{
    static void Main()
    {
        // Print a wellcome message.
        Console.WriteLine("The app solves the Hanoi tower quest.");
        /* Call the "GetNumberOfDisks()" method to get number of disks to move from a user and store a result in a "disksToMove" local variable. */
        int disksToMove = GetNumberOfDisks();
        // Print the resulting disks moving process by calling the recursive "Tower()" method.
        Console.WriteLine("Here is the moving process:");
        Tower(disksToMove, 1, 2, 3);        
    }

    /* Private static method "GetNumberOfDisks()" takes no argumnets, promts a user to enter the number of disks to move, check the correctness and returns this number as an integer. I choose "1 to 100" range because it took more than 5 minutes to solve the problem with Intel Core i7-7700HQ with as many as 20 disks and I didn't get to the end of calculations when I tried 50. So, if you are wirting the app for the supercomputer, you could try 100. */
    private static int GetNumberOfDisks()
    {
        Console.Write("Enter the number of discs to move (from 1 to 100): ");
        int disksToMove = int.Parse(Console.ReadLine());

        while (disksToMove < 1 || disksToMove > 100)
        {
            Console.WriteLine("The number should be more than 0 and less than 100.");
            Console.Write("Enter the number of discs to move (from 1 to 100): ");
            disksToMove = int.Parse(Console.ReadLine());
        }

        return disksToMove;
    }

    /* Here is our hero - the "Tower()" method. It is, as usual, private, static and void as it doesn't return any value. All the arguments are the same as described in the textbook. So the base case is when we got only 1 disk to move. In that case we move it from peg 1 (argument 2) to peg 3 (argument 4). In all other cases we subsequently and recursively call the "Tower()" method, lowering the number of disks to move. In the first call we switch auxiliary peg with destination peg. In the second call we pass hardcoded "1" as the number of disks to move. In the third call we switch initial peg with auxiliary. I am afraid that any further explanations are helpless. The only thing that helped me a bit is analizing a couple of cases step by step. Consider that initial "disksToMove's" value is 1. Where the executen flow would go? And what about 2 or 5? Hopefully, you would get some kind of understanding after appropriate number af such analytical attempts. */
    private static void Tower(int disksToMove, int pegInitial, int pegTemp, int pegDestination)
    {
        if (disksToMove == 1)
        {
            Console.WriteLine($"{pegInitial} --> {pegDestination}");
        }
        else
        {
            Tower(disksToMove - 1, pegInitial, pegDestination, pegTemp);
            Tower(1, pegInitial, pegTemp, pegDestination);
            Tower(disksToMove - 1, pegTemp, pegInitial, pegDestination);
        }
    }
}