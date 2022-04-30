using System;

namespace AssignmentDay3.Clock
{
    public class Clock
    {
        public event TickHandler Tick;
        public delegate void TickHandler(Clock clock, ClockTime clockTime);
        public event Action onTimeChange = delegate { };
        public void Start()
        {
            while (!Console.KeyAvailable)
            {
                System.Threading.Thread.Sleep(1000);
                if (Tick != null)
                {
                    ClockTime clockTime = new ClockTime();
                    clockTime.Now = DateTime.Now;
                    Tick(this, clockTime);
                }
            }
        }
    }
}
