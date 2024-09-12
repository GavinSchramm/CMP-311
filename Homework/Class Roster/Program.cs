// Class Roster Program
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Class_Roster;

class Program
{
    static void Main(string[] args)
    {
        Instructor professor = new Instructor(); // Creates a new intructor object with no information
        Console.WriteLine("Welcome to Class Roster Program"); // Welcomes the user to the app
        Console.Write("What is the intructor's first name? "); // Asks for the intructor first name
        professor.FirstName = Console.ReadLine(); // Reads the input and sets it the instructor's first name
        Console.Write("What is the intructor's last name? "); // Asks for the intructor's first name
        professor.LastName = Console.ReadLine(); // Reads the input and sets it the instructor's last name
        Console.Write("What is the instructor's contact info? "); // Asks for the intructor's contact info
        professor.ContactInfo = Console.ReadLine(); // Reads the input and sets it the instructor's contact info
        Console.WriteLine(""); // For whitespace in the app

        bool endApp = false; // Used to keep asking what the user should do
        List<Student> orderList = new List<Student>(); // Creates an empty list to store the students
        List<Student> lastNameList = new List<Student>(); // Creates an empty list to store the students
        List<Student> classRankList = new List<Student>(); // Creates an empty list to store the students


        while (!endApp)
        {
            Console.WriteLine("What would you like to do?"); // Asks the user what to do and gives a list
            Console.WriteLine("1. Add student: "); // Tells the user what option 1 does
            Console.WriteLine("2. See student list sorted by order: "); // Tells the user what option 2 does
            Console.WriteLine("3. See student list sorted by last name: "); // Tells the user what option 2 does
            Console.WriteLine("4. See student list sorted by class rank: "); // Tells the user what option 2 does
            Console.WriteLine("5. End app: "); // Tells the user what option 3 does
            string userInput = Console.ReadLine(); // Stores the input as a string to see what the user should do
            Console.WriteLine(""); // For whitespace in the app

            if (userInput == "1") // 1 adds a student to a list
            {
                Student student = new Student(); // Creates a new student object with no information

                Console.Write("What is the student's first name? "); // Asks for the intructor first name
                student.FirstName = Console.ReadLine(); // Reads the input and sets it the instructor's first name

                Console.Write("What is the student's last name? "); // Asks for the intructor's first name
                userInput = Console.ReadLine(); // gets the input as a variable
                while (userInput == "") // if the variable is an empty string
                {
                    Console.Write("Please input valid last name: "); // tell user to put something valid
                    userInput = Console.ReadLine(); // ask for another input
                }
                student.LastName = userInput; // takes the userInput variable and sets it the instructor's last name

                Console.Write("What is the student's year in school? "); // Asks for the intructor's contact info
                userInput = Console.ReadLine(); // gets the input as a variable
                while (userInput == "") // if the variable is an empty string
                {
                    Console.Write("Please input valid class rank: "); // tell user to put something valid
                    userInput = Console.ReadLine(); // ask for another input
                }
                student.ClassRank = userInput; // Reads the input and sets it the student's class rank

                orderList.Add(student); // adds the student to the orderList
                Console.WriteLine("Student added successully\n"); // Tells the user the list is added successfully
            }
            else if (userInput == "2") // 2 prints our list of students
            {
                Console.WriteLine(professor); // Prints instructor's information
                foreach (var aStudent in orderList) // goes through the orderList
                {
                    Console.WriteLine(aStudent); // prints out the list 
                }
                Console.WriteLine("End of list.\n"); // lets the user know the end of list
            }
            else if (userInput == "3") // 3 prints our list of students by last name
            {
                lastNameList = orderList.OrderBy(o => o.LastName).ToList(); // updates lastNameList by taking the
                // orderList list and orders it by each item in the list by lastName then puts it all back into a list

                Console.WriteLine(professor); // Prints instructor's information
                foreach (var aStudent in lastNameList) // goes through the lastNameList
                {
                    Console.WriteLine(aStudent); // prints out the student info
                }
                Console.WriteLine("End of list.\n"); // lets the user know the end of list
            }
            else if (userInput == "4") // 4 prints our list of students by class rank
            {
                classRankList = orderList.OrderBy(o => o.ClassRank).ToList(); // updates classRankList by taking the
                // orderList list and orders it by each item in the list by class rank then puts it all back into a list

                Console.WriteLine(professor); // Prints instructor's information
                foreach (var aStudent in classRankList) // goes through the classRankList
                {
                    Console.WriteLine(aStudent); // prints out the student info
                }
                Console.WriteLine("End of list.\n"); // lets the user know the end of list
            }
            else if (userInput == "5") // 5 ends the app and sends a farewell to the user
            {
                endApp = true; // sets boolean to true and ends the while loop
                Console.WriteLine("\nEnding App"); // tells the user the app is ending
                Console.WriteLine("Have a nice day!"); // app sends their user their kind reguards
            }
            else // Catches if input is not 1, 2, 3, 4, or 5
            {
                Console.WriteLine("\nUh oh, thats not an option silly"); // Lets the user know that is not an option
                Console.WriteLine("Try again pookie\n"); // asks user to try again :)
            }
        }
    }
}