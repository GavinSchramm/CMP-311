using System;

namespace EventDI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a wedding and test its functions
            Wedding bubba = new Wedding(1, "Summer of 23", 2000);
            CostEngine ce = new CostEngine(bubba);
            GuestEngine ge = new GuestEngine(bubba);
            
            // Add guests to the wedding
            ge.AddGuest("Keely");
            ge.AddGuest("Gavin");
            ge.AddGuest("Makena");

            Console.WriteLine(bubba.ToString());

            // See guest list
            Console.WriteLine(ge.SeeGuestList());

            // CalcCost function
            Console.Write("Wedding cost with discount is: $");
            Console.WriteLine(ce.CalcCost("d"));


            Console.WriteLine("\n"); //White space for the user


            // Create a birthday and test its functions
            Birthday zayla = new Birthday(1, "She turns 3", 50);
            ce = new CostEngine(zayla);
            ge = new GuestEngine(zayla);

            // Add guests to the birthday
            ge.AddGuest("Mom");
            ge.AddGuest("Dad");
            ge.AddGuest("Aunt");
            ge.AddGuest("Uncle");

            Console.WriteLine(zayla.ToString());

            // See guest list
            Console.WriteLine(ge.SeeGuestList());

            // CalcCost function
            Console.Write("Birthday cost with discount is: $");
            Console.WriteLine(ce.CalcCost("E"));

            Console.WriteLine("\n"); //White space for the user


            // Create a graduatio and test its functions
            Graduation nayla = new Graduation(1, "High School", 100);
            ce = new CostEngine(nayla);
            ge = new GuestEngine(nayla);

            // Add guests to the birthday
            ge.AddGuest("Mommy");
            ge.AddGuest("Daddy");
            ge.AddGuest("Auntie");
            ge.AddGuest("Uncle");

            Console.WriteLine(nayla.ToString());

            // See guest list
            Console.WriteLine(ge.SeeGuestList());

            // CalcCost function
            Console.Write("Grad cost with discount is: $");
            Console.WriteLine(ce.CalcCost("E"));
        }
    }
}
