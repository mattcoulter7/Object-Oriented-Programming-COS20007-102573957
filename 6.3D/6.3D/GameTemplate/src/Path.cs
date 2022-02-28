using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class Path : GameObject
    {
        //Private Field
        private List<MovingObject> _movingobjects = new List<MovingObject>();
        private float _stopx = 185;
        private float _stopy;
        private double _direction;
        private TrafficLight _trafficlight;

        //Property Field
        public List<MovingObject> MovingObjects { get => _movingobjects; set => _movingobjects = value; }
        public float StopX { get => _stopx; set => _stopx = value; }
        public float StopY { get => _stopy; set => _stopy = value; }
        public double Direction { get => _direction; set => _direction = value; }
        public TrafficLight Trafficlight { get => _trafficlight; set => _trafficlight = value; }

        //Constructor
        public Path(TrafficLight trafficlight,float x, float y, float x2, float y2,float stopx,float stopy) : base(x,y)
        {
            _direction = ExtraFunctions.angleOf(X, Y, x2, y2);
            _trafficlight = trafficlight;
            _trafficlight.Paths.Add(this);
            _stopx = stopx;
            _stopy = stopy;
            //CreateRoad();
        }

        public void CreateRoad()
        {
            if (_direction == Math.PI / 2)
            {
                Container.Add(new Rectangle(Color.Black, X, Y, 51, 600));
            }
            else if (_direction == -Math.PI / 2)
            {
                Container.Add(new Rectangle(Color.Black, X, Y, 51, -600));
            }
            else if (_direction == Math.PI)
            {
                Container.Add(new Rectangle(Color.Black, X, Y, -600, 51));
            }
            else if (_direction == 0)
            {
                Container.Add(new Rectangle(Color.Black, X, Y, 600, 51));
            }
        }
        
        //Methods
        public void SpawnMovingObject(Color color)
        {
            new MovingObject(this, color, X, Y);
        }
        public override int? GetIndex()
        {
            foreach (Path p in _trafficlight.Paths)
            {
                if (p == this)
                {
                    return _trafficlight.Paths.IndexOf(this);
                }
            }
            return null;
        }
    }
}
