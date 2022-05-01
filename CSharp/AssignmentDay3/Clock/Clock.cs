using System;
using System.Threading;

namespace AssignmentDay3.Clock
{
    public class Clock
    {
        public event EventHandler<ClockEventArgs> ClockTicked;

        public void Run()
        {
            while (!Console.KeyAvailable)
            {
                OnClockTicked();
                Thread.Sleep(1000);
            }
        }

        protected virtual void OnClockTicked()
        {
            ClockTicked?.Invoke(this, new ClockEventArgs { Now = DateTime.Now });
        }
    }
}
