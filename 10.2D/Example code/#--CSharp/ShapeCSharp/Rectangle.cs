using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeCSharp
{
    public class Rectangle : Shape
    {
        private float _width;
        private float _height;
        public Rectangle(float x, float y, float width, float height) : base(x,y)
        {
            _width = width;
            _height = height;
        }

        public float Width { get => _width; set => _width = value; }
        public float Height { get => _height; set => _height = value; }

        public override void Draw(float x, float y)
        {
            //Draw Method Here...
        }
    }
}
