// Solution to exercises from "C# How to Program 6th edition".
// Chapter 4.
// Making-a-Difference Exercise 02 (04.15) Computerization of Health Records.

using System;
class HealthProfile
{
    /* Instance variables for values that should be checked before assignation.
    I use C# built in DateTime class. The construction DateTime.Now.Year uses Year property which allows us to get current year every time the program stars and assign it to instance variable currentYear. The currentYear should not be changed during the application execution, so we make no public property for it. I also use meters and kilograms instead of inches and pounds because they are measurement standard according to International System of Units.
    https://en.wikipedia.org/wiki/International_System_of_Units */
    private int birthYear;
    private int birthMonth;
    private int birthDay;
    private int currentYear = DateTime.Now.Year;
    private double heightInMeters;
    private double weightInKilograms;

    // Auto-implemented properties for person's first name, last name and gender.
    public string FirstName { get; set; }
    public string LastName { get; set; }
    /* Person's gender could be one of two known genders: male or female. For such values the most efficient way to store them is to use data type known as bool. Bool is initially able to store two values: true or false. Let's create property of type bool and assume that it asks "Is Person Male?". And stored value is an answer. So the true would mean male and false would mean female. */
    public bool Gender { get; set; }
    // Properties for birth date, height and weight.
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
    public int BirthMonth
    {
        get
        {
            return birthMonth;
        }
        set
        {
            if (value >= 0)
            {
            birthMonth = value;
            }
        }
    }
    public int BirthDay
    {
        get
        {
            return birthDay;
        }
        set
        {
            if (value >= 0)
            {
            birthDay = value;
            }
        }
    }
    public double HeightInMeters
    {
        get
        {
            return heightInMeters;
        }
        set
        {
            if (value >= 0)
            {
            heightInMeters = value;
            }
        }
    }
    public double WeightInKilograms
    {
        get
        {
            return weightInKilograms;
        }
        set
        {
            if (value >= 0)
            {
            weightInKilograms = value;
            }
        }
    }

    // HealthProfile constructor that assigns values to variables during an object creation step.
    public HealthProfile(string fName, string lName, bool gender, int bYear, int bMonth, int bDay, double height, double weight)
    {
        FirstName = fName;
        LastName = lName;
        Gender = gender;
        BirthYear = bYear;
        BirthMonth = bMonth;
        BirthDay = bDay;
        HeightInMeters = height;
        WeightInKilograms = weight;
    }

    /* A method that returns person's age in years. Empty paranthesis means that the method doesn't need any parameters to perform it's task. */
    public int AgeInYears()
    {
        return currentYear - BirthYear;
    }

    // A method that returns person's maximum heart rate.
    public int MaxHeartRate()
    {
        return 220 - AgeInYears();
    }

    // A method that returns person's minimum target heart rate.
    public int MinTargetHeartRate()
    {
        return MaxHeartRate() / 2;
    }

    // A method that returns person's maximum target heart rate. We again use C# casting mechanism to get integer value after multiplying.
    public int MaxTargetHeartRate()
    {
        return (int)(MaxHeartRate() * 0.85);
    }
}