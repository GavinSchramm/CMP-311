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
        List<Student> studentList = new List<Student>(); // Creates an empty list to store the students

        while (!endApp)
        {
            Console.WriteLine("What would you like to do?"); // Asks the user what to do and gives a list
            Console.WriteLine("1. Add student: "); // Ditto
            Console.WriteLine("2. See student list: "); // Ditto
            Console.WriteLine("3. End app: "); // Ditto
            string userInput = Console.ReadLine(); // Stores the input as a string to see what the user should do
            Console.WriteLine(""); // For whitespace in the app

            if (userInput == "1") // 1 adds a student to a list
            {
                Student student = new Student(); // Creates a new student object with no information
                Console.Write("What is the student's first name? "); // Asks for the intructor first name
                student.FirstName = Console.ReadLine(); // Reads the input and sets it the instructor's first name
                Console.Write("What is the student's last name? "); // Asks for the intructor's first name
                student.LastName = Console.ReadLine(); // Reads the input and sets it the instructor's last name
                Console.Write("What is the student's year in school? "); // Asks for the intructor's contact info
                student.ClassRank = Console.ReadLine(); // Reads the input and sets it the instructor's contact info
                studentList.Add(student); // adds the student to the list, not working
                Console.WriteLine("Student added successully\n"); // Tells the user the list is added successfully
            }
            else if (userInput == "2") // 2 prints our list of students
            {
                foreach (var aStudent in studentList) // goes through the list by iteration
                {
                    Console.WriteLine(aStudent); // prints out the list 
                }
                Console.WriteLine("End of list.\n"); // lets the user know the end of list
            }
            else if (userInput == "3") // 3 ends the app and sends a farewell to the user
            {
                endApp = true; // sets boolean to true and ends the while loop
                Console.WriteLine("\nEnding App"); // tells the user the app is ending
                Console.WriteLine("Have a nice day!"); // app sends their user their kind reguards
            }
            else // Catches if input is not 1, 2, or 3
            {
                Console.WriteLine("\nUh oh, thats not an option silly"); // Lets the user know that is not an option
                Console.WriteLine("Try again pookie\n"); // asks user to try again :)
            }
        }
    }
}