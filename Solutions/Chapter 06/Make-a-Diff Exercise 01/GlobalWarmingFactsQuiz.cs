// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Making-a-Difference Exercise 01 (06.29) Global Warming Facts Quiz.

/* This exercise could be a good example to demonstrate arrays, but we don't know about them to the moment. But as soon as our software become more and more complicated, let's still try to keep it as simple as possible.

We need to perform the same actions (print a question and answer options and store an answer) five times, one for every question. In such cases it is a good practice to put a recurring logic to a separate method and call this method with appropriate arguments when needed. I've created two methods "PrintQuestionAndAnswers" and "AssignAnAnswer". The first one doesn't return any value and prints question and four answer options passed to it as arguments. The second method asks user for an answer, chech whether an answer is in appropriate range and returns user answer's value. Inside a "Main" method we call these functions five times instead of hardcode these actions themselves. */

using System;

class GlobalWarmingFactsQuiz
{
    static void Main()
    {
        // A variable to store the number of correct answers.
        int correctAnswers = 0;

        // Wellcome messages.
        Console.WriteLine("Global Warming quiz.");
        Console.WriteLine("You'll be asked five question with four answer option and only correct answer in every question).");
        Console.WriteLine();

        // Calling a method that prints a question and answe options.
        PrintQuestionAndAnswers(
            "Question 1. Which industry produce the most heat-trappint pollutions?",
            "1) Transportation.",
            "2) Agriculture.",
            "3) Electricity.",
            "4) Video Games.");

        Console.WriteLine();
        // Initialize a variable with a value entered by a user and checked and returned by "AssignAnAnswer" method.
        int answer1 = AssignAnAnswer();

        // If an answer is correct then increment a total number of correct answers.
        if (answer1 == 3)
        {
            ++correctAnswers;
        }

        Console.WriteLine();

        PrintQuestionAndAnswers(
            "Question 2. Which effect is not caused by global warming?",
            "1) Potential disappearance of some animal species.",
            "2) Terroreast attacks.",
            "3) Havier rainfals.",
            "4) Air pollution.");

        Console.WriteLine();
        int answer2 = AssignAnAnswer();

        if (answer2 == 2)
        {
            ++correctAnswers;
        }

        Console.WriteLine();

        PrintQuestionAndAnswers(
            "Question 3. What is a sharp temperature increase in the last decade called?",
            "1) Hockey stick.",
            "2) Basketball ring.",
            "3) Bezier curve.",
            "4) Sudden shift.");

        Console.WriteLine();
        int answer3 = AssignAnAnswer();

        if (answer3 == 1)
        {
            ++correctAnswers;
        }

        Console.WriteLine();

        PrintQuestionAndAnswers(
            "Question 4. Which gas is claimed to be the main reason of global warming?",
            "1) Nirtous oxide.",
            "2) Chlorine.",
            "3) Carbon dioxide.",
            "4) Methane.");
        
        Console.WriteLine();
        int answer4 = AssignAnAnswer();

        if (answer4 == 3)
        {
            ++correctAnswers;
        }

        Console.WriteLine();

        PrintQuestionAndAnswers(
            "Question 5. Which of these statements is not used by climate change sceptics?",
            "1) Nightwish without Tarja is not that good as it was with her.",
            "2) Natural year-to-year variability in global temperature is so large, with warming and cooling occurring all the time so we can't know for sure whther global temperature is rising or falling.",
            "3) The melting of Arctic sea ice evidence of warming, but not a human made warming.",
            "4) Natural changes in the amount of sunlight being absorbed by the Earth — due to natural changes in cloud cover — are responsible for most of the warming and not hummanity actions>");
        
        Console.WriteLine();
        int answer5 = AssignAnAnswer();

        if (answer5 == 1)
        {
            ++correctAnswers;
        }

        Console.WriteLine();

        // Use switch statement to check the number of correct answers and print appropriate message for each case.
        switch (correctAnswers)
        {
            case 5:
                Console.WriteLine("Excellent! You've correctly answered all questions.");
                break;
            case 4:
                Console.WriteLine("Very good! You have 4 correct answers.");
                break;
            default:
                Console.WriteLine("You hava less than 4 correct answers. Time to brush up on your knowledge of global warming!");
                Console.WriteLine("Here is some interesting links:");
                Console.WriteLine("https://www.nrdc.org/stories/global-warming-101");
                Console.WriteLine("http://www.drroyspencer.com/my-global-warming-skepticism-for-dummies/");
                Console.WriteLine("https://www.epa.gov/ghgemissions/sources-greenhouse-gas-emissions");
                Console.WriteLine("http://www.ucsusa.org/global_warming/science_and_impacts/science/CO2-and-global-warming-faq.html");
                break;
        }
    }

    // Method that prints a question and four answer options passed to it as arguments of type "string".
    // The method is static because we can't call non-static methods from a static method (Main is static).
    private static void PrintQuestionAndAnswers(
        string question, string answer1, string answer2, string answer3, string answer4)
    {
        Console.WriteLine(question);
        Console.WriteLine(answer1);
        Console.WriteLine(answer2);
        Console.WriteLine(answer3);
        Console.WriteLine(answer4);
    }

    /* Method that asks a user to enter some answer, check whether entered digit within correct range
    and return the answer as integer. */
    private static int AssignAnAnswer()
    {
        Console.Write("Your answer: ");
        int answer = int.Parse(Console.ReadLine());

        while (answer != 1
            && answer != 2
            && answer != 3
            && answer != 4)
        {
            Console.WriteLine("The answer should be an integer from 1 to 4.");
            Console.Write("Your answer: ");
            answer = int.Parse(Console.ReadLine());
        }

        return answer;
    }
}