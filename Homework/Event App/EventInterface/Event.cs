using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventInterface
{
    //Interfaces
    public interface IWedding
    {
        void PrintCost();
    }
    public interface IBirthday
    {
        void PrintCost();
    }
    public interface IOther
    {
        void PrintCost();
        double PriceChange(string letter);
    }

    //Event info class
    internal class EventInfo
    {
        // Properties
        private int id;
        private string desc;
        private double cost;

        //Constructors
        public EventInfo()
        {
            id = -1;
            desc = "No description written";
            cost = 0.00;
        }

        public EventInfo(int Id, string Desc, double Cost)
        {
            id = Id;
            desc = Desc;
            cost = Cost;
        }

        // Get/Set methods
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        //Methods
        public override string ToString()
        {
            return "Event Id: " + Id + "\nEvent Description: " + Desc + "\nEvent Cost: $" + Cost;
        }
    }

    // Event class that uses eventInfo
    public class Event : IWedding, IBirthday, IOther
    {
        //Properties
        private EventInfo eventInfo;

        //Constructor
        public Event()
        {
            eventInfo = new EventInfo();
        }
        public Event(int Id, string Desc, double Cost)
        {
            eventInfo = new EventInfo(Id, Desc, Cost);
        }

        //Methods
        void IWedding.PrintCost()
        {
            Console.WriteLine("Wedding cost is: $" + eventInfo.Cost);
        }
        void IBirthday.PrintCost()
        {
            Console.WriteLine("Birthday cost is: $" + eventInfo.Cost);
        }
        void IOther.PrintCost()
        {
            Console.WriteLine("Other event cost is: $" + eventInfo.Cost);
        }
        double IOther.PriceChange(string letter)
        {
            if (letter =="D" || letter == "d")
            {
                eventInfo.Cost = eventInfo.Cost * .9;
                Console.WriteLine("Discount price is: $" + eventInfo.Cost);
                return eventInfo.Cost;
            } 
            else if (letter == "L" || letter  == "l")
            {
                eventInfo.Cost = eventInfo.Cost * 1.1;
                Console.WriteLine("Late price is: $" + eventInfo.Cost);
                return eventInfo.Cost;
            }
            else if (letter == "E" || letter == "e")
            {
                eventInfo.Cost = eventInfo.Cost * .75;
                Console.WriteLine("Late price is: $" + eventInfo.Cost);
                return eventInfo.Cost;
            }
            else if (letter == "F" || letter == "f")
            {
                eventInfo.Cost = eventInfo.Cost * 0;
                Console.WriteLine("Late price is: $" + eventInfo.Cost);
                return eventInfo.Cost;
            }
            else
            {
                Console.WriteLine("No price change. Your price is: $" + eventInfo.Cost);
                return eventInfo.Cost;
            }
        }

        public override string ToString()
        {
            return "Event Id: " + eventInfo.Id + "\nEvent Description: " + eventInfo.Desc + "\nEvent Cost: $" + eventInfo.Cost;
        }
    }
}
