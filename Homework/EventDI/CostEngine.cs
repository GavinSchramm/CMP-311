using System;

namespace EventDI
{
    public class CostEngine
    {
        private readonly ICost eventType;
        public CostEngine(ICost eventT)
        {
            eventType = eventT;
        }
        public double CalcCost(string discount)
        {
            return(eventType.CalcCost(discount));
        }
    }
}