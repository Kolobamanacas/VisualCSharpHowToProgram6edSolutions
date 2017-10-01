// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Making-a-Difference Exercise 01 (05.41) World Population Growth.

using System;

class WorldPopulationGrowth
{
    static void Main()
    {
        /* Here are some useful articles about world population growth:
        https://ourworldindata.org/world-population-growth/
        https://www.theguardian.com/global-development/2015/jul/29/un-world-population-prospects-the-2015-revision-9-7-billion-2050-fertility
        http://blogs.worldbank.org/futuredevelopment/rapid-slowdown-population-growth
        http://www.worldometers.info/world-population/

        According to them, the current number of people on Earth is about 7 491 331 804. Yearly change is estimated as 1.11% in 2017 and drops down by aprroximately 0.0204% every year, but for this exercise we assume that the current growth would stay the same during the next years. */

        int year = 2017;
        bool wasPopulationDoubled = false;
        int yearWhenPopulationDoubled = 0;
        int yearCounter = 1;
        double initialPopulation = 7491331804;
        double population = 7491331804;

        Console.WriteLine($"Year\tAnticipated Population\tPopulation Increase");
        while (yearCounter <= 75)
        {
            /* "population" multiplyed by 0.0111 would equal to 1.11% of the original "population's" value. */
            Console.WriteLine($"{year}\t{population:F0}\t\t{(population * 0.0111):F0}");

            /* Catch and write ther first year when population doubles initial population. Change the "wasPopulationDoubled" to true so this check would happens only once. */
            if (wasPopulationDoubled == false)
            {
                if (population >= initialPopulation * 2)
                {
                    yearWhenPopulationDoubled = year;
                    wasPopulationDoubled = true;
                }
            }

            /* Increase population by 1.11%. Multiplying by 1 is the way to get 100% of any number. So the multiplying by 0.1 would leave 10% as it ten times less. But if we want to increase a number by let's say 10%, we need to add 1 to the 0.1. So any number multipied by 1.1 would equal to 110% of original value. The following assigning using the same logic. We increase population by 1.11% */
            population *= 1.0111;
            ++year;
            ++yearCounter;
        }

        Console.WriteLine();

        // Depending on was the "population" doubled or was it never doubled, print the corresponding message.
        if (yearWhenPopulationDoubled != 0)
        {
            Console.WriteLine($"The population was doubled at {yearWhenPopulationDoubled:F0}'s year.");
        }
        else
        {
            Console.WriteLine($"The population was never doubled.");
        }
    }
}