using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Hw
{
    internal class Model
    {
        // field
        private List<Music> musicList = new List<Music>();

        // methods
        public List<Music> ReturnList () // used to return our music list
        {
            return musicList;
        }
    }
}
