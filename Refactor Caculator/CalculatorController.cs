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
            bool endApp = false;
            string endString = "";

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

                // Work on this
                endApp = CalcView.printEndApp();
            }
        }
    }
}
