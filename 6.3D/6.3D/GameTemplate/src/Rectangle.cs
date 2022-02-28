using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class Rectangle : Shape
    {
        //private field
        private float _width;
        private float _height;


        //property
        public float Width { get => _width;}
        public float Height { get => _height;}

        public Rectangle(Color color, float x, float y,float width,float height) : base(color,x,y)
        {
            _width = width;
            _height = height;
        }

        public override void Draw()
        {
            SwinGame.FillRectangle(Color,X, Y, _width,_height);
        }
        public override bool MouseIn(Point2D pt)
        {
            return SwinGame.PointInRect(pt, X, Y, _width, _height);
        }
        public bool Intersects(Rectangle rect2)
        {
            //top left
            if (rect2.X - X >= 0 && rect2.X - X <= _width &&
            rect2.Y - Y >= 0 && rect2.Y - Y <= _height)
            {
                return true;
            }

            //top right
            if (X - rect2.X >= 0 && X - rect2.X <= _width &&
            rect2.Y - Y >= 0 && rect2.Y - Y <= _height)
            {
                return true;
            }

            //bottom left
            if (rect2.X - X >= 0 && rect2.X - X <= _width &&
            Y - rect2.Y >= 0 && Y - rect2.Y <= _height)
            {
                return true;
            }

            //bottom right
            if (X - rect2.X >= 0 && X - rect2.X <= _width &&
            Y - rect2.Y >= 0 && Y - rect2.Y <= _height)
            {
                return true;
            }
            return false;
        }
    }
}
