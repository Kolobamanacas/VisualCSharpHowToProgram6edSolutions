// Solution to exercises from "C# How to Program 6th edition".
// Chapter 9.
// Exercise 02 (09.04) Duplicate Word Removal.

using System;
using System.Linq;

namespace DuplicateWordRemoval.Classes
{
    public class DuplicateWordRemoval
    {
        #region Public Properties

        /// <summary>
        /// String of text to store sentence entered by a user.
        /// </summary>
        public static string Sentence { get; set; }

        #endregion

        #region Main Method

        public static void Main()
        {
            Console.WriteLine("Wellcome to Duplicate Word Removal app.");
            Console.WriteLine("Please enter not empty sentence with no punctuation marks:");
            Sentence = Console.ReadLine();
            bool isInputWrong = true;

            // Loop here until user enters correct sentence.
            while (isInputWrong)
            {
                if (string.IsNullOrWhiteSpace(Sentence))
                {
                    isInputWrong = true;
                    Console.WriteLine("The sentence should contain at least one character.");
                    Console.WriteLine("Please enter non-empty sentence with no punctuation marks:");
                    Sentence = Console.ReadLine();
                    continue;
                }
                else
                {
                    bool sentenceContainsWrongCharacter = false;

                    foreach (char letter in Sentence)
                    {
                        if (!char.IsLetterOrDigit(letter) && letter != ' ')
                        {
                            sentenceContainsWrongCharacter = true;
                            break;
                        }
                    }

                    if (sentenceContainsWrongCharacter)
                    {
                        isInputWrong = true;
                        Console.WriteLine("The sentence may contains only letters, digits and whitespaces.");
                        Console.WriteLine("Please enter non-empty sentence with no punctuation marks:");
                        Sentence = Console.ReadLine();
                        continue;
                    }
                }

                isInputWrong = false;
            }

            // Sequentially call "ToLower()" method to make all letters in "Sentence" string lowercase, then call "Split()" method to
            // to split string and save every word in separate element of array "separatedWords[]".
            string[] separatedWords = Sentence.ToLower().Split();
            // Call "Distinct()" method to select unique words from the "separatedWords[]" array, then use LINQ query to sort the eventual
            // set of strings ascending.
            IOrderedEnumerable<string> uniqueWordsSortedAscending =
                from word in separatedWords.Distinct()
                orderby word ascending
                select word;

            Console.WriteLine();
            Console.WriteLine("Distinct words from the sentence sorted alphabetically:");

            foreach (string word in uniqueWordsSortedAscending)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        #endregion
    }
}
