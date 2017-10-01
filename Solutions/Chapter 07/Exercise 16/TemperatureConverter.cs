// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 16 (07.22) Temperature Convertions.

using System;
using System.Globalization;

class TemperatureConverter
{
    static void Main()
    {
        // Initialize a local variable as a new object of class "CultureInfo" to use it during input to get dot as decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");
        // Wellcome message and explanations menu.
        Console.WriteLine("Wellcome to temperature convertor.");
        Console.WriteLine("Write \"cf\" if your want to convert celsius to fahrenheit.");
        Console.WriteLine("Write \"fc\" if your want to convert fahrenheit to celsius.");
        // Use a string local variable "mode" to call different methods depending on the mode.
        string mode = Mode();
        // Get a temperature value from a user.
        Console.Write("Enter the temperature value: ");
        double temperature = double.Parse(Console.ReadLine(), cultureEnUs);

        /* Display different output depending of the "mode's" value. Again we need explicilty use class "CultureInfo" to get dot as decimal mark both during input and output. */
        if (mode == "cf")
        {
            Console.WriteLine($"The fahrenheit equivalent of {temperature.ToString(cultureEnUs)} is "
                + $"{Fahrenheit(temperature).ToString(cultureEnUs)}.");
        }
        if (mode == "fc")
        {
            Console.WriteLine($"The celsius equivalent of {temperature.ToString(cultureEnUs)} is "
                + $"{Celsius(temperature).ToString(cultureEnUs)}.");
        }

        Console.WriteLine("The app ends it's work.");
    }

    // Method asks, checks correctness and returns mode as a string value.
    static string Mode()
    {
        Console.Write("Enter the desired mode (\"cf\" or \"fc\"): ");
        string mode = Console.ReadLine();

        while (mode != "cf" && mode != "fc")
        {
            Console.WriteLine("The mode should be \"cf\" or \"fc\".");
            Console.Write("Enter the desired mode (\"cf\" or \"fc\"): ");
            mode = Console.ReadLine();
        }

        return mode;
    }

    /* Both static methods takes double value as arguments and return double value of temperature celsius-fahrenheit equivalent. */
    static double Celsius(double f) => 5.0 / 9.0 * (f - 32);
    static double Fahrenheit(double c) => 9.0 / 5.0 * c + 32;
}