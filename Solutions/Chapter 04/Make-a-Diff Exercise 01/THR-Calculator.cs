// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Making-a-Difference Exercise 01 (04.14) Target-Heart-Rate Calculator.

using System;

class THRCalculator
{
    static void Main()
    {
        /* We could insert user information input right into paranthesis during an object creation step, but in that case the code would be harder to read. So let's create variables to store information passed by user and then use these variables as parameters in paranthesis during an object creation. */
        
        // Prompt user to enter first name.
        Console.WriteLine("Please enter person's first name: ");
        
        // Declare variable to store person's first name and assign user input to it.
        string firstName = Console.ReadLine();
        
        // Prompt user to enter last name.
        Console.WriteLine("Please enter person's last name: ");
        
        // Declare vvariable to store person's last name and assign user input to it.
        string lastName = Console.ReadLine();
        
        // Prompt user to enter birth year.
        Console.WriteLine("Please enter person's birth year: ");
        
        // Get a line of text from user, cast it to integer type and assign the result to a variable just declared.
        int birthYear = int.Parse(Console.ReadLine());
        
        // Prompt user to enter current year.
        Console.WriteLine("Please enter current year: ");
        
        // Get a line of text from user, cast it to integer type and assign the result to a variable just declared.
        int currentYear = int.Parse(Console.ReadLine());
        
        // Create an object of class HeartRates. Use created variables as parameters for class constructor.
        HeartRates person = new HeartRates(firstName, lastName, birthYear, currentYear);
        
        // Print empty line to visualy separete input data from output.
        Console.WriteLine();
        
        // Print person's first name, last name, birth year, age in years, maximum heart rate and target heart rate range.
        Console.WriteLine($"{person.FirstName} {person.LastName}'s data.");
        Console.WriteLine($"Birth year: {person.BirthYear}");
        Console.WriteLine($"Age: {person.AgeInYears} years");
        Console.WriteLine($"Maximum heart rate: {person.MaxHeartRate} BPM");
        Console.WriteLine($"Target heart rate range: {person.MinTargetHeartRate}-{person.MaxTargetHeartRate} BPM");
    }
}