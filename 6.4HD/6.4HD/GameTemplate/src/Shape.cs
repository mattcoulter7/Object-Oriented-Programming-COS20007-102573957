using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public abstract class Shape
    {
        //Private field
        private Color _color;
        private float _x;
        private float _y;
        //Property
        public Color Color { get => _color; set => _color = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }

        //Contructor
        public Shape(Color color, float x, float y)
        {
            _color = color;
            _x = x;
            _y = y;
        }
        //Methods
        public abstract void Draw();
        public abstract bool PointIn(Point2D pt);

        public abstract bool IntersectsRectangle(Rectangle rect2);
        public abstract bool IntersectsCircle(Circle circ2);
    }
}
