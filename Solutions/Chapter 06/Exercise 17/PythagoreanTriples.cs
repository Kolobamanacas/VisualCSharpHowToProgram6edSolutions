// Solution to exercises from "C# How to Program 6th edition".
// Chapter 6.
// Exercise 17 (06.21) Pythagorean Triples.

using System;

class PythagoreanTriples
{
    static void Main()
    {
        // A variable to store number of triples we would found.
        int numberOfTriple = 1;

        /* We need to check the pythagorean theorem for all combinations of "side1", "side2" and "hypotenuse" where every side could be an integer from 1 to 500. This could be done by creating a loop for "side1" that counts from 1 to 500, putting similar loop for "side2" inside the body of this loop and putting the similar loop for "hypotenuse" inside the body of "side2's" loop. The only thing is need to be changed is the number of values we check for "side2". For example, the triples 3, 4, 5 and 4, 3, 5 are the same ones, so we shouldn't count these combinations two times insead of one. To avoid these duplicates, we count "side2's" loop not till 500 but till the current value of "side1". This is also possible because there is no right triangle with "side1" == "side2" and all sides are integers. */
        for (int side1 = 1; side1 <= 500; ++side1)
        {
            for (int side2 = 1; side2 <= side1; ++side2)
            {
                for (int hypotenuse = 1; hypotenuse <= 500; ++hypotenuse)
                {
                    if ((hypotenuse * hypotenuse) == ((side1 * side1) + (side2 * side2)))
                    {
                        /* For every triple we found, print the number of triple and values of "side1", "side2" and "hypotenuse". Again I cast the value of "numberOfTriple" to string type using a ".ToString()" method with spercial parameter "D3". The "D" part of the parameter means that converted value is a digit and "3" means that if a number contains less than 3 digits, then appropriate number of zeros is added to the left of the number to be exactly 3 digits length. */
                        Console.WriteLine($"Triple #{(numberOfTriple).ToString("D3")}: {side1}, {side2}, {hypotenuse}");
                        ++numberOfTriple;
                    }
                }
            }
        }
    }
}