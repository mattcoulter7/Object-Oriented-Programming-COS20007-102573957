using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficController
{
    public class MovingObjectPool
    {
        private Queue<MovingObject> _movingObjects;
        private Path _path;

        public Queue<MovingObject> MovingObjects { get => _movingObjects; set => _movingObjects = value; }

        public MovingObjectPool(Path path,int capacity)
        {
            _movingObjects = new Queue<MovingObject>(capacity);
            _path = path;
            InitialisePool(capacity);
        }
        public MovingObjectPool(Path path) : this(path,10)
        {

        }

        public void InitialisePool(int capacity)
        {
            if (_path.Trafficlight is CarTrafficLight)
            {
                for (int i = 0; i < capacity; i++)
                {
                    _movingObjects.Enqueue(new Car(_path, 0, 0, 0));
                }
            }
            else if (_path.Trafficlight is PedTrafficLight)
            {
                for (int i = 0; i < capacity; i++)
                {
                    _movingObjects.Enqueue(new Pedestrian(_path, 0, 0));
                }
            }
        }
        public void LeavePool(int speed)
        {
            if (_movingObjects.Count != 0) //can't spawn objects from an empty queue
            {
                _movingObjects.First().PrepareForReuse(_path.X,_path.Y,speed,_path);
                _path.MovingObjects.Add(_movingObjects.First());
                _movingObjects.Dequeue();
            }
        }
        public void ReEnterPool(MovingObject m)
        {
            _movingObjects.Enqueue(m);
        }
    }
}
