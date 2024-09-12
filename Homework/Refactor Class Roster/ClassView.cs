using Class_Roster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Class_Roster
{
    internal class ClassView
    {
        public void PrintString(string myString) // to let the controller write outloud
        {
            Console.WriteLine(myString);
        }

        public string GetInput() // to get input from the user
        {
            return (Console.ReadLine());
        }
    }
}
