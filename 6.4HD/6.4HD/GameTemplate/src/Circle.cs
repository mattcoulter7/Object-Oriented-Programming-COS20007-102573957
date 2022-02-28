using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class Circle : Shape
    {
        //private field
        private float _radius;

        //property
        public float Radius { get => _radius; set => _radius = value; }
        
        //contructor
        public Circle(Color color,float x,float y,float radius) : base(color,x,y)
        {
            _radius = radius;
        }

        //methods
        public override void Draw()
        {
            SwinGame.FillCircle(Color, X, Y, _radius);
        }
        public override bool PointIn(Point2D pt)
        {
            return SwinGame.PointInCircle(pt, X, Y, _radius);
        }

        public override bool IntersectsRectangle(Rectangle rect2)
        {
            if (rect2.IntersectsCircle(this))
            {
                return true;
            }
            return false;
        }
        public override bool IntersectsCircle(Circle circ2)
        {
            Point2D pt = new Point2D();
            pt.X = circ2.X;
            pt.Y = circ2.Y;
            if (PointIn(pt))
            {
                return true;
            }
            return false;
        }
    }
}
