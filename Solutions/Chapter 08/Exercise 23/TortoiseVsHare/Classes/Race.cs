// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 23 (08.28) Simulations: The Tortoise and the Hare.


using System;
// Threading itself will be covered in the later chapters of the textbook.
// For now we use it only to make some pauses between events, i.e. to wait for given number of milliseconds.
using System.Threading;

namespace TortoiseVsHare.Classes
{
    class Race
    {
        #region Constants

        private const int TrackLength = 70;
        // Number of milliseconds to wait between actions.
        private const int Interval = 1000;
        private const string TortoiseFullName = "Tortoise";
        private const string HareFullName = "Hare";
        private const char TortoiseShortName = 'T';
        private const char HareShortName = 'H';

        #endregion

        #region Private fields

        private static bool[] tortoiseTrack = new bool[TrackLength + 1];
        private static bool[] hareTrack = new bool[TrackLength + 1];
        private static int tortoiseCurrentPosition = 1;
        private static int hareCurrentPosition = 1;

        #endregion

        #region Private methods

        /// <summary>
        /// Makes a thread sleep for specified in the "Interval" number of milliseconds and clears a screen.
        /// </summary>
        private static void WaitAndClearScreen()
        {
            Thread.Sleep(Interval);
            Console.Clear();
        }

        /// <summary>
        /// Prints status of given track and displays a given runner's name.
        /// </summary>
        /// <param name="track">A track a pare participant runs at.</param>
        /// <param name="runnerShortName">One letter as a short name of a runner.</param>
        /// <param name="runnerFullName">Full name of a runner.</param>
        private static void PrintTrack()
        {
            for (int position = 1; position < TrackLength; ++position)
            {
                // If contenderes land on the same square and a tortoise bites a hare, print "ouch" above this square.
                if (position == tortoiseCurrentPosition
                    && position == hareCurrentPosition)
                {
                    Console.Write("OUCH!!!");
                    break;
                }
                else if (position == tortoiseCurrentPosition)
                {
                    Console.Write($"{TortoiseShortName}");
                }
                else if (position == hareCurrentPosition)
                {
                    Console.Write($"{HareShortName}");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Random number gererator. Returns a random number from 1 to 10.
        /// </summary>
        /// <returns>Returns a random number from 1 to 10.</returns>
        private static int RandomNumber()
        {
            return new Random().Next(1, 11);
        }

        /// <summary>
        /// Change a position of a runner on the given track for a given distance.
        /// </summary>
        /// <param name="track">Track of a runner.</param>
        /// <param name="distance">The distance to add to current runner's position (could be both positive or negative).</param>
        /// <param name="position">A position of a runner.</param>
        private static void MakeMove(bool[] track, int distance, ref int position)
        {
            // A runner leaves it's former position.
            track[position] = false;
            // Calculate runner's new position.
            position += distance;

            // Adjust position if it went out of the range.
            if (position < 1)
            {
                position = 1;
            }
            else if (position > TrackLength)
            {
                position = TrackLength;
            }

            // A runner arrives to a new position.
            track[position] = true;
        }

        /// <summary>
        /// Makes one move for both runners.
        /// </summary>
        private static void MakeOneMove()
        {
            // Calculate tortoise's move.
            int tortoiseMove = RandomNumber();

            if (tortoiseMove <= 5)
            {
                // Make a fast plod.
                MakeMove(tortoiseTrack, 3, ref tortoiseCurrentPosition);
            }
            else if (tortoiseMove <= 7)
            {
                // Make a slip.
                MakeMove(tortoiseTrack, -6, ref tortoiseCurrentPosition);
            }
            else
            {
                // Make a slow plod.
                MakeMove(tortoiseTrack, 1, ref tortoiseCurrentPosition);
            }

            // Calculate hare's move.
            int hareMove = RandomNumber();

            if (hareMove <= 2)
            {
                // Make a big hop.
                MakeMove(hareTrack, 9, ref hareCurrentPosition);
            }
            else if (hareMove <= 3)
            {
                // Make a big slip.
                MakeMove(hareTrack, -12, ref hareCurrentPosition);
            }
            else if (hareMove <= 6)
            {
                // Make a small hop.
                MakeMove(hareTrack, 1, ref hareCurrentPosition);
            }
            else if (hareMove <= 8)
            {
                // Make a small slip.
                MakeMove(hareTrack, -2, ref hareCurrentPosition);
            }
        }

        /// <summary>
        /// Prints names of runners.
        /// </summary>
        private static void PrintLegend()
        {
            Console.WriteLine("Legend:");
            Console.WriteLine($"{TortoiseShortName} - {TortoiseFullName}");
            Console.WriteLine($"{HareShortName} - {HareFullName}");
        }

        #endregion

        #region Public methods

        public static void Main()
        {
            Console.WriteLine("Wellcome to The Tortoise and the Hare race simulation app.");
            WaitAndClearScreen();
            Console.WriteLine("ON YOUR MARK, GET SET");
            WaitAndClearScreen();
            Console.WriteLine("BANG !!!!");
            WaitAndClearScreen();
            Console.WriteLine("AND THEY'RE OFF !!!!");
            WaitAndClearScreen();
            // Put both runners on a start position.
            tortoiseTrack[tortoiseCurrentPosition] = true;
            hareTrack[hareCurrentPosition] = true;

            // While no one wins.
            while (tortoiseTrack[TrackLength] != true
                && hareTrack[TrackLength] != true)
            {
                Console.WriteLine("Game is in the midst.");
                Console.WriteLine();
                PrintTrack();
                PrintLegend();
                MakeOneMove();

                // Wait and clear screen only when game is still in progress.
                if (tortoiseTrack[TrackLength] != true
                && hareTrack[TrackLength] != true)
                {
                    WaitAndClearScreen();
                }
            }

            Console.WriteLine();

            if (tortoiseCurrentPosition == TrackLength
                && hareCurrentPosition == TrackLength)
            {
                Console.WriteLine("It's a tie");
            }
            else if (tortoiseCurrentPosition == TrackLength)
            {
                Console.WriteLine("TORTOISE WINS!!! YAY!!!");
            }
            else
            {
                Console.WriteLine("Hare wins. Yuch.");
            }

            Console.WriteLine();
            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }

        #endregion
    }
}