using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventInterface;

public class Program
{
    static void Main(string[] args)
    {
        Event filler = new Event(); //should print id = -1, "No description", 0
        Event test = new Event(1, "Just a test", 5);
        CostEngine costEngine = new CostEngine();
        IWedding wedding = new Event(2, "Wedding", 10000);
        IBirthday birthday = new Event(3,"Birthday",10);
        IOther suprise = new Event(4, "Suprise", 19);

        Console.WriteLine(filler.ToString());
        Console.WriteLine(test.ToString());
        Console.WriteLine(wedding.ToString());
        Console.WriteLine(birthday.ToString());
        Console.WriteLine(suprise.ToString());

        Console.WriteLine("\nEnd of ToString()\n");
        
        wedding.PrintCost();
        birthday.PrintCost();
        suprise.PrintCost();
        
        Console.WriteLine("\nEnd of PrintCost()\n");
        
        suprise.PriceChange("l");
        suprise.PriceChange("D");
        suprise.PriceChange("Hello");

        Console.WriteLine("\nEnd of PriceChange()\n");

        costEngine.PriceChange("d", 10);
        costEngine.PriceChange("L", 10);
        costEngine.PriceChange("f", 10);
        costEngine.PriceChange("E", 10);
        costEngine.PriceChange("Hello", 10);
        //test above:program below
    }
}