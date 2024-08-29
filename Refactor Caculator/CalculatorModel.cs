using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Caculator
{
    class CalculatorModel
    {
        // fields
        private double num1;
        private double num2;
        private string ans;

        // constructor
        public double Number1
        {
            get { return num1; }
            set { num1 = value; }
        }

        public double Number2
        {
            get { return num2; }
            set { num2 = value; }
        }

        public string Answer
        {
            get { return ans; }
            set { ans = value; }
        }

        // functions
        public double DoOperation(double num1, double num2, string op) // function to do operation
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a": // addition
                    result = num1 + num2;
                    break;
                case "s": // substraction
                    result = num1 - num2;
                    break;
                case "m": // multiplication
                    result = num1 * num2;
                    break;
                case "d": // division
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0) // if second number is not 0, do caculation
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result; // returns the result
        }
        public override string ToString() // takes the feilds and lets us print it out
        {
            return this.ToString();
        }

        public bool endApp(string myString) // used to see if we want to flip true or false
        {
            if (myString == "n") // if input is string "n"
            {
                return true; // return true
            }
            else
            {
                return false; // if literally anything else, return false
            }
        }
    }
}
