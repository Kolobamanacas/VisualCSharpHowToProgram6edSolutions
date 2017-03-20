// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 13(06) (05.22) Tabular Output.

using System;

class TabularOutput
{
    static void Main()
    {
        // We need to print a tabbed table of local variable n and it's product with 10, 100 and 1000.
        // First we initialize (create) local variable of type int and set its value to 1.
        int n = 1;
        
        // Print the label values separater with tab escape sequance "\t".
        Console.WriteLine("N\t\t10 * N\t\t100 * N\t\t1000 * N");
    
        Console.WriteLine();
        
        // Use the number itself as a counter for doing the while loop body's statements for five times.
        while (n <= 5)
        {
            // Print n itself and results of multiplication by 10, 100 and 1000 delimited with tab escape sequences "\t".
            Console.WriteLine($"{n}\t\t{n * 10}\t\t{n * 100}\t\t{n * 1000}");
            // Add one to the n's value.
            ++n;
        }
    }
}