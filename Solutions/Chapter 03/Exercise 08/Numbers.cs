// Solution to exercises from "C# How to Program 6th edition".
// Chapter 3.
// Exercise 08 (03.14) Displaying Numbers.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class Numbers
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        // WriteLine method of class Console prints its argument (which is text in quotation marks) on a screen.
        // It also add new line escape sequence to the end of text which puts system cursor to a new line.
        Console.WriteLine("1 2 3 4");

        /* Wtite method of class Console also prints its argument on a screen but left system cursor right at the end of last printed character. */
        Console.Write("1 ");
        Console.Write("2 ");
        Console.Write("3 ");
        Console.Write("4\n");

        // Declare and inicialize variables of integer type.
        int a = 1;
        int b = 2;
        int c = 3;
        int d = 4;

        /* C# 6'th new feature string interpolation lets us put variables right into text argument of Write and WriteLine methods. To use interpolation one needs to put $ sign before the first quatation mark and wrap variable names in curly braces. */
        Console.WriteLine($"{a} {b} {c} {d}\n");
    } // Exit Main's method body.
} // Exit class body.