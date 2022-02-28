using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public abstract class TrafficLight : GameObject
    {
        //private field
        private bool _state = false;
        private List<Path> _paths = new List<Path>();
        private List<TrafficLight> _trafficlights;

        //property
        public bool State { get => _state; set => _state = value; }
        public List<Path> Paths { get => _paths; set => _paths = value; }
        public List<TrafficLight> Trafficlights { get => _trafficlights; set => _trafficlights = value; }

        //contructor
        public TrafficLight(List<TrafficLight> trafficlights, float x, float y) : base(x,y)
        {
            _trafficlights = trafficlights;
            _trafficlights.Add(this);
        }

        //methods
        public abstract void SpawnMovingObject(int speed);
        public void UpdateState()
        {
            if (_state == false)
            {
                _state = true;
                Sprite.Container[1].Color = Color.LawnGreen;
                Sprite.Container[2].Color = Color.DarkRed;
            }
            else if (_state == true)
            {
                _state = false;
                Sprite.Container[1].Color = Color.DarkGreen;
                Sprite.Container[2].Color = Color.Red;
            }
            ExtraFunctions.PlaySound("trafficlight");
        }
        public bool MouseIn(Point2D pt)
        {
            return Sprite.Container[0].PointIn(pt);
        }
        public override int? GetIndex()
        {
            foreach (TrafficLight t in _trafficlights)
            {
                if (t == this)
                {
                    return _trafficlights.IndexOf(this);
                }
            }
            return null;
        }

        public Path GetLowestCountPath()
        {
            Path lowest = _paths[0];
            foreach (Path p in _paths)
            {
                if (p.MovingObjects.Count < lowest.MovingObjects.Count)
                {
                    lowest = p;
                }
            }
            return lowest;
        }
    }
}
