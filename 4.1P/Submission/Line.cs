using System;
using SwinGameSDK;

namespace MyGame
{
    class Line : Shape
    {
        //private field
        private float _x2;
        private float _y2;
        private float _length;
        private float _angle;

        //GetterSetter
        public float X2 { get => _x2; set => _x2 = value; }
        public float Y2 { get => _y2; set => _y2 = value; }
        public float Length { get => _length; set => _length = value; }
        public float Angle { get => _angle; set => _angle = value; }

        //Constructor
        public Line(Color clr,float length, float angle)
        {
            Color = clr;
            Length = length;
            Angle = angle;
        }
        public Line() : this(Color.Red,100,0)
        {
            
        }
        public override void Draw()
        {
            SwinGame.DrawLine(Color, X, Y, X2 , Y2 );
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Black, X, Y, 5);
            SwinGame.DrawCircle(Color.Black, X2, Y2, 5);
        }
        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointOnLine(pt,X,Y, X2, Y2);
        }
    }
}
