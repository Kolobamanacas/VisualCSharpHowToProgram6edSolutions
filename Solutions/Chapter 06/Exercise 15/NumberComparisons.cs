// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 15 (06.19).

/* The simple exercise to practice in understanding logical and comparision operations. The following WriteLine statements would print either true or false depending on conditions. This exercise could be done simply "in mind", but I decide to write it down just in case. So, here we go. */

using System;

class NumberComparisons
{
    static void Main()
    {
        // Initial values of variables.
        int i = 1;
        int j = 2;
        int k = 3;
        int m = 2;

        // Let's also print them to see them clearly in an output.
        Console.WriteLine($"i is {i}");
        Console.WriteLine($"j is {j}");
        Console.WriteLine($"k is {k}");
        Console.WriteLine($"m is {m}");
        Console.WriteLine();

        // Would return True as soon as "i" is indeed equal to 1.
        Console.WriteLine($"i == 1: {i == 1}");
        // Would return False as soon as "j" is not equal to 3.
        Console.WriteLine($"j == 3: {j == 3}");
        // The whole logical AND condition is true only when all of it's subconditions are true. Otherwise it's false.
        // "i" equals to 1, which means (i >= 1) is true.
        // "j" equals to 3, which is less than 4, which in turn means that (j < 4) is true.
        // The statement would return True as soon as true and true is true. True story bro. :)
        Console.WriteLine($"(i >= 1) && (j < 4): {(i >= 1) && (j < 4)}");
        // Again, "m" equals to 2, which is less than 99. (m <= 99) is true.
        // But "k" is 3 and 3 is not less than 2. So (k < m) is false.
        // True and false is false. The statement would return False.
        Console.WriteLine($"(m <= 99) && (k < m): {(m <= 99) && (k < m)}");
        // The whole logical OR condition is false only when all of it's subconditions are false. Otherwise it's true.
        // 2 >= 1 is true, so (j >= i) is true.
        // And actually a compiler would not check other conditions. The statement would return True.
        Console.WriteLine($"(j >= i) || (k == m): {(j >= i) || (k == m)}");
        /* Here we see a binary OR condition. A compiler executes both statements no matter what. For example if some value would be assigned to a variable in the second statement and the first statement would be true, the value would not be assigned as soon as the second statement would not be execute with ordinary OR. But with binary OR it would be. Here we have no assignement operations insede the statements, so here binary OR behaves as usual one. */
        // k + m = 5 and 5 is not less than 2, so the first condition is false.
        // 3 - j = 1 and 1 is not greater or equals to k (which equals to 3). The second condition is false.
        // As soon as both conditions are false, the result is False.
        Console.WriteLine($"(k + m < j) | (3 - j >= k): {(k + m < j) | (3 - j >= k)}");
        // The negation (!) condition reverse the initial condition.
        // k = 3, m = 2 and 3 > 2 is True.
        // Reversed value of ture is false. The result is False.
        Console.WriteLine($"!(k > m): {!(k > m)}");
    }
}