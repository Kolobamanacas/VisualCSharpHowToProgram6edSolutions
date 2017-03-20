// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise 11(04) (05.20) Salary Calculator.

using System;

class SalaryCalculator
{
    static void Main()
    {
        // Print a wellcome message.
        Console.WriteLine("Salary Calculator.");
        
        /* As we know the number of employees in advance, we could use counter-controlled loop to get and print information about all employees instead of sentinel-controlled one. A while loop do statements of its body until it's condition statement remains true. So we set counter employeeNumber to 1 and will increment it by one every time at the end of the loop until it become larger than number of employees and the condition statement become false.*/
        int employeeNumber = 1;
        
        // While the counter is less or equal than number of employees.
        while (employeeNumber <= 3)
        {
            // Read a number of hours worked by an employee.
            Console.Write("Please enter number of hours worked by an employee this week: ");
            int hoursWorked = int.Parse(Console.ReadLine());
            
            // Read hourly rate of an employee.
            Console.Write("Please enter hourly rate of the employee: ");
            int hourlyRate = int.Parse(Console.ReadLine());
            
            // If an employee worked less than or exactly 40 hours.
            if (hoursWorked <= 40)
            {
                // Calculate and print gross salary without 40 hours excess.
                Console.WriteLine($"A gross salary of the employee is: {(hoursWorked * hourlyRate):F}");
            }
            // If an employee worked more than 40 hours.
            else
            {
                // Calculate and print gross salary including 40 hours excess.
                Console.Write("A gross salary of the employee is: ");
                Console.WriteLine(
                    $"{((40 * hourlyRate) + ((hoursWorked - 40) * (hourlyRate * 1.5))):F}");
            }
            
            Console.WriteLine();
            
            // Add 1 to our employees counter.
            ++employeeNumber;
        }
        
        // Farewell message.
        Console.WriteLine("Number of employees is exceeded. Program is terminated.");
    }
}