using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficController
{
    public class RecursiveTimer : GameTimer
    {

        private double _resetTo;
        private double _updateRate;

        public double ResetTo { get => _resetTo; set => _resetTo = value; }
        public double UpdateRate { get => _updateRate; set => _updateRate = value; }

        public RecursiveTimer(double value, double rate) : base(value)
        {
            _resetTo = value * 60;
            _updateRate = rate;
        }

        public override void Update()
        {
            UpdateResetValue();
            CurrentTime = _resetTo;
        }

        public void UpdateResetValue()
        {
            _resetTo = Math.Ceiling(_resetTo * _updateRate);
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
