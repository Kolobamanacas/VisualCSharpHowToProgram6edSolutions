// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 24 (06.28) Modified Autopolicy Class.

using System;

class ModifiedAutoPolicyTest
{
    static void Main()
    {
      // Create three ModifiedAutoPolicy objects. The third one contains incorrect state.
      ModifiedAutoPolicy policy1 = new ModifiedAutoPolicy(11111111, "Toyota Camry", "NJ");
      ModifiedAutoPolicy policy2 = new ModifiedAutoPolicy(22222222, "Ford Fusion", "ME");
      ModifiedAutoPolicy policy3 = new ModifiedAutoPolicy(33333333, "Tesla Model S", "XX");

      // Display whether each policy is in a no-fault state.
      PolicyInNoFaultState(policy1);
      PolicyInNoFaultState(policy2);
      PolicyInNoFaultState(policy3);
    }

    // Method that displays whether an ModifiedAutoPolicy.
    // Is in a state with no-fault auto insurance.
    public static void PolicyInNoFaultState(ModifiedAutoPolicy policy)
    {
        Console.WriteLine("The auto policy:");
        Console.Write($"Account #: {policy.AccountNumber}; ");
        Console.WriteLine($"Car: {policy.MakeAndModel};");
        Console.Write($"State {policy.State} ");
        Console.Write($"{(policy.IsNoFaultState ? "is": "is not")}");
        Console.WriteLine(" a no-fault state\n");
    }
}