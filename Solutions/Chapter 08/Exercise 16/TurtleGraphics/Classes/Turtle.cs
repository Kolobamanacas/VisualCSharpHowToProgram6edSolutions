// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 16 (08.21) Turtle Graphics.

/* Here we use new for us feature of C#, a preprocessor directive - "#region".
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-region
 * I does nothing except it allows us to collapse and expand some code blocks between "#region" and "#endregion" words.
 * 
 * The class has three regions: private fields, private methods and public methods.
 * Fields include two-dimentional array to store current floor's state, two integers to store current turtle's position,
 * a field which storing direction - an element of enumeration to storing current turtle's direction
 * and finally a boolean field for pen's state (up or down).
 * 
 * You could notice that we are able to declare enumerations outside of the class body. In case they are declared as public,
 * they can be used in any place of the code within a namespace. You can read about namespaces here
 * (or just don't bother about them for now):
 * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/namespaces/
 * 
 * There are 9 private methods, 8 to move turtle to an appropriate direction and 1 to return current turtle's direction string.
 * 
 * And finally there are three publice methods. The first one prints possible commands. The second one prints the floor and
 * all information about current turtle's state. The third one perform an action depends on key passed to the method as argument.
 * You could notice that "return" statement is used in most cases instead of "breake" within a "switch" statement. The "return"
 * statement forces to leave method's body immediately without performing additional actions. This helps us to call "move" methods
 * only in case where "ConsoleKey.UpArrow" is passed as an argument. */

using System;

public enum Directions
{
    Down = 0,
    LowerLeft = 1,
    Left = 2,
    UpperLeft = 3,
    Up = 4,
    UpperRight = 5,
    Right = 6,
    LowerRight = 7
}

class Turtle
{

    #region Private fields

    private int[,] floor = new int[20, 20];
    private int currentPositionX = 0;
    private int currentPositionY = 0;
    private Directions currentDirection = Directions.Right;
    private bool penIsDown = false;

    #endregion

    #region Private methods

    private void TurnLeft()
    {
        if (currentDirection == Directions.Down)
        {
            currentDirection = Directions.LowerRight;
        }
        else
        {
            --currentDirection;
        }
    }

    private void TurnRight()
    {
        if (currentDirection == Directions.LowerRight)
        {
            currentDirection = Directions.Down;
        }
        else
        {
            ++currentDirection;
        }
    }

    private void MoveDown(int distance)
    {
        if (penIsDown)
        {
            floor[currentPositionX, currentPositionY] = 1;

            for (int move = 0; (move < distance) && (currentPositionX < (floor.GetLength(0) - 1)); ++move)
            {
                ++currentPositionX;
                floor[currentPositionX, currentPositionY] = 1;
            }
        }
        else
        {
            if (currentPositionX + distance < (floor.GetLength(0)))
            {
                currentPositionX += distance;
            }
            else
            {
                currentPositionX = floor.GetLength(0) - 1;
            }
        }
    }

    private void MoveLowerLeft(int distance)
    {
        if (penIsDown)
        {
            floor[currentPositionX, currentPositionY] = 1;

            for (int move = 0; (move < distance) && (currentPositionY > 0) && (currentPositionX < floor.GetLength(0) - 1); ++move)
            {
                ++currentPositionX;
                --currentPositionY;
                floor[currentPositionX, currentPositionY] = 1;
            }
        }
        else
        {
            int newPositionX = currentPositionX + distance;
            int newPositionY = currentPositionY - distance;

            if ((newPositionY < 0) || (newPositionX >= floor.GetLength(0)))
            {
                int newDistance = Math.Min(((floor.GetLength(0) - 1) - currentPositionX), (distance + newPositionY));
                currentPositionX += newDistance;
                currentPositionY -= newDistance;
            }
            else
            {
                currentPositionX += distance;
                currentPositionY -= distance;
            }
        }
    }

    private void MoveLeft(int distance)
    {
        if (penIsDown)
        {
            floor[currentPositionX, currentPositionY] = 1;

            for (int move = 0; (move < distance) && (currentPositionY > 0); ++move)
            {
                --currentPositionY;
                floor[currentPositionX, currentPositionY] = 1;
            }
        }
        else
        {
            if (currentPositionY - distance >= 0)
            {
                currentPositionY -= distance;
            }
            else
            {
                currentPositionY = 0;
            }
        }
    }

    private void MoveUpperLeft(int distance)
    {
        if (penIsDown)
        {
            floor[currentPositionX, currentPositionY] = 1;

            for (int move = 0; (move < distance) && (currentPositionY > 0) && (currentPositionX > 0); ++move)
            {
                --currentPositionX;
                --currentPositionY;
                floor[currentPositionX, currentPositionY] = 1;
            }
        }
        else
        {
            int newPositionX = currentPositionX - distance;
            int newPositionY = currentPositionY - distance;

            if (newPositionX < 0 || newPositionY < 0)
            {
                int newDistance = Math.Min((distance + currentPositionX), (distance + currentPositionY));
                currentPositionX -= newDistance;
                currentPositionY -= newDistance;
            }
            else
            {
                currentPositionX -= distance;
                currentPositionY -= distance;
            }
        }
    }

    private void MoveUp(int distance)
    {
        if (penIsDown)
        {
            floor[currentPositionX, currentPositionY] = 1;

            for (int move = 0; (move < distance) && (currentPositionX > 0); ++move)
            {
                --currentPositionX;
                floor[currentPositionX, currentPositionY] = 1;
            }
        }
        else
        {
            if (currentPositionX - distance < 0)
            {
                currentPositionX = 0;
            }
            else
            {
                currentPositionX -= distance;
            }
        }
    }

    private void MoveUpperRight(int distance)
    {
        if (penIsDown)
        {
            floor[currentPositionX, currentPositionY] = 1;

            for (int move = 0; (move < distance) && (currentPositionY < floor.GetLength(1) - 1) && (currentPositionX > 0); ++move)
            {
                --currentPositionX;
                ++currentPositionY;
                floor[currentPositionX, currentPositionY] = 1;
            }
        }
        else
        {
            int newPositionX = currentPositionX - distance;
            int newPositionY = currentPositionY + distance;

            if (newPositionX < 0 || newPositionY >= floor.GetLength(1))
            {
                int newDistance = Math.Min((distance + newPositionX), ((floor.GetLength(1) - 1) - currentPositionY));
                currentPositionX -= newDistance;
                currentPositionY += newDistance;
            }
            else
            {
                currentPositionX -= distance;
                currentPositionY += distance;
            }
        }
    }

    private void MoveRight(int distance)
    {
        if (penIsDown)
        {
            floor[currentPositionX, currentPositionY] = 1;

            for (int move = 0; (move < distance) && (currentPositionY < floor.GetLength(1) - 1); ++move)
            {
                ++currentPositionY;
                floor[currentPositionX, currentPositionY] = 1;
            }
        }
        else
        {
            if (currentPositionY + distance >= floor.GetLength(1))
            {
                currentPositionY = floor.GetLength(1) - 1;
            }
            else
            {
                currentPositionY += distance;
            }
        }
    }

    private void MoveLowerRight(int distance)
    {
        if (penIsDown)
        {
            floor[currentPositionX, currentPositionY] = 1;

            for (int move = 0;
                (move < distance) && (currentPositionX < floor.GetLength(0) - 1) && (currentPositionY < floor.GetLength(1) - 1); ++move)
            {
                ++currentPositionX;
                ++currentPositionY;
                floor[currentPositionX, currentPositionY] = 1;
            }
        }
        else
        {
            int newPositionX = currentPositionX + distance;
            int newPositionY = currentPositionY + distance;

            if (newPositionX >= floor.GetLength(0) || newPositionY >= floor.GetLength(1))
            {
                int newDistance = Math.Min(((floor.GetLength(0) - 1) - currentPositionX), ((floor.GetLength(1) - 1) - currentPositionY));
                currentPositionX += newDistance;
                currentPositionY += newDistance;
            }
            else
            {
                currentPositionX += distance;
                currentPositionY += distance;
            }
        }
    }

    private string GetCurrentDirectionArrow()
    {
        string currentDirectionArrow = "";

        switch (currentDirection)
        {
            case Directions.Down:
                currentDirectionArrow = "Down (↓)";
                break;
            case Directions.LowerLeft:
                currentDirectionArrow = "Lower left (←↓)";
                break;
            case Directions.Left:
                currentDirectionArrow = "Left (←)";
                break;
            case Directions.UpperLeft:
                currentDirectionArrow = "Upper left (←↑)";
                break;
            case Directions.Up:
                currentDirectionArrow = "Up (↑)";
                break;
            case Directions.UpperRight:
                currentDirectionArrow = "Upper right (↑→)";
                break;
            case Directions.Right:
                currentDirectionArrow = "Right (→)";
                break;
            case Directions.LowerRight:
                currentDirectionArrow = "Lower right (↓→)";
                break;
            default:
                break;
        }

        return currentDirectionArrow;
    }

    #endregion

    #region Public methods

    public void DisplayCommands()
    {
        Console.WriteLine("Turtle control buttons:  \"←\" - turn left;  \"→\" - turn right;\n"
            + "\"↑\" - enable forward mode;  \"number, Enter (while in forward mode)\" - move forward for given number of points;\n"
            + "\"↓\" - pen up/down;  \"ESC\" - exit the application.");
    }

    public void PrintAnArray()
    {
        Console.WriteLine($"Pen is: {(penIsDown ? "down" : "up")}");
        Console.WriteLine($"Turtle's current direction: {GetCurrentDirectionArrow()}");
        Console.WriteLine($"Turtle's current position (x:y): {currentPositionX}:{currentPositionY}");
        Console.WriteLine("Current floor status:");

        for (int row = 0; row < floor.GetLength(0); ++row)
        {
            for (int column = 0; column < floor.GetLength(1); ++column)
            {
                if (floor[row, column] == 0)
                {
                    Console.Write("   ");
                }
                else
                {
                    Console.Write(" O ");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public void PerformAnAction(ConsoleKey keyPressed)
    {
        int distance = 0;

        switch (keyPressed)
        {
            case ConsoleKey.LeftArrow:
                TurnLeft();
                return;
            case ConsoleKey.UpArrow:
                Console.Write("Forward mode enabled. Enter the distance: ");
                int.TryParse(Console.ReadLine(), out distance);
                break;
            case ConsoleKey.RightArrow:
                TurnRight();
                return;
            case ConsoleKey.DownArrow:
                penIsDown = !penIsDown;
                floor[currentPositionX, currentPositionY] = 1;
                return;
            default:
                return;
        }

        switch (currentDirection)
        {
            case Directions.Down:
                MoveDown(distance);
                break;
            case Directions.LowerLeft:
                MoveLowerLeft(distance);
                break;
            case Directions.Left:
                MoveLeft(distance);
                break;
            case Directions.UpperLeft:
                MoveUpperLeft(distance);
                break;
            case Directions.Up:
                MoveUp(distance);
                break;
            case Directions.UpperRight:
                MoveUpperRight(distance);
                break;
            case Directions.Right:
                MoveRight(distance);
                break;
            case Directions.LowerRight:
                MoveLowerRight(distance);
                break;
            default:
                return;
        }
    }

    #endregion
}