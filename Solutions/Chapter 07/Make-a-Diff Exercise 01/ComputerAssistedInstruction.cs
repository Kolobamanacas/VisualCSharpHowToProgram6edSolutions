// Solution to exercises from "C# How to Program 6th edition".
// Chapter 7.
// Making-a-Difference Exercise 01 (07.39) Computer-Assisted Instruction.

/* I would personally add a timer to this exercise to make it more fun and rival giving questions by blocks of 10 questions for people could compete for the better results. But we still don't know how to work with time, so let's make it simple for now. */

using System;

class ComputerAssistedInstruction
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

    /* Private static method "Question()" takes no arguments and returns no values. It generates two random numbers from 0 to 9 and asks a user to enter their product. If the answer is incorrect it asks a user to try again. It also calculates the number of correct and incorrect answers and prints them as soon as user answers correctly. */
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
                Console.WriteLine("Very good!");
            }
            else
            {
                ++incorrectAnswers;
                Console.WriteLine("No. Please try again.");
            }
        }

        Console.WriteLine($"Number of correct answers to the moment: {correctAnswers}");
        Console.WriteLine($"Number of incorrect answers to the moment: {incorrectAnswers}");
    }
}