// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Making-a-Difference Exercise 01 (08.34) Polling.

using System;

namespace Polling.Classes
{
    public class Polling
    {
        #region Constants
        
        /// <summary>
        /// Number of possible rates of importance for every topic.
        /// </summary>
        private const int NumberOfRates = 10;

        #endregion

        #region Private Fields

        /// <summary>
        /// The list of topics to be rated.
        /// </summary>
        private static readonly string[] topics = new string[] {
            "Long-term energy storage",
            "Cultured meat",
            "Early diagnostic of oncological diseases",
            "Genome editing",
            "Ways to prevent world economic crises"};
        /// <summary>
        /// Survey results. Each row is a topic and each column is a rating.
        /// </summary>
        private static readonly int[,] pollResults = new int[topics.Length, NumberOfRates];

        #endregion

        #region Main Method

        public static void Main()
        {
            Console.WriteLine("Welcome to polling app.\n"
                + "We will ask you to rate the importance of five topics giving them rate in 1 to 10 range.");
            Console.WriteLine();

            // Local variable we would use to prevent loop where respondents are asked to rate topics.
            bool readNextRespondent = true;
            // Number of repsondents counter.
            int numberOfRespondents = 1;

            // Ask to rate topics until user prevents the loop by answering "no".
            while (readNextRespondent)
            {
                Console.WriteLine($"Respondent {numberOfRespondents}.");
                Console.WriteLine("Please rate the importance of each topic with number from 1 to 10,"
                    + " where 1 - least important topic and 10 is the most important topic.");

                // Ask respondent to rate each topic.
                for (int topicNumber = 0; topicNumber < topics.Length; ++topicNumber)
                {
                    Console.WriteLine($"Topic {topicNumber}: {topics[topicNumber]}.");
                    Console.Write("Enter your rating (integer from 1 to 10): ");
                    // Store string of text entered by a user in local variable.
                    string userInputString = Console.ReadLine();
                    // Local variable to store eventual rating for the certain topic by current user.
                    int userRating;
                    /* Alongside to the "Parse()" method "int" also has "TryParse()" method. It alone helps us to complete two tasks
                     * at a time. First it checks a sting of text passed as the first parameter and if it is possible to parse it to
                     * an integer, the method returns "true". If it isn't possible to parse the string as integer the method returns
                     * "false". Secondly, if pasring is possible it writes the resulting integer to a variable passed as a reference as
                     * the second parameter. */
                    bool isUserInputCorrect = int.TryParse(userInputString, out userRating);

                    // While user entering string that cannot be parsed to integer, of the integer is out of range, ask user to enter
                    // new value.
                    while (!isUserInputCorrect || userRating < 1 || userRating > 10)
                    {
                        Console.WriteLine("You should enter integer in 1 to 10 range.");
                        Console.Write("Please enter your rating (integer from 1 to 10): ");
                        userInputString = Console.ReadLine();
                        isUserInputCorrect = int.TryParse(userInputString, out userRating);
                    }

                    ++pollResults[topicNumber, userRating - 1];
                    Console.WriteLine();
                }

                Console.Write("Do you want to poll more respondents (\"y\" - yes, \"n\" - no): ");
                string userStringInput = Console.ReadLine();

                while (userStringInput != "y" && userStringInput != "n")
                {
                    Console.WriteLine("You should enter \"y\" or \"n\".");
                    Console.Write("Do you want to poll more respondents (\"y\" - yes, \"n\" - no): ");
                    userStringInput = Console.ReadLine();
                }

                if (userStringInput == "y")
                {
                    Console.WriteLine();
                    ++numberOfRespondents;
                    readNextRespondent = true;
                }
                else
                {
                    readNextRespondent = false;
                }
            }

            Console.WriteLine();
            PrintReport();
            Console.WriteLine();
            PrintTopicsWithHighestPoint();
            Console.WriteLine();
            PrintTopicsWithLowestPoint();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();




        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Prints tabular report with five topics down the left side and the 10 ratings across the top, listing in each column the number
        /// of ratings received for each topic.
        /// </summary>
        private static void PrintReport()
        {
            Console.WriteLine("Statistics for all topics and ratings.");
            Console.WriteLine("          Ratings:");
            Console.WriteLine("Topics:   1   2   3   4   5   6   7   8   9  10  Avarage:");

            for (int topicIndex = 0; topicIndex < topics.Length; ++topicIndex)
            {
                int numberOfAssignedRatings = 0;
                int topicRatingsSum = 0;
                Console.Write($"{topicIndex}      ");

                for (int ratingIndex = 0; ratingIndex < pollResults.GetLength(1); ++ratingIndex)
                {
                    // Every rating number is right aligned and takes at least 4 charactes with leading spaces.
                    Console.Write($" {pollResults[topicIndex, ratingIndex], 3}");

                    if (pollResults[topicIndex, ratingIndex] > 0)
                    {
                        // Add every assigned rating to the "topicRatingsSum".
                        topicRatingsSum += ratingIndex + 1;
                        // Increment number of assigned ratings.
                        ++numberOfAssignedRatings;
                    }
                }

                // Print average of ratings per topic.
                Console.Write($"{topicRatingsSum / numberOfAssignedRatings, 9}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Scans "pollResults" array, then finds the topics with highest number of highest scores, then prints it.
        /// </summary>
        private static void PrintTopicsWithHighestPoint()
        {
            // Local variable that stores the number of highest rating assigned to at least one topic.
            int highestRatingIndex = 0;
            // Local variable that tells us whether highest rating is found during the for loop.
            bool isHighesRatingFound = false;

            for (int ratingIndex = (pollResults.GetLength(1) - 1); ratingIndex >= 0; --ratingIndex)
            {
                for (int topicIndex = 0; topicIndex < topics.Length; ++topicIndex)
                {
                    if (pollResults[topicIndex, ratingIndex] > 0)
                    {
                        isHighesRatingFound = true;
                        break;
                    }
                }

                if (isHighesRatingFound)
                {
                    highestRatingIndex = ratingIndex;
                    break;
                }
            }

            // Local variable to store the highest rating.
            int highestRatingValue = 0;

            // Find value of the highest rating.
            for (int topicIndex = 0; topicIndex < topics.Length; ++topicIndex)
            {
                if (pollResults[topicIndex, highestRatingIndex] > highestRatingValue)
                {
                    highestRatingValue = pollResults[topicIndex, highestRatingIndex];
                }
            }

            // Find all topics with highest rating.
            int[] topicsWithHighestRating = new int[0];

            for (int topicIndex = 0; topicIndex < topics.Length; ++topicIndex)
            {
                // For all found topics, write their numbers to the "topicsWithHighestRating" array.
                if (pollResults[topicIndex, highestRatingIndex] == highestRatingValue)
                {
                    // Use temp array to meake "topicsWithHighestRating" size larger by 1, but save existing values.
                    // Create a temp array as a full compy of "topicsWithHighestRating".
                    int[] tempArray = topicsWithHighestRating;
                    // Make "topicsWithHighestRating" larger by one.
                    topicsWithHighestRating = new int[topicsWithHighestRating.Length + 1];
                    // Copy all data from temp array to newly created one.
                    Array.Copy(tempArray, 0, topicsWithHighestRating, 0, tempArray.Length);
                    // Write index of the topic to the last position in the array.
                    topicsWithHighestRating[topicsWithHighestRating.Length - 1] = topicIndex;
                }
            }

            Console.WriteLine($"The following topics have the highest rating ({highestRatingIndex + 1}):");

            for (int topicIndex = 0; topicIndex < topicsWithHighestRating.Length; ++topicIndex)
            {
                Console.WriteLine($"{topicsWithHighestRating[topicIndex]} - {topics[topicsWithHighestRating[topicIndex]]}");
            }
        }

        /// <summary>
        /// Scans "pollResults" array, then finds the topics with highest number of lowest scores, then prints it.
        /// </summary>
        private static void PrintTopicsWithLowestPoint()
        {
            // Local variable that stores the number of lowest rating assigned to at least one topic.
            int lowestRatingIndex = 0;
            // Local variable that tells us whether lowest rating is found during the for loop.
            bool isLowestRatingFound = false;

            for (int ratingIndex = 0; ratingIndex < pollResults.GetLength(1); ++ratingIndex)
            {
                for (int topicIndex = 0; topicIndex < topics.Length; ++topicIndex)
                {
                    if (pollResults[topicIndex, ratingIndex] > 0)
                    {
                        isLowestRatingFound = true;
                        break;
                    }
                }

                if (isLowestRatingFound)
                {
                    lowestRatingIndex = ratingIndex;
                    break;
                }
            }

            // Local variable to store the lowest rating.
            int lowestRatingValue = int.MaxValue;

            // Find value of the lowest rating.
            for (int topicIndex = 0; topicIndex < topics.Length; ++topicIndex)
            {
                if (pollResults[topicIndex, lowestRatingIndex] != 0
                    && pollResults[topicIndex, lowestRatingIndex] < lowestRatingValue)
                {
                    lowestRatingValue = pollResults[topicIndex, lowestRatingIndex];
                }
            }

            // Find all topics with lowest rating.
            int[] topicsWithLowestRating = new int[0];

            for (int topicIndex = 0; topicIndex < topics.Length; ++topicIndex)
            {
                // For all found topics, write their numbers to the "topicsWithLowestRating" array.
                if (pollResults[topicIndex, lowestRatingIndex] == lowestRatingValue)
                {
                    // Use temp array to meake "topicsWithHighestRating" size larger by 1, but save existing values.
                    // Create a temp array as a full compy of "topicsWithHighestRating".
                    int[] tempArray = topicsWithLowestRating;
                    // Make "topicsWithHighestRating" larger by one.
                    topicsWithLowestRating = new int[topicsWithLowestRating.Length + 1];
                    // Copy all data from temp array to newly created one.
                    Array.Copy(tempArray, 0, topicsWithLowestRating, 0, tempArray.Length);
                    // Write index of the topic to the last position in the array.
                    topicsWithLowestRating[topicsWithLowestRating.Length - 1] = topicIndex;
                }
            }

            Console.WriteLine($"The following topics have the lowest rating ({lowestRatingIndex + 1}):");

            for (int topicIndex = 0; topicIndex < topicsWithLowestRating.Length; ++topicIndex)
            {
                Console.WriteLine($"{topicsWithLowestRating[topicIndex]} - {topics[topicsWithLowestRating[topicIndex]]}");
            }
        }

        #endregion
    }
}