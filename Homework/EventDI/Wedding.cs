using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EventDI
{
    public class Wedding : EventInfo, ICost, IGuest
    {
        //Fields
        List<string> guestList = new List<string>();
        //Constructor
        public Wedding(int Id, string Desc, double Cost) : base(Id, Desc, Cost)
        {
        }
        //Methods
        double ICost.CalcCost(string disCode) // Calculates the cost
        {
            double tempCost = Cost;
            if (disCode == "D" || disCode == "d")
            {
                tempCost = tempCost * .85;
                return tempCost;
            }
            else if (disCode == "L" || disCode == "l")
            {
                tempCost = tempCost * 1.35;
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
            Console.WriteLine("Wedding Guest List:");
            foreach (string name in guestList)
            {
                pntStr += name;
                pntStr += "\n";
            }
            return (pntStr);
        }
        public override string ToString()
        {
            return ("Wedding - ID: " + this.Id + ", Desc: " + this.Desc + ", Cost: " + this.Cost);
        }
    }
}