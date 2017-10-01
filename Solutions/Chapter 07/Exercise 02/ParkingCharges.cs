// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Exercise 02 (07.08) Parking Charges.

using System;
using System.Globalization;

class ParkingCharges
{
    static void Main()
    {
        // Initialize a local variable as a new object of class "CultureInfo" to use it during output to get dot as decimal mark.
        CultureInfo cultureEnUs = new CultureInfo("en-US");

        // Print wellcome messages.
        Console.WriteLine("Wellcome to Parking Charges Calculator.");
        Console.WriteLine("You'll be asked for number of parking hours for each customer.");
        // Variable to store running total for the whole day.
        decimal runningTotal = 0;
        // Initialize "toProceed" local variable to "false" to use it as a control statemnt in the do-while loop.
        bool toProceed = false;

        // Ask a user for the next customer info until he/she enters "no".
        do
        {
            // Get parking hours from user.
            int parkingHours = GetParkingHours();
            // Get charges for the current customer.
            decimal customerCharge = CalculateCharges(parkingHours, ref runningTotal);
            // Print charges for current customer and current running total.
            Console.WriteLine($"Current customer charge is: {customerCharge.ToString("0.00", cultureEnUs)}$.");
            Console.WriteLine($"Current running total is: {runningTotal.ToString("0.00", cultureEnUs)}$.");
            Console.WriteLine();
            // Ask a user whether he/she wants to enter parking hours for the next customer.
            toProceed = ToProceed();
        } while (toProceed);
        
    }

    /* "ToProceed()" method asks a user whether he/she wants to enter parking hours for the next customer. If a user enters "yes" then the method returns the value of "true" and otherwise it returns "false". */
    static bool ToProceed()
    {
        Console.Write("Do you want to enter information about the next customer (\"yes\" or \"no\"): ");
        string answer = Console.ReadLine();

        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write("Do you want to enter information about the next customer (\"yes\" or \"no\"): ");
            answer = Console.ReadLine();
        }

        if (answer == "yes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /* "GetParkingHours()" method asks user to enter number of hours, checks whether the entered number is correct and returns this number to a caller method. */
    static int GetParkingHours()
    {
        Console.Write("Please enter the number of parking hours for the customer (1 to 24): ");
        int parkingHours = int.Parse(Console.ReadLine());

        while (parkingHours <= 0 || parkingHours > 24)
        {
            Console.WriteLine("The number of parking hours should be within 1 to 24 range.");
            Console.Write("Please enter the correct number of parking hours for the customer (1 to 24): ");
            parkingHours = int.Parse(Console.ReadLine());
        }

        return parkingHours;
    }

    /* "CalculateCharges()" method calculates the charge amount for the current customer and return it as a decimal. It also adds this value to the "runningTotal" local variable passed there by a reference. */
    static decimal CalculateCharges(int parkingHours, ref decimal runningTotal)
    {
        decimal customerCharge = 0;

        if (parkingHours <= 3)
        {
            customerCharge = (decimal)2;
        }
        else if (parkingHours <= 19)
        {
            customerCharge = (decimal)(2 + ((parkingHours - 3) * 0.5));
        }
        else
        {
            customerCharge = (decimal)10;
        }

        runningTotal += customerCharge;
        return customerCharge;
    }
}