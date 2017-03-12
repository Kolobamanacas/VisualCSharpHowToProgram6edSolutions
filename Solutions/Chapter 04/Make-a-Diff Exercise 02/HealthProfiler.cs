// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Making-a-Difference Exercise 02 (04.15) Computerization of Health Records.

using System;
using System.Globalization;

class HealthProfiler
{
    static void Main()
    {
        // An object of CultureInfo class to store regional settings. We need it to make dot a decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");

        // Prompt user to enter first name.
        Console.WriteLine("Please enter person's first name: ");

        // Declare variable to store person's first name and assign user input to it.
        string fName = Console.ReadLine();

        // Prompt user to enter last name.
        Console.WriteLine("Please enter person's last name: ");

        // Declare variable to store person's last name and assign user input to it.
        string lName = Console.ReadLine();

        // Prompt user to enter gender.
        Console.WriteLine("Please enter person's gender (use \"true\" for male and \"false\" for female): ");

        // Declare variable to store person's gender and assign user input to it.
        bool gender = bool.Parse(Console.ReadLine());

        // Prompt user to enter birth year.
        Console.WriteLine("Please enter person's birth year: ");

        // Get a line of text from user, cast it to integer type and assign the result to a variable just declared.
        int bYear = int.Parse(Console.ReadLine());

        // Prompt user to enter birth month.
        Console.WriteLine("Please enter person's birth month (in digital form): ");
        
        // Get a line of text from user, cast it to integer type and assign the result to a variable just declared.
        int bMonth = int.Parse(Console.ReadLine());

        // Prompt user to enter birth day.
        Console.WriteLine("Please enter person's birth day (in digital form): ");

        // Get a line of text from user, cast it to integer type and assign the result to a variable just declared.
        int bDay = int.Parse(Console.ReadLine());

        // Prompt user to enter height.
        Console.WriteLine("Please enter person's height (in meters): ");

        /* Get a line of text from user, cast it to double type and assign the result to a variable just declared. We use cultureEnUs object as a second parameter of Parse method to make sure that the application would recognise number with dot as a decimal mark. */
        double height = double.Parse(Console.ReadLine(), cultureEnUs);

        // Prompt user to enter weight.
        Console.WriteLine("Please enter person's weight (in kilograms): ");

        /* Get a line of text from user, cast it to double type and assign the result to a variable just declared. We use cultureEnUs object as a second parameter of Parse method to make sure that the application would recognise number with dot as a decimal mark. */
        double weight = double.Parse(Console.ReadLine(), cultureEnUs);

        /* Now, when we got all the information we needed, we can create an object of class HealthProfile and pass all got values as parameters to class constructor. */
        HealthProfile person = new HealthProfile(fName, lName, gender, bYear, bMonth, bDay, height, weight);

        // Print empty line for clearer output.
        Console.WriteLine();

        // Display person's first and last name.
        Console.WriteLine($"Health profile for {person.FirstName} {person.LastName}");
        
        // To display person's gender we need to use if construction. I hope that the next chapter will introduce IF-ELSE statement. :)
        // If person is male.
        if (person.Gender == true)
        {
            Console.WriteLine("Gender: Male");
        }
        // If person is not male (i.e. female).
        if (person.Gender == false)
        {
            Console.WriteLine("Gender: Female");
        }

        /* Display person's birth date using international standard date notation (YYYY-MM-DD).
        https://en.wikipedia.org/wiki/ISO_8601 */
        Console.WriteLine($"Birth date: {person.BirthYear}-{person.BirthMonth}-{person.BirthDay}");

        // Display person's height and weight.
        Console.WriteLine($"Height: {(person.HeightInMeters).ToString(cultureEnUs)}m");
        Console.WriteLine($"Weight: {person.WeightInKilograms}kg");
        Console.WriteLine($"Age: {person.AgeInYears()} years");
        Console.WriteLine(
            $"Body mass index (BMI): {(person.WeightInKilograms / (person.HeightInMeters * person.HeightInMeters)).ToString(cultureEnUs)}");
        Console.WriteLine($"Maximum heart rate: {person.MaxHeartRate()}");
        Console.WriteLine($"Target heart rate range: {person.MinTargetHeartRate()}-{person.MaxTargetHeartRate()}");

        // Print empty line for clearer output.
        Console.WriteLine();

        // Display BMI reference information.
        Console.WriteLine("BMI values");
        Console.WriteLine("Underweight:   less than 18.5");
        Console.WriteLine("Normal:        between 18.5 and 24.9");
        Console.WriteLine("Overweight:    between 24.9 and 29.9");
        Console.WriteLine("Obese:         30 or greater");
    }
}