// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Making-a-Difference Exercise 01 (04.14) Target-Heart-Rate Calculator.

class HeartRates
{
    /* Date values like years should better be checked before assigning to a variable, so we create instance variables and properties for them.
    Create instance variables for years. */
    private int birthYear;
    private int currentYear;

    /* Names don't need be checked before setting their values, so auto-implemented properties are easy and comvinient way to store them in computer's memory. */
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Properties for years instance variables.
    public int BirthYear
    {
        get
        {
            return birthYear;
        }
        set
        {
            if (value >= 0)
            {
                birthYear = value;
            }
        }
    }

    public int CurrentYear
    {
        get
        {
            return currentYear;
        }
        set
        {
            if (value >= 0)
            {
                currentYear = value;
            }
        }
    }

    // A property that returns person's age in years.
    public int AgeInYears
    {
        get
        {
            return CurrentYear - BirthYear;
        }
    }

    // A property that returns person's maximum heart rate.
    public int MaxHeartRate
    {
        get
        {
            return 220 - AgeInYears;
        }
    }

    // A property that returns person's minimum target heart rate.
    public int MinTargetHeartRate
    {
        get
        {
            return MaxHeartRate / 2; // A number devided by 2 is 50% of original number.
        }
    }

    /* Here we have to use some technique that wasn't mentioned in the textbook before. C# provides convinient way to cast (convert) one type of data to another. I already used ToString and Parse methods in previous exercises and there is one more way. Let's say we need to cast double number 156.24 to an integer. It can be easily done with (int)156.24 operation. So we just put type name (int) in paranthesis to the left of number we want to cast. It is important to remember that in this example the decimal part of number (which is .24) would be trimmed. One can use such casting technique not only with numbers but with expressions as well. The number of beats per minute should be an integer so trimming decimal part after multiplying MaxTaRgetHeartRate by 0.85 is ok. */
    public int MaxTargetHeartRate
    {
        get
        {
            // Get 85% of MaxHeartRate and cast it to int.
            return (int)(MaxHeartRate * 0.85);
        }
    }

    public HeartRates(string fName, string lName, int bYear, int cYear)
    {
        FirstName = fName;
        LastName = lName;
        BirthYear = bYear;
        CurrentYear = cYear;
    }
}