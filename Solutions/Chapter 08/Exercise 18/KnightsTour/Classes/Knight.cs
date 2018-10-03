// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 18 (08.23) Knight's Tour: Brute-Force Approaches.

/* Here you find a new C# feature - a pair of "#region" and "#endregion". Regions don't affect app's behavior at all.
 * They simply help to break code parts to pieces, collapse and expand them for easy navigation and reading.
 * For example I put all private fields in "Private Fields" region.
 * You could collapse it to clear the space and expand it only when needed.
 * 
 * The second new feature is a verbatim identifier "@". We use it to create verbatim string - string that
 * contains newline characters and all other characters in on variable. "@" also has another implementations. You can read about it here:
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/verbatim */

using System;

class Knight
{
    #region Constructor

    public Knight()
    {
        // When an object of the class is created set "UseAccessibilityTable" and "UseLookup" to false.
        UseAccessibilityTable = false;
        UseLookup = false;
    }

    #endregion

    #region Private fields

    // Two-dimentional array of integers which represents a chess board. All elements by default are initialized to 0.
    private int[,] board = new int[8, 8];
    // Two one-dimentional arrays, which store possible knight's moves.
    private int[] horizontalMoves = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
    private int[] verticalMoves = new int[] { -1, -2, -2, -1, 1, 2, 2, 1 };
    // The table stores the number of points every point is accessible from.
    private int[,] accessibilityTable = new int[,]
    {
        { 2, 3, 4, 4, 4, 4, 3, 2 },
        { 3, 4, 6, 6, 6, 6, 4, 3 },
        { 4, 6, 8, 8, 8, 8, 6, 4 },
        { 4, 6, 8, 8, 8, 8, 6, 4 },
        { 4, 6, 8, 8, 8, 8, 6, 4 },
        { 4, 6, 8, 8, 8, 8, 6, 4 },
        { 3, 4, 6, 6, 6, 6, 4, 3 },
        { 2, 3, 4, 4, 4, 4, 3, 2 }
    };

    #endregion

    #region Public properties.

    // Properties that stores knight's current position.
    public int CurrentPositionRow { get; set; }
    public int CurrentPositionColumn { get; set; }
    // Properties used to determine whether to use accessibility table and lookup or not.
    public bool UseAccessibilityTable { get; set; }
    public bool UseLookup { get; set; }
    // A property that would count the number of moves a knight made during the game.
    public int NumberOfMovesMade { get; set; }

    #endregion

    #region Public methods.

    // These methods return the number of rows and columns of a "board[]" array.
    public int GetBoardRowsNumber() => board.GetLength(0);
    public int GetBoardColumnsNumber() => board.GetLength(1);
    // All moves are presented by numbers from 0 to 7.
    // The "PrintAllKnightsMoves()" method uses verbatim string to remind user which number represents which move.
    public void PrintAllKnightsMoves()
    {
        // The string prefixed with "@" symbol is a verbatim string. It stores all symbols including new line characters as one string.
        Console.WriteLine(@"All knight's moves:
    0        1     2       3         ↓ ← ←       ↓     ↓       ↓
→ → ↑        ↑     ↑       ↑ ← ←     4           ↓     ↓       → → 7
          →  ↑     ↑ ←                         5 ←     → 6");
    }

    // The method determins whether a move with a given number could be made from given row and column positions.
    // It retuns true if move is possible and false otherwise.
    public bool MoveIsPossible(int move, int positionRow, int positionColumn)
    {
        // Assume that move is impossible by default.
        bool moveIsPossible = false;

        // Create variables and store new positions after potential move is made.
        int newPositionRow = positionRow + verticalMoves[move];
        int newPositionColumn = positionColumn + horizontalMoves[move];

        // If new possible position is within row and column borders and is not yet visited set "moveIsPossible" to "true".
        if (newPositionRow >= 0
            && newPositionRow < board.GetLength(0)
            && newPositionColumn >= 0
            && newPositionColumn < board.GetLength(1)
            && board[newPositionRow, newPositionColumn] == 0)
        {
            moveIsPossible = true;
        }

        return moveIsPossible;
    }

    // The method determins whether there are possible moves.
    // It returns "true" in case when at least one move is possible and returns "false" otherwise.
    public bool PossibleMoveExists()
    {
        // Assume that there is not possible moves by default.
        bool moveExists = false;

        // For every move from 0 to 7 if new possible position is within row and column borders
        // and is not yet visited, break the loop and set "moveExists" to "true".
        for (int move = 0; move <= 7; ++move)
        {
            int newPositionRow = CurrentPositionRow + verticalMoves[move];
            int newPositionColumn = CurrentPositionColumn + horizontalMoves[move];

            if (newPositionRow >= 0
                && newPositionRow < board.GetLength(0)
                && newPositionColumn >= 0
                && newPositionColumn < board.GetLength(1)
                && board[newPositionRow, newPositionColumn] == 0)
            {
                moveExists = true;
                break;
            }
        }

        return moveExists;
    }

    // "PrintBoard()" method prints chess board. It marks a point with "0" if it was not yet visited, with "1" if if was visited
    // and with "K" if knight is currently placed there.
    public void PrintBoard()
    {
        Console.WriteLine("The board status:");
        Console.Write("    ");

        for (int columnNumber = 0; columnNumber < board.GetLength(1); ++columnNumber)
        {
            Console.Write($"({columnNumber})");
        }

        Console.WriteLine();

        for (int row = 0; row < board.GetLength(0); ++row)
        {
            Console.Write($"({row}) ");

            for (int column = 0; column < board.GetLength(1); ++column)
            {
                if (row == CurrentPositionRow && column == CurrentPositionColumn)
                {
                    Console.Write(" K ");
                }
                else if (board[row, column] == 0)
                {
                    Console.Write(" 0 ");
                }
                else
                {
                    Console.Write(" 1 ");
                }
            }

            Console.Write($" ({row})");
            Console.WriteLine();
        }

        Console.Write("    ");

        for (int columnNumber = 0; columnNumber < board.GetLength(1); ++columnNumber)
        {
            Console.Write($"({columnNumber})");
        }

        Console.WriteLine();
    }

    // Mark a point on given row and column as visited.
    public void MarkPointAsVisited(int row, int column)
    {
        board[row, column] = 1;
    }

    // The method makes different moves depending on whether accessibility table and/or lookup are used.
    public void MakeMove(int moveNumber = 0)
    {
        // If nither accessibility table nor lookup is used, that means that "moveNumber" is passed
        // and it is alreadey checked for possibility. In such a case we update current position directly.
        if (!UseAccessibilityTable && !UseLookup)
        {
            CurrentPositionRow += verticalMoves[moveNumber];
            CurrentPositionColumn += horizontalMoves[moveNumber];
        }
        else
        {
            // Create a local variable to store number of a move with the lowest accessibility.
            int moveWithLowestAccessibility = 0;

            // But first write there the first possible move to compare all other moves with it.
            for (int newMoveNumber = 0; newMoveNumber <= 7; ++newMoveNumber)
            {
                if (MoveIsPossible(newMoveNumber, CurrentPositionRow, CurrentPositionColumn))
                {
                    moveWithLowestAccessibility = newMoveNumber;
                    break;
                }
            }

            // Logic for the case when accessibility table is used but lookup is not.
            if (UseAccessibilityTable && !UseLookup)
            {
                // Find accessibility for the first possible move and then compare accessibility of all other possible moves with it,
                // writing the number of move with lowest accessibility to "moveWithLowestAccessibility".
                int newPositionRow1 = CurrentPositionRow + verticalMoves[moveWithLowestAccessibility];
                int newPositionColumn1 = CurrentPositionColumn + horizontalMoves[moveWithLowestAccessibility];
                int newAccessibility1 = accessibilityTable[newPositionRow1, newPositionColumn1];

                for (int newMoveNumber = 0; newMoveNumber <= 7; ++newMoveNumber)
                {
                    if (MoveIsPossible(newMoveNumber, CurrentPositionRow, CurrentPositionColumn))
                    {
                        int newPositionRow2 = CurrentPositionRow + verticalMoves[newMoveNumber];
                        int newPositionColumn2 = CurrentPositionColumn + horizontalMoves[newMoveNumber];
                        int newAccessibility2 = accessibilityTable[newPositionRow2, newPositionColumn2];

                        if (newAccessibility2 < newAccessibility1)
                        {
                            moveWithLowestAccessibility = newMoveNumber;
                        }
                    }
                }
            }

            // Logic for the case when both accessibility table and lookup are used.
            if (UseAccessibilityTable && UseLookup)
            {
                int newPositionRow1Level1 = 0;
                int newPositionColumn1Level1 = 0;
                int newAccessibility1 = 8;

                // Loop to check all reachable positions (level 1), then find the first (level 2) position reachable from it
                // and store accessibility number of found position in "newAccessibility1".
                for (int newMoveNumber1 = 0; newMoveNumber1 <= 7; ++newMoveNumber1)
                {
                    if (MoveIsPossible(newMoveNumber1, CurrentPositionRow, CurrentPositionColumn))
                    {
                        newPositionRow1Level1 = CurrentPositionRow + verticalMoves[newMoveNumber1];
                        newPositionColumn1Level1 = CurrentPositionColumn + horizontalMoves[newMoveNumber1];

                        for (int newMoveNumber2 = 0; newMoveNumber2 <= 7; ++newMoveNumber2)
                        {
                            if (MoveIsPossible(newMoveNumber2, newPositionRow1Level1, newPositionColumn1Level1))
                            {
                                int newPositionRow1Level2 = newPositionRow1Level1 + verticalMoves[newMoveNumber2];
                                int newPositionColumn1Level2 = newPositionColumn1Level1 + horizontalMoves[newMoveNumber2];
                                newAccessibility1 = accessibilityTable[newPositionRow1Level2, newPositionColumn1Level2];
                                break;
                            }
                        }
                    }
                }

                // Loop to check every reachable position (level 1) and all (level 2) positions reachable from them.
                // Accessibility number of every level 2 reachable position is compared to "newAccessibility1"
                // and the lowest value is stored in "moveWithLowestAccessibility" at the end.
                for (int newMoveNumber1 = 0; newMoveNumber1 <= 7; ++newMoveNumber1)
                {
                    if (MoveIsPossible(newMoveNumber1, CurrentPositionRow, CurrentPositionColumn))
                    {
                        int newPositionRow2Level1 = CurrentPositionRow + verticalMoves[newMoveNumber1];
                        int newPositionColumn2Level1 = CurrentPositionColumn + horizontalMoves[newMoveNumber1];

                        for (int newMoveNumber2 = 0; newMoveNumber2 <= 7; ++newMoveNumber2)
                        {
                            if (MoveIsPossible(newMoveNumber2, newPositionRow2Level1, newPositionColumn2Level1))
                            {
                                int newPositionRow2Level2 = newPositionRow2Level1 + verticalMoves[newMoveNumber2];
                                int newPositionColumn2Level2 = newPositionColumn2Level1 + horizontalMoves[newMoveNumber2];
                                int newAccessibility2 = accessibilityTable[newPositionRow2Level2, newPositionColumn2Level2];

                                if (newAccessibility2 < newAccessibility1)
                                {
                                    moveWithLowestAccessibility = newMoveNumber1;
                                }
                            }
                        }
                    }
                }
            }

            // For the case when both accessibility table and lookup are not used, current position is already updated.
            // For the rest cases we update current position using "moveWithLowestAccessibility" we found
            // and also update "accessibilityTable[]" array, decrementing the value of the new current position point.
            if (UseAccessibilityTable)
            {
                CurrentPositionRow += verticalMoves[moveWithLowestAccessibility];
                CurrentPositionColumn += horizontalMoves[moveWithLowestAccessibility];
                --accessibilityTable[CurrentPositionRow, CurrentPositionColumn];
            }
        }

        // Mark new current position as visited, using appropriate method.
        MarkPointAsVisited(CurrentPositionRow, CurrentPositionColumn);
        // Increment total number of moves made during the game.
        ++NumberOfMovesMade;
    }

    // Reset all board properties and fields to their initial values
    // and sets knight's current row and column positions to values of "newStartPositionX" and "newStartPositionY" correspondingly.
    public void ResetBoard(int newStartPositionX, int newStartPositionY)
    {
        CurrentPositionRow = newStartPositionX;
        CurrentPositionColumn = newStartPositionY;
        NumberOfMovesMade = 0;
        board = new int[8, 8];

        if (UseAccessibilityTable)
        {
            accessibilityTable = new int[,]
            {
                { 2, 3, 4, 4, 4, 4, 3, 2 },
                { 3, 4, 6, 6, 6, 6, 4, 3 },
                { 4, 6, 8, 8, 8, 8, 6, 4 },
                { 4, 6, 8, 8, 8, 8, 6, 4 },
                { 4, 6, 8, 8, 8, 8, 6, 4 },
                { 4, 6, 8, 8, 8, 8, 6, 4 },
                { 3, 4, 6, 6, 6, 6, 4, 3 },
                { 2, 3, 4, 4, 4, 4, 3, 2 }
            };
        }
    }

    // Print game statistics and results for the game played from selected start position.
    public void PrintResultsOnePosition()
    {
        Console.WriteLine("Game is over. Nome more moves possible.");
        Console.Write($"The last position: {CurrentPositionRow}:{CurrentPositionColumn}. ");
        Console.WriteLine($"Moves made: {NumberOfMovesMade}");

        if (NumberOfMovesMade == 63)
        {
            Console.WriteLine("Congratiolations! You made a full tour!");
        }

        PrintBoard();

        Console.WriteLine();
    }

    // Print game statistics and results for 64 games played from every possible position.
    public void PrintResultsAllPositions(int successfulTours, int unsuccessfulTours)
    {
        Console.WriteLine("Game is over. 64 tour attempts made from every start position.");
        Console.WriteLine($"Successful tours: {successfulTours}");
        Console.WriteLine($"Unsuccessful tours: {unsuccessfulTours}");
    }

    // Print game statistics and results for games played using random modes.
    public void PrintResultsForRandom(int[] tourStatistics)
    {
        int toursMade = 0;

        // Summ all tours data from "tourStatistics[]" to get full number of tours made.
        for (int move = 0; move < tourStatistics.Length; ++move)
        {
            if (tourStatistics[move] != 0)
            {
                toursMade += tourStatistics[move];
            }
        }

        Console.WriteLine("Game is over.");
        Console.WriteLine($"Tours made: {toursMade}");
        Console.WriteLine("Number of tours for every number of moves:");
        Console.WriteLine("# of moves    # of tours made with appropriate number of moves");

        // Print number of moves made during a tour and number of tours made with this number of moves for all tours made.
        for (int move = 0; move < tourStatistics.Length; ++move)
        {
            if (tourStatistics[move] != 0)
            {
                Console.WriteLine($"{move.ToString("D2")}            {tourStatistics[move]}");
            }
        }

        Console.WriteLine();
    }

    #endregion
}