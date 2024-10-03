using System;
using System.Collections.Generic;
using System.Text;

namespace EventDI
{
    public interface IGuest
    {
        void AddGuest(string invite);
        string SeeGuestList();
    }
}
