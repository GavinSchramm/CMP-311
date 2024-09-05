using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Hw
{
    internal class Pop : Music
    {
        // field
        private string year;

        // constructors
        public Pop() : base()
        {
            year = "";
        }

        public Pop(string Title, string Artist, string Year): base(Title, Artist)
        {
            year = Year;
        }

        // get and set functions
        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        // method
        public override string ToString()
        {
            return Title + " by " + Artist + " released in " + Year;
        }
    }
}
