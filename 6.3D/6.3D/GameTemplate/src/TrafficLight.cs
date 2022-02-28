using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class TrafficLight : GameObject
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
            Container.Add(new Rectangle(Color.Black,X,Y,35,75));
            Container.Add(new Circle(Color.DarkGreen, X + 17, Y + 17, 13));
            Container.Add(new Circle(Color.Red, X + 17, Y + 57, 13));

        }

        //methods
        public void UpdateState()
        {
            if (_state == false)
            {
                _state = true;
                Container[1].Color = Color.LawnGreen;
                Container[2].Color = Color.DarkRed;
            }
            else if (_state == true)
            {
                _state = false;
                Container[1].Color = Color.DarkGreen;
                Container[2].Color = Color.Red;
            }
            ExtraFunctions.PlaySound("trafficlight");
        }

        public bool MouseIn(Point2D pt)
        {
            return Container[0].MouseIn(pt);
        }
        public void SpawnCar()
        {
            int pathnum;
            if (_paths[0].MovingObjects.Count >= _paths[1].MovingObjects.Count)
            {
                pathnum = 1;
            }
            else
            {
                pathnum = 0;
            }
            _paths[pathnum].SpawnMovingObject(Color.Blue);
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
    }
}
