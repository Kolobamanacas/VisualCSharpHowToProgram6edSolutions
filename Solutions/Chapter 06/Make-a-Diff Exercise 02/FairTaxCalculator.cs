// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Making-a-Difference Exercise 2 (06.03) Tax Plan Alternatives; The "FairTax".

/* The topic took me some time to understand. I believe that managers of FairTax have problems with turning the project into a law also because there so few sources with good, easy and clear explanation of how does FairTax work. These links were the most helpful to me:
https://youtu.be/NFDJ-1MrrPU
https://en.wikipedia.org/wiki/Poverty_in_the_United_States#Measures_of_poverty

Here is my understanding of a situation. The most of taxes are eliminated and replaced by consuption tax. Consumtion tax is paid on the basis of what goods and services people buy and not on the basis of their salary. FairTax is calculated as 23% of total amount of money a person spend to buy goods and services. Just like that. As I understood the mess with "30% tax" arise from the mechanics of calculation of some current US taxes, where percentage is taken not from, let's say every 100$ a person spend, but from every 77$. 23% of 100$ is almost the same amount of money as 30% of 77$.

The second important part of FairTax is pre-bate. It is the way to create a balance between rich and poor and help the second group to stay bouyant. With pre-bate systeme a person with valid social security ID monthly get amount of money depending on it's income, marrige status and number of childer. This amount is based on povery level declared by United States Department of Health and Human Services. Marrige status and number of children also affect monthly consumption allowance which is amount of money a family could spend with not taxes. */

using System;
using System.Globalization;

class FairTaxCalculator
{
    // Initialize a static field as a new object of class "CultureInfo" to use it during output to get dot as decimal mark.
    private static CultureInfo cultureEnUs = new CultureInfo("en-US");

    static void Main()
    {
        Console.WriteLine("Wellcome to FairTax calculator.\nPlease tell us about your family size.");
        
        /* Call "IsMarried" method to check whether a user is married. The method would return "false" if a user is forever alone and "true" otherwise. */
        bool isMarried = IsMarried();
        /* Call "NumberOfChildred" method to prompt a user to enter a number of children and check the correctness. The method returns a number from 0 to 8. */
        int numberOfChildren = NumberOfChildren();
        /* Method "MonthlyPrebate calculates and returns a prebate sum of money depending on family status and size. */
        decimal monthlyPrebate = MonthlyPrebate(isMarried, numberOfChildren);
        /* With similar logic "MonthlyConsumptionAllowance" method calculates and returns monthly consumption limit. */
        decimal monthlyConsumptionAllowance = MonthlyConsumptionAllowance(isMarried, numberOfChildren);
        // Here we would store all user's spendings.
        decimal totalExpensesForAMonth = 0;
        // Here we would store all user's spendings which we need to subtract the tax from.
        decimal taxExpensesForAMonth = 0;
        
        Console.WriteLine();
        Console.WriteLine("Enter expenses of your family for a month in US dollars for every proposed category.");
        
        /* We add taxed expenses to both "totalExpensesForAMonth" and "taxExpensesForAMonth". But for expenses which is not taxed (like education) we add expenses only to "totalExpensesForAMonth". Your could also probably notice that "Parse()" method now takes two arguments instead of one. The second one is an object of class CultureInfo, which holds an information of specific culture. I put it there to have dot as decimal mark instead of comma which is usually used as decimal mark in my region. */

        Console.Write("Housing: ");
        decimal housingExpenses = decimal.Parse(Console.ReadLine(), cultureEnUs);
        totalExpensesForAMonth += housingExpenses;
        taxExpensesForAMonth += housingExpenses;
        
        Console.Write("Food: ");
        decimal foodExpenses = decimal.Parse(Console.ReadLine(), cultureEnUs);
        totalExpensesForAMonth += foodExpenses;
        taxExpensesForAMonth += foodExpenses;
        
        Console.Write("Clothing: ");
        decimal clothingExpenses = decimal.Parse(Console.ReadLine(), cultureEnUs);
        totalExpensesForAMonth += clothingExpenses;
        taxExpensesForAMonth += clothingExpenses;

        Console.Write("Transportation: ");
        decimal transportationExpenses = decimal.Parse(Console.ReadLine(), cultureEnUs);
        totalExpensesForAMonth += transportationExpenses;
        taxExpensesForAMonth += transportationExpenses;

        Console.Write("Education: ");
        totalExpensesForAMonth += decimal.Parse(Console.ReadLine(), cultureEnUs);

        Console.Write("Health care: ");
        decimal healthCareExpenses = decimal.Parse(Console.ReadLine(), cultureEnUs);
        totalExpensesForAMonth += healthCareExpenses;
        taxExpensesForAMonth += healthCareExpenses;

        Console.Write("Vacations: ");
        decimal vacationsExpenses = decimal.Parse(Console.ReadLine(), cultureEnUs);
        totalExpensesForAMonth += vacationsExpenses;
        taxExpensesForAMonth += vacationsExpenses;

        // Here we would store the amount of money to be taxed after subtraction of monthly consuption allowance.
        decimal expensesToBeTaxed = 0;

        /* The main output. Here I have to use even more arguments inside a "ToString()" method to get a nice look of the output. "0.00" tells that we want to see only two digits after a decimal mark. And "cultureEnUs" is used to have dot as a decimal mark and not comma, which is used as decimal mark in my region. */
        Console.WriteLine();
        Console.WriteLine($"Your total expenses for a month are {(totalExpensesForAMonth).ToString("0.00", cultureEnUs)}$.");
        Console.WriteLine("There are some expense categories (like education) that are not taxed. ");
        Console.WriteLine($"Your expenses excluding these categories are {(taxExpensesForAMonth).ToString("0.00", cultureEnUs)}$.");
        Console.WriteLine($"Taking into account your family size your monthly consumption allowance is {(monthlyConsumptionAllowance).ToString("0.00", cultureEnUs)}$. ");
        
        /* A variable to store FairTax rate itselft. Suffix "m" near "0.23" number means that the number belongs to the decimal type. Without it "0.23" would be treated as double. For some reason I get a compiler error when I try to put the "0.23m" directly inside of "decimal.Multiply()" method. The (decimal) cast doesn't work either. */
        decimal fairTaxRate = 0.23m;

        if (taxExpensesForAMonth > monthlyConsumptionAllowance)
        {
            expensesToBeTaxed = taxExpensesForAMonth - monthlyConsumptionAllowance;
            Console.WriteLine($"Which means that the total amount of money to be taxed is: {(expensesToBeTaxed).ToString("0.00", cultureEnUs)}$.");
            /* Of course here I could use "expensesToBeTaxed * fairTaxRate" but I decide to show that "decimal" type (which technically a class) also has a method "Multiply()" which is sometimes useful because it checks whether both operands are decimal type. */
            Console.WriteLine($"The amount of money to be paid as Fair Tax this month is: {(decimal.Multiply(expensesToBeTaxed, fairTaxRate)).ToString("0.00", cultureEnUs)}$.");
        }
        else
        {
            Console.WriteLine("As soon as your family spent less that your consumption limit you would not be taxed this month at all.");
        }

        Console.WriteLine($"Your family would also get additional {(monthlyPrebate).ToString("0.00", cultureEnUs)}$ as a part of pre-bate.");

        Console.WriteLine();
        Console.WriteLine("That's it. :)");
    }

    static bool IsMarried()
    {
        Console.Write("Are you married (type \"yes\" for yes and \"no\" for no): ");
        string isMarried = Console.ReadLine();

        // We can compare a string entered by user with any other string. It is useful to check an input correctness.
        while (isMarried != "yes"
            && isMarried != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\". Please enter a correct answer.");
            Console.Write("Are you married (type \"yes\" for yes and \"no\" for no): ");
            isMarried = Console.ReadLine();
        }

        // If a user entered "yes" return "true" - he/she is married. Otherwise return "false".
        if (isMarried == "yes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static int NumberOfChildren()
    {
        Console.Write("How many shildren do you have (from 0 to 8): ");

        int numberOfChildren = int.Parse(Console.ReadLine(), cultureEnUs);

        /* Technically, people could have more than 8 children (my great-grandmother had about 18), but let's assume that 8 is ok for now. */
        while (numberOfChildren < 0
            || numberOfChildren > 8)
        {
            Console.WriteLine("The number of children should be from 0 to 8. Please enter a correct answer.");
            Console.Write("How many shildren do you have (from 0 to 8): ");
            numberOfChildren = int.Parse(Console.ReadLine(), cultureEnUs);
        }

        return numberOfChildren;
    }

    /* I took these rates of prebate and consuption allowance from wikipedia. */

    static decimal MonthlyPrebate(bool isMarried, int numberOfChildren)
    {
        if (isMarried)
        {
            switch (numberOfChildren)
            {
                case 0:
                    return 451;
                case 1:
                    return 531;
                case 2:
                    return 611;
                case 3:
                    return 690;
                case 4:
                    return 770;
                case 5:
                    return 850;
                case 6:
                    return 930;
                case 7:
                    return 1009;
                default:
                    Console.WriteLine("Your shouldn't be able to get here. Something wrong has happened.");
                    return 0;
            }
        }
        else
        {
            switch (numberOfChildren)
            {
                case 0:
                    return 226;
                case 1:
                    return 305;
                case 2:
                    return 385;
                case 3:
                    return 465;
                case 4:
                    return 545;
                case 5:
                    return 624;
                case 6:
                    return 699;
                case 7:
                    return 784;
                default:
                    Console.WriteLine("Your shouldn't be able to get here. Something wrong has happened.");
                    return 0;
            }
        }
    }

    static decimal MonthlyConsumptionAllowance(bool isMarried, int numberOfChildren)
    {
        if (isMarried)
        {
            switch (numberOfChildren)
            {
                case 0:
                    return 23540 / 12;
                case 1:
                    return 27700 / 12;
                case 2:
                    return 31860 / 12;
                case 3:
                    return 36020 / 12;
                case 4:
                    return 40180 / 12;
                case 5:
                    return 44340 / 12;
                case 6:
                    return 48500 / 12;
                case 7:
                    return 52660 / 12;
                default:
                    return (52660 / 12) + (((numberOfChildren - 7) * 4160) / 12);
            }
        }
        else
        {
            switch (numberOfChildren)
            {
                case 0:
                    return 11770 / 12;
                case 1:
                    return 15930 / 12;
                case 2:
                    return 20090 / 12;
                case 3:
                    return 24250 / 12;
                case 4:
                    return 28410 / 12;
                case 5:
                    return 32570 / 12;
                case 6:
                    return 36490 / 12;
                case 7:
                    return 40890 / 12;
                default:
                    return (40890 / 12) + (((numberOfChildren - 7) * 4160) / 12);
            }
        }
    }
}