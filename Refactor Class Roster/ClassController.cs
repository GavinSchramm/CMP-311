using Class_Roster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Class_Roster
{
    class ClassController
    {
        public ClassController()
        {
            ClassView classView = new ClassView();
            ClassModel classModel = new ClassModel();

            classView.PrintString("Welcome to the Class Roster App");
            classView.PrintString("");

            classView.PrintString("What is teacher first name?");
            string firstName = classView.GetInput();
            classView.PrintString("What is teacher last name?");
            string lastName = classView.GetInput();
            classView.PrintString("What is teacher contact info?");
            string personInfo = classView.GetInput();
            classModel.InstructorInfo(firstName, lastName, personInfo);


            bool endApp = false; // bool var to know when to end app

            while (!endApp) // while not false, or while don't end app
            {
                classView.PrintString(""); // White space for user
                classView.PrintString("What would you like to do?"); // Asks the user what to do and gives a list
                classView.PrintString("1. Add student: "); // Tells the user what option 1 does
                classView.PrintString("2. See student list sorted by order: "); // Tells the user what option 2 does
                classView.PrintString("3. See student list sorted by last name: "); // Tells the user what option 2 does
                classView.PrintString("4. See student list sorted by class rank: "); // Tells the user what option 2 does
                classView.PrintString("5. End app: "); // Tells the user what option 3 does
                classView.PrintString("");
                string userInput = classView.GetInput(); // Stores the input as a string to see what the user should do

                if (userInput == "1")
                {
                    classView.PrintString(""); // White space for user
                    classView.PrintString("Student First Name: "); // asks for first name
                    firstName = classView.GetInput(); // Stores the input as first name

                    classView.PrintString("Student Last Name: "); // asks for last name
                    lastName = classView.GetInput(); // stores it as last name

                    while (lastName == "") // check if the last name is an empty string
                    {
                        classView.PrintString("Please input valid last name: "); // if is empty, tell them that not allowed
                        lastName = classView.GetInput(); // ask for another input
                    }

                    classView.PrintString("Student Class Rank: "); // asks for class rank
                    personInfo = classView.GetInput(); // Stores it as last name
                    
                    while (personInfo == "") // check if class rank is empty string
                    {
                        classView.PrintString("Please input valid class rank: "); // if empty, tell user that
                        personInfo = classView.GetInput(); // ask for another input
                    }

                    classModel.AddStudent(firstName, lastName, personInfo); // adds the student to the list

                }
                else if (userInput == "2")
                {
                    classView.PrintString(classModel.ReturnInstructor());
                    classView.PrintList(classModel.SortList("Order",classModel.ReturnList())); // prints list by order
                }
                else if (userInput == "3")
                {
                    classView.PrintString(classModel.ReturnInstructor());
                    classView.PrintList(classModel.SortList("Last", classModel.ReturnList())); // prints list by last name
                }
                else if (userInput == "4")
                {
                    classView.PrintString(classModel.ReturnInstructor());
                    classView.PrintList(classModel.SortList("Rank", classModel.ReturnList())); // prints list by class rank
                }
                else if (userInput == "5")
                {
                    classView.PrintString("Like NSYNC, Bye Bye Bye"); // bids farewell to user
                    endApp = true; // makes end app true
                }
                else // final check if user puts something other than valid option
                {
                    classView.PrintString("Womp Womp, not a valid option"); // womp womp
                }
            }
        }
    }
}
