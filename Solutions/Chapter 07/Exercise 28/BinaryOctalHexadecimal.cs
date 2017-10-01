// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 28 (07.34) Binary, Octal and Hexadecimal.

using System;

class BinaryOctalHexadecimal
{
    static void Main()
    {
        /* Initialize local variable "OutString" to store equivalent of numbers with different base. We could print these numbers directly from methods, but implemented approach helps us to make nice columns in the output. */
        string outString = "";

        // For 256 numbers from 1 to 256.
        for (int number = 1; number <= 256; ++number)
        {
            // Print a number with a decimal base, aligned to the left with "column size" equals to 4.
            Console.Write($"{number, 4}");
            // Call method "PrintNumberSystem()" that writes "number" in the base of 2 to the "outString" variable.
            PrintNumberSystem(number, 2, ref outString);
            // Print taken number string with indentation of 12.
            Console.Write($"{outString, 12}");
            // Make "outString" empty before the next use.
            outString = "";
            
            /* The rest code is very similar to the previous, with only difference - the base, given as argument, is different. It equals to 8 in the second method "PrintNumberSystem()" call and to 16 in the third. */

            PrintNumberSystem(number, 8, ref outString);
            Console.Write($"{outString, 6}");
            outString = "";
            
            PrintNumberSystem(number, 16, ref outString);
            Console.Write($"{outString, 6}");
            outString = "";
            Console.WriteLine();
        }
    }

    /* private static method "PrintNumberSystem()" takes three arguments: number, to be converted to another number system with a base, given as the second argument and string passed by reference to write the result value to. To convert a decimal number to a number with different base this number should be divided to the base. The remainder of this first division would be the last digit in the following output. The quotient of the first division is again divided by the base and again the remainder would be the second-to-last digit in the output. These divisions continue until the quotient becomes less then the base. In this case, the remainder after division (which in this case is the number itself) becomes the first digit of the output number. Here again the recursion helps us to complete a task. The base case in this case would be the case when quotient of previous divisions become less than number system base. In this case all we need to do is to concatinate the remainder after divison of this quotient by a base, i.e. the quotient itself with "outString" string variable. In other cases we recursivle call the method itself changing the number to the quotient of division number by the number system base, then concatinate the remainder of this division with "outString" string variable. */
    private static void PrintNumberSystem(int number, int numberBase, ref string outString)
    {
        if (number < numberBase)
        {
            outString += number.ToString("x");
        }
        else
        {
            PrintNumberSystem(number / numberBase, numberBase, ref outString);
            outString += (number % numberBase).ToString("x");
        }
    }
}