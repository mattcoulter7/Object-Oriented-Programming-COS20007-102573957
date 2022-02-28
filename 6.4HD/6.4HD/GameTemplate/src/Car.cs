using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class Car : MovingObject
    {
        public Car(Path path, int speed,float x,float y) : base(path, speed,x,y)
        {
            AngerTimer = new OnceTimer(ExtraFunctions.RandomNumberBetween(10, 40) * 60);//generates amount of seconds between 5 and 30
            Sprite.AddShape(new Rectangle(Color.Blue, x, y, 30, 30));//the car rectangle is added to the container
            Sprite.AddShape(new Circle(Color.Black, x, y, 5));
        }
        public override void Move()
        {
            for (int i = 0; i < Speed; i++)//changes the speed, this method is necessary to ensure no pixels are skipped
            {
                if (SafeToMove())
                {
                    X += Convert.ToSingle(Math.Cos(GetPath.Direction.Angle));
                    Y += Convert.ToSingle(Math.Sin(GetPath.Direction.Angle));
                }
            }
        }
        public override bool SafeToMove()
        {
            if ((!AtRedLight() && !ObjectInFront() || Triggered) && !Crashed)
            {
                return true;
            }
            return false;
        }
        public override bool ObjectInFront()
        {
            if (GetIndex() != 0) //means there is at least one car in front
            {
                switch (GetPath.Direction.Angle)//directions is necessary as for the car to be behind another car, the condition is dependent on direction
                {
                    case 0:
                        {
                            if (MovingObjectInFront().X - X <= 40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case Math.PI / 2:
                        {
                            if (Y - MovingObjectInFront().Y >= -40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case Math.PI:
                        {
                            if (MovingObjectInFront().X - X >= -40)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case -Math.PI / 2:
                        {
                            if (Y - MovingObjectInFront().Y <= 40)//has gap of 10px between vehicles
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
        
        

        //determines if two objects have collided
        public override void TestCrash(List<MovingObject> MovingObjects)
        {
            foreach (MovingObject m in MovingObjects)//this object intersection is tested with every single movingobject
            {
                if (this != m && m.Within(100,100,500,500)) //can't crash into itself
                {
                    if (m.Sprite.Container[0] is Rectangle)
                    {
                        if (Sprite.Container[0].IntersectsRectangle(m.Sprite.Container[0] as Rectangle)) //if their rectangle intersect
                        {
                            m.Crash();
                            Crash();//call crash if crash occurs
                        }
                    }
                    else if (m.Sprite.Container[0] is Circle)
                    {
                        if (Sprite.Container[0].IntersectsCircle(m.Sprite.Container[0] as Circle)) //if their rectangle intersect
                        {
                            m.Crash();
                            Crash();//call crash if crash occurs
                        }
                    }

                }

            }
        }

        public override void Crash()
        {
            if (!Crashed)
            {
                ExtraFunctions.PlaySound("crash");
                Color = Color.Orange;
                Crashed = true;
            }
        }
        public override bool CheckAngerTimerCondition()
        {
            if (!PointCrossed(GetPath.Stop) && !Crashed)
            {
                return true;
            }
            return false;
        }
        public override void Rage()
        {
            //ExtraFunctions.PlaySound("angery");
            Color = Color.Red;
            Speed *= 2;//angry cars drive faster
            Triggered = true;
        }
        public override bool AtRedLight()
        {
            if (!GetPath.Trafficlight.State && AtPoint(GetPath.Stop))
            {
                return true;
            }
            return false;
        }
        //determines if the vehicle is at the red light
        public override bool AtPoint(float stop)
        {
            //Red Light
            if (GetPath.Direction.Angle == Math.PI || GetPath.Direction.Angle == 0)//positioned is determined by x for horizontal moving objects
            {
                if (X == stop)//if the trafficlight is red and theyre at the stop point
                {
                    return true;
                }
            }
            else if (GetPath.Direction.Angle == -Math.PI / 2 || GetPath.Direction.Angle == Math.PI / 2)//positioned is determined by y for vertical moving objects
            {
                if (Y == stop)//if the trafficlight is red and theyre at the stop point
                {
                    return true;
                }
            }
            return false;
        }
        public override bool PointCrossed(float stop)
        {
            switch (GetPath.Direction.Angle)
            {
                case 0: //right
                    {
                        if (X > stop) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                    }
                case Math.PI / 2: //down
                    {
                        if (Y > stop) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                    }
                case Math.PI: //left
                    {
                        if (X<stop) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                    }
                case -Math.PI / 2: //up
                    {
                        if (Y<stop) //in front of stop point
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

        //returns vehicle in front of current car
        public override MovingObject MovingObjectInFront()
        {
            return GetPath.MovingObjects[GetIndex() - 1 ?? default];
        }

        public override void PrepareForReuse(float x, float y, int speed, Path path)
        {
            X = x;
            Y = y;
            Speed = speed;
            GetPath = path;
            Crashed = false;
            Triggered = false;
            Active = true;
        }

    }
}
