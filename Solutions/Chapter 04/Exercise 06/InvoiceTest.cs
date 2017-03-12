// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Exercise 06 (04.10) Invoice Class.

using System;
using System.Globalization;

class InvoiceTest
{
    static void Main()
    {
        // Create three objects of class Invoice using class constructor to set intial values.
        // Notice that we use "m" postfix after fourth parameter. You use m postfix if you want a numeric real literal to be treated as decimal.
        Invoice saw = new Invoice("PN1", "Saw", 2, 55.30m);
        Invoice hammer = new Invoice("PN2", "Hammer", 5, 32.50m);
        Invoice battary = new Invoice("PN3", "Battary", 0, 6.00m);
        
        /* Again the following is little peek ahead. Now the problem is that during the output C# uses different default encodings on different computers. And if printed characters are not supported by an encoding, they would be printed as gibberish. That is the case with currency sign used in my region (₽). Furtunately the unicode standard and more precisely UTF-8 was developed as a common encoding for all possible characters for all possible languages in the world. So we are able to use single encoding for all possible cases for now and in the future. You can read more about encodings here:
        https://www.w3.org/International/questions/qa-what-is-encoding
        https://en.wikipedia.org/wiki/Character_encoding
        https://msdn.microsoft.com/en-us/library/ms404377(v=vs.110).aspx */

        // Make UTF-8 our output encoding.
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // I also want real numbers (decimals) be printed with dot as a decimal mark, so I also change Culture Info to en-US.
        CultureInfo cultureEnUs = new CultureInfo("en-US");

        // Display initial values for the first object.
        Console.WriteLine("Values of object 1.");
        Console.WriteLine($"Part number: {saw.PartNumber}");
        Console.WriteLine($"Description: {saw.PartDescription}");
        Console.WriteLine($"Purchased items: {saw.PurchasedQuantity}");
        Console.WriteLine($"Price per item: {(saw.PricePerItem).ToString(cultureEnUs)} ₽");
        Console.WriteLine($"Total invoice amount is: {saw.GetInvoiceAmount().ToString(cultureEnUs)} ₽");
        
        // Write additional empty line for clearer output view.
        Console.WriteLine();
        
        // The same output for the second object.
        Console.WriteLine("Values of object 2.");
        Console.WriteLine($"Part number: {hammer.PartNumber}");
        Console.WriteLine($"Description: {hammer.PartDescription}");
        Console.WriteLine($"Purchased items: {hammer.PurchasedQuantity}");
        Console.WriteLine($"Price per item: {(hammer.PricePerItem).ToString(cultureEnUs)} ₽");
        Console.WriteLine($"Total invoice amount is: {hammer.GetInvoiceAmount().ToString(cultureEnUs)} ₽");
        
        Console.WriteLine();
        
        // The output for the third object.
        Console.WriteLine("Values of object 3.");
        Console.WriteLine($"Part number: {battary.PartNumber}");
        Console.WriteLine($"Description: {battary.PartDescription}");
        Console.WriteLine($"Purchased items: {battary.PurchasedQuantity}");
        Console.WriteLine($"Price per item: {(battary.PricePerItem).ToString(cultureEnUs)} ₽");
        Console.WriteLine($"Total invoice amount is: {battary.GetInvoiceAmount().ToString(cultureEnUs)} ₽");
        
        Console.WriteLine();
        
        // Change the description of the first object and see if it changed.
        Console.WriteLine("Please enter new name for the object1:");
        saw.PartDescription = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine($"New object1 description is: {saw.PartDescription}");

        Console.WriteLine();
    }
}