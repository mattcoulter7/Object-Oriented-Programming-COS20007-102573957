using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    public class Direction
    {
        private double _angle;
        public double Angle { get => _angle; set => _angle = value; }
        public Direction(double angle)
        {
            _angle = DegreeToRadian(angle);
        }
        
        public double DegreeToRadian(double value)
        {
            return value * Math.PI / 180;
        }
    }
}
