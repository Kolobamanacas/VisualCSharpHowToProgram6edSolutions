// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 05 (08.10) Sales Comissions.

using System;

class SalesComissions
{
    static void Main()
    {
        // Print a wellcome message.
        Console.WriteLine("The app prints sales commissions statistic.");
        // An array of integers which contains 9 elemets with default value 0.
        int[] salaries = new int[9];
        // A local variable "sales" to keep sales of each salesperson.
        int sales = 0;

        // While a user doesn't enter "-1", increment values of appropriate cells in the salaries array.
        do
        {
            // Ask user to enter sales of a salesperson for a week.
            Console.Write("Enter sales for the next salesperson for a week (-1 to exit): ");
            // Get sales from a user.
            sales = int.Parse(Console.ReadLine());

            // Handle wrong input. Sales can't be less than 0 and "-1" is sentinel value.
            if (sales < -1)
            {
                // So if a user enters any number less than 0 and sentinel value, print error message and start another loop.
                Console.WriteLine("Sales value should be an integer greater or equal to 0 (or -1 to exit).");
                continue;
            }
            else if (sales == -1)
            {
                // If a user enters the sentinel value - terminate a loop.
                break;
            }
            else if (sales >= 0)
            {
                // If a user enters correct sales rate, then increment an appropriate value in the "salaries" array.
                /* We are actually interested in salary which salesperson get, not in his/her sales. So we get 9% of sales by multiplying sales by 0.09. This would implicitly case it to double, so we need to manually cast it back to int shrinking fractional part. */
                int salesPercent = (int)(sales * 0.09);

                /* As soon as we don't include $200 yet, the division of salary by 100 would leave exact number we need to use as indices for an array. This is the case for all cases except the last one ($800+), so we process it individually. */
                if (salesPercent >= 800)
                {
                    ++salaries[8];
                }
                else
                {
                    ++salaries[salesPercent / 100];
                }
            }
        } while (sales != -1);

        Console.WriteLine();
        // Print a summary header.
        Console.WriteLine("Salesperson salary summary:");

        // Count 9 times from 0 to 8.
        for (int count = 0; count < salaries.Length; ++count)
        {
            // Print headers for an output.
            if (count == 8)
            {
                // Print header for the last case, which we again process individually.
                Console.Write("$1000 and over: ");
            }
            else
            {
                /* Here we use "count" to print headers by adding 2 and multiplying the result by 100 in first part and by adding 3 then multipying the result by 100 and subtracting 1 from the result in the second part. */
                Console.Write($"      ${(count + 2) * 100}-{((count + 3) * 100) - 1}: ");
            }

            // Print an value of an element of the "salaries" array with index equals to "count".
            Console.WriteLine($"{salaries[count]}");
        }
    }
}