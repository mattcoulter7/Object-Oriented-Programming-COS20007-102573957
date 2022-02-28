using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeCSharp
{
    public class Circle : Shape
    {
        private float _radius;
        public Circle(float x, float y, float radius) : base(x, y)
        {
            _radius = radius;
        }

        public float Radius { get => _radius; set => _radius = value; }

        public override void Draw(float x, float y)
        {
            //Draw Method Here...
        }
    }
}
