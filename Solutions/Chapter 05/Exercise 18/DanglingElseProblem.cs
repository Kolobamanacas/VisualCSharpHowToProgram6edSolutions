// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 18(11) (05.27) Dangling-else Problem.

using System;

class DanglingElseProblem
{
    static void Main()
    {
        // Add some local variables to be able to check results and read them from user.
        Console.Write("Please enter value for x: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Please enter value for y: ");
        int y = int.Parse(Console.ReadLine());
        
        // Add curly braces ("{" and "}") to indicate bodies of every "if" and "else" statements.
        if (x > 5)
        {
            if (y > 5)
            {
                Console.WriteLine("x and y are > 5");
            }
        }
        else
        {
            Console.WriteLine("x is <= 5");
        }
    }
}