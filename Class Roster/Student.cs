using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Roster
{
    internal class Student : Person
    {
        // Properties for Student
        private string classRank;

        // Constructors for no parameters and three parameter
        public Student() : base()
        {
            classRank = "";
        }
        public Student(string FirstName, string LastName, string ClassRank) : base(FirstName, LastName)
        {
            classRank = ClassRank;
        }

        // Get and set methods
        public string ClassRank
        {
            get { return classRank; }
            set { classRank = value; }
        }

        // Method to overwrite the ToString method so it works with our class
        public override string ToString()
        {
            return "Student: " + this.FirstName + " " + this.LastName + " " + this.ClassRank;
        }
    }
}