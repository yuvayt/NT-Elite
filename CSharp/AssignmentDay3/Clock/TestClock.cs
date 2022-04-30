using System;

namespace AssignmentDay3.Clock
{
    public class TestClock
    {
        public static void Run()
        {
            Clock clock = new Clock();
            Listener listener = new Listener();
            listener.Subscribe(clock);
            Console.WriteLine("Press any key to exit Clock");
            clock.Start();
        }
    }
}