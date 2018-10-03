// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 15 (08.20) Total Sales.

/* Here we make a step forward and start using objects and their properties. In the first place we a slip,
 * which could be represented as an object. In that case a slip object could have a salesnumber property, a product number property
 * and dollar value property. In addition to them I've added two additional properties: total number of salespersons
 * and total number of products. These two would help us to check the numbers entered by user and to prevent errors.
 * In the most modern systems the data is stored in databases and in our case two-dimentional array is used instead.
 * For comfortable work with this array, we create a TotalSales class, which have only one property sales - a two-dimentional array.
 * The size of the array is specified in the class constructor. The class also has two methods.
 * The first adds data from a slip to an array. The second prints data from the table.
 * As soon as properties and methods of TotalSales class are not static, we can create many ojects (and tables in them) if needed.
 * Please notice that if the number of salepersons is changed and become more than 6, the output could be displaced or corrupted
 * depending on screen resolution. */

using System;

// "SalesCalculator" is the main class from where the app execution is started.
class SalesCalculator
{
    static void Main()
    {
        /* Create an object of class "TotalSales", providing "5" and "3" as parameters for the class's constructor. Using them
         * the constructor is creating an object, which private two-dimentional field "sales[]" would have 5 rows with 3 columns. */
        TotalSales salesTable = new TotalSales(5, 3);

        // Print a welcome message.
        Console.WriteLine("The app calculates total sales for 3 salespersons and 5 product types.\n"
            + "In order to fill the resulting summary sales table, you need to provide a list of slips,\n"
            + "where every slip contains: number of a salesperson, numeber of a product\n"
            + "and total dollar value of the product sold that day by the salesperson.");

        // Declare a local variable "toContinue" to use it in while loop continuation test.
        bool toContinue = true;

        // While user answers "y" for the "ToContinue()" method's question.
        while (toContinue)
        {
            Console.WriteLine();
            Console.WriteLine("Entering data for the next slip.");
            Console.Write("Please enter a salesperson number: ");
            /* Create an object of class "Slip", providing "5" and "3" as parameters for the class's constructor. Using them
             * the constructor is creating a "slip" object which wouldn't allow to set product or salesperson greater than these values.
             * Notice that new object is created during every iteration of while loop.
             * Old objects are deleted from memory by the C# garbage collector.
             *  https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/ */
            Slip slip = new Slip(5, 3);
            // Write the next number of a salesperson to "SalesmanNumber" - the property of "slip" object.
            slip.SalesmanNumber = int.Parse(Console.ReadLine());
            Console.Write("Please enter a product number: ");
            // Write the next number of a product to "ProductNumber" - the property of "slip" object.
            slip.ProductNumber = int.Parse(Console.ReadLine());
            Console.Write("Please enter the total dollar value of the product sold that day: ");
            // Write the next dollar value to "DollarValue" - the property of "slip" object.
            slip.DollarValue = decimal.Parse(Console.ReadLine());
            /* Call a "salesTable" class's method "AddSalesDataFromSlip()" providing a "slip" object as a parameter.
             * The method would add data stored in the object to a "sales" field stored in its class. */
            salesTable.AddSalesDataFromSlip(slip);
            // Ask user whether he/she wants to enter data for the next slip.
            toContinue = ToContinue();
        }

        Console.WriteLine();
        Console.WriteLine("The total sales table:");
        // Call a "salesTable" class's method "PrintTotalSalesTable()" which prints a resulting table.
        salesTable.PrintTotalSalesTable();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Press any key to exit.");
        /* The method "ReadKey()" of class "Console" is similar to "ReadLine()" method, but reads not a string of characters,
         * followed by "Enter" key, but in contrast reads a single character pressed by a user.
         * It is useful when you need a console window to left opened after an application finishes its work. */
        Console.ReadKey();
    }

    /* Public static method "ToContinue()", which takes no argument. It asks a user whether he/she wants
     * to enter the value from the next slip, then returns "ture" if users answers "y" and returns "false" if user answers "n". */
        public static bool ToContinue()
    {
        Console.Write("Do you want to enter data for another slip (type \"y\" for yes and \"n\" for no): ");
        string answer = Console.ReadLine();

        while (answer != "y" && answer != "n")
        {
            Console.WriteLine("The answer should be \"y\" or \"n\".");
            Console.Write("Do you want to enter data for another slip (type \"y\" for yes and \"n\" for no): ");
            answer = Console.ReadLine();
        }

        if (answer == "y")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}