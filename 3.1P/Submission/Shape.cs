using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.Drawing;

namespace MyGame
{
    class Shape
    {
        //private field
        private Color _color = Color.Green;
        private float _x = 0;
        private float _y = 0;
        private int _width = 100;
        private int _height = 100;
        private bool _selected;

        //GetterSetter
        public Color _Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public float xCoord
        {
            get { return _x; }
            set { _x = value; }
        }
        public float yCoord
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        //Constructor
        public Shape(Point2D pt)
        {
            _x = pt.X;
            _y = pt.Y;
        }

        //Methods
        public void Draw()
        {
            SwinGame.FillRectangle(_color,_x,_y,_width,_height);
        }

        public void DrawOutline()
        {
            SwinGame.DrawRectangle(Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
        }

        public bool IsAt(Point2D pt)
        {
            return SwinGame.PointInRect(pt, _x, _y, _width, _height);
        }

    }
}
