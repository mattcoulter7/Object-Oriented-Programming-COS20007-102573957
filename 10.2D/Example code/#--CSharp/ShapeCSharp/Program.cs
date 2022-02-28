using System;
using System.Collections.Generic;

namespace ShapeCSharp
{
    public class Program
    {
        static void Main()
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Rectangle(0, 0, 50, 100));
            shapes.Add(new Circle(100, 100, 20));

            foreach (Shape shape in shapes)
            {
                shape.Draw(shape.X, shape.Y);
            }
        }
    }
}




