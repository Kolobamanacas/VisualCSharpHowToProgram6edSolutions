// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Exercise 08 (04.12) Date Class.

class Date
{
    // Create three auto-implemented properties of type int.
    public int Year{ get; set; }
    public int Month{ get; set; }
    public int Day{ get; set; }

    // Create a constructor to assign values to all instance variables (implicitly created by properties) at an object declaration step.
    public Date(int yearValue, int monthValue, int dayValue)
    {
        /* As it written in the task, we assume that input values are all correct, so we simply assign them to variables through their properties. */
        Year = yearValue;
        Month = monthValue;
        Day = dayValue;
    }

    public void DisplayDate()
    {
        Console.WriteLine($"{Month}/{Day}/{Year}");
    }
}