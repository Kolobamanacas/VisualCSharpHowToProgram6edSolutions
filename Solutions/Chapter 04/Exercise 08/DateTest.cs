// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Exercise 08 (04.12) Date Class.

using System;

class DateTest
{
    static void Main()
    {
        // Creationg and object of class Date with three integer values passed as arguments to class constructor.
        Date dateObject = new Date(2016, 12, 27);
        
        // Display date stored in dateObject object calling Date class DisplayDate method.
        Console.WriteLine($"The date is:");
        dateObject.DisplayDate();
    }
}