using System;
using System.IO;

class Program
{
    static void Main()
    {
        int totalNumber = 0; // creates the variable to store the result
        string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" }; // array of numbers to check for
        string file = @"D:\Code Stuffs\Advent of Code\Day 1\numbersText.txt"; // location of the file with the puzzle

        using (StreamReader read = new StreamReader(file)) // reads the file
        {
            string line;
            while ((line = read.ReadLine()) != null) // loops through each line in the file
            {
                string digit = ""; // declares the digit variable to combine the two numbers in each line
                string lineReversed = ""; // declares lineReversed outside the loop

                foreach (char c in line) // loops through each character in the line
                {
                    if (Array.Exists(numbers, digit => digit == c.ToString())) // checks if the character is contained in the numbers array
                    {
                        Console.WriteLine("Found a digit: " + c); // if a number is found it will declare it 
                        digit = digit + c; // adds the declared variable to the digit string
                        char[] charArray = line.ToCharArray(); // turns the line into an array so it can be reversed
                        Array.Reverse(charArray); // reverses the string
                        lineReversed = new string(charArray); // stores the reversed string in a variable called lineReversed
                        Console.WriteLine(lineReversed);
                        break; // exits the loop so if there are more than 2 digits it won't count all of them
                    }
                }

                foreach (char c in lineReversed) // loops through each character in the reversed line
                {
                    if (Array.Exists(numbers, digit => digit == c.ToString())) // checks if the character is contained in the numbers array
                    {
                        Console.WriteLine("Found a digit: " + c);
                        digit = digit + c;
                        break; // exits the loop so if there are more than 2 digits it won't count all of them
                    }
                }

                totalNumber = totalNumber + Convert.ToInt32(digit);
            }
            Console.WriteLine($"The answer is {totalNumber}");
        }
    }
}



