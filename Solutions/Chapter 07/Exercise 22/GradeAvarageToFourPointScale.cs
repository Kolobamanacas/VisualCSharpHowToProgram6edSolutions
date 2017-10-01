// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 22 (07.28) Converting Grade Avarages to a Four-Point Scale.

/* After some previous exercises this one seems too easy, so at the beginning I thought that I don't understand the task correctly. But I didn't find any other interpretation options, so I decide to leave the solution as is. */

using System;

class GradeAvarageToFourPointScale
{
    static void Main()
    {
        // Print a wellcome message.
        Console.WriteLine("The app converts a student's avarage grade to a four-point scale.");
        // Use separate method to read a value of average grade.
        int average = GetAnAverageValue();
        // Print the result.
        Console.WriteLine($"A student's average grade {average} four-point scale equivalent is: {QualityPoints(average)}");
    }

    /* Special method that asks for a number, checks it's correctness and return it. */
    static int GetAnAverageValue()
    {
        Console.Write("Please enter a student's average (0 to 100): ");
        int average = int.Parse(Console.ReadLine());

        while (average < 0 || average > 100)
        {
            Console.WriteLine("The average should be within 0 to 100 range.");
            Console.Write("Please enter a student's average (0 to 100): ");
            average = int.Parse(Console.ReadLine());
        }

        return average;
    }

    /* A static method "QualityPoints()" takes an integer as an argument and returns it's four-point scale equivalent. */
    static int QualityPoints(int average)
    {
        if (average >= 90)
        {
            return 4;
        }
        else if (average >= 80)
        {
            return 3;
        }
        else if (average >= 70)
        {
            return 2;
        }
        else if (average >= 60)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}