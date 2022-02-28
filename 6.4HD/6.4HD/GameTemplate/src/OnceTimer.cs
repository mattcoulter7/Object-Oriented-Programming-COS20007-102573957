using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficController
{
    class OnceTimer : GameTimer
    {
        public OnceTimer(double value) : base(value)
        {
        }
        public override void Update()
        {
            StopTimer();
        }
        public override bool ReachesZero()
        {
            if (CurrentTime <= 0)
            {
                return true;
            }
            return false;
        }

        public override void StopTimer()
        {
            State = false;
        }
    }
}
