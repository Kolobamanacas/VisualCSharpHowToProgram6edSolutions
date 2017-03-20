// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 30(23) (05.39) Infinite Series: Mathematical Constant e.

using System;

class Factorials
{
    // This method would get an integer number as an argument and return its factorial.
    public static int GetFactorial(int number)
    {        
        // Factorial of zero is one.
        if (number == 0)
        {
            number = 1;
        }
        
        int counter = 1;
        int numberFactorial = number;
        
        while (counter < number)
        {
            numberFactorial *= (number - counter);
            ++counter;
        }

        return numberFactorial;        
    }
}