// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Exercise 21 (03.27) Integer Equivalent to a Chracter.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class IntegerEquivalent
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        /* Print integer equivalents of letters, numbers and special symbols on a screen. (int) before a character casts a character to its integer number representation in the corresponding character set a computer uses to represent all possible characters. */
        Console.WriteLine($"The integer equivalent of A is {(int)'A'}.");
        Console.WriteLine($"The integer equivalent of B is {(int)'B'}.");
        Console.WriteLine($"The integer equivalent of C is {(int)'C'}.");
        Console.WriteLine($"The integer equivalent of a is {(int)'a'}.");
        Console.WriteLine($"The integer equivalent of b is {(int)'b'}.");
        Console.WriteLine($"The integer equivalent of c is {(int)'c'}.");
        Console.WriteLine($"The integer equivalent of 0 is {(int)'0'}.");
        Console.WriteLine($"The integer equivalent of 1 is {(int)'1'}.");
        Console.WriteLine($"The integer equivalent of 2 is {(int)'2'}.");
        Console.WriteLine($"The integer equivalent of $ is {(int)'$'}.");
        Console.WriteLine($"The integer equivalent of * is {(int)'*'}.");
        Console.WriteLine($"The integer equivalent of + is {(int)'+'}.");
        Console.WriteLine($"The integer equivalent of / is {(int)'/'}.");
        Console.WriteLine($"The integer equivalent of space character is {(int)' '}.");
    } // Exit Main's method body.
} // Exit class body.