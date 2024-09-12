using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Hw
{
    internal class Music
    {
        // field
        private string title;
        private string artist;

        // constructors
        public Music()
        {
            title = "";
            artist = "";
        }

        public Music(string Title, string Artist)
        {
            title = Title;
            artist = Artist;
        }

        // get and set functions
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        // methods
        public override string ToString()
        {
            return Title + " by " + Artist;
        }
    }
}
