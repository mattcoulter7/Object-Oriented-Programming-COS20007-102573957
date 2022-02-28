using SwinGameSDK;
using System;
using System.Collections.Generic;

namespace TrafficController
{
    public abstract class MovingObject : GameObject
    {//Private Field
        private int _speed;//changes the speed the object moves
        private Path _path;//a reference to the path that contains this object
        private bool _crashed;
        private GameTimer _angertimer; //determines how long until objects becomes angry
        private bool _triggered = false;
        private bool _active = false;

        public GameTimer AngerTimer { get => _angertimer; set => _angertimer = value; }

        //Property Field

        public Path GetPath { get => _path; set => _path = value; }
        public bool Crashed { get => _crashed; set => _crashed = value; }
        public int Speed { get => _speed; set => _speed = value; }
        public bool Triggered { get => _triggered; set => _triggered = value; }
        public bool Active { get => _active; set => _active = value; }

        //Constructor
        public MovingObject(Path path, int speed,float x,float y) : base(x,y)
        {
            _speed = speed;
            _path = path; //path reference is assigned
        }

        public abstract void Move();
        public abstract bool ObjectInFront();
        public abstract void Crash();
        public abstract void TestCrash(List<MovingObject> MovingObjects);
        //ticks down the anger timer
        public abstract bool CheckAngerTimerCondition();
        public abstract void Rage();
        public abstract bool AtRedLight();
        //determines if the vehicle is at the red light
        public abstract bool AtPoint(float stop);
        public abstract bool PointCrossed(float stop);

        //returns vehicle in front of current car
        public abstract MovingObject MovingObjectInFront();

        public bool Within(float x1, float y1, float x2, float y2)
        {
            if (X >= x1 && Y >= y1 && X <= x2 && Y <= y2)
            {
                return true;
            }
            return false;
        }
        public abstract bool SafeToMove();

        public void LeaveIntersection()
        {
            Active = false;
            GetPath.MovingObjectsPool.ReEnterPool(this);
            GetPath.MovingObjects.Remove(this);
        }
        public override int? GetIndex()
        {
            foreach (MovingObject m in GetPath.MovingObjects)
            {
                if (m == this)
                {
                    return GetPath.MovingObjects.IndexOf(this);
                }
            }
            return null;
        }
        public abstract void PrepareForReuse(float x, float y, int speed, Path path);
        public int UpdateScore()
        {
            if (Triggered)
            {
                return -1;
            }
            return 1;
        }

    }
}
