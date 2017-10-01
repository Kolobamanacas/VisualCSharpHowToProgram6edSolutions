// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 26 (07.32) Distance Between Two Points.

/* Thanks to the first link in a Google, we know that The distance formula is derived from the Pythagorean theorem. To find the distance between two points (x1,y1) and (x2,y2), all that you need to do is use the coordinates of these ordered pairs and apply the following formula:
Distance = Square root of ((x2 - x1)^2 + (y2 - y1)^2).
The symbol "^2" here means second power of an expression. And actually the position of x2 and x1 the same as position of y2 and y1 inside parenthesis is not important because squaring the result would give a positive number anyway.
http://www.mathwarehouse.com/algebra/distance_formula/index.php */

using System;
using System.Globalization;

class DistanceBetweenTwoPoints
{
    static void Main()
    {
        // Initialize a local variable as a new object of class "CultureInfo" to use it during input to get dot as decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;
        // Local variables to store point's coordinates.
        double x1 = 0.0;
        double y1 = 0.0;
        double x2 = 0.0;
        double y2 = 0.0;
        // Print a wellcome message.
        Console.WriteLine("The app calculates the distance between two point with given coordinates.");
        
        while (toProceed)
        {
            // Read coordinates values from a user.
            Console.Write("Enter the x1 value of point 1: ");
            x1 = double.Parse(Console.ReadLine(), cultureEnUs);
            Console.Write("Enter the y1 value of point 1: ");
            y1 = double.Parse(Console.ReadLine(), cultureEnUs);
            Console.Write("Enter the x2 value of point 2: ");
            x2 = double.Parse(Console.ReadLine(), cultureEnUs);
            Console.Write("Enter the y2 value of point 2: ");
            y2 = double.Parse(Console.ReadLine(), cultureEnUs);

            // Print results using string interpolation and method "ToString()" with "cultureEnUs" as a parameter, to get dot as a decimal mark in a double values.
            Console.WriteLine($"The distance between point 1 ({x1.ToString(cultureEnUs)}, {y1.ToString(cultureEnUs)}) "
                + $"and point 2 ({x2.ToString(cultureEnUs)}, {y2.ToString(cultureEnUs)}) is: "
                + $"{Distance(x1, y1, x2, y2).ToString(cultureEnUs)}");

            Console.WriteLine();
            // Check whether a user wants to continue.
            toProceed = ToProceed();
        }
    }

    /* "ToProceed()" method asks a user whether he/she wants to calculate antoher distance. If a user enters "yes" then the method returns the value of "true" and otherwise it returns "false". */
    private static bool ToProceed()
    {
        Console.Write("Do you want to calculate antoher distance (\"yes\" or \"no\"): ");
        string answer = Console.ReadLine();

        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write("Do you want to calculate antoher distance (\"yes\" or \"no\"): ");
            answer = Console.ReadLine();
        }

        if (answer == "yes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /* Private static expression-bodied method "Distance()" takes four double values of two points coordinates as arguments and retuns the distance between these points. It uses static method "Sqrt()" of class "Math" to calculate square root from the whole expression. It also uses static method "Pow()" of the same class "Math" to rise an expression to the power of 2. */
    private static double Distance(double x1, double y1, double x2, double y2) =>
        Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
}