using SwinGameSDK;
using System;
using System.Collections.Generic;

namespace TrafficController
{
    public class MovingObject : GameObject
    {
        
        
        //Private Field
        private int _speed = 2;//changes the speed the object moves
        private double _angertimer; //determines how long until objects becomes angry
        private bool _angerstate = false;//once anger timer ends, the angerstate is updated to true
        private Path _path;//a reference to the path that contains this object
        private bool _crashed;

        //Property Field
        public int Speed { get => _speed; set => _speed = value; }
        public double AngerTimer { get => _angertimer; set => _angertimer = value; }
        public bool AngerState { get => _angerstate; set => _angerstate = value; }
        public Path Path { get => _path; set => _path = value; }
        public bool Crashed { get => _crashed; set => _crashed = value; }

        //Constructor
        public MovingObject(Path path,Color color, float x, float y) : base(x, y)
        {
            _angertimer = ExtraFunctions.RandomNumberBetween(10,60) * 60;//generates amount of seconds between 15 and 100
            _path = path;//path reference is assigned
            _path.MovingObjects.Add(this);//add object to the path
            Container.Add(new Rectangle(color, X, Y, 30, 30));//the car rectangle is added to the container

        }

        //Methods

        //moves the car in appropriate direction under given conditions
        public void Move()
        {
            for (int i=0;i<_speed;i++)//changes the speed, this method is necessary to ensure no pixels are skipped
            {
                if (!AtRedLight() && !CarInFront() || //car stops at red light when light is red, car stop if car is in front
                    _angerstate && AtRedLight()) //car drives when angry at red light
                {
                    Container[0].X += Convert.ToSingle(Math.Cos(_path.Direction));
                    Container[0].Y += Convert.ToSingle(Math.Sin(_path.Direction));
                }
            }
        }

        public bool AtRedLight()
        {
            if (!_path.Trafficlight.State && AtPoint(_path.StopX, _path.StopY))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //determines if the vehicle is at the red light
        public bool AtPoint(float x, float y)
        {
            //Red Light
            if (_path.Direction == Math.PI || _path.Direction == 0)//positioned is determined by x for horizontal moving objects
            {
                if (Container[0].X == x)//if the trafficlight is red and theyre at the stop point
                {
                    return true;
                }
                return false;
            }
            else if (_path.Direction == -Math.PI/2 || _path.Direction == Math.PI/2)//positioned is determined by y for vertical moving objects
            {
                if (Container[0].Y == y)//if the trafficlight is red and theyre at the stop point
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        //determines if the object has crossed the red light stop point
        public bool PointCrossed(float x, float y)
        {
            switch(_path.Direction)
            {
                case 0:
                {
                        if (Container[0].X > x) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                }
                case Math.PI / 2:
                {
                        if (Container[0].Y > y) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                }
                case Math.PI:
                {
                        if (Container[0].X < x) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                }
                case -Math.PI / 2:
                {
                        if (Container[0].Y < y) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                }
                default:
                {
                        return false;
                }
            }
            
        }

        //
        public bool CarInFront()
        {
            if (GetIndex() != 0) //means there is at least one car in front
            {
                switch (_path.Direction)//directions is necessary as for the car to be behind another car, the condition is dependent on direction
                {
                    case 0:
                        {
                            if (MovingObjectInFront().Container[0].X - Container[0].X <= 40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case Math.PI / 2:
                        {
                            if (Container[0].Y - MovingObjectInFront().Container[0].Y >= -40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case Math.PI:
                        {
                            if (MovingObjectInFront().Container[0].X - Container[0].X >= -40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case -Math.PI / 2:
                        {
                            if (Container[0].Y - MovingObjectInFront().Container[0].Y <= 40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    default:
                        {
                            return false;
                        }
                }
                
            }
            return false; //first vehicle always moves
        }

        //returns vehicle in front of current car
        //used stop stop the vehicle behind the other vehicle
        public MovingObject MovingObjectInFront()
        {
            return _path.MovingObjects[GetIndex() - 1 ?? default];
        }

        
        //ticks down the anger timer
        public void TickAngerTimer()
        {
            if (!PointCrossed(_path.StopX, _path.StopY))//red light point
            { 
                _angertimer -= 1;
            }
              
            if (_angertimer == 0)//once the timer ends
            {
                UpdateAngerState();// the anger state is updated
            }

        }
        public void UpdateAngerState()
        {
            if (!_angerstate)
            {
                ExtraFunctions.PlaySound("angery");
                _angertimer -= 1;//stops the angerstate from continuing to update
                Container[0].Color = Color.Red;
                _speed = 4;//angry cars drive faster
                _angerstate = true;
            }
            else if (_angerstate)
            {
                _angerstate = false;
                Container[0].Color = Color.Blue;
            }
        }

        //determines if two objects have collided
        public void TestCrash(List<MovingObject> HorizontalMovingObjects)
        {
            foreach (MovingObject movingobject in HorizontalMovingObjects)//this object intersection is tested with every single movingobject
            {
                if (this != movingobject) //can't crash into itself
                {
                    foreach (Rectangle rect in Container)//converts from shape into rectangle
                    {
                        if (rect.Intersects(movingobject.Container[0] as Rectangle)) //if their rectangle intersect
                        {
                            Crash(movingobject);//call crash if crash occurs
                        }
                    }
                }
                
            }
        }

        public double GetScore()
        {
            if(!_angerstate)
            {
                return _angertimer/60;
            }
            else if (_angerstate)
            {
                return -50;
            }
            return 0;
        }

        //determines whether object is within the intersection, for memory saving
        public bool Visible()
        {
            if (Container[0].X >= 100 && Container[0].Y >= 100 && Container[0].X <= 470 && Container[0].Y <= 470)
            {
                return true;
            }
            return false;
        }

        public void Crash(MovingObject movingobject)
        {
            if (!_crashed)
            {
                ExtraFunctions.PlaySound("crash");
                Container[0].Color = Color.Orange;
                movingobject.Container[0].Color = Color.Orange;
                Stop();//stops current vehicle
                movingobject.Stop();// stop crashed into vehicle
                _crashed = true;
            }
            
        }

        //stop the vehicle
        public void Stop()
        {
            _speed = 0;
        }
        //returns index of this vehicle in path list
        public override int? GetIndex()
        {
            foreach(MovingObject m in _path.MovingObjects)
            {
                if (m == this)
                {
                    return _path.MovingObjects.IndexOf(this);
                }
            }
            return null;
        }

    }
}
