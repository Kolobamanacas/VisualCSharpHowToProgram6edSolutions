// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 15 (08.20) Total Sales.

using System;
// This directive is needed to use CultureInfo class.
using System.Globalization;

// Declare a class "TotalSales" to store a table with all sales in its object.
class TotalSales
{
    /* Property "cultureEnUS" is an object of class "CultureInfo". It's used to print dots (and not commas) as decimal marks during output. 
     * We don't need different culture for different TotalSales objects, thus we can make it static. */
    private static CultureInfo cultureEnUs = new CultureInfo("en-US");
    /* Private field "sales[]" is a two-dimentional array which stores data of decimal type.
     * The size of the array is specified in the class's constructor. */
    private decimal[,] sales;

    // The constructor of the class. It gets two integers as arguments which are used to specify the size of the "sales[]" table.
    public TotalSales(int numberOfProducts, int numberOfSalespeople)
    {
        // Initialize "sales" field with new value of two-dimentional array with "numberOfProducts" rows and "numberOfSalespeople" columns.
        sales = new decimal[numberOfProducts, numberOfSalespeople];
    }

    // Public method "AddSalesDataFromSlip()" that takes an object of class "Slip" as an argument and returns no value.
    public void AddSalesDataFromSlip(Slip slip)
    {
        /* Add dollar value taken from a "slip" to a cell with appropriate index numbers of a product and a salesperson.
         * Indexes in arrays in C# starts from 0, but in everyday life people usually start counting from 1.
         * To avoid space waisting we store salesperson with number 1 in a cell with index number 0, salesperson with number 2 in cell
         * with index number 1 and so on. It is related to both rows and columns and both product numbers and salespersons numbers. 
         * And as soon as object of clsss "Slip" stores real numbers of a salesperson and a product, we need to decrements them
         * by 1 before using as indexes of the array. */
        sales[(slip.ProductNumber - 1), (slip.SalesmanNumber - 1)] += slip.DollarValue;
    }

    // Public method "PrintTotalSalesTable()" that takes no arguments, returns no value and prints content of the "sales[]" array.
    public void PrintTotalSalesTable()
    {
        // Print whitespaces as indentation for table's horizontal header.
        Console.Write("                  ");

        /* Print salesperson with it's number as the second part of horizontal header.
         * Number of salespersons is equal to number of columns of the "sales[]" array. Go through all elements of the array
         * with "for" statment and use inremented index of every column as a number of salesperson.
         * An incremented index is manually converted to a string using "ToString()" method with parameter "D2",
         * which makes sure that the output is a digit and that it have at least two digits in it with leading zeros when needed. */
        for (int column = 0; column < sales.GetLength(1); ++column)
        {
            Console.Write($"  Salesperson {(column + 1).ToString("D2")}");
        }

        // Print the last part of horizontal table header.
        Console.WriteLine("  Sum by products");

        /* Declare a local variable "sumByProduct" of type decimal and initialize it to 0.
         * It is used to temporary store the sum of dollar values for every combination of a product and all salespersons. */
        decimal sumByProduct = 0;

        // Print vertical headers and dollar values for every row and column.
        for (int row = 0; row < sales.GetLength(0); ++row)
        {
            // For every row print a product with its number as a vertical header. The string formatting is equal to horizontal headers.
            Console.Write($"Product {(row + 1).ToString("D2")}        ");

            for (int column = 0; column < sales.GetLength(1); ++column)
            {
                // For every column of a row add dollar value of a column to "sumByProduct" to eventually get sum of a row.
                sumByProduct += sales[row, column];
                /* For every column print a dolar value of appropriate combination of product and salesperson. 
                 * Here we manually cast a value to a string, specifying two arguments "F2" and "cultureEnUs".
                 * "F2" tells "ToString()" method that the output string is non-integer (i.e. rational, irrational) number,
                 * where "2" specifies number of digits after decimal mark.
                 * "cultureEnUs" is an object of system class "CultureInfo", is used to tell "ToString()" method to use US formatting
                 * standard for numbers (i.e. use dot as a decimal mark).
                 * The comma followed by number "16" within the curly braces is the way to set a string indentation with right alignment.
                 * We can use negative value like "-16" to set left alignment if needed. */
                Console.Write($"{((sales[row, column]).ToString("F2", cultureEnUs)), 16}");
            }

            // At the end of each row print the sum of dollar values for the row, calculated withint the "for" loop above.
            Console.WriteLine($"{(sumByProduct.ToString("F2", cultureEnUs)), 17}");
            // Set the "sumByProduct" to 0, to use it in the next iteration of the "for" loop.
            sumByProduct = 0;
        }

        // Print horizontal header for the last row.
        Console.Write("Sym by salesperson");

        /* Declare a local variable "sumBySalesperson" of type decimal and initialize it to 0.
         * It is used to temporary store the sum of dollar values for every combination of a salesperson and all products. */
        decimal sumBySalesperson = 0;

        // Print the last row.
        for (int column = 0; column < sales.GetLength(1); ++column)
        {

            for (int row = 0; row < sales.GetLength(0); ++row)
            {
                // For every row add dollar value of appropriate combination of product and salesperson to "sumBySalesperson".
                sumBySalesperson += sales[row, column];
            }

            // At the end of each column print the sum of dollar values for the column, calculated withint the "for" loop above.
            Console.Write($"{(sumBySalesperson.ToString("F2", cultureEnUs)), 16}");

            // Set the "sumBySalesperson" to 0, to use it in the next iteration of the "for" loop.
            sumBySalesperson = 0;
        }
    }
}