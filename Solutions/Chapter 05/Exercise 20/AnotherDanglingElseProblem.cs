// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 20(13) (05.29) Another Dangling-else Problem.

using System;

class AnotheDanglingElseProblem
{
    static void Main()
    {
        /* Despite the direct term to add only braces, I believe we grown enough to print some additional strings of text for simplier output. */
        
        // Initialize local variables for the first case.
        int x = 5;
        int y = 8;
        
        // Print a case label explaining message.
        Console.WriteLine("Case 1 (x == 5; y == 8):");
        
        /* We have four lines and in the first case we need 1st, 3rd and 4th to be printed. As soon as "x" is 5 and "y" is 8, both checked conditions would be true. This means that we need to put unwanted second line inside the body of else statement of the second inner if and put 3rd and 4th line inside the body of the first outer if but after the bodies of the second if-else statements. */
        if (y == 8)
        {
            if (x == 5)
            {
                Console.WriteLine("@@@@@");
            }
            else
            {
                Console.WriteLine("#####");
            }
            
            Console.WriteLine("$$$$$");
            Console.WriteLine("&&&&&");
        }
        
        Console.WriteLine();
        
        // Print a case label explaining message.
        Console.WriteLine("Case 2 (x == 5; y == 8):");
        
        
        /* This time the variables have the same values but only the first line need to be printed so we put it inside the body of the second innermost if and put all other lines inside the body of else statement. In this case it could be else related to any of if statements. */
        if (y == 8)
        {
            if (x == 5)
            {
                Console.WriteLine("@@@@@");
            }
        }
        else
        {
            Console.WriteLine("#####");
            Console.WriteLine("$$$$$");
            Console.WriteLine("&&&&&");
        }
        
        Console.WriteLine();
        
        // Print a case label explaining message.
        Console.WriteLine("Case 3 (x == 5; y == 8):");
        
        
        /* Logic is equivalent here. We "hide" 2nd and 3rd lines inside of the body of else statement which never be executed while both conditions checked are true. */
        if (y == 8)
        {
            if (x == 5)
            {
                Console.WriteLine("@@@@@");
            }
            else
            {
                Console.WriteLine("#####");
                Console.WriteLine("$$$$$");
            }
            
            Console.WriteLine("&&&&&");
        }
        
        // For the last 4th case the "y" local variable become 7.
        y = 7;
        
        Console.WriteLine();
        
        // Print a case label explaining message.
        Console.WriteLine("Case 3 (x == 5; y == 7):");
        
        
        /* In the last 4th case the first checked condition become false which means that all the body of outermost if statement is not executed. We need to print 2nd, 3rd and 4th lines so lets put them inside the else statement related to the outermost if. The first line would not be executed. */
        if (y == 8)
        {
            if (x == 5)
            {
                Console.WriteLine("@@@@@");
            }
        }
        else
        {
            Console.WriteLine("#####");
            Console.WriteLine("$$$$$");
            Console.WriteLine("&&&&&");
        }
    }
}