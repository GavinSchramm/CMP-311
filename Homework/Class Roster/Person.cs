using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Class_Roster // Namespace to connect all the files together
{
    public class Person // Parent class to hold our info about people
    {
        // Properties for people
        private string firstName;
        private string lastName;

        // Constructors for no parameters and two parameters
        public Person()
        {
            firstName = "";
            lastName = "";
        }
        public Person(string FirstName, string LastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }

        // The get and set methods or two of our four CRUD opperations, create and read
        public string FirstName 
        { 
            get { return firstName; }
            set { firstName = value; } 
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        // Method to overwrite the ToString method so it works with our class
        public override string ToString() 
        {
            return "Person: " + FirstName + " " + LastName;
        }
    }
}