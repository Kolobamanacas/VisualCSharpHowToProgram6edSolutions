// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Exercise 12 (03.18) Displaying Shapes with Asterisks.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class AsteriskShapes
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        /* Display needed number of asterisks and spaces one statement per line. WriteLine mothod ends the output line with a newline escape sequence. */
        Console.WriteLine("*********    ***      *        *");
        Console.WriteLine("*       *   *   *    ***      * *");
        Console.WriteLine("*       *  *     *  *****    *   *");
        Console.WriteLine("*       *  *     *    *     *     *");
        Console.WriteLine("*       *  *     *    *    *       *");
        Console.WriteLine("*       *  *     *    *     *     *");
        Console.WriteLine("*       *  *     *    *      *   *");
        Console.WriteLine("*       *   *   *     *       * *");
        Console.WriteLine("*********    ***      *        *");
    } // Exit Main's method body.
} // Exit class body.