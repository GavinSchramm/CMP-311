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

        public List<Music> SortList(string sort, List<Music> list)
        {
            if (sort == "Order")
            {
                return list; // returns the list un sorted
            }
            else if (sort == "Title")
            {
                list = list.OrderBy(o => o.Title).ToList(); // sorts the list by last name
                return list;
            }
            else if (sort == "Artist")
            {
                list = list.OrderBy(o => o.Artist).ToList(); // sorts the list by class rank
                return list; // returns the list
            }
            else
            {
                return list; // if something messes up, it will return the base list
            }
        }

        public void AddPop(string Title, string Artist, string Year)
        {
            Pop popSong = new Pop(Title, Artist, Year);
            musicList.Add(popSong);
        }

        public void AddMusical(string Title, string Artist, string Orgin)
        {
            Musical musicalSong = new Musical(Title, Artist, Orgin);
            musicList.Add(musicalSong);
        }
    }
}
