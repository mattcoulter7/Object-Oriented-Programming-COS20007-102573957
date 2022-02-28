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
        public override bool MouseIn(Point2D pt)
        {
            return SwinGame.PointInCircle(pt, X, Y, _radius);
        }
    }
}
