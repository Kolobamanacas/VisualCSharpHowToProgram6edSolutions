// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 18 (08.23) Knight's Tour: Brute-Force Approaches.

/* The app is generally similar to 17 (08.22), but here we add new modes:
 * - to chosse initial position, then make given number of tours with random move selecting;
 * - to choose initial position, then make tours with random move selecting until the first successful;
 * - to randomly choose initial position, then make given number of tours with random move selecting;
 * - to randomly choose initial position, then make tours with random move selecting until the first successful.
 * 
 * Here we also meet new method of class "Array" called "Resize". It is used to change number of values in an array.
 * https://msdn.microsoft.com/en-us/library/bb348051(v=vs.110).aspx */

using System;

class KnightsTour
{
    // Private field, an object of class "Random" to generate random numbers.
    private static Random randomNumber = new Random();

    // Enumeration "GameMode" representing three game modes to be chosen from.
    private enum GameMode
    {
        Auto,
        Manual,
        Random
    };

    private enum RandomGameMode
    {
        SetNumberOfTours,
        PlayTillFirstSuccess
    };

    static void Main()
    {
        // Change console's output encoding to UTF-8. It's a good practice for all future developments.
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Create an object of class Knight and call it "kenobi".
        Knight kenobi = new Knight();

        Console.WriteLine("Wellcome to Knight's Tour game");
        Console.Write("Choose a moving mode (press \"A\" for automatic mode, \"M\" for manual mode, or \"R\" for random mode): ");
        // Create an element of enumeration ConsoleKey and assign it to a key, pressed by a user.
        ConsoleKey keyPressed = Console.ReadKey(true).Key;
        Console.WriteLine();

        // Loop asking a user to choose a mode by pressing "A", "M" or "R'. 
        while (keyPressed != ConsoleKey.A && keyPressed != ConsoleKey.M && keyPressed != ConsoleKey.R)
        {
            Console.WriteLine("You should press \"A\", \"M\" or \"R\".");
            Console.Write("Choose a moving mode (press \"A\" for automatic mode, \"M\" for manual mode, or \"R\" for random mode): ");
            // ReadKey method of a Console class get a key pressed by a user. "true" parameter tells it to print a key a user pressed.
            keyPressed = Console.ReadKey(true).Key;
            Console.WriteLine();
        }

        // Local variable of type "GameMode" created earlier within a class, used to perform different actions depending on selected game mode.
        GameMode gameMode = GameMode.Auto;

        switch (keyPressed)
        {
            case ConsoleKey.A:
                gameMode = GameMode.Auto;
                break;
            case ConsoleKey.M:
                gameMode = GameMode.Manual;
                break;
            case ConsoleKey.R:
                gameMode = GameMode.Random;
                break;
            default:
                break;
        }

        // Create a variable to later determine whether to choose knight's start position.
        bool chooseStartPosition = false;

        // Manual mode explicitly means choosing start positions, but for auto mode we ask user whether he/she wants to use it.
        if (gameMode == GameMode.Auto)
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

        // Manual mode explicitly means choosing start positions, but for random mode we also ask user whether he/she wants to use it.
        if (gameMode == GameMode.Random)
        {
            keyPressed = ConsoleKey.Spacebar;
            Console.Write("Do you want to choose start position (press \"Y\" for \"yes\" or \"N\" for \"no\"): ");
            keyPressed = Console.ReadKey(true).Key;
            Console.WriteLine();


            // Loop until user presses "Y" or "N".
            while (keyPressed != ConsoleKey.Y && keyPressed != ConsoleKey.N)
            {
                Console.WriteLine("You should press \"Y\" or \"N\".");
                Console.Write("Do you want to choose start position (press \"Y\" for \"yes\" or \"N\" for \"no\"): ");
                keyPressed = Console.ReadKey(true).Key;
                Console.WriteLine();
            }

            // If user pressed "Y" then assign "true" to "chooseStartPosition".
            if (keyPressed == ConsoleKey.Y)
            {
                chooseStartPosition = true;
            }
        }

        // For manual mode and in case of user selected to choose knight's start position in auto mode, let him/her do so.
        if (gameMode == GameMode.Manual || chooseStartPosition)
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

        // If game is played in random mode and player decided not to choose start position
        // then generate a random start position and mark it as visited.
        if (gameMode == GameMode.Random && !chooseStartPosition)
        {
            // "GetBoardRowsNumber()" returns a number of rows of a board.
            // And "Next()" method generates a random number between 0 and number returned with "GetBoardRowsNumber()" minus 1.
            // So for 8 rows, "Next()" returns number from 0 to 7.
            kenobi.CurrentPositionRow = randomNumber.Next(kenobi.GetBoardRowsNumber());
            kenobi.CurrentPositionColumn = randomNumber.Next(kenobi.GetBoardColumnsNumber());
            kenobi.MarkPointAsVisited(kenobi.CurrentPositionRow, kenobi.CurrentPositionColumn);
        }

        // All the logic for manual mode.
        if (gameMode == GameMode.Manual)
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

            // End of "if (gameMode == GameMode.Manual)".
        }

        // All the logic for automatic mode.
        if (gameMode == GameMode.Auto)
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

            // End of "if (gameMode == GameMode.Auto)".
        }

        if (gameMode == GameMode.Random)
        {
            // The array store of tours made for every tour length.
            int[] tourStatistics = new int[64];
            // Set "keyPressed" to unused value.
            keyPressed = ConsoleKey.Spacebar;
            Console.WriteLine("Press \"S\" to set number of tours to make or \"F\" to play games until the first successful tour:");
            // Read a key pressed by a user.
            keyPressed = Console.ReadKey(true).Key;

            while (keyPressed != ConsoleKey.S && keyPressed != ConsoleKey.F)
            {
                Console.WriteLine("You should press \"S\" or \"F\".");
                Console.WriteLine("Press \"S\" to set number of tours to make or \"F\" to play games until the first successful tour:");
                keyPressed = Console.ReadKey(true).Key;
                Console.WriteLine();
            }

            // If user pressed "S" set the "randomGameMode" to "RandomGameMode.SetNumberOfTours"
            // and set it to "RandomGameMode.PlayTillFirstSuccess" otherwise.
            RandomGameMode randomGameMode = keyPressed == ConsoleKey.S
                ? RandomGameMode.SetNumberOfTours
                : RandomGameMode.PlayTillFirstSuccess;

            if (randomGameMode == RandomGameMode.SetNumberOfTours)
            {
                // Additional variables to reset start position after each tour.
                int initialPositionRow = kenobi.CurrentPositionRow;
                int initialPositionColumn = kenobi.CurrentPositionColumn;

                Console.Write("Set the number of tours to make: ");
                int numberOfTours = int.Parse(Console.ReadLine());

                // Make given number of tours.
                for (int tour = 0; tour < numberOfTours; ++tour)
                {
                    // Make one tour.
                    while (kenobi.PossibleMoveExists())
                    {
                        int[] possibleMoves = new int[0];

                        // Find all possible moves from current position and store them in "possibleMoves" array.
                        for (int move = 0; move <= 7; ++move)
                        {
                            if (kenobi.MoveIsPossible(move, kenobi.CurrentPositionRow, kenobi.CurrentPositionColumn))
                            {
                                // Make "possibleMoves" one cell larger. All the previous values are not lost.
                                Array.Resize(ref possibleMoves, possibleMoves.Length + 1);
                                // Store new move found to the new created cell of "possibleMoves" array.
                                possibleMoves[possibleMoves.Length - 1] = move;
                            }
                        }

                        // "possibleMoves[]" array holds all number of moves possible from the current position.
                        // We generate random number between 0 (minimum index of the array) and maximum index of the array,
                        // then use to randomly choose a move from "possibleMoves[]" and assign the value to "randomMoveNumber".
                        int randomMoveNumber = possibleMoves[randomNumber.Next(0, possibleMoves.Length)];
                        // Make a move with given number.
                        kenobi.MakeMove(randomMoveNumber);
                    }

                    // A knight could make from 0 to 63 moves and "tourStatistics[]" have cells with index from 0 to 63.
                    // Each cell of "tourStatistics[]" represents a tour with number of moves equals to array's index.
                    ++tourStatistics[kenobi.NumberOfMovesMade];

                    // Reset the board and return a night to initial/new random position.
                    if (chooseStartPosition)
                    {
                        kenobi.ResetBoard(initialPositionRow, initialPositionColumn);
                    }
                    else
                    {
                        int randomInitialRow = randomNumber.Next(kenobi.GetBoardRowsNumber());
                        int randomInitialColumn = randomNumber.Next(kenobi.GetBoardColumnsNumber());
                        kenobi.ResetBoard(randomInitialRow, randomInitialColumn);
                    }
                }
            }

            if (randomGameMode == RandomGameMode.PlayTillFirstSuccess)
            {
                // Additional variables to reset start position after each tour.
                int initialPositionRow = kenobi.CurrentPositionRow;
                int initialPositionColumn = kenobi.CurrentPositionColumn;

                bool fullTourMade = false;

                // Make given number of tours.
                while (!fullTourMade)
                {
                    // Make one tour.
                    while (kenobi.PossibleMoveExists())
                    {
                        int[] possibleMoves = new int[0];

                        // Find all possible moves from current position and store them in "possibleMoves" array.
                        for (int move = 0; move <= 7; ++move)
                        {
                            if (kenobi.MoveIsPossible(move, kenobi.CurrentPositionRow, kenobi.CurrentPositionColumn))
                            {
                                // Make "possibleMoves" one cell larger. All the previous values are not lost.
                                Array.Resize(ref possibleMoves, possibleMoves.Length + 1);
                                // Store new move found to the new created cell of "possibleMoves" array.
                                possibleMoves[possibleMoves.Length - 1] = move;
                            }
                        }

                        // "possibleMoves[]" array holds all number of moves possible from the current position.
                        // We generate random number between 0 (minimum index of the array) and maximum index of the array,
                        // then use to randomly choose a move from "possibleMoves[]" and assign the value to "randomMoveNumber".
                        int randomMoveNumber = possibleMoves[randomNumber.Next(0, possibleMoves.Length)];
                        // Make a move with given number.
                        kenobi.MakeMove(randomMoveNumber);
                    }

                    // A knight could make from 0 to 63 moves and "tourStatistics[]" have cells with index from 0 to 63.
                    // Each cell of "tourStatistics[]" represents a tour with number of moves equals to array's index.
                    ++tourStatistics[kenobi.NumberOfMovesMade];

                    if (kenobi.NumberOfMovesMade == 63)
                    {
                        fullTourMade = true;
                    }

                    // Reset the board and return a night to initial/new random position.
                    if (chooseStartPosition)
                    {
                        kenobi.ResetBoard(initialPositionRow, initialPositionColumn);
                    }
                    else
                    {
                        int randomInitialRow = randomNumber.Next(kenobi.GetBoardRowsNumber());
                        int randomInitialColumn = randomNumber.Next(kenobi.GetBoardColumnsNumber());
                        kenobi.ResetBoard(randomInitialRow, randomInitialColumn);
                    }
                }
            }

            // After all tours are made, the console screen is cleared and game statistics is printed.
            Console.Clear();
            kenobi.PrintResultsForRandom(tourStatistics);
            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }
    }
}