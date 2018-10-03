// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 16 (08.21) Turtle Graphics.

/* I hope that you've completed all previous exercises by yourself and have rough understanding of covered topics
 * cause here we using some stuff didn't mention in the book yet, simply to make the app more interesting.
 * I would also omit comments for simple parts hoping that you have idea what's going on. Again if no, you could
 * contact me and I would be glad to help.
 
 * So in the first place I've changed the demands to the app, cause pressing numbers for actions and confirming them with Enter if boring.
 * C#'s Console class has a method "ReadKey(), which reads not a whole string of chracters or a single character,
 * but a button you press itself. You could use boolean value as a parameter to specify whether to print pressed button or not
 * (true - don't print). "ReadKey()" by default returns an object of class "ConsoleKeyInfo", which represents combinations of pressed keys
 * To get single key, we need to use property "Key" right after the method, which would return an element of enumeration "ConsoleKey".
 * "ConsoleKey" contains most of standard keyboard's keys. You could find a list of them here:
 * https://msdn.microsoft.com/en-us/library/system.consolekey(v=vs.110).aspx
 * This helps us to use navigation arrows (left and right) to change turtle's direction, user "up" arrow to move forward and "down"
 * button to change pen's position from up to down and vice versa. "ESC" I believe is the most appropriate button for exit command.
 * 
 * As it requested in the exercise I've added more functionality - the possibilty to go diagonally.
 * 
 * Class "Console" also has method "Clear()", which clears the console window from all previous characters.
 * Using it the while loop reprints all the info and the array every time an action is made, giving us a real time feeling.
 * 
 * I also wanted to make "up" button to simple move turtle one step forward, instead of specifying number of steps,
 * but it was easier to implemnt, so I decide to practice a bit.
 * 
 * A few words about unicode. The unicode standard and more precisely UTF-8 is developed as a common encoding for all possible characters
 * for all possible languages in the world. It also include arrow character like ↓, ←, ↑, →, ↖, ↗, ↘ and ↙. Unfortunately the default fonts
 * of Windows Console like "Consolas" or "Lucida Console" have no glyphs for the last 4 symbols thus for the compatibility
 * I used only first 4.
 * The command "Console.OutputEncoding = System.Text.Encoding.UTF8" changes console's encoding to UTF-8.
 * 
 * You can read more about unicode here:
 * https://www.w3.org/International/questions/qa-what-is-encoding
 * https://en.wikipedia.org/wiki/Character_encoding
 * https://msdn.microsoft.com/en-us/library/ms404377(v=vs.110).aspx
 */

using System;

class TurtleGraphics
{
    public static void Main()
    {
        // Change console's output encoding to UTF-8.
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Create an object of class Turtle and call it "donatello". Why not? He is a programmer too.
        Turtle donatello = new Turtle();
        // Create an object of class ConsoleKey and assign it to any key we don't use in the app (Space Bar).
        ConsoleKey keyPressed = ConsoleKey.Spacebar;

        // While user don't press "ESC" button.
        while (keyPressed != ConsoleKey.Escape)
        {
            // Clear Console window from any previous characters.
            Console.Clear();
            // Call donatello's "DisplayCommands()" method, which prints a hint for a user with all possible commands.
            donatello.DisplayCommands();
            // Call donatello's "PrintAnArray()" method to print two-dimentional array.
            donatello.PrintAnArray();
            // Read a key pressed by a user and assign it to "keyPressed" local variable.
            keyPressed = Console.ReadKey(true).Key;
            // Call donatello's "PerformAnAction()" method, which perform different actions (if do) depending on key pressed.
            donatello.PerformAnAction(keyPressed);
        }
    }
}
