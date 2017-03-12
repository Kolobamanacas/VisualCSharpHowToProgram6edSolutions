// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Exercise 05 (04.09) Account Modification.

// Fig. 4.11: Account.cs
// Account class with a balance and a Deposit method.

class Account
{
    public string Name { get; set; } // auto-implemented property
    private decimal balance; // instance variable

    // Account constructor that receives two parameters  
    public Account(string accountName, decimal initialBalance) 
    {
        Name = accountName;
        Balance = initialBalance; // Balance's set accessor validates
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
            if (value > 0.0m) // m indicates that 0.0 is a decimal literal
            {
            balance = value;
            }
        }
    }

    // method that deposits (adds) only a valid amount to the balance
    public void Deposit(decimal depositAmount)
    {
        if (depositAmount > 0.0m) // if the depositAmount is valid
        {
            Balance = Balance + depositAmount; // add it to the balance 
        }
    }

    // Method that withdraws (subtracts) amount from the balance if it is not higher that current account's amount.
    public void Withdraw(decimal withdrawAmount)
    {
        if (withdrawAmount > balance)
        {
            Console.WriteLine("Withdrawal ammount exceeded account balance.");
        }
        
        if (withdrawAmount <= balance)
        {
            Balance = Balance - withdrawAmount;
        }
    }
}