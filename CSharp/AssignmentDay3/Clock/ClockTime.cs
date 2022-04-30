using System;

namespace AssignmentDay3.Clock
{
    public class ClockTime : EventArgs
    {
        private DateTime _now;
        public DateTime Now
        {
            get
            {
                return this._now;
            }
            set
            {
                this._now = value;
            }
        }
    }
}