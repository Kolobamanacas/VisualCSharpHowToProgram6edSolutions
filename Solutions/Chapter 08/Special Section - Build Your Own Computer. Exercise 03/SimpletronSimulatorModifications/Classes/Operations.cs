// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Special Section: Build Your Own Computer. Exercise 03 (08.33) Project: Simpletron Simulator Modifications

namespace SimpletronSimulatorModifications.Classes
{
    /// <summary>
    /// List of operations possible with Simpletron computer.
    /// </summary>
    public static class Operations
    {
        #region Constants

        // Input and output operations.
        /// <summary>
        /// Read a word from the keyboard into a specific location in memory.
        /// </summary>
        public const int Read = 10;
        /// <summary>
        /// Write a word from a specific location in memory to the screen.
        /// </summary>
        public const int Write = 11;
        /// <summary>
        /// Write a newline character to the screen.
        /// </summary>
        public const int WriteNewLine = 12;
        /// <summary>
        /// Read a string of text and store it in the successive number of cells starting at the specific loaction in memory.
        /// Each command in a cell stores two letters and the first part of the first command stores the total number of letters.
        /// </summary>
        public const int ReadString = 13;
        /// <summary>
        /// Write a string of text from the seccessive number of cells starting at the specific loaction in memory to the screen.
        /// Each command in a cell stores two letters and the first part of the first command stores the total number of letters.
        /// </summary>
        public const int WriteString = 14;

        // Load and store operations.
        /// <summary>
        /// Load a word from a specific location in memory into the accumulator.
        /// </summary>
        public const int Load = 20;
        /// <summary>
        /// Store a word from the accumulator into specific location in memory.
        /// </summary>
        public const int Store = 21;

        // Arithmetic operations.
        /// <summary>
        /// Add a word from a specific location in memory to the word in the accumulator (leave the result in the accumulator).
        /// </summary>
        public const int Add = 30;
        /// <summary>
        /// Subtract a word from a specific location in memore from the word in the accumulator (leave the result in the accumulator).
        /// </summary>
        public const int Subtract = 31;
        /// <summary>
        /// Divide a word from a specific location in memory into the word in the accumulator (leave the result in the accumulator).
        /// </summary>
        public const int Divide = 32;
        /// <summary>
        /// Multiply a word from a specific loaction in memory by the word in the accumulator (leave the result in the accumulator).
        /// </summary>
        public const int Multiply = 33;
        /// <summary>
        /// Calculate a reminder after division of a word from a specific location in memory into the word in the accumulator
        /// (leave the result in the accumulator).
        /// </summary>
        public const int Reminder = 34;
        /// <summary>
        /// Raises a number in the accumulator to the power of a number from a specific location in memory
        /// (leave the result in the accumulator).
        /// </summary>
        public const int Power = 35;

        // Transfer-of-control operations.
        /// <summary>
        /// Branch to a specific location in memory.
        /// </summary>
        public const int Branch = 40;
        /// <summary>
        /// Branch to a specific location in memory if the accumulator is negative.
        /// </summary>
        public const int BranchNeg = 41;
        /// <summary>
        /// Branch to a specific location in memory if the accumulator is zero.
        /// </summary>
        public const int BranchZero = 42;
        /// <summary>
        /// Halt. The program has completed its task.
        /// </summary>
        public const int Halt = 43;

        #endregion
    }
}