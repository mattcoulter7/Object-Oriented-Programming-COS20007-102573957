using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class Line : Shape
    {
        //private field
        private float _x2;
        private float _y2;
        //property
        public float X2 { get => _x2; set => _x2 = value; }
        public float Y2 { get => _y2; set => _y2 = value; }

        //contructor
        public Line(Color color, float x, float y,float x2,float y2) : base(color,x,y)
        {
            _x2 = x2;
            _y2 = y2;
        }

        //methods
        public override void Draw()
        {
            SwinGame.DrawLine(Color,X,Y,_x2,_y2);
        }
        public override bool PointIn(Point2D pt)
        {
            return SwinGame.PointOnLine(pt, X, Y, _x2, _y2);
        }
        public override bool IntersectsRectangle(Rectangle rect2)
        {
            if (rect2.X - rect2.Width >= X && rect2.X <= X)
            {
                if (rect2.Y - Y <= rect2.Height || Y - rect2.Y <= rect2.Height)
                {
                    return true;
                }
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
