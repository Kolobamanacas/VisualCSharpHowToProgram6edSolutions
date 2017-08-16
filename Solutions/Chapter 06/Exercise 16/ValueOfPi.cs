// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 16 (06.20) Calculation the Value of Pi.

/* TODO:
https://www.codeproject.com/Articles/383871/Demystify-Csharp-floating-point-equality-and-relat */

using System;
using System.Globalization;

class ValueOfPi
{
    static void Main()
    {
        // Initialize a new object of class "CultureInfo" to use it during output to get dot as decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");
        // Initial value of pi.
        double pi = 4;
        /* Below are variables to hold a number of term in which the appropriate value of pi is met for the first time. Explanations are also below. */
        // The number of term where pi equals to 3.14 for the first time.
        int value1FirstMetTerm = 0;
        // The number of term where pi equals to 3.141 for the first time.
        int value2FirstMetTerm = 0;
        // The number of term where pi equals to 3.1415 for the first time.
        int value3FirstMetTerm = 0;
        // The number of term where pi equals to 3.14159 for the first time.
        int value4FirstMetTerm = 0;

        // Loop for the given number of times.
        for (int term = 1; term <= 150000; ++term)
        {
            /* If you look closer to the formula given in the textbook, you could notice that addition and subtractons operations are alternate. You could also notice that divider started from 3 and is incemented by 2 in each term. So we need to get sequence of odd numbers starting from 3, like: 3, 5, 7, 9, etc. Such a behavior could be simulated with adding 1 to the product of 2 and positive integers. Just try it in your head: 1 + (2 * 1) = 3; 1 + (2 * 2) = 5; and so on. But how to decide whether to add or to subtract a value from pi value of the current step? This could be easily done! Fortunately a sequence of integers itself forms a row of changing odd and even numbers. And as soon as the first action is subtraction and the first number in a sequence of dividers is 3 (which in turn got by term = 1) we could do subtraction if a term is odd and addition when a term is even. The last thing to explain here is that term is integer, but we need to get a double to add (or subtract) it to pi. So we cast "term" to double at the very beginning and as soon as during all arithmetic operations operands are converted to the most "high" data type the result would be also a double. If it is hard to get from the first time, just try to read the code and understand what's happening at the every step. */

            // If a term is odd, we subtract.
            if (term % 2 != 0)
            {
                pi -= (4 / (1 + (2 * (double)term)));
            }
            // If a term is even, we add.
            if (term % 2 == 0)
            {
                pi += (4 / (1 + (2 * (double)term)));
            }

            /* Print a number of term and a value of pi for every term. I want a term number to be three digits length, so I cast it to string type using a ".ToString()" method with spercial parameter "D6". The "D" part of the parameter means that converted value is a digit and "6" means that if a number contains less than 6 digits, then appropriate number of zeros is added to the left of the number to be exactly 6 digits length. The similar ".ToString()" method with "cultureEnUs" parameter is used to get a dot as a decimal mark. */
            Console.WriteLine($"Term {(term).ToString("D6")}. Pi = {(pi).ToString(cultureEnUs)}");

            /* Now the interesting part. The question in the textbook is at which term we get 3.14 and other numbers for the first time. Of course we could just run the app and find the first occurrences "manually". But aren't we going to be programmers after all? :) For solving the problem there are two topics you need to be familiar with. The first one is "Floating point numbers equality problem". Unfortunately I didn't find the "ultimate" article covering the problem which at the same time is easy enough to understand. So you could probably need to google it yourself. If you know one, it would be nice enough to send me a link. The second thing is absolute values of numbers. The topic is well explained at wiki:
            https://en.wikipedia.org/wiki/Absolute_value
            
            Sssssooooo. Consider we need to find the first number where the integer part equals to 3 and the first two digits to the right of a dot equalst to 1 and 4. There is neither way to compare a part of a double value nor a "simple" way to truncate the part we are not interested in. But there is a Math.Truncate() method that returns the integer part of a double. Using this method we could multiply "pi" by 100 to "move" all digits we need to the left of decimal mark and truncate the the right part with "Truncate()" method. We would also need to multiply 3.14 by 100 for comparison to be correct. There is also another way to solve the task. When you cast a double value to an integer, the fractial part is truncated implicitly. Let's use both approaches. */

            /* If the term is not found yet and "pi" contains 3.14, then write current term number to the variable "value1FirstMetTerm". We multiply "pi" by 100 to move decimal mark two steps to the right, then truncate the fractial part and then compare it with 314, which is 3.14 multiplied by the same value of 100. Two equal numbers stay equal after both of them multiplied by the same number. */
            if (value1FirstMetTerm == 0
                && Math.Truncate(pi * 100) == 314)
            {
                value1FirstMetTerm = term;
            }
            /* Here instead of using "Math.Truncate()" method we cast "pi" multiplied by 1000 to int, which implicitly truncate a fractial part. Then we compare the result with 3141, which is 3.141 multiplied by 1000. You can use any approach you like. I'll use both just for as an example. */
            if (value2FirstMetTerm == 0
                && ((int)(pi * 1000)) == 3141)
            {
                value2FirstMetTerm = term;
            }
            if (value3FirstMetTerm == 0
                && Math.Truncate(pi * 10000) == 31415)
            {
                value3FirstMetTerm = term;
            }
            if (value4FirstMetTerm == 0
                && ((int)(pi * 100000)) == 314159)
            {
                value4FirstMetTerm = term;
            }
        }

        Console.WriteLine();

        /* After a list of "pi" values, let's print numbers of terms where reqested values first met. If "value1FirstMetTerm" not equals to 0, this means that it was found and assigned, so we can print a number. If it equals to 0, then the value we looked for has never met. */
        if (value1FirstMetTerm != 0)
        {
            Console.WriteLine($"The value of 3.14 is first met at term number: {value1FirstMetTerm}");
        }
        else
        {
            Console.WriteLine("The value of 3.14 is never met.");
        }
        if (value2FirstMetTerm != 0)
        {
            Console.WriteLine($"The value of 3.141 is first met at term number: {value2FirstMetTerm}");
        }
        else
        {
            Console.WriteLine("The value of 3.141 is never met.");
        }
        if (value3FirstMetTerm != 0)
        {
            Console.WriteLine($"The value of 3.1415 is first met at term number: {value3FirstMetTerm}");
        }
        else
        {
            Console.WriteLine("The value of 3.1415 is never met.");
        }
        if (value4FirstMetTerm != 0)
        {
            Console.WriteLine($"The value of 3.14159 is first met at term number: {value4FirstMetTerm}");
        }
        else
        {
            Console.WriteLine("The value of 3.14159 is never met.");
        }

        /* The answers are:
        The value of 3.14 is first met at term number: 118
        The value of 3.141 is first met at term number: 1687
        The value of 3.1415 is first met at term number: 10793
        The value of 3.14159 is first met at term number: 136120 */
    }
}