// Solution to exercises from "C# How to Program 6th edition".
// Chapter 9.
// Exercise 03 (09.05) Sorting Letters and Removing Duplicates.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SortingLettersAndRemovingDuplicates.Classes
{
    public class SorterAndDuplicatesRemover
    {
        #region Main Method

        public static void Main()
        {
            string randomString = GenerateRandomString(30);
            List<char> randomChars = new List<char>();
            Console.WriteLine("Initial list of characters:");

            foreach (char letter in randomString)
            {
                Console.Write(letter);
                randomChars.Add(letter);
            }

            IOrderedEnumerable<char> randomCharsSortedAscending =
                from letter in randomChars
                orderby letter ascending
                select letter;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("List of characters sorted ascending:");

            foreach (char letter in randomCharsSortedAscending)
            {
                Console.Write(letter);
            }

            IOrderedEnumerable<char> randomCharsSortedDescending =
                from letter in randomChars
                orderby letter descending
                select letter;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("List of characters sorted descending:");

            foreach (char letter in randomCharsSortedDescending)
            {
                Console.Write(letter);
            }

            IOrderedEnumerable<char> randomCharsSortedAscendingWithRemovedDuplicates =
                from letter in randomChars.Distinct()
                orderby letter ascending
                select letter;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("List of characters sorted ascending with removed duplicates:");

            foreach (char letter in randomCharsSortedAscendingWithRemovedDuplicates)
            {
                Console.Write(letter);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns text string of random chracters with specified lenght.
        /// </summary>
        /// <param name="numberOfLetters">Number of characters the returned string should contain.</param>
        private static string GenerateRandomString(int numberOfLetters)
        {
            string randomString = "";

            // System.IO namespace contains "Path" class, which has "GetRandomFileName()" method, which in turn returns string of 12
            // random characters including one comma (,). Replacing comma with empty space we get string of 11 random characters.
            // Thus we get the desired number of characters to generate from the "numberOfLetters" parameter and for every 11 characters we
            // generate additional 11 random characters and append them to "randomString".
            for (int letterIndex = 0; letterIndex < (((numberOfLetters - 1) / 11) + 1); ++letterIndex)
            {
                randomString += Path.GetRandomFileName().Replace(",", "");
            }

            // Return the number of random strings specified in "numberOfLetters" parameter.
            return randomString.Substring(0, numberOfLetters);
        }

        #endregion
    }
}