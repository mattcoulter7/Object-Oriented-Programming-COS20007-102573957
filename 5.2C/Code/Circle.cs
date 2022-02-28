﻿using SwinGameSDK;
using System;
using System.IO;

namespace MyGame
{
    class Circle : Shape
    {
        private int _radius;
        
        public int Radius { get => _radius; set => _radius = value; }
        public Circle(Color color, int radius)
        {
            Color = color;
            _radius = radius;
        }
        public Circle() : this(Color.Blue,50)
        {

        }

        public override void Draw()
        {
            SwinGame.FillCircle(Color,X,Y,_radius);
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Black, X, Y, _radius + 2);
        }
        public override bool IsAt(Point2D pt)
        {
            return SwinGame.PointInCircle(pt, X, Y, _radius);
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}
