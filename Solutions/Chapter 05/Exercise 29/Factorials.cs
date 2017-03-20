// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 29(22) (05.38) Factorials.

using System;

class Factorials
{
    static void Main()
    {
        /* Let's just visualize the given algorithm. We would ignore the case when a number equals to 0, cause factorial of zero is 1 and a number multiplied by 1 is always the same number. We would use three local variables. The "number" would store a number entered by a user. The "numberFactorial" would at the end store the factorial of the "number". The "counter" would initially hold zero, but would be incremented by 1 giving a new multiplier for resulting "numberFactorial" at every loop. */
        
        Console.Write("Please enter a nonnegative integer number to deterine its factorial: ");
        int number = int.Parse(Console.ReadLine());
        
        // Factorial of zero is one.
        if (number == 0)
        {
            number = 1;
        }
        
        int counter = 1;
        int numberFactorial = number;
        
        Console.WriteLine();
        
        // The first part of output.
        Console.Write($"{number}! = {number}");
        
        while (counter < number)
        {
            numberFactorial *= (number - counter);
            Console.Write($" * {number - counter}");
            ++counter;
        }
        
        // The last part of output.
        Console.Write($" = {numberFactorial}");
    }
}