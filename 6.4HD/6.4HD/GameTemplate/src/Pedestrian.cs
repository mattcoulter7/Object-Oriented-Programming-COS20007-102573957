using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class Pedestrian : MovingObject
    {
        public Pedestrian(Path path, float x, float y) : base(path,1,x,y)
        {
            AngerTimer = new OnceTimer(ExtraFunctions.RandomNumberBetween(30, 90) * 60);//generates amount of seconds between 5 and 30
            Sprite.AddShape(new Circle(Color.Purple,GetPath.X,GetPath.Y,4));
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
                            if (MovingObjectInFront().X - X <= 8)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case Math.PI / 2:
                        {
                            if (Y - MovingObjectInFront().Y >= -8)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case Math.PI:
                        {
                            if (MovingObjectInFront().X - X >= -8)//has gap of 10px between vehicles
                            {
                                return true;
                            }
                            return false;
                        }
                    case -Math.PI / 2:
                        {
                            if (Y - MovingObjectInFront().Y <= 8)//has gap of 10px between vehicles
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
        public override void Crash()
        {
            Crashed = true;
        }
        public override void TestCrash(List<MovingObject> MovingObjects)
        {
            throw new NotImplementedException(); //crash does not need to be tested with pedestrians because they don't crash into cars, casrs crash into them.
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
            ExtraFunctions.PlaySound("angery");
            Sprite.Container[0].Color = Color.Red;
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
                        if (X < stop) //in front of stop point
                        {
                            return true;
                        }
                        return false;
                    }
                case -Math.PI / 2: //up
                    {
                        if (Y < stop) //in front of stop point
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
