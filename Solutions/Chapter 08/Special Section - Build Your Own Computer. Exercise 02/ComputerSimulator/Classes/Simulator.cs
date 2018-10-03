// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Special Section: Build Your Own Computer. Exercise 02 (08.32) Computer Simulator

using System;

namespace ComputerSimulator.Classes
{
    public class Simulator
    {
        #region Constants

        /// <summary>
        /// The number of cells "memory[]" contains.
        /// </summary>
        private const int MemorySize = 100;
        /// <summary>
        /// Sentinel value used to prevent reading commands from a user.
        /// </summary>
        private const int SentinelValue = -99999;
        /// <summary>
        /// Minimum allowed value for a command/number.
        /// </summary>
        private const int MinValueRange = -9999;
        /// <summary>
        /// Maximum allowed value for a command/number.
        /// </summary>
        private const int MaxValueRange = +9999;

        #endregion

        #region Private fields

        /// <summary>
        /// Represents memory of the Simpletron with 100 available cells.
        /// </summary>
        private static readonly int[] memory = new int[MemorySize];
        /// <summary>
        /// Number of cell in memory, the is currently executed.
        /// </summary>
        private static int instructionCounter = 0;
        /// <summary>
        /// CPU register from where commands are executed by a processor.
        /// </summary>
        private static int instructionRegister = 0;
        /// <summary>
        /// A register where operations code of an instruction is stored.
        /// </summary>
        private static int operationCode = 0;
        /// <summary>
        /// A register where operand (i.e. cell in the memory to be processed) is stored.
        /// </summary>
        private static int operand = 0;
        /// <summary>
        /// A field that represents accumulator.
        /// </summary>
        private static int accumulator = 0;
        /// <summary>
        /// A mark used to check when to stop execution of the app.
        /// </summary>
        private static bool halt = false;

        #endregion

        #region Private Methods

        /// <summary>
        /// Analyse and parse a command and executes it.
        /// </summary>
        private static void ExecuteCommand()
        {
            // Read a word with a command from the currently executed memory location to the CPU register.
            instructionRegister = memory[instructionCounter];
            // Get the operation code from the first part of a command.
            operationCode = instructionRegister / 100;
            // Get the number of the cell (an address of a location in memory) from the second part of a command.
            operand = instructionRegister % 100;

            // Using operation code, the address number stored in a command, "accumulator" and the number of current executed cell in memory
            // we are able to accomlish all sorts of operations, including change the next executed cell and exiting the app by changing
            // the "halt's" value to false. We increment "instructionCounter" every action except for non-conditional branching.
            switch (operationCode)
            {
                case Operations.Read:
                    Console.Write("Enter an integer: ");
                    int userNumberInput = int.Parse(Console.ReadLine());

                    while (userNumberInput < MinValueRange || userNumberInput > MaxValueRange)
                    {
                        Console.WriteLine($"*** You should enter a number in a range from {MinValueRange} to {MaxValueRange}. ***");
                        Console.Write("Enter an integer: ");
                        userNumberInput = int.Parse(Console.ReadLine());
                    }

                    memory[operand] = userNumberInput;
                    ++instructionCounter;
                    break;
                case Operations.Write:
                    Console.WriteLine(memory[operand]);
                    ++instructionCounter;
                    break;
                case Operations.Load:
                    accumulator = memory[operand];
                    ++instructionCounter;
                    break;
                case Operations.Store:
                    memory[operand] = accumulator;
                    ++instructionCounter;
                    break;
                case Operations.Add:
                    if (accumulator + memory[operand] > MaxValueRange)
                    {
                        Console.WriteLine("*** Accumulator overflow occurs during addition operation ***");
                        Console.WriteLine("*** Simpletron execution abnormally terminated ***");
                        halt = true;
                    }
                    else
                    {
                        accumulator += memory[operand];
                        ++instructionCounter;
                    }
                    break;
                case Operations.Subtract:
                    if (accumulator - memory[operand] < MinValueRange)
                    {
                        Console.WriteLine("*** Accumulator overflow occurs during subtracting operation ***");
                        Console.WriteLine("*** Simpletron execution abnormally terminated ***");
                        halt = true;
                    }
                    else
                    {
                        accumulator -= memory[operand];
                        ++instructionCounter;
                    }
                    break;
                case Operations.Divide:
                    try
                    {
                        accumulator /= memory[operand];
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("*** Division by zero occurs ***");
                        Console.WriteLine("*** Simpletron execution abnormally terminated ***");
                        halt = true;
                        break;
                    }
                    ++instructionCounter;
                    break;
                case Operations.Multiply:
                    if (accumulator * memory[operand] > MaxValueRange)
                    {
                        Console.WriteLine("*** Accumulator overflow occurs during multiplying operation ***");
                        Console.WriteLine("*** Simpletron execution abnormally terminated ***");
                        halt = true;
                    }
                    else
                    {
                        accumulator *= memory[operand];
                        ++instructionCounter;
                    }
                    break;
                case Operations.Branch:
                    instructionCounter = operand;
                    break;
                case Operations.BranchNeg:
                    if (accumulator < 0)
                    {
                        instructionCounter = operand;
                    }
                    else
                    {
                        ++instructionCounter;
                    }
                    break;
                case Operations.BranchZero:
                    if (accumulator == 0)
                    {
                        instructionCounter = operand;
                    }
                    else
                    {
                        ++instructionCounter;
                    }
                    break;
                case Operations.Halt:
                    Console.WriteLine("*** Simpletron execution terminated ***");
                    halt = true;
                    break;
                default:
                    Console.WriteLine("*** Warning! The halt command is missed at the end of the command list! ***\n"
                        + "*** Simpletron execution terminated ***");
                    halt = true;
                    break;
            }
        }

        /// <summary>
        /// Prints current values stored in all registers and memory cells.
        /// </summary>
        private static void PrintRegistersAndMemoryContent()
        {
            // All values of the memory dump should be presented as four-digit values. Ordinary ":D4" formatting would not convert 0 to 0000
            // as we need thus we first get absolute value of a number and after converting it to string we use "PadLeft()" method which
            // concatenates a char given as the second parameter to the left of the string to get a string of length given as the first
            // parameter. Then we add "-" or "+" sign to the string we got.
            string accumulatorAndSign = (accumulator < 0 ? "-" : "+") + (Math.Abs(accumulator).ToString().PadLeft(4, '0'));
            string instructionRegisterAndSign = (instructionRegister < 0 ? "-" : "+") + (Math.Abs(instructionRegister).ToString().PadLeft(4, '0'));
            string instructionCounterWithPadding = instructionCounter.ToString().PadLeft(2, '0');
            string operationCodeWithPadding = operationCode.ToString().PadLeft(2, '0');
            string operandWithPadding = operand.ToString().PadLeft(2, '0');
            Console.Write("REGISTERS:\n"
                + $"accumulator          {accumulatorAndSign}\n"
                + $"instructionCounter      {instructionCounterWithPadding}\n"
                + $"instructionRegister  {instructionRegisterAndSign}\n"
                + $"operationCode           {operationCodeWithPadding}\n"
                + $"operand                 {operandWithPadding}\n\n"
                + "MEMORY:\n"
                + "       0     1     2     3     4     5     6     7     8     9");

            // Print values of all memory cells.
            for (int cell = 0; cell < memory.Length; ++cell)
            {
                if (cell % 10 == 0)
                {
                    Console.WriteLine();
                    Console.Write($"{cell:D2}");
                }

                string cellValueAndSign = memory[cell] < 0 ? $"{memory[cell]:D4}" : $"+{memory[cell]:D4}";
                Console.Write($" {cellValueAndSign}");
            }

            Console.WriteLine();
        }

        #endregion

        #region Public Methods

        public static void Main()
        {
            // Print a welcome message.
            Console.WriteLine("*** Welcome to Simpletron! ***\n"
                + "*** Please enter your program one instruction ***\n"
                + "*** (or data word) at a time into the input ***\n"
                + "*** text field. I will display the location ***\n"
                + "*** number and a question mark (?). You then ***\n"
                + "*** type word for that location. Enter ***\n"
                + $"*** {SentinelValue} to stop entering your program. ***");

            // Temporary variable to store user's input.
            string userCommandInput = string.Empty;
            // Integer representation of a command entered by a user.
            int command = 0;

            // Prompt user to enter values for memory cells until the sentinel value is entered or until all memory cells are filled.
            for (int cell = 0; cell < memory.Length; ++cell)
            {
                Console.Write($"{cell:D2} ? ");
                userCommandInput = Console.ReadLine();

                // If user enters not a number, print warning message and repeat step for the current cell.
                try
                {
                    command = int.Parse(userCommandInput);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"*** You should enter a number in a range from {MinValueRange} to {MaxValueRange}. ***");
                    // Decrement "cell" so the "for" loop to repeat step for the same cell.
                    --cell;
                    continue;
                }

                // If user enters a number lager or lower than allowed and it is not a sentinel value print warning message
                // and repeat step for the current cell.
                if (command != SentinelValue && (command < MinValueRange || command > MaxValueRange))
                {
                    Console.WriteLine($"*** You should enter a number in a range from {MinValueRange} to {MaxValueRange}. ***");
                    // Decrement "cell" so the "for" loop to repeat step for the same cell.
                    --cell;
                    continue;
                }

                // Stop asking for the new commands when user enters sentinel value.
                if (command == SentinelValue)
                {
                    break;
                }

                // Write a command entered by a user the the memory cell.
                memory[cell] = command;
            }

            Console.WriteLine();
            Console.WriteLine("*** Program loading complete ***\n"
                + "*** Program execution begins ***");
            Console.WriteLine();

            // Executin process begins.
            while (!halt)
            {
                ExecuteCommand();
            }

            Console.WriteLine();
            PrintRegistersAndMemoryContent();
            Console.WriteLine();
            Console.WriteLine("*** Simulation complete. Press any key to exit. ***");
            Console.ReadKey();
        }

        #endregion
    }
}