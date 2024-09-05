using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Hw
{
    internal class Musical : Music
    {
        // field
        private string orgin;

        // constructors
        public Musical() : base()
        {
            orgin = "";
        }

        public Musical(string Title, string Artist, string Orgin) : base(Title, Artist)
        {
            orgin = Orgin;
        }

        // get and set functions
        public string Orgin
        {
            get { return orgin; }
            set { orgin = value; }
        }

        // methods
        public override string ToString()
        {
            return Title + " by " + Artist + " from the musical: " + Orgin;
        }
    }
}
