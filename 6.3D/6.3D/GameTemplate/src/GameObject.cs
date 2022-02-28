using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficController
{
    public abstract class GameObject
    {
        //private field
        private List<Shape> _container = new List<Shape>();
        private float _x;
        private float _y;
        //preoprty
        public List<Shape> Container { get => _container; set => _container = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }

        //constructor
        public GameObject(float x, float y)
        {
            _x = x;
            _y = y;
        }
        //methods
        public void Draw()
        {
            foreach (Shape shape in Container)
            {
                shape.Draw();
            }
        }
        public abstract int? GetIndex();

    }
}
