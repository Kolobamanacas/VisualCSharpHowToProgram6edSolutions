// Solution to exercises from "C# How to Program 6th edition".
// Chapter 03.
// Exercise 22 (03.28) Digits of an Integer.

// Join System namespace to be able to use Console class.
using System;

// Declare a class to perform our task.
class DigitsOfAnInteger
{
    // Declare the Main method - app's entry point.
    static void Main()
    {
        // Declare a variable of integer type to store the number user would input in computer's memory.
        int number;
        
        // Ask user to enter a five-digit number.
        Console.Write("Please enter a five-digit number: ");
        // Get line of text from user's input, cast it to ineger type and assign the value to the variable number.
        number = int.Parse(Console.ReadLine());
        
        // Write additional empty line for clearer output view.
        Console.WriteLine();
        
        /* Ok now. The algorithm is as follows. To print the highest (leftmost) digit of a number we simply need to divide it by integer which is multiple of ten and have 1 as its leftmost digit (i.e. 10, 100, 1000, etc). This integer should have the same number of following zeros as the original number's number of digits to the right of digit we want to print. The only exception is one-digit number, which we could print directly.
        
        It sound difficult but let's look at the example. Let's say we want to print the first digit of number 234 (two hundreds thirty four) which obviuosly equals 2. Number 234 has two digits at the right from the leftmost digit (3 and 4). This means that our multiple of ten divisor should have two zeros at the right of 1, so the divisor is 100. As soon as all the numbers are integers, the result of division of integer by integer is always integer too. This leads us to 234 / 100 = 2. Just what we've looking for.
        
        But what about the rest digits? To print them with the same technique we need to somehow get rid of leftmost digit we've already printed. This is easy to do with the reminder operator and the same devisor. 234 % 100 = 34. See? Now we have 3 as the leftmost digit which we can easily print using the same division technique. But this time the divisor would be one zero less. 34 / 10 = 3.
        
        Now we can take reminder (34 % 10 = 4) and print it directrly with as a last digit.
        
        Let's write some code which would follow the algotithm and print digits of five-digit number. */
        
        Console.WriteLine($"The digits of number {number} are:");
        Console.WriteLine($"{number / 10000}  {(number % 10000) / 1000}  {(number % 1000) / 100}  {(number % 100) / 10}  {number % 10}");
        
        /* When one enters more than five digits as a number, the first printed digit includes all higher digits as soon is quotient of division by 10000 is larger than one digit.
        When one enters less than five digits as a number, all missed higher digits are replaced with zeros because quotient of number less than 10000 divided by 10000 always equals to 0. */
    } // Exit Main's method body.
} // Exit class body.