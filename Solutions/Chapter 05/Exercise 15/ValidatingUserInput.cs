// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 15(08) (05.24) Validationg User Input.

using System;

class Analysis
{
    static void Main()
    {
        // initialize variables in declarations   
        int passes = 0; // number of passes       
        int failures = 0; // number of failures   
        int studentCounter = 1; // student counter
        
        // process 10 students using counter-controlled iteration
        while (studentCounter <= 10)
        {
            // prompt user for input and obtain a value from the user
            Console.Write("Enter result (1 = pass, 2 = fail): ");
            int result = int.Parse(Console.ReadLine());
            
            /* Unfortunately I didn't find the way to solve this task without another feature we are unaware yet. It is called conditional operator && and it is well explained in the next chapter. Conditional operator && helps you to check two (or more) conditions at the same time. In case of two conditions the check returns true only if both checked conditions are true. So we add another while loop which loops until the input is incorrect. The correct inputs are 1 and 2, thus we continue looping until user inputs 1 or 2. If you know the way to solve the problem without &&, it would be nice for you to tell me. :) */
            while (result != 1 && result != 2)
            {
                // Display an error message.
                Console.WriteLine("Invalid input.");
                Console.Write("Enter result (1 = pass, 2 = fail): ");
                result = int.Parse(Console.ReadLine());
            }
            
            // if...else is nested in the while statement           
            if (result == 1)
            {
                passes = passes + 1; // increment passes      
            }
            else
            {
                failures = failures + 1; // increment failures
            }
            
            // increment studentCounter so loop eventually terminates
            studentCounter = studentCounter + 1;
        } 
        
        // termination phase; prepare and display results
        Console.WriteLine($"Passed: {passes}\nFailed: {failures}");
        
        // determine whether more than 8 students passed
        if (passes > 8)
        {
            Console.WriteLine("Bonus to instructor!");
        }
    } 
} 