using Class_Roster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Class_Roster
{
    internal class ClassModel
    {
        private List<Student> orderList = new List<Student>(); // our list to store our students
        private Instructor prof = new Instructor();

        public void InstructorInfo(string First, string Last, string Info)
        {
            prof.FirstName = First; // makes student's first name equal to parameter
            prof.LastName = Last; // makes student's last name equal to parameter
            prof.ContactInfo = Info; // makes student's class rank equal to parameter
        }

        public string ReturnInstructor()
        {
            return prof.ToString();
        }

        public void AddStudent(string First, string Last, string ClassRank)
        {
            Student student = new Student(); // creates a new student object
            student.FirstName = First; // makes student's first name equal to parameter
            student.LastName = Last; // makes student's last name equal to parameter
            student.ClassRank = ClassRank; // makes student's class rank equal to parameter
            orderList.Add(student); // adds the student to the list
        }

        public List<Student> SortList(string sort,List<Student> list)
        {
            if (sort == "Order")
            {
                return list; // returns the list un sorted
            }
            else if (sort == "Last")
            {
                list = list.OrderBy(o => o.LastName).ToList(); // sorts the list by last name
                return list;
            }
            else if (sort == "Rank")
            {
                list = list.OrderBy(o => o.ClassRank).ToList(); // sorts the list by class rank
                return list; // returns the list
            }
            else
            {
                return list; // if something messes up, it will return the base list
            }
        }

        public List<Student> ReturnList()
        {
            return orderList;
        }
    }
}
