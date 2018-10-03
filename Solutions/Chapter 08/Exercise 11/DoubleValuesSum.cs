// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 11 (08.16) Using the foreach Statement.

using System;

class DoubleValuesSum
{
    static void Main(string[] args)
    {
        double sum = 0;

        foreach (string number in args)
        {
            sum += double.Parse(number);
        }

        Console.WriteLine($"The sum of given numbers is: {sum}");
    }
}