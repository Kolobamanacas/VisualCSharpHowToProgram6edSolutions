// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Making-a-Difference Exercise 01 (03.31) Body Mass Index Calculator.

// Join System namespace to be able to use Console class.
using System;
// Joint System.Globalization namespace to be able to use CultureInfo. See comments below.
using System.Globalization;

// Declare a class to perform our task.
class BMI
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        /* Declare and initialize variables of type double to store in memory weight in kilograms and height in meters. I am using kilograms and meters instead of pounds and inches (or orther units) because kilograms and meters are world standard according to International System of Units (https://en.wikipedia.org/wiki/International_System_of_Units). */
        double weightInKilograms;
        double heightInMeters;

        /* The following is my little peek ahead. The problem is that different countries use different character as a decimal mark. A decimal mark is a symbol used to separate the integer part from the fractional part of a number written in decimal form. The most popular decimal mark characters are dot "." and comma ",". For example, if in the Great Britain you would write "403.12", in the Germany you would write "403,12". We are going to use numbers of type double in this application, which means that we need to parse text inputted by user to a number. But again number would be "403,12" or "403.12". Which input user should use?
        
        The bad news are that this topic is still under great debates and there is no common standard for the decimal mark yet. I decide to use dot for the following reason: most well known programming languages specifically use dot. So if you use dot, it would be easier to you to understand and use other prorgamming languages at this point.

        The C# language supports a mechanism that allows you to choose decimal mark character depending on your reginal standard. Regional standard refers to date, time, currency formats, etc. By default the application you write uses a regional standard of your operation system. But you are able to change default reginal standard for your application and that is what I would do. I want to use dots instead of commas (which is used by default by my reginal standard). I would not explain it in details by now because we are not yet ready so just read the comments carefully and leave the code as it is. */

        // Just like we've created variables of type integer or string, we create object of class CultureInfo and call it cultureEnUs.
        // We give cultureEnUs a value of en-US reginal standard.
        CultureInfo cultureEnUs = new CultureInfo("en-US");

        // Ask user to input his weight in kilograms.
        Console.Write("Please enter you weight in kilograms: ");
        // By default a parse method of type double could "get" different number of arguments (comma-separated values in braces).
        // The first value "Console.ReadLine()" would become a string we want to pars.
        // And the second value "cultureEnUs" is the object which holds a reginal standard.
        weightInKilograms = double.Parse(Console.ReadLine(), cultureEnUs);
        // Ask user to input his height in meters.
        Console.Write("Please enter you height in meters: ");
        /* Read height from user, parse it to double and store the value in the heightInMeters variable. Again, use object cultureEnUs as the second argument. */
        heightInMeters = double.Parse(Console.ReadLine(), cultureEnUs);

        // Display additional empty line for clearer output view.
        Console.WriteLine();

        // Display the user's body mass index.
        Console.WriteLine($"Your body mass index is: {weightInKilograms / (heightInMeters * heightInMeters)}");

        // Display additional empty line for clearer output view.
        Console.WriteLine();

        // Display reference information.
        Console.WriteLine("BMI VALUES");
        Console.WriteLine("Underweight:  less than 18.5");
        Console.WriteLine("Normal:       between 18.5 and 24.9");
        Console.WriteLine("Overweight:   between 25 and 29.9");
        Console.WriteLine("Obese:        30 or greater.");

    } // Exit Main's method body.
} // Exit class body.