// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 14(07) (05.23) Find the Two Largest Numbers.

using System;

class FindTheTwoLargestNumbers
{
    static void Main()
    {
        // Print a welcome message.
        Console.WriteLine("The two largest number finder.");
        Console.WriteLine();
        
        // Initialize variables.
        int counter = 1;
        int number = 0;
        int firstLargest = 0;
        int secondLargest = 0;
        
        // Read the first number and write it as the largest one.
        Console.Write("Please enter the first number: ");
        firstLargest = int.Parse(Console.ReadLine());
        
        /* Now for our loop to work correctly we need to set fist two numbers in the correct oreder, for the firstLargest be greater than the secondLargest. */
        
        // Thus we read second value to a "number" local variable.
        Console.Write("Please enter the next number: ");
        number = int.Parse(Console.ReadLine());
        
        // Then we compare this number with current "firstLargest".
        if (number > firstLargest)
        {
            // And if this number is larger than current "firstLargest" we make "firstLargest" the "secondLargest".
            secondLargest = firstLargest;
            // And the "number" become the "firstLargest".
            firstLargest = number;
        }
        else
        {
            // But if this number less than the "firstLargest" we simply write it as the "secondLargest".
            secondLargest = number;
        }
        
        /* As mentioned in the exercise, user shouldn't enter the same number twice, but with implemented approach the software would correctly handle both cases.
        
        Now we are ready for the loop implementing. We already got two numbers from user, which means, there are only eight left. So for eight times or while counter is less than or equal to 8. */
        while (counter <= 8)
        {
            // Read the next number from a user.
            Console.Write("Please enter the next number: ");
            number = int.Parse(Console.ReadLine());
            
            /* Here we implement the same logic as we did above. As soon as the "firstLargest" is always larger than the "secondLargest", if the new "number" is larger than the "firstLargest" we write previous "firstLargest"'s value to the "secondLargest" variable and write this "numbers"'s value as the new "firstLargest". In opposite, if new "numbers"'s value is less than the "firstLargest" we simply compare it with the "secondLargest" and replace the "secondLargest" with the new "numbers"'s value if the "secondLargest" is less. */
            if (number > firstLargest)
            {
                secondLargest = firstLargest;
                firstLargest = number;
            }
            else if (number > secondLargest)
            {
                secondLargest = number;
            }
            
            // Increment counter by one.
            ++counter;
        }
        
        Console.WriteLine();
        // Print two largest numbers and farewell message.
        Console.WriteLine($"The first largest number is: {firstLargest}");
        Console.WriteLine($"The second largest number is: {secondLargest}");
        Console.WriteLine();
        Console.WriteLine("Program is terminated.");
    }
}