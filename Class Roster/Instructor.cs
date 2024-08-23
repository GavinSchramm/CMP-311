using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Roster
{
    internal class Instructor : Person
    {
        // Properties for Instructor
        private string contactInfo;

        // Constructors for no parameters and three parameter
        public Instructor(): base()
        {
            contactInfo = "";
        }
        public Instructor(string FirstName, string LastName, string ContactInfo): base(FirstName, LastName) 
        {
            contactInfo = ContactInfo;
        }

        // Get and set methods
        public string ContactInfo
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }

        // Method to overwrite the ToString method so it works with our class
        public override string ToString()
        {
            return "Instructor: " + this.FirstName + " " + this.LastName + " " + this.ContactInfo;
        }
    }
}