// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 19 (08.24) Eight Queens.

/* In this file I've used XML comments (triple slash comments before variables and methods) for the first time. XML comments have many
 * applications, but I use them mostly because it allows you to see variable's or method's description or exlanations at any places of
 * the code by simply hovering mouse of variable's or method's name. You can read about XML comments here:
 * https://docs.microsoft.com/en-us/dotnet/csharp/codedoc */

using System;

class Queen
{
    #region Constructor

    public Queen()
    {
        // We could calculate heuristic table manually and just hardcode it here, but aren't we're going to become programmers?
        // Let's make the heuristic table to be calculated the moment an object of class "Queen" is created.
        FillHeuristicTable();
    }

    #endregion

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
    /// Number of moves made during a game.
    /// </summary>
    private int movesMade = 0;

    #endregion

    #region Public properties

    /// <summary>
    /// Current queen's position row.
    /// </summary>
    public int CurrentRow { get; set; }

    /// <summary>
    /// Current queen's position column.
    /// </summary>
    public int CurrentColumn { get; set; }

    /// <summary>
    /// Number of moves made to the moment of the game.
    /// </summary>
    public int MovesMade { get; }

    #endregion

    #region Private methods

    /// <summary>
    /// Fills the heuristic table with default values.
    /// </summary>
    private void FillHeuristicTable()
    {
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

    #endregion

    #region Public methods.

    /// <summary>
    /// Returns the number of rows in the "board[]".
    /// </summary>
    /// <returns>Some text here</returns>
    public int GetBoardNumberOfRows() => board.GetLength(0);

    /// <summary>
    /// Returns the number of columns in the "board[]".
    /// </summary>
    /// <returns></returns>
    public int GetBoardNumberOfColumns() => board.GetLength(1);

    /// <summary>
    /// Prints heuristic table, elimination table and the board.
    /// </summary>
    public void PrintAllBoards()
    {
        Console.WriteLine("Game table:                           Heuristic table:                      Eliminated points:");
        Console.WriteLine("    0   1   2   3   4   5   6   7         0   1   2   3   4   5   6   7         0   1   2   3   4   5   6   7");

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

            Console.Write($"    {row.ToString()} ");

            for (int column = 0; column < GetBoardNumberOfColumns(); ++column)
            {
                Console.Write($"  {heuristicTable[row, column].ToString("D2")}");
            }

            Console.Write($"    {row.ToString()} ");

            for (int column = 0; column < GetBoardNumberOfColumns(); ++column)
            {
                if (eliminatedPoints[row, column] > 0)
                {
                    Console.Write("  * ");
                }
                else
                {
                    Console.Write("    ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Mark every point possibly eliminated by a queen standing on given row and column with queen's number.
    /// </summary>
    public void MarkEliminatedPoints(int queenPositionRow, int queenPositionColumn)
    {
        // Mark whole row as eliminated.
        for (int columnToMark = 0; columnToMark < GetBoardNumberOfColumns(); ++columnToMark)
        {
            if (eliminatedPoints[queenPositionRow, columnToMark] == 0)
            {
                eliminatedPoints[queenPositionRow, columnToMark] = movesMade;
            }
        }

        // Mark whole column as eliminated.
        for (int rowToMark = 0; rowToMark < GetBoardNumberOfRows(); ++rowToMark)
        {
            if (eliminatedPoints[rowToMark, queenPositionColumn] == 0)
            {
                eliminatedPoints[rowToMark, queenPositionColumn] = movesMade;
            }
        }

        // Mark values diagonally for top left as eliminated.
        int rowToMarkTopLeft = queenPositionRow - 1;
        int columnToFillTopLeft = queenPositionColumn - 1;

        while (rowToMarkTopLeft >= 0 && columnToFillTopLeft >= 0)
        {
            if (eliminatedPoints[rowToMarkTopLeft, columnToFillTopLeft] == 0)
            {
                eliminatedPoints[rowToMarkTopLeft, columnToFillTopLeft] = movesMade;
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
                eliminatedPoints[rowToMarkTopRight, columnToMarkTopRight] = movesMade;
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
                eliminatedPoints[rowToMarkBottomRight, columnToMarkBottomRight] = movesMade;
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
                eliminatedPoints[rowToMarkBottomLeft, columnToMarkBottomLeft] = movesMade;
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
                && eliminatedPoints[queenPositionRow, columnToAdd] == movesMade)
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
                && eliminatedPoints[rowToAdd, queenPositionColumn] == movesMade)
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
            if (eliminatedPoints[rowToAddTopLeft, columnToAddTopLeft] == movesMade)
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
            if (eliminatedPoints[rowToAddTopRight, columnToAddTopRight] == movesMade)
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
            if (eliminatedPoints[rowToAddBottomRight, columnToAddBottomRight] == movesMade)
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
            if (eliminatedPoints[rowToAddBottomLeft, columnToAddBottomLeft] == movesMade)
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
    public bool SafePointExists()
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
    /// Ask user to put a queen to one of the available not eliminated point of a board.
    /// </summary>
    public void MakeMove()
    {
        // Create two temporary arrays to store all possible non-eliminated paoints to put a queen to.
        int[] availableRows = new int[0];
        int[] availableColumns = new int[0];

        for (int row = 0; row < GetBoardNumberOfRows(); ++row)
        {
            for (int column = 0; column < GetBoardNumberOfColumns(); ++column)
            {
                // If point is not eliminated, then increase the number of elements in "availableRows[]" and "availableColumns[]" arrays
                // and write the "row" and "column" from the loops to the newly created cells within them.
                // The resulting arrays would contain all row+column combinations of possible places to put a queen.
                if (eliminatedPoints[row, column] == 0)
                {
                    Array.Resize(ref availableRows, availableRows.Length + 1);
                    availableRows[availableRows.Length - 1] = row;
                    Array.Resize(ref availableColumns, availableColumns.Length + 1);
                    availableColumns[availableColumns.Length - 1] = column;
                }
            }
        }

        Console.WriteLine("The task is to put 8 queens on the board with no queen attacking any other queen.");
        Console.WriteLine("List of currently available moves:");

        // "availableRows[]" and "availableColumns[]" should always be the same size, so we check only one of them.
        for (int move = 0; move < availableRows.Length; ++move)
        {
            string moveString = move < 10
                ? $"Move {move} "
                : $"Move {move}";

            Console.Write($"{moveString} - {availableRows[move].ToString("D2")}:{availableColumns[move].ToString("D2")}   ");

            // Add new line for every five values.
            if ((move + 1) % 5 == 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine();
        Console.Write("Enter the number of move to make: ");
        int moveNumber = int.Parse(Console.ReadLine());

        while (moveNumber < 0 || moveNumber >= availableRows.Length)
        {
            Console.WriteLine($"The number should be within {0} to {availableRows.Length - 1} range.");
            Console.Write("Enter the number of move to make: ");
            moveNumber = int.Parse(Console.ReadLine());
        }

        CurrentRow = availableRows[moveNumber];
        CurrentColumn = availableColumns[moveNumber];
        // Write a number of a queen to the "board[]" to be able to see the order in which they were put on the board.
        // Notice that here we increment the value of "movesMade" and only then assign it to "board's" cell.
        board[CurrentRow, CurrentColumn] = ++movesMade;
        // Mark all points potentially eliminated by the new queen as eliminated.
        MarkEliminatedPoints(CurrentRow, CurrentColumn);
        // Change heuristic table according to new position.
        UpdateHeuristicTable(CurrentRow, CurrentColumn);
    }

    #endregion
}