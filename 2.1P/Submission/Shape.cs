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
        private Color _color = Color.Green;
        private float _x = 0;
        private float _y = 0;
        private int _width = 100;
        private int _height = 100;

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




        public void Draw()
        {
            SwinGame.FillRectangle(_color,_x,_y,_width,_height);
        }

        public bool PointInRect(Point2D pt,float x, float y, float w, float h)
        {
            if (pt.X >= x & pt.X <= x + w)
            {
                if (pt.Y >= y & pt.Y <= y + h)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
                  
        }
    }
}
