using System;

namespace AssignmentDay3.Clock
{
    public class DisplayService
    {
        public void OnClockTicked(object source, ClockEventArgs args)
        {
            Console.WriteLine(args.Now.ToString("HH:mm:ss"));
        }
    }
}