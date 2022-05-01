using System;

namespace AssignmentDay3.Clock
{
    public class ClockEventArgs : EventArgs
    {
        private DateTime _now;
        public DateTime Now
        {
            get { return _now; }
            set { _now = value; }
        }
    }
}
