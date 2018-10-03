// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Special Section: Build Your Own Computer. Exercise 03 (08.33) Project: Simpletron Simulator Modifications

using System;
// Add "Globalization" namespace to use "NumberStyles.HexNumber" enum further in code. This allows us to use an overloaded method "Parse()"
// taking a value of "NumberStyle" enum type as the second parameter. With "NumberStyles.HexNumber" as the second parameter the "Parse()"
// method would interpret a string of text it gets as the first parameter as hexadecimal number.
using System.Globalization;
// Add "Linq" namespace to use "Contains()" method which could find certain values in arrays. We would learn much more about Linq in the
// following chapters of the textbook.
using System.Linq;
using System.Text;

namespace SimpletronSimulatorModifications.Classes
{
    public class Simulator
    {
        #region Constants

        /// <summary>
        /// The number of cells "memory[]" contains.
        /// </summary>
        private const int MemorySize = 1000;
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
        /// <summary>
        /// Maximum allowed length of a string.
        /// </summary>
        private const int StringMaxLength = 99;
        /// <summary>
        /// The list of characters allowed by the simulated machine. A to Z uppercase alphabet and space character.
        /// </summary>
        private static readonly char[] AllowedStringCharacters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ' };

        #endregion

        #region Private fields

        /// <summary>
        /// Represents memory of the Simpletron with 1000 available cells.
        /// </summary>
        private static readonly double[] memory = new double[MemorySize];
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
        private static double accumulator = 0;
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
            instructionRegister = (int)memory[instructionCounter];
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
                    Console.Write("Enter an number: ");
                    double userNumberInput = double.Parse(Console.ReadLine());

                    while (userNumberInput < MinValueRange || userNumberInput > MaxValueRange)
                    {
                        Console.WriteLine($"*** You should enter a number in a range from {MinValueRange} to {MaxValueRange}. ***");
                        Console.Write("Enter an number: ");
                        userNumberInput = double.Parse(Console.ReadLine());
                    }

                    memory[operand] = (int)userNumberInput;
                    ++instructionCounter;
                    break;
                case Operations.Write:
                    Console.WriteLine(memory[operand]);
                    ++instructionCounter;
                    break;
                case Operations.WriteNewLine:
                    Console.WriteLine();
                    break;
                case Operations.ReadString:
                    char wrongChar = ' ';
                    Console.WriteLine("Enter a string of text of uppercase letters or spaces:");
                    string userStringInput = Console.ReadLine();

                    // Ask user to re-enter string if user didn't enter any symbol
                    // or if string is larger than we could allocate (as we use the first half of a word to indicate a string length we are
                    // able to allocate maximum of 99 symbols) or if we don't have enough free memory cells or if string contains wrong
                    // charaters.
                    while (userStringInput.Length == 0
                        || userStringInput.Length >= StringMaxLength
                        || operand + ((userStringInput.Length + 2) / 2) > MemorySize
                        || DoesStringContainsWrongCharacters(userStringInput, ref wrongChar))
                    {
                        if (userStringInput.Length == 0)
                        {
                            Console.Write("A string of text should contain at least one character. ");
                        }
                        else if (userStringInput.Length >= StringMaxLength)
                        {
                            Console.Write($"An entered string of text exceeds allowed maximim length ({StringMaxLength} symbols). ");
                        }
                        else if (operand + ((userStringInput.Length + 2) / 2) > MemorySize)
                        {
                            Console.Write("There is not enough memory left to store a string of such length. ");
                        }
                        else if (DoesStringContainsWrongCharacters(userStringInput, ref wrongChar))
                        {
                            Console.Write($"A string of text contains inappropriate character \"{wrongChar}\". ");
                        }

                        Console.WriteLine("Please re-enter a string of text of uppercase letters or spaces:");
                        userStringInput = Console.ReadLine();
                    }

                    // We made sure that string stored in "userStringInput" contains at least one character. Knowing this we write
                    // total number of characters and the first character of a string to the first cell in possible sequence of cells.
                    memory[operand] = (userStringInput.Length * 100) + userStringInput[0];

                    // If there is more than 1 letter, write the rest of them to succeeding cell, two letters per cell.
                    if (userStringInput.Length > 1)
                    {
                        // Local variable used to write letters in the succeeding sequence of memory cells by shifting the number of cell,
                        // stored in the "operand" for every two letters of a text string.
                        int operandShift = 1;

                        // Write every two letters of the string to succeeding memory cell.
                        for (int letterIndex = 1; letterIndex < userStringInput.Length; letterIndex += 2)
                        {
                            // If there is only one letter left, write it to the cells. Otherwise write two letters into two cells.
                            if (letterIndex + 1 > userStringInput.Length)
                            {
                                memory[operand + operandShift] = userStringInput[letterIndex] * 100;
                            }
                            else
                            {
                                memory[operand + operandShift] =
                                    (userStringInput[letterIndex] * 100)
                                    + (userStringInput[letterIndex + 1]);
                            }

                            ++operandShift;
                        }
                    }

                    ++instructionCounter;
                    break;
                case Operations.WriteString:

                    if (operand + ((int)memory[operand] / 2) > MemorySize)
                    {
                        Console.WriteLine(
                            "The specified string can't be printed as it's length exceeds the number of memory cells left.");
                        Console.WriteLine($"Starting cell: {operand}, String length: {memory[operand]}, Last cell in memory: {MemorySize}");
                        halt = true;
                        break;
                    }
                    else if ((int)memory[operand] <= 0)
                    {
                        Console.WriteLine(
                            $"The specified string can't be printed as it's length ({memory[operand]} symbols) is less or euqal to zero.");
                        halt = true;
                        break;
                    }

                    // As soon as string contains at least one character, print the first character.
                    Console.Write($"{(char)memory[operand + 1]}");

                    // If there is more than 1 letter, print the rest of them from succeeding cells.
                    if ((int)memory[operand] > 1)
                    {
                        // Local variable used to write letters in the succeeding sequence of memory cells by shifting the number of cell,
                        // stored in the "operand" for every two letters of a text string.
                        int operandShift = 1;

                        // Print every two letters of the string from succeeding memory cells.
                        for (int letterIndex = 1; letterIndex < memory[operand]; letterIndex += 2)
                        {
                            // If there is only one letter left, print it from the cells. Otherwise print two letters into two cells.
                            if (letterIndex + 1 > memory[operand])
                            {
                                Console.Write($"{(char)memory[operand + operandShift]}");
                            }
                            else
                            {
                                Console.Write($"{(char)memory[operand + operandShift]}");
                                Console.Write($"{(char)memory[operand + operandShift + 1]}");
                            }

                            ++operandShift;
                        }
                    }

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
                        Console.WriteLine("*** Division by zero occurs during division operation ***");
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
                case Operations.Reminder:
                    try
                    {
                        accumulator %= memory[operand];
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("*** Division by zero occurs during reminder operation ***");
                        Console.WriteLine("*** Simpletron execution abnormally terminated ***");
                        halt = true;
                        break;
                    }

                    ++instructionCounter;
                    break;
                case Operations.Power:
                    for (int factor = 0; factor < memory[operand]; ++factor)
                    {
                        if (accumulator * accumulator > MaxValueRange)
                        {
                            Console.WriteLine("*** Accumulator overflow occurs during power operation ***");
                            Console.WriteLine("*** Simpletron execution abnormally terminated ***");
                            halt = true;
                            break;
                        }
                        else
                        {
                            accumulator *= accumulator;
                        }
                    }

                    // Increment "instructionCounter" only when power operation is pefromed successfully.
                    if (!halt)
                    {
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
                + "        0     1     2     3     4     5     6     7     8     9");

            // Print values of all memory cells.
            for (int cell = 0; cell < memory.Length; ++cell)
            {
                if (cell % 10 == 0)
                {
                    Console.WriteLine();
                    Console.Write($"{cell:D3}");
                }

                string cellValueAndSign = memory[cell] < 0 ? $"{memory[cell]:D4}" : $"+{memory[cell]:D4}";
                Console.Write($" {cellValueAndSign}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Return "true" when "stringToCheck" contains any not allowed character. Return "false" otherwise.
        /// </summary>
        /// <param name="stringToCheck">String of text to be verified for wrong characters.</param>
        /// <param name="wrongChar">Method writes disallowed character here in case if such letter is found in a passed string.</param>
        private static bool DoesStringContainsWrongCharacters(string stringToCheck, ref char wrongChar)
        {
            // Local variable that stores the eventual result of the check.
            bool doesContains = false;

            // A string of text in some way is an array of characters, so we could use the following "foreach" loop to check value of every
            // letter of a text string.
            foreach (char letter in stringToCheck)
            {
                // Use Linq method "Contains()" to find if a letter is allowed by our machine.
                if (!AllowedStringCharacters.Contains(letter))
                {
                    // If the letter is not allowed, write it to "wrongChar", set "doesContains" to false and break the "foreach" loop.
                    wrongChar = letter;
                    doesContains = true;
                    break;
                }
            }

            return doesContains;
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
                    command = int.Parse(userCommandInput, NumberStyles.HexNumber);
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