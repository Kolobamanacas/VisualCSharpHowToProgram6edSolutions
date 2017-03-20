// Solution to exercises from "C# How to Program 6th edition".
// Chapter 5.
// Exercise Making-a-Difference Exercise 02 (05.42) Enforcing Privicy with Cryptography.

using System;

class EnforcingPrivicyWithCryptography
{
    static void Main()
    {
        /* Ok, instead of making two programs let's make one program which would be able to encrypt and decrypt a four digit number.
        
        The first part (an encryption) was easy enough, but the reverse process is much more tricky. I spent a couple of minutes before giving up and googled for the solution. The problem was to find the reverse operation of division remainder. We basically have ten options. When a number equals to any digit from 0 to 2, a result equals to number + 7. In the rest cases (when initial number equals to from 3 to 9) a result equals to number + 3. This works only in a case when a number contains only one digit and when divider is 10. Of course we could use IF condition statement to check wether a result belongs to any of mentioned sets, but user named NPE suggest a much more convinient solution.
        http://stackoverflow.com/questions/25773702/reverse-of-getting-a-remainder
        It turns out that number + 7 % 10 equals to result + 3 % 10. It is difficult to understand at the first glance, but you could check all ten cases to get the idea and to make sure it works correctrly. */
        
        // Welcome message.
        Console.WriteLine("Four-digits encryptor/decryptor.");
        Console.WriteLine();
        // Main menu. User choose wether he/she wants to encrypt or decrypt number by entering 1 or 2 correspondingly.
        Console.Write("Please enter 1 if you want to encrypt number or 2 if you want to decrypt it. Enter any other number to exit: ");

        int action = int.Parse(Console.ReadLine());

        if (action == 1)
        {
            Console.Write("Please enter four-digits number to encrypt: ");
            int numberToEncrypt = int.Parse(Console.ReadLine());
            
            // Write every digit to it's own variable.
            int firstDigit = numberToEncrypt / 1000;
            int secondDigit = (numberToEncrypt % 1000) / 100;
            int thirdDigit = (numberToEncrypt % 100) / 10;
            int fourthDigit = numberToEncrypt % 10;

            // Replace every digit with the remainder after dividing of sum of the digit and 7 by 10.
            firstDigit = (firstDigit + 7) % 10;
            secondDigit = (secondDigit + 7) % 10;
            thirdDigit = (thirdDigit + 7) % 10;
            fourthDigit = (fourthDigit + 7) % 10;

            // Swap the first digit with the third and the second digit with the fourth.
            int tempDigit = firstDigit;
            firstDigit = thirdDigit;
            thirdDigit = tempDigit;
            tempDigit = secondDigit;
            secondDigit = fourthDigit;
            fourthDigit = tempDigit;

            int encryptedNumber = (firstDigit * 1000) + (secondDigit * 100) + (thirdDigit * 10) + (fourthDigit);

            Console.WriteLine($"The encrypted number is: {encryptedNumber:D4}");

        }
        else if (action == 2)
        {
            Console.Write("Please enter four-digits number to decrypt: ");
            int numberToDecrypt = int.Parse(Console.ReadLine());

            // Write every digit to it's own variable.
            int firstDigit = numberToDecrypt / 1000;
            int secondDigit = (numberToDecrypt % 1000) / 100;
            int thirdDigit = (numberToDecrypt % 100) / 10;
            int fourthDigit = numberToDecrypt % 10;

            // Swap back the second digit with the fourth and the first digit with the third.
            int tempDigit = secondDigit;
            secondDigit = fourthDigit;
            fourthDigit = tempDigit;
            tempDigit = firstDigit;
            firstDigit = thirdDigit;
            thirdDigit = tempDigit;

            // Replace every digit with the remainder after dividing of sum of the digit and 3 by 10.
            firstDigit = (firstDigit + 3) % 10;
            secondDigit = (secondDigit + 3) % 10;
            thirdDigit = (thirdDigit + 3) % 10;
            fourthDigit = (fourthDigit + 3) % 10;
            
            int decryptedNumber = (firstDigit * 1000) + (secondDigit * 100) + (thirdDigit * 10) + (fourthDigit);

            Console.WriteLine($"The decrypted number is: {decryptedNumber:D4}");
        }
    }
}