using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficController
{
    public abstract class GameTimer
    {
        private double _currentTime;
        private bool state = true;

        public GameTimer(double value)
        {
            _currentTime = value;
        }
        public bool State { get => state; set => state = value; }
        public double CurrentTime { get => _currentTime; set => _currentTime = value; }

        public void Tick()
        {
            _currentTime -= 1;
        }
        public abstract void Update();
        public abstract bool ReachesZero();
        public abstract void StopTimer();
    }
}
