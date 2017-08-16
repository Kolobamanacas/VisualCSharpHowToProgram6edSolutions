// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Exercise 23 (03.29) Table of Squares and Cubes.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class SquaresAndCubes
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        // So the task is to display numbers from 0 to 10 and its squares and cubes using single variable x. Lets declare and initialize it right at the declaration step.
        int x = 0;
        
        // Display the line with headers.
        Console.WriteLine("Number   Square   Cube");
        // As soon as x = 0 it is ready to the first iteration of calculations. Just display all the values.
        Console.WriteLine($"{x}        {x * x}        {x * x * x}");
        // Now the interesting part. Every iteration cycle we would give the x a new value, but the display statement would stay almost the same - we would change only number of space characters to stay inside supposed columns.
        // Give x a new value of 1.
        x = 1;
        // Display new results line.
        Console.WriteLine($"{x}        {x * x}        {x * x * x}");
        // Continue the same steps.
        x = 2;
        Console.WriteLine($"{x}        {x * x}        {x * x * x}");
        x = 3;
        Console.WriteLine($"{x}        {x * x}        {x * x * x}");
        x = 4;
        Console.WriteLine($"{x}        {x * x}       {x * x * x}");
        x = 5;
        Console.WriteLine($"{x}        {x * x}       {x * x * x}");
        x = 6;
        Console.WriteLine($"{x}        {x * x}       {x * x * x}");
        x = 7;
        Console.WriteLine($"{x}        {x * x}       {x * x * x}");
        x = 8;
        Console.WriteLine($"{x}        {x * x}       {x * x * x}");
        x = 9;
        Console.WriteLine($"{x}        {x * x}       {x * x * x}");
        x = 10;
        Console.WriteLine($"{x}       {x * x}      {x * x * x}");
    } // Exit Main's method body.
} // Exit class body.