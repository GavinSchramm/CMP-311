using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Hw
{
    internal class Controller
    {
        public Controller()
        {
            Model model = new Model();
            View view = new View();

            Console.WriteLine("Hello World!");

            List<Music> list = new List<Music>();
            Pop test = new Pop("Holding Onto You", "Twenty One Pilots", "2012");
            Musical filler = new Musical("Greased Lighting", "Grease Sound Track", "Grease");
            list.Add(test);
            list.Add(filler);

            foreach (Music music in list)
            {
                Console.WriteLine(music);
            }
            Console.WriteLine("Test Over\n");
        }
    }
}
