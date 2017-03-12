// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Exercise 09 (04.13) Removing Duplicated Code in Method Main.

// Fig. 4.11: Account.cs
// Account class with a balance and a Deposit method.

class Account
{
    // auto-implemented property
    public string Name { get; set; }
    // instance variable
    private decimal balance;

    // Account constructor that receives two parameters  
    public Account(string accountName, decimal initialBalance) 
    {
        Name = accountName;
        // Balance's set accessor validates
        Balance = initialBalance;
    }

    // Balance property with validation
    public decimal Balance
    {
        get
        {
            return balance;
        }
        private set // can be used only within the class
        {
            // validate that the balance is greater than 0.0; if it's not,
            // instance variable balance keeps its prior value
            // m indicates that 0.0 is a decimal literal
            if (value > 0.0m)
            {
                balance = value;
            }
        }
    }

    // method that deposits (adds) only a valid amount to the balance
    public void Deposit(decimal depositAmount)
    {
        // if the depositAmount is valid
        if (depositAmount > 0.0m)
        {
            // add it to the balance
            Balance = Balance + depositAmount;
        }
    }
}

