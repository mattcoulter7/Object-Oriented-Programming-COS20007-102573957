using SwinGameSDK;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyGame
{
    public abstract class Shape
    {
        //private field
        private Color _color;
        private float _x;
        private float _y;
        private bool _selected;
        private static Dictionary<string, Type> _ShapeClassRegistry = new Dictionary<string, Type>();

        public static void RegisterShape(string name, Type t)
        {
            _ShapeClassRegistry[name] = t;
        }
        public static Shape CreateShape(string name)
        {
            return (Shape)Activator.CreateInstance ( _ShapeClassRegistry[name]);
        }

        public static string GetType(Shape s)
        {
            foreach (KeyValuePair<string, Type> entry in _ShapeClassRegistry)
            {
                if (s.GetType() == entry.Value)
                {
                    return entry.Key;
                }
            }
            return null;
        }

        //GetterSetter
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        //Constructor
        public Shape(Color clr)
        {
            _color = clr;
        }
        public Shape() : this(Color.Yellow)
        {

        }

        //abstract methods
        public abstract void Draw();
        public abstract void DrawOutline();
        public abstract bool IsAt(Point2D pt);

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(GetType(this));
            writer.WriteLine(Color.ToArgb());
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }
        public virtual void LoadFrom(StreamReader reader)
        {
            Color = Color.FromArgb(reader.ReadInteger());
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
}
