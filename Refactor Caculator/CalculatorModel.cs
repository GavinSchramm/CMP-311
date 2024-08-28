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
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result;
        }
        public override string ToString()
        {
            return this.ToString();
        }
    }
}
