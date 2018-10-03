// Solution to exercises from "C# How to Program 6th edition".
// Chapter 9.
// Exercise 01 (09.03) Querying an Array of Invoice Objects.

namespace QueryingAnArrayOfInvoiceObjects.Classes
{
    public class Invoice
    {
        #region Private Fields

        // Declare variables for Invoice object.
        private int quantityValue;
        private decimal priceValue;

        #endregion

        #region Constructors

        // Four-argument constructor.
        public Invoice(int part, string description, int count, decimal pricePerItem)
        {
            PartNumber = part;
            PartDescription = description;
            Quantity = count;
            Price = pricePerItem;
        }

        #endregion

        #region Public Properties

        // Auto-implemented property PartNumber.
        public int PartNumber { get; set; }
        // Auto-implemented property PartDescription.
        public string PartDescription { get; set; }

        // Property for quantityValue; ensures value is positive.
        public int Quantity
        {
            get
            {
                return quantityValue;
            }
            set
            {
                // Determine whether quantity is positive.
                if (value > 0)
                {
                    // Valid quantity assigned.
                    quantityValue = value;
                }
            }
        }

        // Property for pricePerItemValue; ensures value is positive.
        public decimal Price
        {
            get
            {
                return priceValue;
            }
            set
            {
                // Determine whether price is non-negative.
                if (value >= 0M)
                {
                    // Valid price assigned.
                    priceValue = value;
                }
            }
        }

        #endregion

        #region Public Methods

        // Return string containing the fields in the Invoice in a nice format;
        // left justify each field, and give large enough spaces so
        // all the columns line up
        public override string ToString() =>
           $"{PartNumber,-5} {PartDescription,-20} {Quantity,-5} {Price,6:C}";

        #endregion
    }
}