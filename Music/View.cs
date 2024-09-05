using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Hw
{
    internal class View
    {
        // no fields
        // no constructor

        // methods
        public void PrintLine(string myString)
        {
            Console.WriteLine(myString);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
