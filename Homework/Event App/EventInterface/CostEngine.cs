using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventInterface
{
    public class CostEngine
    {
        public double PriceChange(string letter, double Cost)
        {
            if (letter == "D" || letter == "d")
            {
                Cost = Cost * .9;
                Console.WriteLine("Discount price is: $" + Cost);
                return Cost;
            }
            else if (letter == "L" || letter == "l")
            {
                Cost = Cost * 1.1;
                Console.WriteLine("Late price is: $" + Cost);
                return Cost;
            }
            else if (letter == "E" || letter == "e")
            {
                Cost = Cost * .75;
                Console.WriteLine("Employee price is: $" + Cost);
                return Cost;
            }
            else if (letter == "F" || letter == "f")
            {
                Cost = Cost * 0;
                Console.WriteLine("Free! price is: $" + Cost);
                return Cost;
            }
            else
            {
                Console.WriteLine("No price change. Your price is: $" + Cost);
                return Cost;
            }
        }
    }
}
