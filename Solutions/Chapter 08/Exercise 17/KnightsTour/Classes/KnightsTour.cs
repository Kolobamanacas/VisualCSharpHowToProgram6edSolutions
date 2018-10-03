// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 17 (08.22) Knight's Tour.

/* The C#'s "System" namespace contains enumeration called "ConsoleKey" it contains most of keys presented on standard PC keyboard.
 * It also contains struct "ConsoleKeyInfo", which has a "Key" variable. Combining this features we could use "ReadKey()" method
 * of class "Console" together with "Key" variable to get an element of enumeration "ConsoleKey" representing a key pressed by a user.
 * "ReadKey()" method also supports getting a boolean parapter. In case if "true" is passed, pressed key is printed during input.
 * You could read about ConsoleKye and structs here:
 * https://msdn.microsoft.com/en-us/library/system.consolekey%28v=vs.110%29.aspx
 * https://msdn.microsoft.com/en-us/library/system.consolekeyinfo(v=vs.110).aspx
 * https://msdn.microsoft.com/en-us/library/471w8d85(v=vs.110).aspx
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/struct */

using System;

class KnightsTour
{
    static void Main()
    {
        // Change console's output encoding to UTF-8. It's a good practice for all future developments.
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Create an object of class Knight and call it "kenobi".
        Knight kenobi = new Knight();

        Console.WriteLine("Wellcome to Knight's Tour game");
        Console.Write("Choose a moving mode (press \"A\" for automatic mode, or \"M\" for manual mode): ");
        // Create an element of enumeration ConsoleKey and assign it to a key, pressed by a user.
        ConsoleKey keyPressed = Console.ReadKey(true).Key;
        Console.WriteLine();

        // Loop asking a user to choose a mode by pressing "A" or "M'. 
        while (keyPressed != ConsoleKey.A && keyPressed != ConsoleKey.M)
        {
            Console.WriteLine("You should press \"A\" or \"M\".");
            Console.Write("Choose a moving mode (press \"A\" for automatic mode, or \"M\" for manual mode): ");
            // ReadKey method of a Console class get a key pressed by a user. "true" parameter tells it to print a key a user pressed.
            keyPressed = Console.ReadKey(true).Key;
            Console.WriteLine();
        }

        // Store "true" in "autoMode" variable if user have pressed "A" and store "false" otherwise.
        bool autoMode = keyPressed == ConsoleKey.A
            ? true
            : false;

        // Create a variable to later determine whether to choose knight's start position.
        bool chooseStartPosition = false;

        // Manual mode explicitly means choosing start positions, but for auto mode we ask user whether he/she wants to use it.
        if (autoMode)
        {
            keyPressed = ConsoleKey.Spacebar;
            Console.Write("Do you want to choose start position\n"
                + "(Press \"C\" to choose start position or \"A\" to make 64 tours from every possible start position): ");
            keyPressed = Console.ReadKey(true).Key;
            Console.WriteLine();


            // Loop until user presses "A" or "C".
            while (keyPressed != ConsoleKey.C && keyPressed != ConsoleKey.A)
            {
                Console.WriteLine("You should press \"C\" or \"A\".");
                Console.Write("Do you want to choose start position\n"
                + "(Press\"C\" to choose start position or \"A\" to make 64 tours from every possible start position): ");
                keyPressed = Console.ReadKey(true).Key;
                Console.WriteLine();
            }

            // If user pressed "C" then assign "true" to "chooseStartPosition".
            if (keyPressed == ConsoleKey.C)
            {
                chooseStartPosition = true;
            }
        }

        // For manual mode and in case of user selected to choose knight's start position in auto mode, let him/her do so.
        if (!autoMode || chooseStartPosition)
        {
            // Create two local variables and store there initial row and column numbers entered by a user.
            // I use 0 to 7 numbers instead of 1 to 8 for development simplicity.
            Console.Write($"Choose a start position row (type a number from 0 to {kenobi.GetBoardRowsNumber() - 1} and press Enter): ");
            int rowToSet = int.Parse(Console.ReadLine());

            while (rowToSet < 0 || rowToSet >= kenobi.GetBoardRowsNumber())
            {
                Console.WriteLine($"You should type an integer from \"0\" to \"{kenobi.GetBoardRowsNumber() - 1}\".");
                Console.Write($"Choose a start position row (type a number from 0 to {kenobi.GetBoardRowsNumber() - 1} and press Enter): ");
                rowToSet = int.Parse(Console.ReadLine());
            }

            Console.Write($"Choose a start position column (type a number from 0 to {kenobi.GetBoardColumnsNumber() - 1} and press Enter): ");
            int columnToSet = int.Parse(Console.ReadLine());

            while (columnToSet < 0 || columnToSet >= kenobi.GetBoardColumnsNumber())
            {
                Console.WriteLine($"You should type an integer from \"0\" to \"{kenobi.GetBoardColumnsNumber() - 1}\".");
                Console.Write($"Choose a start position column (type a number from 0 to {kenobi.GetBoardColumnsNumber() - 1} and press Enter): ");
                columnToSet = int.Parse(Console.ReadLine());
            }

            // Set current poisition row and column to values entered by a user.
            kenobi.CurrentPositionRow = rowToSet;
            kenobi.CurrentPositionColumn = columnToSet;
            // As soon as knight already stays on the point, call apropriate method to mark it as visited.
            kenobi.MarkPointAsVisited(rowToSet, columnToSet);
        }

        // All the logic for manual mode.
        if (!autoMode)
        {
            // Here we print and reprint all the information, including table every time user presses a buttom.
            // If the pressed button corresponds to a possible move, the move is made. Current information is reprinted otherwise.
            while (kenobi.PossibleMoveExists())
            {
                Console.Clear();
                Console.WriteLine("Knight's Tour");
                Console.Write($"Moving mode: manual. Current position: {kenobi.CurrentPositionRow}:{kenobi.CurrentPositionColumn}. ");
                Console.WriteLine($"Moves made: {kenobi.NumberOfMovesMade}");
                kenobi.PrintAllKnightsMoves();
                kenobi.PrintBoard();
                Console.Write("Press a move number: ");
                // Set initial value of "moveNumber" to 100. There is no move with such a number.
                int moveNumber = 100;
                // Read a key pressed by a user to "keyPressed" element of enumeration "ConsoleKey".
                keyPressed = Console.ReadKey(true).Key;

                // If user presses a number from 0 to 7, assign it to "moveNumber". In all other cases - leave previous value there.
                switch (keyPressed)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        moveNumber = 0;
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        moveNumber = 1;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        moveNumber = 2;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        moveNumber = 3;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        moveNumber = 4;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        moveNumber = 5;
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        moveNumber = 6;
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        moveNumber = 7;
                        break;
                    default:
                        break;
                }

                // If user entered a move from 0 to 7 inclusive and this move is possible - make it.
                if (moveNumber >= 0
                    && moveNumber <= 7
                    && kenobi.MoveIsPossible(moveNumber, kenobi.CurrentPositionRow, kenobi.CurrentPositionColumn))
                {
                    kenobi.MakeMove(moveNumber);
                }

                // End of "while" loop.
            }

            // This method deletes all previous information printed in console window.
            Console.Clear();
            // Print game statistics using "PrintResultsOnePosition()" method of class "Knight".
            kenobi.PrintResultsOnePosition();
            Console.Write("Press any key to exit.");
            // This is used to let user see previus message before console window is closed.
            // After user presses any pressed the app terminates.
            Console.ReadKey();

            // End of "if (!autoMode)".
        }

        // All the logic for automatic mode.
        if (autoMode)
        {
            // Assign "Spacebar" key to "keyPressed" as soon as app wouldn't use it for any command.
            keyPressed = ConsoleKey.Spacebar;
            // Ask user whether he/she want to use accessibility table and if so, assign "true" to "kenobi.UseAccessibilityTable".
            Console.Write("Do you want to use accessibility table (press \"Y\" for yes, or \"N\" for no): ");
            keyPressed = Console.ReadKey(true).Key;

            while (keyPressed != ConsoleKey.Y && keyPressed != ConsoleKey.N)
            {
                Console.WriteLine("You should press \"Y\" or \"N\".");
                Console.Write("Do you want to use accessibility table (press \"Y\" for yes, or \"N\" for no): ");
                keyPressed = Console.ReadKey(true).Key;
            }

            if (keyPressed == ConsoleKey.Y)
            {
                kenobi.UseAccessibilityTable = true;
            }

            Console.WriteLine();

            if (kenobi.UseAccessibilityTable)
            {
                // Assign "Spacebar" key to "keyPressed" as soon as app wouldn't use it for any command.
                keyPressed = ConsoleKey.Spacebar;
                // Ask user whether he/she want to use lookup and if so, assign "true" to "kenobi.UseLookup".
                Console.Write("Do you want to use lookup (press \"Y\" for yes, or \"N\" for no): ");
                keyPressed = Console.ReadKey(true).Key;

                while (keyPressed != ConsoleKey.Y && keyPressed != ConsoleKey.N)
                {
                    Console.WriteLine("You should press \"Y\" or \"N\".");
                    Console.Write("Do you want to use lookup (press \"Y\" for yes, or \"N\" for no): ");
                    keyPressed = Console.ReadKey(true).Key;
                }

                if (keyPressed == ConsoleKey.Y)
                {
                    kenobi.UseLookup = true;
                }
            }

            // If user decided to choose a start position, they are already assigned previously so app start moving a knight.
            // The moves logic is different depending on whether users has chosen to use accessibility table and lookup.
            if (chooseStartPosition)
            {
                while (kenobi.PossibleMoveExists())
                {
                    for (int moveNumber = 0; moveNumber <= 7; ++moveNumber)
                    {
                        if (kenobi.MoveIsPossible(moveNumber, kenobi.CurrentPositionRow, kenobi.CurrentPositionColumn))
                        {
                            kenobi.MakeMove(moveNumber);
                            // We force "for" loop to breake to start counting from 0 every time a move made.
                            // This allows us to make a move with lowest number possible every time.
                            break;
                        }
                    }
                }

                // After all moves are made, the console screen is cleared and game statistics is printed.
                Console.Clear();
                kenobi.PrintResultsOnePosition();
                Console.Write("Press any key to exit.");
                Console.ReadKey();
            }

            // Here we impelement all the logic for a case where knight makes 64 different tours.
            // 1st tour is made from 0:0 start position and the last one is made from 63:63 start position.
            if (!chooseStartPosition)
            {
                // These varuables is used to store the number of successful and unsuccessful tours made by a knight.
                // Their sum always eqauls to 64 at the end of a game.
                int successfulTours = 0;
                int unseccessfulTours = 0;

                // Two "for" loops used to cover all possible start positions.
                for (int positionX = 0; positionX <= 7; ++positionX)
                {
                    for (int positionY = 0; positionY <= 7; ++positionY)
                    {
                        // "ResetBoard()" method of class "Knight" resets all board properties and fields to their initial values
                        // and sets knight's current row and column positions to values of "positionX" and "positionY" correspondingly.
                        kenobi.ResetBoard(positionX, positionY);

                        // If accessibility table is used possible moves made until there is at least one possible move.
                        if (!kenobi.UseAccessibilityTable)
                        {
                            while (kenobi.PossibleMoveExists())
                            {
                                for (int moveNumber = 0; moveNumber <= 7; ++moveNumber)
                                {
                                    if (kenobi.MoveIsPossible(moveNumber, kenobi.CurrentPositionRow, kenobi.CurrentPositionColumn))
                                    {
                                        kenobi.MakeMove(moveNumber);
                                        // We force "for" loop to breake to start counting from 0 every time a move made.
                                        // This allows us to make a move with lowest number possible every time.
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // For cases when accessibility table or/and lookup is used, the logic is implemented within "MakeMove()".
                            while (kenobi.PossibleMoveExists())
                            {
                                kenobi.MakeMove();
                            }
                        }

                        // Count successful and unsuccessful tours for every tour made.
                        if (kenobi.NumberOfMovesMade == 63)
                        {
                            ++successfulTours;
                        }
                        else
                        {
                            ++unseccessfulTours;
                        }
                    }
                }

                // After all moves are made, the console screen is cleared and game statistics is printed.
                Console.Clear();
                kenobi.PrintResultsAllPositions(successfulTours, unseccessfulTours);
                Console.Write("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}