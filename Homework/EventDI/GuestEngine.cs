using System;

namespace EventDI
{
    public class GuestEngine
    {
        private readonly IGuest eventType;
        public GuestEngine(IGuest eventT)
        {
            eventType = eventT;
        }
        public void AddGuest(string name)
        {
            eventType.AddGuest(name);
        }
        public string SeeGuestList()
        {
            return(eventType.SeeGuestList());
        }
    }
}