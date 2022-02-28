using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeCSharp
{
    public abstract class Shape
    {
        private float _x;
        private float _y;
        public Shape(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }

        public abstract void Draw(float x, float y);
    }
}
