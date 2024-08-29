using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Refactor_Caculator
{
    class CalculatorView
    {
        public void printString(string toPrintOut) // function to print out what is in the parameter
        {
            Console.WriteLine(toPrintOut); // prints out from the parameter
        }

        public double getDouble() // prompt the user to get a double value
        {
            string numInput; // variable used to get input from user, it is a string as that is what our input is

            Console.WriteLine("Write a number"); // tells user to write a number
            numInput = Console.ReadLine(); // stores the number in the variable, still as a string

            double cleanNum = 0; // variable to put our number in if it is a double

            while (!double.TryParse(numInput, out cleanNum)) // while loop to check if the input is a double or not
            {
                Console.Write("This is not valid input. Please enter a numeric value: "); // lets the user know that is not a number
                numInput = Console.ReadLine(); // reads the input and stores it in the variable
            }
            return cleanNum; // if number is really a number, return the number as a double
        }

        public string printOptions() // function to print out the options and get input from user
        {
            string op = ""; // variable to store user input
            while (op == "") // loop to see if string is empty
            {
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? "); // the five lines above tell the user what is a valid response
                op = Console.ReadLine(); // gets input and stores it in a variable

                if (op == null || !Regex.IsMatch(op, "[a|s|m|d]")) // checks if the input was null or is not one of the options
                {
                    Console.WriteLine("Error: Unrecognized input."); // tells the user that is not a valid input
                    op = ""; // sets the variable back to a string to restart the loop
                }
            }
            return op; // if string is good, return the string
        }

        public string printEndApp() // used to ask the reader if they want to end the app
        {
            Console.WriteLine("To end app, press n, to make another calculation, type literally anything else:");
            string temp = Console.ReadLine(); // gets input from user
            return temp; // returns the input 
        }
    }
}
