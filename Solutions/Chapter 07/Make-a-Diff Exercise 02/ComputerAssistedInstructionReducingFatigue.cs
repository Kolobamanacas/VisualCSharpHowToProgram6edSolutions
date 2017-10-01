// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Making-a-Difference Exercise 02 (07.40) Computer-Assisted Instruction: Reducing Student Fatigue.

/* It is a minor change comparing to previous version of this app. We simple add more answers options after user's product guess. */

using System;

class ComputerAssistedInstructionReducingFatigue
{
    // Private static field to store number of correct answers.
    private static int correctAnswers = 0;
    // Private static field to store number of incorrect answers.
    private static int incorrectAnswers = 0;
    // Creating an object "randomNumbers" of a class "Random" for following random number generation.
    private static Random randomNumbers = new Random();

    static void Main()
    {
        // Print a wellcome message.
        Console.WriteLine("The app helps you to learn multiplication.");
        // Initialize "toProceed" local variable to "true" to use it as a control statemnt in the while loop.
        bool toProceed = true;

        while (toProceed)
        {
            // Call for "Question()" method that generates two numbers, print a questions and check the correctness of the answer.
            Question();

            Console.WriteLine();
            // Ask a user whether he/she wants to proceed.
            toProceed = ToProceed();
        }
    }

    /* "ToProceed()" method asks a user whether he/she wants to check another multiplication expression. If a user enters "yes" then the method returns the value of "true" and otherwise it returns "false". */
    private static bool ToProceed()
    {
        Console.Write("Do you want to check antoher expression (\"yes\" or \"no\"): ");
        string answer = Console.ReadLine();

        while (answer != "yes" && answer != "no")
        {
            Console.WriteLine("The answer should be \"yes\" or \"no\".");
            Console.Write("Do you want to check antoher expression (\"yes\" or \"no\"): ");
            answer = Console.ReadLine();
        }

        if (answer == "yes")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /* Private static method "Question()" takes no arguments and returns no values. It generates two random numbers from 0 to 9 and asks a user to enter their product. If the answer is incorrect it asks a user to try again with different phrases chosen by "switch" statement and randomly generated number. It also calculates the number of correct and incorrect answers and prints them as soon as user answers correctly. */
    private static void Question()
    {
        int number1 = randomNumbers.Next(10);
        int number2 = randomNumbers.Next(10);
        int answer = -1;

        while (answer != number1 * number2)
        {
            Console.Write($"How much is {number1} times {number2}: ");
            answer = int.Parse(Console.ReadLine());

            if (answer == number1 * number2)
            {
                ++correctAnswers;

                switch (randomNumbers.Next(4) + 1)
                {
                    case 1:
                        Console.WriteLine("Very good!");
                        break;
                    case 2:
                        Console.WriteLine("Excellent!");
                        break;
                    case 3:
                        Console.WriteLine("Nice work!");
                        break;
                    case 4:
                        Console.WriteLine("Keep up the good work!");
                        break;
                    default:
                        Console.WriteLine("Something went wrong. You shouldn't be able to get here.");
                        break;
                }
            }
            else
            {
                ++incorrectAnswers;

                switch (randomNumbers.Next(4) + 1)
                {
                    case 1:
                        Console.WriteLine("No. Please try again.");
                        break;
                    case 2:
                        Console.WriteLine("Wring. Try once more.");
                        break;
                    case 3:
                        Console.WriteLine("Don't give up!");
                        break;
                    case 4:
                        Console.WriteLine("No. Keep trying.");
                        break;
                    default:
                        Console.WriteLine("Something went wrong. You shouldn't be able to get here.");
                        break;
                }
            }
        }

        Console.WriteLine($"Number of correct answers to the moment: {correctAnswers}");
        Console.WriteLine($"Number of incorrect answers to the moment: {incorrectAnswers}");
    }
}