// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Exercise 06 (04.10) Invoice Class.

class Invoice
{
    // Price and quantity require some operations chech so we create instance variables and properties for them.
    private int purchasedQuantity;
    private decimal pricePerItem;

    /* We don't need to perform additional actions during getting and setting values of part number and part description. That's why we can use simple auto-implemented properties to store and maintain their values. C# automatically creates hidden instance variable for each auto-implemented property. */
    public string PartNumber{ get; set; }
    public string PartDescription{ get; set; }

    // Declare properties for quantity and price per item instance variables with get and set methods.
    public int PurchasedQuantity
    {
        get
        {
            // A get method simly returns a value of instance variable related to the property.
            return purchasedQuantity;
        }
        set
        {
            /* We change value of purchased quantity instance variable only if new number is positive. It can't be negative quantity of items. */
            if (value > 0)
            {
            purchasedQuantity = value;
            }
        }
    }

    public decimal PricePerItem
    {
        get
        {
            // A get method simly returns a value of instance variable related to the property.
            return pricePerItem;
        }
        set
        {
            // Again we change price per item instance variable only if new number is positive. It can't be negative price.
            if (value > 0)
            {
            pricePerItem = value;
            }
        }
    }

    /* Declare a class constructor with four parameters of appropriate types. While calling to class constructor a caller provides four values which are used as arguments for constructor to assign these values to instance variables. But even constructor performs it using properties rather than instance variables directly. */
    public Invoice(string partNumberParam, string partDescriptionParam, int purchasedQuantityParam, decimal pricePerItemParam)
    {
        PartNumber = partNumberParam;
        PartDescription = partDescriptionParam;
        PurchasedQuantity = purchasedQuantityParam;
        PricePerItem = pricePerItemParam;
    }

    // Declare a method "Get Invoice Amount" which would return the amount of invoice (purchased quantity times price per item).
    public decimal GetInvoiceAmount()
    {
        return (purchasedQuantity * pricePerItem);
    }
}