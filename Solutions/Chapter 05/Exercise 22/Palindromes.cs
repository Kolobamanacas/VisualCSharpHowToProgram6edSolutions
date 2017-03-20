// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 20(15) (05.31) Palindromes.

using System;

class Palindromes
{
    static void Main()
    {
        // Print a welcome message.
        Console.WriteLine("Palindrome determiner.");
        Console.WriteLine();
        
        // Read a number from a user.
        Console.Write("Please enter a five-digit number: ");
        int number = int.Parse(Console.ReadLine());
        
        /* So how do we know whether a number contains exectly five digits? That could be done by checking two conditions: whether a number larger than the maximum possible five-digit number and whether it is lower than the minimum possible five-digit number. If any of these conditions is true, the number is not a five-digit one. An easy way to check these conditions is to use division.
        
        For the first case: the minimum possible six-digit number is 100000. This means that division of any five-digit number by 100000 should always result in 0 and division of any six-digit number by 100000 should always result in at least 1. Using this fact we could know that if a number devided by 100000 would not give a zero, this number is larger than a five-digit one.
        
        For the second case: the logic is similar. The lowest five-digit number is 10000, so any five-digit number divided by 10000 should result in at least 1. This means that if a number divided by 10000 result in zero it is lower than a five-digit one.
        
        Here again I didn't find a better solution rather than using a condition statement ||. The condition statement || returns true when at least one of it's conditions returns true. The condition statements are well explained in chapter 6. */
        while ((number / 100000) != 0 || (number / 10000) == 0)
        {
            Console.WriteLine($"The number {number} is not a five-digit number.");
            Console.Write("Please enter a five-digit number: ");
            number = int.Parse(Console.ReadLine());
        }
        
        /* This task is pretty simple because we have a number with fixed length of five digits. This means that we need to compare the first digit with the last one and the second digit with the fourth one. If in both comparisons numbers would be equal - the whole number is a palindrome.
        
        Now how do we "separate" any digit from other digits inside a number? This can be done with division and reminder operations. For example a number 65703 divided by 10000 would leave 6 which is the leftmost digit. And a reminder of the same 65703 number divided by 10 is 3 which is le rightmost digit. The second and the fourth digits could be separated with two-steps operations. For the second digit they are division (65703 / 1000 = 65) then reminder (65 % 10 = 5). And for the fourth digit they are reminder (65703 % 100 = 3) then division (3 / 10 = 0). */
        if (number / 10000 == number % 10)
        {
            if (number / 1000) % 10 == (number % 100) / 10)
            {
                Console.WriteLine($"The number {number} is a palindrome.");
            }
        }
        else
        {
            Console.WriteLine($"The number {number} is not a palindrome.");
        }
    }
}