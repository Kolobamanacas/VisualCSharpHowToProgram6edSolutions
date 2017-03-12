// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Exercise 07 (04.11) Employee Class.

using System;
using System.Globalization;

class EmployeeTest
{
    static void Main()
    {
        // Create two objects of class Employee sending three parameters as arguments to class constructor.
        Employee personA = new Employee("Ivan", "Kuznetsov", 210m);
        Employee personB = new Employee("John", "Smith", 2300m);
        
        // Make UTF-8 an output encoding.
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        // Create an object of class CultureInfo that would contain en-US regional settings.
        CultureInfo cultureEnUs = new CultureInfo("en-US");
        
        /* Display initial salaries of employees. There is some new stuff here. When one needs to print a value taking into account both currency and regional settings it could be done with converting a value to a string using special method ToString. ToString can use parameters to specify its output. We use letter "c" to tell ToString that output part is sum of money. We also pass the object cultureEnUs to specify regional standard. */
        Console.WriteLine($"The year salary of {personA.FirstName} {personA.LastName} is: {(personA.SalaryMonthly * 12).ToString("c", cultureEnUs)}", cultureEnUs);
        Console.WriteLine($"The year salary of {personB.FirstName} {personB.LastName} is: {(personB.SalaryMonthly * 12).ToString("c", cultureEnUs)}$", cultureEnUs);
        
        // Print additional empty line for clearer output.
        Console.WriteLine();
        
        /* Increase monthly salary of both persons by 10%. Multiplying by 1.10 would increase a number by 10%. The 1.10 should be followed by "m" to be recognized as decimal by a compiler. */
        personA.SalaryMonthly = personA.SalaryMonthly * 1.10m;
        personB.SalaryMonthly = personB.SalaryMonthly * 1.10m;
        
        // Display salaries of employees after 10% rise.
        Console.WriteLine($"The new value of year salary of {personA.FirstName} {personA.LastName} is: {(personA.SalaryMonthly * 12).ToString("c", cultureEnUs)}$", cultureEnUs);
        Console.WriteLine($"The new value of year salary of {personB.FirstName} {personB.LastName} is: {(personB.SalaryMonthly * 12).ToString("c", cultureEnUs)}$", cultureEnUs);
    }
}