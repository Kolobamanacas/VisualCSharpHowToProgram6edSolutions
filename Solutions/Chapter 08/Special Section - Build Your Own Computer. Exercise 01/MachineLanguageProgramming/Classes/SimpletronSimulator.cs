// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Special Section: Build Your Own Computer. Exercise 01 (08.31) Machine-Language Programming

using System;

namespace MachineLanguageProgramming.Classes
{
    public class SimpletronSimulator
    {
        #region Constants

        /// <summary>
        /// The number of cells to store words available in the simulated computer.
        /// </summary>
        private const int MemorySizeInWords = 100;

        /// <summary>
        /// Available simulation modes.
        /// </summary>
        private enum SimulationModes
        {
            Adder = 1,
            Avarage = 2,
            Largest = 3
        };

        #endregion

        #region Private fields

        /// <summary>
        /// Array of integers that represents memory locations.
        /// </summary>
        private static int[] memory = new int[MemorySizeInWords];
        /// <summary>
        /// Location in memory where current command execution takes place.
        /// </summary>
        private static int currentLocation = 0;
        /// <summary>
        /// A field that represents accumulator.
        /// </summary>
        private static int accumulator = 0;
        /// <summary>
        /// A mark used to check when to stop execution of an app.
        /// The initial value is "true" for the app to terminate in case no mode is selected.
        /// </summary>
        private static bool halt = true;

        #endregion

        #region Private methods

        /// <summary>
        /// Analyse and parse a command and executes it.
        /// </summary>
        private static void ExecuteCommand()
        {
            // Get a word with a command from the currently executed memory location.
            int command = memory[currentLocation];
            // Get the operation code from the first part of a command.
            int operation = command / 100;
            // Get the number of the cell (an address of a location in memory) from the second part of a command.
            int address = command % 100;

            // Using operation code, the address number stored in a command, "accumulator" and the number of current executed cell in memory
            // we are able to accomlish all sorts of operations, including change the next executed cell and exiting the app by changing
            // the "halt's" value to false.
            switch (operation)
            {
                case Operations.Read:
                    memory[address] = int.Parse(Console.ReadLine());
                    break;
                case Operations.Write:
                    Console.WriteLine(memory[address]);
                    break;
                case Operations.Load:
                    accumulator = memory[address];
                    break;
                case Operations.Store:
                    memory[address] = accumulator;
                    break;
                case Operations.Add:
                    accumulator += memory[address];
                    break;
                case Operations.Subtract:
                    accumulator -= memory[address];
                    break;
                case Operations.Divide:
                    accumulator /= memory[address];
                    break;
                case Operations.Multiply:
                    accumulator *= memory[address];
                    break;
                case Operations.Branch:
                    // Since the "currentLocation" is incremented after each command, we need to decrement the it's value beforehand to
                    // eventually get the exact cell executed.
                    currentLocation = address - 1;
                    break;
                case Operations.BranchNeg:
                    if (accumulator < 0)
                    {
                        // Since the "currentLocation" is incremented after each command, we need to decrement the it's value beforehand to
                        // eventually get the exact cell executed.
                        currentLocation = address - 1;
                    }
                    break;
                case Operations.BranchZero:
                    if (accumulator == 0)
                    {
                        // Since the "currentLocation" is incremented after each command, we need to decrement the it's value beforehand to
                        // eventually get the exact cell executed.
                        currentLocation = address - 1;
                    }
                    break;
                case Operations.Halt:
                    halt = true;
                    break;
                default:
                    halt = true;
                    break;
            }
        }

        #endregion

        #region Public Methods

        public static void Main()
        {
            Console.WriteLine("Welcome to Simpletron simulation app.");
            Console.WriteLine("Please select an app to simulate (enter \"1\", \"2\" or \"3\"):");
            Console.WriteLine("   1 - Read positive numbers and compute and displey their sum. Terminate input when a negative number is entered.");
            Console.WriteLine("   2 - Compute an avarage of seven entered numbers.");
            Console.WriteLine("   3 - Determine the largest number of given series. The first entered number indicates how many numbers will be processed.");
            int simulationMode = int.Parse(Console.ReadLine());

            while (simulationMode != 1 && simulationMode != 2 && simulationMode != 3)
            {
                Console.Write("The app number should be \"1\", \"2\" or \"3\". Please select an app to simulate: ");
                simulationMode = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Simulation started.");

            // Add appropriate command and data words to their place into memory depending of selected program to simulate.
            if (simulationMode == (int)SimulationModes.Adder)
            {
                // Change the "halt" mark to "false" so the app could be executed.
                halt = false;
                // Read a number to a memroy cell 11.
                memory[0] = 1011;
                // Load a number from cell 11 to the accumulator.
                memory[1] = 2011;
                // If a value in the accumulator is negative, branch to 14 so halting the program.
                memory[2] = 4114;
                // Read a number to a memory cell 12.
                memory[3] = 1012;
                // Load a number from cell 12 to the accumulator.
                memory[4] = 2012;
                // If a value in the accumulator is negative, branch to 14 so halting the program.
                memory[5] = 4114;
                // Load a number from cell 11 to the accumulator.
                memory[6] = 2011;
                // Add a number from cell 12 to a number in the accumulator.
                memory[7] = 3012;
                // Store a result number from the accumulator to cell 13.
                memory[8] = 2113;
                // Print a number from cell 13 to the screen.
                memory[9] = 1113;
                // Branch to location 00 to restart the loop.
                memory[10] = 4000;
                // Empty cells for storing data.
                memory[11] = 0000;
                memory[12] = 0000;
                memory[13] = 0000;
                // Halt the program.
                memory[14] = 4300;
            }
            else if (simulationMode == (int)SimulationModes.Avarage)
            {
                // Change the "halt" mark to "false" so the app could be executed.
                halt = false;
                // Read a number from user and save it to cell 09.
                memory[0] = 1009;
                // Load a number from cell 09 to the accumulator.
                memory[1] = 2009;
                // Add a number from cell 10 to a number in the accumulator and store a result in the accumulator.
                memory[2] = 3010;
                // Store the new value of the sum of all summands in cell 10.
                memory[3] = 2110;
                // Load a number of summands left to add stored in cell 11 to the accumulator.
                memory[4] = 2011;
                // Subtract 1 stored in cell 12 from the number of left summands stored in the accumulator.
                memory[5] = 3112;
                // Store the number of summands left to add to cell 11.
                memory[6] = 2111;
                // If the result is 0, i.e. there is no more summands to sum, branch to 14, to compute result and Halt.
                memory[7] = 4214;
                // Branch back to cell 00.
                memory[8] = 4000;
                // Cells to store numbers.
                memory[9] = 0000;
                memory[10] = 0000;
                memory[11] = 0007;
                memory[12] = 0001;
                // The total number of operands.
                memory[13] = 0007;
                // Load total sum of all entered numbers to the accumulator.
                memory[14] = 2010;
                // Divide sum of all entered numbers stored in the accumulator by 7 stored in cell 13.
                memory[15] = 3213;
                // Store resulting avarage from the accumulator to cell 10.
                memory[16] = 2110;
                // Print the resulting avarage stored in cell 10 to a screen.
                memory[17] = 1110;
                // Halt the program.
                memory[18] = 4300;
            }
            else if (simulationMode == (int)SimulationModes.Largest)
            {
                // Change the "halt" mark to "false" so the app could be executed.
                halt = false;
                // Read a number of numbers to be processed from user and save it in cell 15.
                memory[0] = 1015;
                // Read a number from user and save it in cell 16.
                memory[1] = 1016;
                // Load current largest number stored in cell 17 into the accumulator.
                memory[2] = 2017;
                // Subtract number stored in cell 16 from the number in the accumulator.
                memory[3] = 3116;
                // If the new value in the accumulator is negative, branch to cell 10.
                memory[4] = 4110;
                // Load a number of operands left into the accumulator.
                memory[5] = 2015;
                // Subtract 1 stored in cell 18 from number of operands left.
                memory[6] = 3118;
                // If the number in the accumulator is zero, branch to cell 13 to the end of the programm to print the result and halt.
                memory[7] = 4213;
                // Store the number of operands left to read from the accumulator to cell 15.
                memory[8] = 2115;
                // Branch back to the beginning to read new number.
                memory[9] = 4001;
                // Load new largest number to the accumulator.
                memory[10] = 2016;
                // Store the new largest number from the accumulator to cell 17.
                memory[11] = 2117;
                // Branch to cell 05 to decrement the number of left operands and then read next number and or halt the program.
                memory[12] = 4005;
                // Print resulting largest number stored in cell 17 to the screen.
                memory[13] = 1117;
                // Halt.
                memory[14] = 4300;
                // Store here number of numbers to be processed.
                memory[15] = 0000;
                // Store here every new number entered by a user.
                memory[16] = 0000;
                // Store here current largest number.
                memory[17] = 0000;
                // Store 1 here, to use in decremention operations.
                memory[18] = 0001;
            }

            // Start executing app from the location 0 till the "halt" command met.
            while (!halt)
            {
                ExecuteCommand();
                // Change current program's execution cell.
                ++currentLocation;
            }

            Console.WriteLine();
            Console.WriteLine("Simulation complete. Press any key to exit.");
            Console.ReadKey();
        }

        #endregion
    }
}