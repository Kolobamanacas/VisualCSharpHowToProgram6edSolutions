// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 15 (08.20) Total Sales.

using System;

// Declare a class "Slip" to temporary store slip data in its object.
class Slip
{
    /* Declare private field of type int "numberOfSalespersons" and initizlize it to 0.
     * Tt is used to store total number of salesperson and together with "numberOfProducts" set in class's constructor
     * and helps to check the numbers entered by a user and to prevent errors. */
    private int numberOfSalespersons = 0;
    // Declare private field of type int "numberOfProducts" and initialize it to 0.
    private int numberOfProducts = 0;
    // Private field of integer type "salesmanNumber" is used to store number of a salesperson written in a slip.
    private int salesmanNumber;
    // Private field of integer type "productNumber" is used to store number of a product written in a slip.
    private int productNumber;
    // Private field of decimal type "dollarValue" is used to store dollar value written in a slip.
    private decimal dollarValue;

    // Class constructor, where "numberOfProducts" and "numberOfSalespersons" are set.
    public Slip(int numberOfProducts, int numberOfSalespersons)
    {
        /* Assign the value of "numberOfProducts" given as argument to a class field "numberOfProducts".
         * "this" needed to distinguish variables with the same name.
         * A variable with "this" is always a part of a class where it's called. */
        this.numberOfProducts = numberOfProducts;
        // Assign the value of "numberOfSalespersons" given as argument to a class field "numberOfSalespersons".
        this.numberOfSalespersons = numberOfSalespersons;
    }

    // Public property "SalesmanNumber". We use simple get method within it and add additional check for input correctness in set method.
    public int SalesmanNumber
    {
        // When some code tries to get the value of property "SalesmanNumber" the value of field "salesmanNumber" is returned.
        get
        {
            return salesmanNumber;
        }
        /* When some code tries to set the value to property "SalesmanNumber" an additional check is performed,
         * making it impossible to set incorrect value. */
        set
        {
            // If someone tries to assign a value less than 1 or greater than "numberOfSalespersons" to "SalesmanNumber".
            while (value < 1 || value > numberOfSalespersons)
            {
                // Print an error message and ask to re-enter the value.
                Console.WriteLine($"The salesperson number should be in 1 to {numberOfSalespersons} range.");
                Console.Write($"Please enter a salesperson number (1 to {numberOfSalespersons}): ");
                value = int.Parse(Console.ReadLine());
            }

            // Assign the correct value to the field "salesmanNumber".
            salesmanNumber = value;
        }
    }

    // Public property "ProductNumber". We use simple get method within it and add additional check for input correctness in set method.
    public int ProductNumber
    {
        // When some code tries to get the value of property "ProductNumber" the value of field "productNumber" is returned.
        get
        {
            return productNumber;
        }
        /* When some code tries to set the value to property "ProductNumber" an additional check is performed,
         * making it impossible to set incorrect value. */
        set
        {
            // If someone tries to assign a value less than 1 or greater than "numberOfProducts" to "ProductNumber".
            while (value < 1 || value > numberOfProducts)
            {
                // Print an error message and ask to re-enter the value.
                Console.WriteLine($"The product number should be in 1 to {numberOfProducts} range.");
                Console.Write($"Please enter a product number (1 to {numberOfProducts}): ");
                value = int.Parse(Console.ReadLine());
            }

            // Assign the correct value to the field "productNumber".
            productNumber = value;
        }
    }

    // Public property "DollarValue".
    public decimal DollarValue
    {
        // When some code tries to get the value of property "DollarValue" the value of field "dollarValue" is returned.
        get
        {
            return dollarValue;
        }
        /* When some code tries to set the value to property "DollarValue" an additional check is performed,
         * making it impossible to set incorrect value. */
        set
        {
            // If someone tries to assign a value less or equal to 0 to "DollarValue".
            while (value <= 0)
            {
                // Print an error message and ask to re-enter the value.
                Console.WriteLine("A dollar value of sales can't be a negative value or zero.");
                Console.Write("Please enter the total dollar value of the product sold that day: ");
                value = decimal.Parse(Console.ReadLine());
            }

            // Assign the correct value to the field "dollarValue".
            dollarValue = value;
        }
    }
}