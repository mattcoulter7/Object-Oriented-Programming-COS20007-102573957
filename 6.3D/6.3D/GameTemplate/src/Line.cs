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
        public override bool MouseIn(Point2D pt)
        {
            return SwinGame.PointOnLine(pt, X, Y, _x2, _y2);
        }
    }
}
