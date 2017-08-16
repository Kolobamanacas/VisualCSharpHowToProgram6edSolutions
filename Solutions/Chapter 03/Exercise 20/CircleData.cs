// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Exercise 20 (03.26) Diameter, Circumference and Aria of a Circle.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class CircleData
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        // Declare variable of type integer to store a circle's radius in computer's memory.
        int radius = 0;

        // Ask user to input a value as circle's radius.
        Console.WriteLine("Please enter interger number as a radius of a circle: ");
        // Write a value inputted by user to a radius variable.
        radius = int.Parse(Console.ReadLine());

        // Print Diameter, Circumference and Aria of a Circle with given radius on a screen.
        Console.WriteLine($"Diameter of the circle with radius {radius} is {2 * radius}.");
        Console.WriteLine($"Circumference of the circle with radius {radius} is {2 * Math.PI * radius}.");
        Console.WriteLine($"Aria of the circle with radius {radius} is {Math.PI * radius * radius}.");
    }
}