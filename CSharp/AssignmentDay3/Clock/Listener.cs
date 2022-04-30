using System;

namespace AssignmentDay3.Clock
{
    public class Listener
    {
        public void Subscribe(Clock clock)
        {
            clock.Tick += new Clock.TickHandler(DisplayTime);
        }
        private void DisplayTime(Clock clock, ClockTime clockTime)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}