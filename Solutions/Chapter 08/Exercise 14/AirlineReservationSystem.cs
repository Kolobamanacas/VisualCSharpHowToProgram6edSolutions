// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 14 (08.19) Airline Reservation System.

/* This soluion for the exercise 08.19 is a good example of wrong planning. :) This app is designed to serve the needs of only one single plane. In case when in some distant future I would need to add the possibility to reserve seats in different planes, the app would need to be substantially rewritten. Object oriented approach could be a good way to solve the task with a "Plane" class, its "numberOfSeats" properties, etc. */

using System;

class AirlineReservationSystem
{
    static void Main()
    {
        // Constant local variable to store the number of seats in the plane.
        const int numberOfSeats = 10;
        // Local variable, one-dimentional array that stores 10 values of type bool set to "False" by default.
        bool[] availableSeats = new bool[numberOfSeats];
        /* Local variable of type int to store the index of a value in the "availableSeats[]" array of the current free seat.
        It becomes greater than (availableSeats.Length / 2 - 1) when there is no more seats. */
        int freeSeatAtFirstClass = 0;
        /* We assume that a plane has equal number of seats in both classes, with first half starting from seat 1 (with index 0) for the First Class and the second half for the Economy Class. That is why, the index of the first seat of the Economy Class equals to (availableSeats.Length / 2). */
        int freeSeatAtEconomy = availableSeats.Length / 2;
        /* Local constants for commands would be used by a user: 1 to reserve a seat in the First Class,
        2 to reserve a seat in the Econom Class and 0 to exit. */
        const int firstClass = 1;
        const int economyClass = 2;
        const int exitCommand = 0;
        // Local variable of type int to srote user input.
        int reserveClass = -1;
        // Print a wellcome message.
        Console.WriteLine("Airline reservation system.");
        Console.WriteLine();

        // Offer to reserve next seat until user enters "0".
        while (reserveClass != exitCommand)
        {
            /* Print a message that shows current available seats in both classes. */
            PrintStatistic(availableSeats, freeSeatAtFirstClass, freeSeatAtEconomy);
            
            /* There is no more free seats in the First Class, when the index of next free seat stored in "freeSeatAtFirstClass"
            becomes greater than the largest index of the first half of all indices or "availableSeats[]" array.
            There is no more free seats in the Economy Class, when the index of next free seat stored in "freeSeatAtEconomy"
            becomes greater than the last index of the "availableSeats[]" array.
            Check both these values before letting a user to do anything and there is no more free places, print an appropriate message and exit the "while" loop. */
            if (freeSeatAtFirstClass > ((availableSeats.Length / 2) - 1)
                && freeSeatAtEconomy > (availableSeats.Length - 1))
            {
                Console.WriteLine("There is no free seats in the plane. Next flight leaves in 3 hours.");
                break;
            }
            
            /* Call the "GetReserveClass()" method which asks a user for a desired action (e.g. to reserve a seat or exit),
            then store a value, returned by the method in a local variable "reserveClass". */
            reserveClass = GetReserveClass();

            // If the code, entered by a user is 0, exit the "while" loop.
            if (reserveClass == exitCommand)
            {
                break;
            }
            // Else if the code, entered by a user is 1, try to reserve a seat in the First Class.
            else if (reserveClass == firstClass)
            {
                // If there are free seats in the First Class.
                if (freeSeatAtFirstClass <= ((availableSeats.Length / 2) - 1))
                {
                    // Reserve a seat in the First Class.
                    ReserveASeat(availableSeats, firstClass, ref freeSeatAtFirstClass);
                }
                /* Else if there is no free seats in the first class, call the "UseAnotherClass()" method
                which would return "True" if user would agree to be placed in the Economy Class instead. And the the method returned "True" */
                else if (UseAnotherClass(reserveClass))
                {
                    // Reserve a seat in the Economy Class.
                    ReserveASeat(availableSeats, economyClass, ref freeSeatAtEconomy);
                }
            }
            // Else if the code, entered by a user is 2, try to reserve a seat in the Economy Class.
            else if (reserveClass == economyClass)
            {
                // If there are free seats in the Economy Class.
                if (freeSeatAtEconomy <= (availableSeats.Length - 1))
                {
                    // Reserve a seat in the Economy Class.
                    ReserveASeat(availableSeats, economyClass, ref freeSeatAtEconomy);
                }
                // Else if there is no free seats in the Economy Class and user agrees to be placed in the First Class.
                else if (UseAnotherClass(reserveClass))
                {
                    // Reserve a seat in the First Class.
                    ReserveASeat(availableSeats, firstClass, ref freeSeatAtFirstClass);
                }
            }

            // Print empty line to separate outputs for different seats reservation.
            Console.WriteLine();
        }

        // Print "Thank you" message whenever the app is terminated.
        Console.WriteLine("Thank you for choosing our airline!");
    }

    // Private static method "PrintStatistic()", takes one array of bool elements and two integers as arguments and returns no value.
    private static void PrintStatistic(bool[] availableSeats, int freeSeatAtFirstClass, int freeSeatAtEconomy)
    {
        /* Print the number of available seats, calculated with the array "availableSeats[]"
        and indices stored in "freeSeatAtFirstClass" and "freeSeatAtEconomy" given as arguments.. */
        Console.WriteLine($"There are {(availableSeats.Length / 2) - freeSeatAtFirstClass} free seats in the First Class "
            + $"and {availableSeats.Length - freeSeatAtEconomy} free seats in the Economy Class.");
    }

    // Private static method "GetReserveClass()" takes no arguments and returns an integer value of a code for an action (1, 2 or 0).
    private static int GetReserveClass()
    {
        // Print a prompt.
        Console.Write("Please type 1 for First Class, 2 for Economy and 0 to exit: ");
        /* Read a line of text form user, convert it to "int", using built-in "Parse()" method,
        then store the result in the "reserveClass" local variable. */
        int reserveClass = int.Parse(Console.ReadLine());

        // Ask user to re-enter value until he/she enters "1", "2" or "0".
        while (reserveClass != 0 && reserveClass != 1 && reserveClass != 2)
        {
            Console.WriteLine("The answer should be \"1\", \"2\" or \"0\".");
            Console.Write("Please type 1 for First Class, 2 for Economy and 0 to exit: ");
            reserveClass = int.Parse(Console.ReadLine());
        }

        // Return the integer of action. 1 and 2 are for reserving a seat in the First and Economy classes accordingly and 0 for exit.
        return reserveClass;
    }

    /* Private static method "ReserveASeat()", which takes one array of bool values, one integer and one integer given by reference as parameters and returns no value. 
    Instead of creating separate methods for reserving a seat for First Class and Economy Class, we create one universal method that does both.
    The first parameter, which is an array would be the same for all calls.
    The second parameter represents a class in which seat need to be reserved, chosen by a user.
    The third parameter is the number of free seats left in the appropriate class.
    The third parameter is passed by reference as soon as we need to update it's value after reserving a seat */
    private static void ReserveASeat(bool[] availableSeats, int reserveClass, ref int freeSeatInClass)
    {
        // Local variable of type string to store flight class name based on "reserveClass" given to method as an argument.
        string className = reserveClass == 1
            ? "First Class"
            : "Economy Class";
        // Reserve a seat by setting appropriate value of "availableSeats[]" array to true.
        availableSeats[freeSeatInClass] = true;
        /* Don't forget to increment the value of index of the next free seat in a class.
        As soon as "freeSeatInClass" passed to the method by reference, it's original value is changed when changed here in a method. */
        ++freeSeatInClass;
        // Print a confirmation of successful reservation.
        Console.WriteLine($"The seat number {freeSeatInClass} is successfully reserved in the {className}.");
    }

    /* Private static method "UseAnotherClass()" that takes one integer as argument and returns bool value ("True" of "False").
    The purpose of the method is to tell user that there is no free seats in one class and offer to reserve a seat in the other.
    The method returns "True" if a user agrees and "False" otherwise. */
    private static bool UseAnotherClass(int reserveClass)
    {
        // Local variables of type string to store flight class names based on "reserveClass" given to method as an argument.
        string originalClass = reserveClass == 1
            ? "First Class"
            : "Economy Class";
        // This variable assign the value opposite to the "originalClass".
        string changeClass = reserveClass != 1
            ? "First Class"
            : "Economy Class";
        
        // Print a prompt with classes mentioned.
        Console.Write($"Unfortunately, there is no more free seats in the {originalClass}. "
            + $"Do you want to be placed in the {changeClass} (\"yes\" or \"no\"): ");
        // Write the answer entered by a user to the "answer" local variable of type string.
        string answer = Console.ReadLine();

        // If a user entered incorrected value, loop until he/she inters "yes" or "no".
        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write($"Unfortunately, there is no more free seats in the {originalClass}. "
                + $"Do you want to be placed in the {changeClass} (\"yes\" or \"no\"): ");
            answer = Console.ReadLine();
        }

        // If a user answer "yes" return "True" and "False" otherwise.
        if (answer == "yes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}