using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Caculator
{
    class CalculatorController
    {
        public CalculatorController()
        {
            bool endApp = false; // flag to see if we want to end the app

            while (!endApp)
            {
                CalculatorView CalcView = new CalculatorView(); // Creates our view class
                CalculatorModel CalcModel = new CalculatorModel(); // creates our model class

                CalcView.printString("Welcome to Caculator app"); // welcomes the user to the app

                CalcView.printString("\nNumber 1: "); // Tells the user this is the first number
                CalcModel.Number1 = CalcView.getDouble(); // gets double from the user and stores it as num1 in CalcModel

                CalcView.printString("\nNumber 2: "); // Tells the user this is the second number
                CalcModel.Number2 = CalcView.getDouble(); // gets double from the user and stores it as num2 in CalcModel

                CalcModel.Answer = CalcView.printOptions(); // Tells the user the options they can choose from

                CalcView.printString("Your answer is: ");
                CalcView.printString(CalcModel.DoOperation(CalcModel.Number1, CalcModel.Number2, CalcModel.Answer).ToString());
                // tells the user what their answer is with the DoOperation function

                endApp = CalcModel.endApp(CalcView.printEndApp()); // prompts the user if they want to end the app or contuine
                // working on the app and depending on the response will change the endApp flag true to close out of the app
            }
        }
    }
}
