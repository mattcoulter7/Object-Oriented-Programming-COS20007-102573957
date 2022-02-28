using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficController
{
    public class Sprite
    {
        private List<Shape> _container;
        public float X
        {
            get
            {
                return _container[0].X;
            }
            set
            {
                foreach (Shape shape in _container)
                {
                    shape.X = value;
                }
            }
        }
        public float Y
        {
            get
            {
                return _container[0].Y;
            }
            set
            {
                foreach (Shape shape in _container)
                {
                    shape.Y = value;
                }
            }
        }

        public List<Shape> Container { get => _container; set => _container = value; }

        public Sprite()
        {
            _container = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            _container.Add(shape);
        }

        public void Draw()
        {
            foreach (Shape shape in _container)
            {
                shape.Draw();
            }
        }
    }

}
