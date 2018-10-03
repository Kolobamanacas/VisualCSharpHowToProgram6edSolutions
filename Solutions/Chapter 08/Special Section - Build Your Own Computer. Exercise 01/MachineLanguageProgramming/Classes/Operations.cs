// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Special Section: Build Your Own Computer. Exercise 01 (08.31) Machine-Language Programming

namespace MachineLanguageProgramming.Classes
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