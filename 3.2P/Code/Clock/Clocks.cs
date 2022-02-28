using System;

namespace Clock
{
    class Clock
    {
        //private field
        private Counter _hours = new Counter();
        private Counter _mins = new Counter();
        private Counter _secs = new Counter();
        private string _now; 

        public Counter Hours { get => _hours; set => _hours = value; }
        public Counter Mins { get => _mins; set => _mins = value; }
        public Counter Secs { get => _secs; set => _secs = value; }
        public string Now { get => _now; set => _now = value; }

        //methods
        public void Tick()
        {
            Secs.Increment();
            if (Secs.Count == 60)
            {
                Secs.Reset();
                Mins.Increment();
            }
            if (Mins.Count == 60)
            {
                Mins.Reset();
                Hours.Increment();
            }
            if (Hours.Count == 24)
            {
                Hours.Reset();
            }
        }
        public string ReturnTime()
        {
            Now = Hours.Count.ToString("D2") + ":" + Mins.Count.ToString("D2") + ":" + Secs.Count.ToString("D2");
            return Now;
        }        
    }
}
