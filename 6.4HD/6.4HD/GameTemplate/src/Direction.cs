using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficController
{
    public class Direction
    {
        private Dictionary<string,double> _angleOfName = new Dictionary<string,double>();
        private double _angle; 
        public Direction(float x1, float y1, float x2, float y2)
        {
            InitialiseDictionary();
            _angle = angleOf(x1,y1,x2,y2);

        }
        public Direction(string direction)
        {
            InitialiseDictionary();
            _angle = _angleOfName[direction];
        }

        private void InitialiseDictionary()
        {
            _angleOfName.Add("right", 0);
            _angleOfName.Add("left", Math.PI);
            _angleOfName.Add("down", Math.PI / 2);
            _angleOfName.Add("up", -Math.PI / 2);
        }

        public double Angle { get => _angle; set => _angle = value; }
        public Dictionary<string, double> AngleOfName { get => _angleOfName; set => _angleOfName = value; }

        public static double angleOf(float x1, float y1, float x2, float y2)
        {
            float xDiff = x2 - x1;
            float yDiff = y2 - y1;
            return Math.Atan2(yDiff, xDiff);
        }
    }
}
