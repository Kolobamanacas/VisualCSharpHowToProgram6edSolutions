// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 08(01) (05.17) Gas Mileage.

using System;

class GasMileage
{
    static void Main()
    {
        // Local variables used for results output need to be initialized to zero at the declaration step.
        int tankfulsCount = 0;
        double milesPerGallonTotal = 0;
        
        // Read number of miles driven (could be sentinel) from a user.
        Console.Write("Please enter miles driven for the first tankful (use -1 to finish): ");
        int milesDriven = int.Parse(Console.ReadLine());
        
        Console.WriteLine();
        
        // If entered value is a sentinel, print corresponding messege.
        if (milesDriven == -1)
        {
            Console.WriteLine("No information about tankfuls was provided.");
        }
        
        // While user enters correct miles driven numbers.
        while (milesDriven != -1)
        {
            // Read number of gallons used.
            Console.Write("Please enter gallons used: ");
            int gallonsUsed = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
            
            // Add 1 to the total number of tankfuls.
            ++tankfulsCount;
            
            
            /* The following code could be simplier, but I decide to make the output a bit more natural so the number endings would correspond the numbers. We have 4 general cases: "st" for the 1st, "nd" for the 2nd, "rd" for the 3rd and "th" for all other cases. We can easily get the last digit of any integer number by getting its reminder after devision by 10. So all four cases are similar except the endings of tankful count numbers. */
            if (tankfulsCount % 10 == 1)
            {
                Console.WriteLine(
                    $"Miles per gallon consumption for the {tankfulsCount}st tankful: {((double)milesDriven / gallonsUsed):F}");
            }
            else if (tankfulsCount % 10 == 2)
            {
                Console.WriteLine(
                    $"Miles per gallon consumption for the {tankfulsCount}nd tankful: {((double)milesDriven / gallonsUsed):F}");
            }
            else if (tankfulsCount % 10 == 3)
            {
                Console.WriteLine(
                    $"Miles per gallon consumption for the {tankfulsCount}rd tankful: {((double)milesDriven / gallonsUsed):F}");
            }
            else
            {
                Console.WriteLine(
                    $"Miles per gallon consumption for the {tankfulsCount}th tankful: {((double)milesDriven / gallonsUsed):F}");
            }
            
            // Add number of current tankful consumption to the total.
            milesPerGallonTotal += (double)milesDriven / gallonsUsed;
            
            // Print total consumption for all tankfuls to the moment.
            Console.WriteLine($"Total miles per gallon usage to the moment: {milesPerGallonTotal:F}");
            
            Console.WriteLine();
            
            // Before the while loop ends, read number of miles driven (could be sentinel) for the next tankful.
            Console.Write("Please enter miles driven for the next tankful (use -1 to finish): ");
            milesDriven = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
        }
        
        Console.WriteLine("Sentinel value (-1) is entered. Program is terminated.");
    }
}