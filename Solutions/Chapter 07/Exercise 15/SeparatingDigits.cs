// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 15 (07.21) Separating Digits.

/* Here we meet recustion for the first time. It always was a weak point for me, but there is no subject one can't learn by spending appropriate time and efforts. */

using System;

class SeparatingDigits
{
    static void Main()
    {
        Console.WriteLine("The app will separate every digit in the provided integer with two spaces.");
        Console.Write("Please enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Your separated number is:");
        DisplayDigits(number);
    }

    /* How does the method work? First of all it is a static method that takes one integer as argument and returns no value. Then it has two behaivoral scripts. When the base case (number / 10 == 0) occurs the method prints the reminder after "number" is divided by 10. Otherwise it calls itself modifying the original number argument dividing it by 10 and then prints two spaces and reminder after division of "number" by 10. As it is not very clear from this explanation how the method actually works, let's examine a couple examples.
    
    Example 1. Consider the "number" equals to any number less than 10, let's say 4.
    In this case the when the method called for the first time the "if" condition check (number / 10 == 0) returns "true" and method prints the number 4 direcly and it's work done.

    Example 2. Consider now more complex case, where "number" equals to 42.
    Now "if" condition check returns "false" and expressions inside the "else's" body are executed.
    At this point the method calls another instance of "DisplayDigits()" method but with modified argument, giving 42 / 2, i.e. 4 to called method as an argument. The originally called method still need to execute one more expression, but it has to wait until called method finish it's work.
    The secondary called method takes 4 as an argument and simply prints this number 4 as we saw in the example 1.
    After secondary called method has printed "4", the originally called method could execute it's last statement, to print two spaces and reminder after division of 42 and 10, which in turn is 2.

    Example 3. Now let's say the "number" equals to 742.
    Let's also give called methods numbers, to be able to recognize them easily. So the first called "DisplayDigits()" method (which is called from the "Main()") would be "method1". The method called from "method1" would be "method2", etc.
    - "Method1" gets 742 as an argument, fails if condition test and calls "method2", leaving one statment to execute after "method2" would finish it's job.
    - "Method2" gets 74 as an argument, fails if condition test and calls "method3", leaving one statement to execute after "method3 would finish it's job.
    - "Method3" gets 7 as an argument, succeed in if condition test and prints 7.
    - "Method3" finished it's job and now "method2" could finish it's own and print reminder after division 74 by 10, i.e. it prints 4.
    - At last "method2" finished it's job and now "method1" could print the reminder after division 742 by 10, which is 2.

    Recursion is a powerful tool, though it is complex and tangled topic which usually demands more practice and examples. But I hope that it is clear for now with this simple example. */
    static void DisplayDigits(int number)
    {
        if (number / 10 == 0)
        {
            Console.Write(number.ToString());
        }
        else
        {
            DisplayDigits(number / 10);
            Console.Write($"  {number % 10}");
        }
    }
}