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
        private List<MovingObject> _movingObjects;
        private MovingObjectPool _movingObjectsPool;
        private float _stop;
        private Direction _direction;
        private TrafficLight _trafficlight;

        //Property Field
        public MovingObjectPool MovingObjectsPool { get => _movingObjectsPool; set => _movingObjectsPool = value; }
        public float Stop { get => _stop; set => _stop = value; }
        public Direction Direction { get => _direction; set => _direction = value; }
        public TrafficLight Trafficlight { get => _trafficlight; set => _trafficlight = value; }
        public List<MovingObject> MovingObjects { get => _movingObjects; set => _movingObjects = value; }

        //Constructor
        public Path(TrafficLight trafficlight,float x, float y, float x2, float y2,float stop) : base(x,y)
        {
            _movingObjects = new List<MovingObject>();
            Sprite.AddShape(new Line(Color.Black, x, y, x2, y2));
            _direction = new Direction(x, y, x2, y2);
            _trafficlight = trafficlight;
            _trafficlight.Paths.Add(this);
            _stop = stop;
            _movingObjectsPool = new MovingObjectPool(this);
        }

        //Methods
        public void SpawnMovingObject(int speed)
        {
            _movingObjectsPool.LeavePool(speed);
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
