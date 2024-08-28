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
        public void printString(string toPrintOut)
        {
            Console.WriteLine(toPrintOut);
        }

        public double getDouble()
        {
            string numInput;

            Console.WriteLine("Write a number");
            numInput = Console.ReadLine();

            double cleanNum = 0;
            while (!double.TryParse(numInput, out cleanNum))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput = Console.ReadLine();
            }
            return cleanNum;
        }

        public string printOptions()
        {
            string op = "";
            while (op == "")
            {
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");
                op = Console.ReadLine();
                if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
                {
                    Console.WriteLine("Error: Unrecognized input.");
                    op = "";
                }
            }
            return op;
        }

        public bool printEndApp() // Work on this
        {
            Console.WriteLine("To end app, press n, to make another calculation, type literally anything else:");
            string temp = Console.ReadLine();
            if (temp == "n")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
