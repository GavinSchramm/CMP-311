using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventDI
{
    //Event info class
    public class EventInfo
    {
        // Properties
        private int id;
        private string desc;
        private double cost;

        //Constructors
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
}
