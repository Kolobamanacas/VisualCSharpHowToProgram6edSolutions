// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 20 (08.25) Eight Queens: Brute-Force Approaches.

using System;
using System.Collections.Generic;

class Queen
{
    #region Private fields

    /// <summary>
    /// Chess board. Contains 8 rows with 8 columns.
    /// </summary>
    private int[,] board = new int[8, 8];

    /// <summary>
    /// Each point of the table contains the number of positions from which the point could be eliminated.
    /// </summary>
    private int[,] heuristicTable = new int[8, 8];

    /// <summary>
    /// A point contains 0 if it is not yet eliminated and if it is, it contains the number of a queen which has been eliminated the point.
    /// </summary>
    private int[,] eliminatedPoints = new int[8, 8];

    /// <summary>
    /// Current queen's position row.
    /// </summary>
    public int currentRow;

    /// <summary>
    /// Current queen's position column.
    /// </summary>
    public int currentColumn;

    /// <summary>
    /// Used to generate random numbers.
    /// </summary>
    private static Random randomNumber = new Random();

    #endregion

    #region Public properties

    // Notice that this property could be got by other classes but set only within "Queen's" class.
    /// <summary>
    /// Number of moves made to the moment of the game.
    /// </summary>
    public int MovesMade { get; private set; }

    #endregion

    #region Private methods

    /// <summary>
    /// Returns the number of rows in the "board[]".
    /// </summary>
    /// <returns>Some text here</returns>
    private int GetBoardNumberOfRows() => board.GetLength(0);

    /// <summary>
    /// Returns the number of columns in the "board[]".
    /// </summary>
    /// <returns></returns>
    private int GetBoardNumberOfColumns() => board.GetLength(1);

    /// <summary>
    /// Fills the heuristic table with default values.
    /// </summary>
    private void ResetHeuristicTable()
    {
        heuristicTable = new int[8, 8];

        for (int row = 0; row < GetBoardNumberOfRows(); ++row)
        {
            for (int column = 0; column < GetBoardNumberOfColumns(); ++column)
            {
                // Increment heuristic table's point for the current queen's position.
                ++heuristicTable[row, column];

                // Increment values for the whole row, except for the position where a queen stands.
                for (int columnToFill = 0; columnToFill < GetBoardNumberOfColumns(); ++columnToFill)
                {
                    if (columnToFill != column)
                    {
                        ++heuristicTable[row, columnToFill];
                    }
                }

                // Increment values for the whole column, except for the position where a queen stands.
                for (int rowToFill = 0; rowToFill < GetBoardNumberOfRows(); ++rowToFill)
                {
                    if (rowToFill != row)
                    {
                        ++heuristicTable[rowToFill, column];
                    }
                }

                // Increment values diagonally for top left.
                int rowToFillTopLeft = row - 1;
                int columnToFillTopLeft = column - 1;

                while (rowToFillTopLeft >= 0 && columnToFillTopLeft >= 0)
                {
                    ++heuristicTable[rowToFillTopLeft, columnToFillTopLeft];
                    --rowToFillTopLeft;
                    --columnToFillTopLeft;
                }

                // Increment values diagonally for top right.
                int rowToFillTopRight = row - 1;
                int columnToFillTopRight = column + 1;

                while (rowToFillTopRight >= 0 && columnToFillTopRight < GetBoardNumberOfColumns())
                {
                    ++heuristicTable[rowToFillTopRight, columnToFillTopRight];
                    --rowToFillTopRight;
                    ++columnToFillTopRight;
                }

                // Increment values diagonally for bottom right.
                int rowToFillBottomRight = row + 1;
                int columnToFillBottomRight = column + 1;

                while (rowToFillBottomRight < GetBoardNumberOfRows() && columnToFillBottomRight < GetBoardNumberOfColumns())
                {
                    ++heuristicTable[rowToFillBottomRight, columnToFillBottomRight];
                    ++rowToFillBottomRight;
                    ++columnToFillBottomRight;
                }

                // Increment values diagonally for bottom left.
                int rowToFillBottomLeft = row + 1;
                int columnToFillBottomLeft = column - 1;

                while (rowToFillBottomLeft < GetBoardNumberOfRows() && columnToFillBottomLeft >= 0)
                {
                    ++heuristicTable[rowToFillBottomLeft, columnToFillBottomLeft];
                    ++rowToFillBottomLeft;
                    --columnToFillBottomLeft;
                }
            }
        }
    }

    /// <summary>
    /// Mark every point possibly eliminated by a queen standing on given row and column with queen's number.
    /// </summary>
    private void MarkEliminatedPoints(int queenPositionRow, int queenPositionColumn)
    {
        // Mark whole row as eliminated.
        for (int columnToMark = 0; columnToMark < GetBoardNumberOfColumns(); ++columnToMark)
        {
            if (eliminatedPoints[queenPositionRow, columnToMark] == 0)
            {
                eliminatedPoints[queenPositionRow, columnToMark] = MovesMade;
            }
        }

        // Mark whole column as eliminated.
        for (int rowToMark = 0; rowToMark < GetBoardNumberOfRows(); ++rowToMark)
        {
            if (eliminatedPoints[rowToMark, queenPositionColumn] == 0)
            {
                eliminatedPoints[rowToMark, queenPositionColumn] = MovesMade;
            }
        }

        // Mark values diagonally for top left as eliminated.
        int rowToMarkTopLeft = queenPositionRow - 1;
        int columnToFillTopLeft = queenPositionColumn - 1;

        while (rowToMarkTopLeft >= 0 && columnToFillTopLeft >= 0)
        {
            if (eliminatedPoints[rowToMarkTopLeft, columnToFillTopLeft] == 0)
            {
                eliminatedPoints[rowToMarkTopLeft, columnToFillTopLeft] = MovesMade;
            }

            --rowToMarkTopLeft;
            --columnToFillTopLeft;
        }

        // Mark values diagonally for top right as eliminated.
        int rowToMarkTopRight = queenPositionRow - 1;
        int columnToMarkTopRight = queenPositionColumn + 1;

        while (rowToMarkTopRight >= 0 && columnToMarkTopRight < GetBoardNumberOfColumns())
        {
            if (eliminatedPoints[rowToMarkTopRight, columnToMarkTopRight] == 0)
            {
                eliminatedPoints[rowToMarkTopRight, columnToMarkTopRight] = MovesMade;
            }

            --rowToMarkTopRight;
            ++columnToMarkTopRight;
        }

        // Mark values diagonally for bottom right as eliminated.
        int rowToMarkBottomRight = queenPositionRow + 1;
        int columnToMarkBottomRight = queenPositionColumn + 1;

        while (rowToMarkBottomRight < GetBoardNumberOfRows() && columnToMarkBottomRight < GetBoardNumberOfColumns())
        {
            if (eliminatedPoints[rowToMarkBottomRight, columnToMarkBottomRight] == 0)
            {
                eliminatedPoints[rowToMarkBottomRight, columnToMarkBottomRight] = MovesMade;
            }

            ++rowToMarkBottomRight;
            ++columnToMarkBottomRight;
        }

        // Mark values diagonally for bottom left as eliminated.
        int rowToMarkBottomLeft = queenPositionRow + 1;
        int columnToMarkBottomLeft = queenPositionColumn - 1;

        while (rowToMarkBottomLeft < GetBoardNumberOfRows() && columnToMarkBottomLeft >= 0)
        {
            if (eliminatedPoints[rowToMarkBottomLeft, columnToMarkBottomLeft] == 0)
            {
                eliminatedPoints[rowToMarkBottomLeft, columnToMarkBottomLeft] = MovesMade;
            }

            ++rowToMarkBottomLeft;
            --columnToMarkBottomLeft;
        }
    }

    /// <summary>
    /// Decrements values of heuristic table eliminated by a queen put on the provided row and column.
    /// </summary>
    public void UpdateHeuristicTable(int queenPositionRow, int queenPositionColumn)
    {
        // Create two arrays to store all points eliminated by new queen's position.
        int[] newEliminatedPointsRow = new int[0];
        int[] newEliminatedPointsColumn = new int[0];

        // Add current queen's position to eliminated row and column.
        Array.Resize(ref newEliminatedPointsRow, newEliminatedPointsRow.Length + 1);
        newEliminatedPointsRow[newEliminatedPointsRow.Length - 1] = queenPositionRow;
        Array.Resize(ref newEliminatedPointsColumn, newEliminatedPointsColumn.Length + 1);
        newEliminatedPointsColumn[newEliminatedPointsColumn.Length - 1] = queenPositionColumn;

        // Add points of the row to eliminated, except for the position where a queen stands.
        // Number of made moves always shows a number of the last queen placed on a board.
        for (int columnToAdd = 0; columnToAdd < GetBoardNumberOfColumns(); ++columnToAdd)
        {
            if (columnToAdd != queenPositionColumn
                && eliminatedPoints[queenPositionRow, columnToAdd] == MovesMade)
            {
                Array.Resize(ref newEliminatedPointsRow, newEliminatedPointsRow.Length + 1);
                newEliminatedPointsRow[newEliminatedPointsRow.Length - 1] = queenPositionRow;
                Array.Resize(ref newEliminatedPointsColumn, newEliminatedPointsColumn.Length + 1);
                newEliminatedPointsColumn[newEliminatedPointsColumn.Length - 1] = columnToAdd;
            }
        }

        // Add points of the column to eliminated, except for the position where a queen stands.
        for (int rowToAdd = 0; rowToAdd < GetBoardNumberOfRows(); ++rowToAdd)
        {
            if (rowToAdd != queenPositionRow
                && eliminatedPoints[rowToAdd, queenPositionColumn] == MovesMade)
            {
                Array.Resize(ref newEliminatedPointsRow, newEliminatedPointsRow.Length + 1);
                newEliminatedPointsRow[newEliminatedPointsRow.Length - 1] = rowToAdd;
                Array.Resize(ref newEliminatedPointsColumn, newEliminatedPointsColumn.Length + 1);
                newEliminatedPointsColumn[newEliminatedPointsColumn.Length - 1] = queenPositionColumn;
            }
        }

        // Add points diagonally for top left.
        int rowToAddTopLeft = queenPositionRow - 1;
        int columnToAddTopLeft = queenPositionColumn - 1;

        while (rowToAddTopLeft >= 0 && columnToAddTopLeft >= 0)
        {
            if (eliminatedPoints[rowToAddTopLeft, columnToAddTopLeft] == MovesMade)
            {
                Array.Resize(ref newEliminatedPointsRow, newEliminatedPointsRow.Length + 1);
                newEliminatedPointsRow[newEliminatedPointsRow.Length - 1] = rowToAddTopLeft;
                Array.Resize(ref newEliminatedPointsColumn, newEliminatedPointsColumn.Length + 1);
                newEliminatedPointsColumn[newEliminatedPointsColumn.Length - 1] = columnToAddTopLeft;
            }

            --rowToAddTopLeft;
            --columnToAddTopLeft;
        }

        // Add points diagonally for top right.
        int rowToAddTopRight = queenPositionRow - 1;
        int columnToAddTopRight = queenPositionColumn + 1;

        while (rowToAddTopRight >= 0 && columnToAddTopRight < GetBoardNumberOfColumns())
        {
            if (eliminatedPoints[rowToAddTopRight, columnToAddTopRight] == MovesMade)
            {
                Array.Resize(ref newEliminatedPointsRow, newEliminatedPointsRow.Length + 1);
                newEliminatedPointsRow[newEliminatedPointsRow.Length - 1] = rowToAddTopRight;
                Array.Resize(ref newEliminatedPointsColumn, newEliminatedPointsColumn.Length + 1);
                newEliminatedPointsColumn[newEliminatedPointsColumn.Length - 1] = columnToAddTopRight;
            }

            --rowToAddTopRight;
            ++columnToAddTopRight;
        }

        // Add points diagonally for bottom right.
        int rowToAddBottomRight = queenPositionRow + 1;
        int columnToAddBottomRight = queenPositionColumn + 1;

        while (rowToAddBottomRight < GetBoardNumberOfRows() && columnToAddBottomRight < GetBoardNumberOfColumns())
        {
            if (eliminatedPoints[rowToAddBottomRight, columnToAddBottomRight] == MovesMade)
            {
                Array.Resize(ref newEliminatedPointsRow, newEliminatedPointsRow.Length + 1);
                newEliminatedPointsRow[newEliminatedPointsRow.Length - 1] = rowToAddBottomRight;
                Array.Resize(ref newEliminatedPointsColumn, newEliminatedPointsColumn.Length + 1);
                newEliminatedPointsColumn[newEliminatedPointsColumn.Length - 1] = columnToAddBottomRight;
            }

            ++rowToAddBottomRight;
            ++columnToAddBottomRight;
        }

        // Add points diagonally for bottom left.
        int rowToAddBottomLeft = queenPositionRow + 1;
        int columnToAddBottomLeft = queenPositionColumn - 1;

        while (rowToAddBottomLeft < GetBoardNumberOfRows() && columnToAddBottomLeft >= 0)
        {
            if (eliminatedPoints[rowToAddBottomLeft, columnToAddBottomLeft] == MovesMade)
            {
                Array.Resize(ref newEliminatedPointsRow, newEliminatedPointsRow.Length + 1);
                newEliminatedPointsRow[newEliminatedPointsRow.Length - 1] = rowToAddBottomLeft;
                Array.Resize(ref newEliminatedPointsColumn, newEliminatedPointsColumn.Length + 1);
                newEliminatedPointsColumn[newEliminatedPointsColumn.Length - 1] = columnToAddBottomLeft;
            }

            ++rowToAddBottomLeft;
            --columnToAddBottomLeft;
        }

        // Now for every eliminated point we decrement all the points they could potentialy eliminate.
        // "EliminatedPointsRow[]" and "EliminatedPointsColumn[]" arrays should contain the same number of elements so we check only one.
        for (int point = 0; point < newEliminatedPointsRow.Length; ++point)
        {
            // Decrement heuristic table's point for the current queen's position.
            if (heuristicTable[newEliminatedPointsRow[point], newEliminatedPointsColumn[point]] > 0)
            {
                --heuristicTable[newEliminatedPointsRow[point], newEliminatedPointsColumn[point]];
            }

            // Decrement values for the whole row, except for the position where a queen stands.
            for (int columnToDecrement = 0; columnToDecrement < GetBoardNumberOfColumns(); ++columnToDecrement)
            {
                if (columnToDecrement != newEliminatedPointsColumn[point]
                    && heuristicTable[newEliminatedPointsRow[point], columnToDecrement] > 0)
                {
                    --heuristicTable[newEliminatedPointsRow[point], columnToDecrement];
                }
            }

            // Decrement values for the whole column, except for the position where a queen stands.
            for (int rowToDecrement = 0; rowToDecrement < GetBoardNumberOfRows(); ++rowToDecrement)
            {
                if (rowToDecrement != newEliminatedPointsRow[point]
                    && heuristicTable[rowToDecrement, newEliminatedPointsColumn[point]] > 0)
                {
                    --heuristicTable[rowToDecrement, newEliminatedPointsColumn[point]];
                }
            }

            // Decrement values diagonally for top left.
            int rowToDecrementTopLeft = newEliminatedPointsRow[point] - 1;
            int columnToDecrementTopLeft = newEliminatedPointsColumn[point] - 1;

            while (rowToDecrementTopLeft >= 0 && columnToDecrementTopLeft >= 0)
            {
                if (heuristicTable[rowToDecrementTopLeft, columnToDecrementTopLeft] > 0)
                {
                    --heuristicTable[rowToDecrementTopLeft, columnToDecrementTopLeft];
                }

                --rowToDecrementTopLeft;
                --columnToDecrementTopLeft;
            }

            // Decrement values diagonally for top right.
            int rowToDecrementTopRight = newEliminatedPointsRow[point] - 1;
            int columnToDecrementTopRight = newEliminatedPointsColumn[point] + 1;

            while (rowToDecrementTopRight >= 0 && columnToDecrementTopRight < GetBoardNumberOfColumns())
            {
                if (heuristicTable[rowToDecrementTopRight, columnToDecrementTopRight] > 0)
                {
                    --heuristicTable[rowToDecrementTopRight, columnToDecrementTopRight];
                }

                --rowToDecrementTopRight;
                ++columnToDecrementTopRight;
            }

            // Decrement values diagonally for bottom right.
            int rowToDecrementBottomRight = newEliminatedPointsRow[point] + 1;
            int columnToDecrementBottomRight = newEliminatedPointsColumn[point] + 1;

            while (rowToDecrementBottomRight < GetBoardNumberOfRows() && columnToDecrementBottomRight < GetBoardNumberOfColumns())
            {
                if (heuristicTable[rowToDecrementBottomRight, columnToDecrementBottomRight] > 0)
                {
                    --heuristicTable[rowToDecrementBottomRight, columnToDecrementBottomRight];
                }

                ++rowToDecrementBottomRight;
                ++columnToDecrementBottomRight;
            }

            // Decrement values diagonally for bottom left.
            int rowToDecrementBottomLeft = newEliminatedPointsRow[point] + 1;
            int columnToDecrementBottomLeft = newEliminatedPointsColumn[point] - 1;

            while (rowToDecrementBottomLeft < GetBoardNumberOfRows() && columnToDecrementBottomLeft >= 0)
            {
                if (heuristicTable[rowToDecrementBottomLeft, columnToDecrementBottomLeft] > 0)
                {
                    --heuristicTable[rowToDecrementBottomLeft, columnToDecrementBottomLeft];
                }

                ++rowToDecrementBottomLeft;
                --columnToDecrementBottomLeft;
            }
        }
    }

    /// <summary>
    /// Returns "true" if at least 1 not eliminated point presented on a board.
    /// </summary>
    /// <returns></returns>
    private bool SafePointExists()
    {
        // Local variable to store a result to return.
        bool safePointExists = false;
        // We need to break two upcoming loops at a time in order to save some processor time.
        // So instead of using two "for" loops let's initialize two local variables "row" and "column"
        // and loop continuation confdition variable - "keepLooping", which we add to both "while" loops.
        // When we need to break both loops, we change "keepLooping" to false.
        int row = 0;
        int column = 0;
        bool keepLooping = true;

        while (row < GetBoardNumberOfRows() && keepLooping)
        {
            while (column < GetBoardNumberOfColumns() && keepLooping)
            {
                // If the point is not eliminated yet breake the loop and assign true to "safePointExists".
                if (eliminatedPoints[row, column] == 0)
                {
                    safePointExists = true;
                    keepLooping = false;
                }

                ++column;
            }

            column = 0;
            ++row;
        }

        return safePointExists;
    }

    /// <summary>
    /// Writes randomly chosen point with lowest elimination number to current row and column values.
    /// </summary>
    private void SetPointWithLowestEliminationNumber(ref int rowToUpdate, ref int columnToUpdate)
    {
        // Assume that 1000 is the lowest elimination number (an impossibly high value).
        int lowestEliminationNumber = 1000;

        // If we find a point with elimination number lower than already found, then replace old value with the new one.
        for (int row = 0; row < GetBoardNumberOfRows(); ++row)
        {
            for (int column = 0; column < GetBoardNumberOfColumns(); ++column)
            {
                if (eliminatedPoints[row, column] == 0
                    && heuristicTable[row, column] < lowestEliminationNumber)
                {
                    lowestEliminationNumber = heuristicTable[row, column];
                }
            }
        }

        // Temporary arrays to store all points with lowest elimination number.
        int[] rowsWithLowestEliminationNumber = new int[0];
        int[] columnWithLowestEliminationNumber = new int[0];

        // Find all points with found elimination number and add them to the arrays.
        for (int row = 0; row < GetBoardNumberOfRows(); ++row)
        {
            for (int column = 0; column < GetBoardNumberOfColumns(); ++column)
            {
                if (eliminatedPoints[row, column] == 0
                    && heuristicTable[row, column] == lowestEliminationNumber)
                {
                    Array.Resize(ref rowsWithLowestEliminationNumber, rowsWithLowestEliminationNumber.Length + 1);
                    rowsWithLowestEliminationNumber[rowsWithLowestEliminationNumber.Length - 1] = row;
                    Array.Resize(ref columnWithLowestEliminationNumber, columnWithLowestEliminationNumber.Length + 1);
                    columnWithLowestEliminationNumber[columnWithLowestEliminationNumber.Length - 1] = column;
                }
            }
        }

        // Both arrays should have the same number of values. So we use only one of them to generate a move number.
        // Generate a number between 0 and number of elements in the array - 1.
        int randomMoveNumber = randomNumber.Next(rowsWithLowestEliminationNumber.Length);

        // Write row and column of found point to class's fields of current row and column.
        rowToUpdate = rowsWithLowestEliminationNumber[randomMoveNumber];
        columnToUpdate = columnWithLowestEliminationNumber[randomMoveNumber];
    }

    /// <summary>
    /// Removes a queen with given number from the board.
    /// </summary>
    /// <param name="queenNumber">Number of a queen to remove from the board.</param>
    private void RemoveQueenFromBoard(int queenNumber)
    {
        for (int row = 0; row < GetBoardNumberOfRows(); ++row)
        {
            for (int column = 0; column < GetBoardNumberOfColumns(); ++column)
            {
                if (board[row, column] == queenNumber)
                {
                    board[row, column] = 0;
                }
            }
        }
    }

    /// <summary>
    /// eturns "true" if all eight queens are on the board and noone attacks each other.
    /// </summary>
    /// <returns></returns>
    private bool CombinationIsSuccessful()
    {
        // Assume that combination is successful by default.
        bool combinationIsSuccessful = true;
        bool keepLooping = true;

        // Keep looping until all points are checked or until a queen could be possibly attacked is found.
        for (int row = 0; (row < GetBoardNumberOfRows() && keepLooping); ++row)
        {
            for (int column = 0; (column < GetBoardNumberOfColumns() && keepLooping); ++column)
            {
                // If queen's "attack area" is not empty, break the loop and return "false".
                if (board[row, column] != 0
                    && !AttackAreaIsEmpty(row, column))
                {
                    combinationIsSuccessful = false;
                    keepLooping = false;
                }
            }
        }

        return combinationIsSuccessful;
    }

    /// <summary>
    /// Returns "true" if a queen with given row and column has no other queens on it's row, column or diagonals.
    /// </summary>
    /// <param name="row">Row of a queen standing on the board.</param>
    /// <param name="column">Column of a queen standing on the board.</param>
    /// <returns></returns>
    private bool AttackAreaIsEmpty(int row, int column)
    {
        bool areaIsEmpty = true;

        // Check all rows it the queen's column. If there other queens on the same column, attack area is not empty.
        for (int rowToCheck = 0; (rowToCheck < GetBoardNumberOfRows() && areaIsEmpty); ++rowToCheck)
        {
            if (rowToCheck != row && board[rowToCheck, column] != 0)
            {
                areaIsEmpty = false;
            }
        }

        // Check all columns it the queen's row. If there other queens on the same row, attack area is not empty.
        for (int columnToCheck = 0; (columnToCheck < GetBoardNumberOfColumns() && areaIsEmpty); ++columnToCheck)
        {
            if (columnToCheck != column && board[row, columnToCheck] != 0)
            {
                areaIsEmpty = false;
            }
        }

        // Check top left diagonal.
        int rowToCheckTopLeft = row - 1;
        int columnToCheckTopLeft = column - 1;

        while (rowToCheckTopLeft >= 0
            && columnToCheckTopLeft >= 0
            && areaIsEmpty)
        {
            if (board[rowToCheckTopLeft, columnToCheckTopLeft] != 0)
            {
                areaIsEmpty = false;
            }

            --rowToCheckTopLeft;
            --columnToCheckTopLeft;
        }

        // Check top right diagonal.
        int rowToCheckTopRight = row - 1;
        int columnToCheckTopRight = column + 1;

        while (rowToCheckTopRight >= 0
            && columnToCheckTopRight < GetBoardNumberOfColumns()
            && areaIsEmpty)
        {
            if (board[rowToCheckTopRight, columnToCheckTopRight] != 0)
            {
                areaIsEmpty = false;
            }

            --rowToCheckTopRight;
            ++columnToCheckTopRight;
        }

        // Check bottom right diagonal.
        int rowToCheckBottomRight = row + 1;
        int columnToCheckBottomRight = column + 1;

        while (rowToCheckBottomRight < GetBoardNumberOfRows()
            && columnToCheckBottomRight < GetBoardNumberOfColumns()
            && areaIsEmpty)
        {
            if (board[rowToCheckBottomRight, columnToCheckBottomRight] != 0)
            {
                areaIsEmpty = false;
            }

            ++rowToCheckBottomRight;
            ++columnToCheckBottomRight;
        }

        // Check bottom left diagonal.
        int rowToCheckBottomLeft = row + 1;
        int columnToCheckBottomLeft = column - 1;

        while (rowToCheckBottomLeft < GetBoardNumberOfRows()
            && columnToCheckBottomLeft >= 0
            && areaIsEmpty)
        {
            if (board[rowToCheckBottomLeft, columnToCheckBottomLeft] != 0)
            {
                areaIsEmpty = false;
            }

            ++rowToCheckBottomLeft;
            --columnToCheckBottomLeft;
        }

        return areaIsEmpty;
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Set number of made moves and values of all tables to their initial values.
    /// </summary>
    public void ResetTables()
    {
        board = new int[8, 8];
        ResetHeuristicTable();
        MovesMade = 0;
    }

    /// <summary>
    /// Plays one game, choosing queens positions randomly from the list of moves with lowes elimination number.
    /// </summary>
    public void TryRandomCombination()
    {
        while (SafePointExists())
        {
            // Make a move.
            SetPointWithLowestEliminationNumber(ref currentRow, ref currentColumn);
            // Write a number of a queen to the "board[]" to be able to see the order in which they were put on the board.
            // Notice that here we increment the value of "MovesMade" and only then assign it to "board's" cell.
            board[currentRow, currentColumn] = ++MovesMade;
            // Mark all points potentially eliminated by the new queen as eliminated.
            MarkEliminatedPoints(currentRow, currentColumn);
            // Change heuristic table according to new position.
            UpdateHeuristicTable(currentRow, currentColumn);
        }
    }

    /// <summary>
    /// Prints the "board[]" with all queens placed there.
    /// </summary>
    public void PrintSuccessfulCombination()
    {
        Console.WriteLine();
        Console.WriteLine("Game table:");
        Console.WriteLine("    0   1   2   3   4   5   6   7");

        for (int row = 0; row < GetBoardNumberOfRows(); ++row)
        {
            Console.Write($"{row.ToString()} ");

            for (int column = 0; column < GetBoardNumberOfColumns(); ++column)
            {
                if (board[row, column] == 0)
                {
                    Console.Write("    ");
                }
                else
                {
                    Console.Write($"  Q{board[row, column].ToString()}");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Prints the board given as a parameter with all queens placed there.
    /// </summary>
    /// <param name="boardToPrint"></param>
    public void PrintGivenBoard(int[,] boardToPrint)
    {
        Console.WriteLine("    0   1   2   3   4   5   6   7");

        for (int row = 0; row < GetBoardNumberOfRows(); ++row)
        {
            Console.Write($"{row.ToString()} ");

            for (int column = 0; column < GetBoardNumberOfColumns(); ++column)
            {
                if (boardToPrint[row, column] == 0)
                {
                    Console.Write("    ");
                }
                else
                {
                    Console.Write($"  Q{boardToPrint[row, column].ToString()}");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Checks all possible combinations and prints only successful combinations found.
    /// </summary>
    public void FindAndPrintAllSolutions()
    {
        // Initialize a list of boards to store successful combinations there.
        List<int[,]> successfulBoards = new List<int[,]>();
        Console.WriteLine("The task is in progress.");
        // Progress count integer.
        int progressCounter = 0;

        // Sixteen cycles, two per queen to check all possible combinations.
        // Cycle for queen 1.
        for (int queen1Row = 0; queen1Row < GetBoardNumberOfRows(); ++queen1Row)
        {
            for (int queen1Column = 0; queen1Column < GetBoardNumberOfColumns(); ++queen1Column)
            {
                Console.WriteLine($"  > {++progressCounter} of 64 checking cycles are made.");

                RemoveQueenFromBoard(1);
                board[queen1Row, queen1Column] = 1;

                // Cycle for queen 2.
                for (int queen2Row = 0; queen2Row < GetBoardNumberOfRows(); ++queen2Row)
                {
                    for (int queen2Column = 0; queen2Column < GetBoardNumberOfColumns(); ++queen2Column)
                    {
                        if (board[queen2Row, queen2Column] == 0
                            || board[queen2Row, queen2Column] > 1)
                        {
                            RemoveQueenFromBoard(2);
                            board[queen1Row, queen1Column] = 2;
                        }

                        // Cycle for queen 3.
                        for (int queen3Row = 0; queen3Row < GetBoardNumberOfRows(); ++queen3Row)
                        {
                            for (int queen3Column = 0; queen3Column < GetBoardNumberOfColumns(); ++queen3Column)
                            {
                                if (board[queen3Row, queen3Column] == 0
                                    || board[queen3Row, queen3Column] > 2)
                                {
                                    RemoveQueenFromBoard(3);
                                    board[queen3Row, queen3Column] = 3;
                                }

                                // Cycle for queen 4.
                                for (int queen4Row = 0; queen4Row < GetBoardNumberOfRows(); ++queen4Row)
                                {
                                    for (int queen4Column = 0; queen4Column < GetBoardNumberOfColumns(); ++queen4Column)
                                    {
                                        if (board[queen4Row, queen4Column] == 0
                                            || board[queen4Row, queen4Column] > 3)
                                        {
                                            RemoveQueenFromBoard(4);
                                            board[queen4Row, queen4Column] = 4;

                                        }

                                        // Cycle for queen 5.
                                        for (int queen5Row = 0; queen5Row < GetBoardNumberOfRows(); ++queen5Row)
                                        {
                                            for (int queen5Column = 0; queen5Column < GetBoardNumberOfColumns(); ++queen5Column)
                                            {
                                                if (board[queen5Row, queen5Column] == 0
                                                    || board[queen5Row, queen5Column] > 4)
                                                {
                                                    RemoveQueenFromBoard(5);
                                                    board[queen5Row, queen5Column] = 5;
                                                }

                                                // Cycle for queen 6.
                                                for (int queen6Row = 0; queen6Row < GetBoardNumberOfRows(); ++queen6Row)
                                                {
                                                    for (int queen6Column = 0; queen6Column < GetBoardNumberOfColumns(); ++queen6Column)
                                                    {
                                                        if (board[queen6Row, queen6Column] == 0
                                                            || board[queen6Row, queen6Column] > 5)
                                                        {
                                                            RemoveQueenFromBoard(6);
                                                            board[queen6Row, queen6Column] = 6;
                                                        }

                                                        // Cycle for queen 7.
                                                        for (int queen7Row = 0; queen7Row < GetBoardNumberOfRows(); ++queen7Row)
                                                        {
                                                            for (int queen7Column = 0; queen7Column < GetBoardNumberOfColumns(); ++queen7Column)
                                                            {
                                                                if (board[queen7Row, queen7Column] == 0
                                                                    || board[queen7Row, queen7Column] > 6)
                                                                {
                                                                    RemoveQueenFromBoard(7);
                                                                    board[queen7Row, queen7Column] = 7;
                                                                }

                                                                // Cycle for queen 8.
                                                                for (int queen8Row = 0; queen8Row < GetBoardNumberOfRows(); ++queen8Row)
                                                                {
                                                                    for (int queen8Column = 0; queen8Column < GetBoardNumberOfColumns(); ++queen8Column)
                                                                    {
                                                                        if (board[queen8Row, queen8Column] == 0
                                                                            || board[queen8Row, queen8Column] > 7)
                                                                        {
                                                                            RemoveQueenFromBoard(8);
                                                                            board[queen8Row, queen8Column] = 8;

                                                                            // If combination is successful, add the board to the list.
                                                                            if (CombinationIsSuccessful())
                                                                            {
                                                                                successfulBoards.Add(board);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Print all boards with successful combinations.
        int numberOfCombination = 0;

        foreach (int[,] boardToPrint in successfulBoards)
        {
            Console.WriteLine($"Successful combination number {numberOfCombination}:");
            PrintGivenBoard(boardToPrint);
        }
    }

    #endregion
}