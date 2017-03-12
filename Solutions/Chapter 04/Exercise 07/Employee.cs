// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Exercise 07 (04.11) Employee Class.

class Employee
{
    /* Before assigning a new value to a monthly salary variable we need to check whether a new value is correct. Therefore we create an instance variable and it's property. */
    private decimal salaryMonthly;

    /* String variables do not need anything special during get and set operations, thus auto-implemented property is the best way to handle them. */
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public decimal SalaryMonthly
    {
        get
        {
            return salaryMonthly;
        }
        set
        {
            if (value >= 0)
            {
            salaryMonthly = value;
            }
        }
    }

    public Employee(string fName, string lName, decimal mSalary)
    {
        FirstName = fName;
        LastName = lName;
        SalaryMonthly = mSalary;
    }
}