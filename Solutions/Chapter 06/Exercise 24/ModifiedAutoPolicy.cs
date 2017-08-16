// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 24 (06.28) Modified Autopolicy Class.

class ModifiedAutoPolicy
{
    // Policy account number.
    public int AccountNumber { get; set; }
    // Car that policy applies to.
    public string MakeAndModel { get; set; }
    /* When we use auto implemented "get" and "set" accessors, a compiler implicitly creates a field with the same name. But when we use manually implemented accessors we need to initialize this field manually. */
    private string state;
    // Two-letter state abbreviation.
    public string State
    {
        // Get accessor's body must be declared in cases when "set" accessor's body is declared too.
        get
        {
            return state;
        }
        set
        {
            // Use compound condition to check whether a state is valid.
            if (value == "CT"
                || value == "MA"
                || value == "ME"
                || value == "NH"
                || value == "NJ"
                || value == "NY"
                || value == "PA"
                || value == "VT")
            {
                /* If a state is valid, assign it's value to "state" field. The "value" is "built in" argument presented in properties. */
                state = value;
            }
            else
            {
                /* If a state is invalid, print an error and assign "ERROR" to the "state" field as a state name. I also use a string interpolation to put an incorrect state's name into a string. */
                Console.WriteLine($"Error: Provided state name ({value}) is incorrect.");
                Console.WriteLine();
                state = "ERROR";
            }
        }
    }

    // Constructor.
    public ModifiedAutoPolicy(int accountNumber, string makeAndModel, string state)
    {
        AccountNumber = accountNumber;
        MakeAndModel = makeAndModel;
        State = state;
    }

    // Returns whether the state has no-fault insurance.
    public bool IsNoFaultState
    {
        get
        {
            bool noFaultState;

            // Determine whether state has no-fault auto insurance.
            // Get ModifiedAutoPolicy object's state abbreviation.
            switch (State)
            {
                case "MA": case "NJ": case "NY": case "PA":
                    noFaultState = true;
                    break;
                default:
                    noFaultState = false;
                    break;
            }

            return noFaultState;
        }
    }
}