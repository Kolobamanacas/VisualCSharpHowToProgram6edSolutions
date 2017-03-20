// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 23(16) (05.32) Display a Decimal Equivalent of a Binary Number.

using System;

class BinaryToDecimal
{
    static void Main()
    {
        /* This time the problem is more tricky. I didn't find solution better than consider a binary number as a decimal during the separation (or picking of) a digit from a whole number. The binary number would always have 1 as the leftmost digit. This means that a number with "n" digits would always leave one if divided by the lowes number with the same number of digits ("n") and it would always leave zero if divided by the lowest number with "n + 1" number of digits. For example 1010 / 1000 = 1 and 1010 / 10000 = 0. These properties give us the possibility to find out the end of number entered by a user while searching from left to right. */
        
        /* A local variable to store a divider, which we would use to find out whether we read all digits from a binary number. */
        int divider = 1;
        /* A local variable to store a multiplier which we would use to "convert" every binary digit to a decimal digit to get a resulting decimal value. */
        int multiplier = 1;
        /* A local variable to store a binary number from which we would cut its rightmost digit every time during a loop. We need two variables to hold user input because one would hold the original value till the end of runtime and the second would be shrinked to 0 at the end of the loops. */
        int binaryNumberToShrink = 0;
        // A local variable to store a resulting decimal number.
        int decimalEquivalent = 0;
        
        // Welcome message.
        Console.WriteLine("Binary to decimal converter.");
        Console.WriteLine();
        // Ask user to enter a number.
        Console.Write("Please enter a binary number: ");
        int binaryNumber = int.Parse(Console.ReadLine());
        // Write the new binary value to the second local variable.
        binaryNumberToShrink = binaryNumber;
        
        /* Now the "binaryNumber" divided by the initial "divider" would leave zero in two cases: when "binaryNumber" equals to zero from the beginning and when "divider" become larger than the "binaryNumber" during the looping. As soon as initial value of the "decimalEquivalent" is zero, we are ok with the first case.
        
        Every digit of a binary number is a power of two (i.e. 0, 1, 2, 4, 8, 16, 32, etc). So to get the resulting decimal number we need two operations to be done. The first one is to pick up a digit from a whole number. For simplicity we would always pick up the rightmost digit and then shrink an initial value. Picking the rightmost digit up can be done with the reminder after division by 10 operation. The reminder after division of the "binaryNumberToShrink" by 10 would always leave the rightmost digit of the "binaryNumberToShrink". The second one is to multiply a picked number by a power of two related to digit's position. We would do these operations for every digit in a number.
        
        If you still have some troubles in understanding of what's going on, carefully read the hint in the textbook, then read the code to understand how does it work. */
        
        while (binaryNumber / divider != 0)
        {
            decimalEquivalent += (binaryNumberToShrink % 10) * multiplier;
            
            divider *= 10;
            multiplier *= 2;
            binaryNumberToShrink /= 10;
        }
        
        Console.WriteLine($"The decimal equivalent of the binary number {binaryNumber} is: {decimalEquivalent}.");
        
        /* Notice that provided code would work correctly only when user enters correct (i.e. binary) number. */
    }
}