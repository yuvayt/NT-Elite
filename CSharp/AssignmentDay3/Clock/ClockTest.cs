using System;

namespace AssignmentDay3.Clock
{
    public class ClockTest
    {
        public static void RunTest()
        {
            Clock clock = new Clock();
            DisplayService displayService = new DisplayService();
            clock.ClockTicked += displayService.OnClockTicked;

            Console.WriteLine("Press any key to exit Clock");
            clock.Run();
            Console.WriteLine();
        }
    }
}