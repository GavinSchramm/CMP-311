using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDI
{
    public class Graduation : EventInfo, ICost, IGuest
    {
        //Fields
        List<string> guestList = new List<string>();
        //Constructor
        public Graduation(int Id, string Desc, double Cost) : base(Id, Desc, Cost)
        {
        }
        //Methods
        double ICost.CalcCost(string disCode) // Calculates the cost
        {
            double tempCost = Cost;
            if (disCode == "D" || disCode == "d")
            {
                tempCost = tempCost * .9;
                return tempCost;
            }
            else if (disCode == "L" || disCode == "l")
            {
                tempCost = tempCost * 1.1;
                return tempCost;
            }
            else if (disCode == "E" || disCode == "e")
            {
                tempCost = tempCost * .75;
                return tempCost;
            }
            else if (disCode == "F" || disCode == "f")
            {
                tempCost = tempCost * 0;
                return tempCost;
            }
            else
            {
                return tempCost;
            }
        }
        void IGuest.AddGuest(string name) // Adds a guest to the guest list
        {
            guestList.Add(name);
        }

        string IGuest.SeeGuestList() // returns a string of the guest list
        {
            string pntStr = "";
            Console.WriteLine("Graduation Guest List:");
            foreach (string name in guestList)
            {
                pntStr += name;
                pntStr += "\n";
            }
            return (pntStr);
        }
        public override string ToString()
        {
            return ("Graduation - ID: " + this.Id + ", Desc: " + this.Desc + ", Cost: " + this.Cost);
        }
    }
}
