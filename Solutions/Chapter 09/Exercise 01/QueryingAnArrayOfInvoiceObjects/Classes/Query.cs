// Solution to exercises from "C# How to Program 6th edition".
// Chapter 9.
// Exercise 01 (09.03) Querying an Array of Invoice Objects.

using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryingAnArrayOfInvoiceObjects.Classes
{
    public class Query
    {
        #region Main Method

        public static void Main()
        {
            // Set UTF-8 as a default encoding to be able to see correct money signs of different cultures in the console.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Create a list of invoices where each invoice is initialized with parameters from Fig. 9.8 Sample data.
            List<Invoice> invoices = new List<Invoice>()
            {
                new Invoice(83, "Electric sander", 7, 57.98m),
                new Invoice(24, "Power saw", 18, 99.99m),
                new Invoice(7, "Sledge hammer", 11, 21.50m),
                new Invoice(77, "Hammer", 75, 11.99m),
                new Invoice(39, "Lawn mower", 3, 79.50m),
                new Invoice(68, "Screwdriver", 106, 6.99m),
                new Invoice(56, "Jig saw", 21, 11.00m),
                new Invoice(3, "Wrench", 34, 7.50m)
            };

            Console.WriteLine("Initial list of invoices:");

            foreach (Invoice invoice in invoices)
            {
                Console.WriteLine(invoice);
            }

            Console.WriteLine();
            List<Invoice> invoicesOrderedByPartDescription = GetInvoicesSortedByPartDescription(invoices);
            Console.WriteLine("Invoices sorted by part desctiption:");

            foreach (Invoice invoice in invoicesOrderedByPartDescription)
            {
                Console.WriteLine(invoice);
            }

            Console.WriteLine();
            List<Invoice> invoicesOrderedByPrice = GetInvoicesSortedByPrice(invoices);
            Console.WriteLine("Invoices sorted by price:");

            foreach (Invoice invoice in invoicesOrderedByPrice)
            {
                Console.WriteLine(invoice);
            }

            Console.WriteLine();

            IEnumerable<(string partDescription, int quantity)> partDescriptionsAndQuantities =
                GetPartDescriptionsAndQuantitiesSortedByQuantity(invoices);

            Console.WriteLine("Part description and quantity sorted by quantity:");

            foreach ((string partDescription, int quantity) in partDescriptionsAndQuantities)
            {
                Console.WriteLine(partDescription + ": " + quantity);
            }

            Console.WriteLine();

            IEnumerable<(string partDescription, decimal invoiceTotal)> partDescriptionsAndValuesSortedByValues =
                GetPartDescriptionsAndValuesSortedByValue(invoices);

            Console.WriteLine("Part description and total value sorted by total value:");

            foreach ((string partDescription, decimal invoiceTotal) in partDescriptionsAndValuesSortedByValues)
            {
                Console.WriteLine(partDescription + ": " + invoiceTotal);
            }

            Console.WriteLine();

            IEnumerable <decimal> totalValuesRange = GetTotalValueRange(partDescriptionsAndValuesSortedByValues, 200, 500);

            Console.WriteLine("Total values sorted by total value in range $200 to $500:");

            foreach (decimal totalValue in totalValuesRange)
            {
                Console.WriteLine(totalValue);
            }

            Console.WriteLine();
            Console.WriteLine("That's it. Press any key to exit.");
            Console.ReadKey();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns the original list of invoices sorted by part description.
        /// </summary>
        /// <param name="invoicesToSort">Initial list of invoices to be sorted.</param>
        private static List<Invoice> GetInvoicesSortedByPartDescription(List<Invoice> invoicesToSort)
        {
            IOrderedEnumerable<Invoice> sortedInvoices =
                from invoice in invoicesToSort
                orderby invoice.PartDescription ascending
                select invoice;

            return sortedInvoices.ToList();
        }

        /// <summary>
        /// Returns the original list of invoices sorted by price.
        /// </summary>
        /// <param name="invoicesToSort">Initial list of invoices to be sorted.</param>
        private static List<Invoice> GetInvoicesSortedByPrice(List<Invoice> invoicesToSort)
        {
            IOrderedEnumerable<Invoice> sortedInvoices =
                from invoice in invoicesToSort
                orderby invoice.Price ascending
                select invoice;

            return sortedInvoices.ToList();
        }

        /// <summary>
        /// Returns part description and quantity selected from given list of invoices and sorted by quantity.
        /// </summary>
        /// <param name="sourceInvoices">Initial list of invoices to select data from.</param>
        private static IEnumerable<(string partDescription, int quantity)> GetPartDescriptionsAndQuantitiesSortedByQuantity(
            List<Invoice> sourceInvoices)
        {
            return
                from invoice in sourceInvoices
                orderby invoice.Quantity ascending
                select (invoice.PartDescription, invoice.Quantity);
        }

        /// <summary>
        /// Returns part description and product of quantity and price selected from given list of invoices and sorted by product.
        /// </summary>
        /// <param name="sourceInvoices">Initial list of invoices to select data from.</param>
        private static IEnumerable<(string partDescription, decimal value)> GetPartDescriptionsAndValuesSortedByValue(
            List<Invoice> sourceInvoices)
        {
            return
                from invoice in sourceInvoices
                let total = invoice.Quantity * invoice.Price
                orderby total
                select (invoice.PartDescription, total);
        }

        /// <summary>
        /// Returns invoice totals with value in inclusive given range.
        /// </summary>
        /// <param name="sourceInvoices">List of invoices to select from.</param>
        /// <param name="lowBound">Inclusive low bound of a range.</param>
        /// <param name="upperBound">Inclusive upper bound of a range.</param>
        private static IEnumerable<decimal> GetTotalValueRange(
            IEnumerable<(string partDescription, decimal invoiceTotal)> sourceInvoices,
            decimal lowBound,
            decimal upperBound)
        {
            return
                from invoice in sourceInvoices
                where invoice.invoiceTotal >= 200 && invoice.invoiceTotal <= 500
                select invoice.invoiceTotal;
        }

        #endregion
    }
}