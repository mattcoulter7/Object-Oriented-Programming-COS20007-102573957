﻿using System.Collections.Generic;
using System.Linq;
using SwinGameSDK;
using System;

namespace MyGame
{
    class Drawing
    {
        //Private Field
        private readonly List<Shape> _shapes;
        private Color _background;
        private readonly List<Shape> result = new List<Shape>();

        //GetterSetter
        public Color Background { get => _background; set => _background = value; }
        public int ShapeCount { get => _shapes.Count(); }
        public List<Shape> SelectedShapes
        {
            get {
                
                foreach (Shape s in _shapes)
                {
                    if (s.Selected == true)
                    {
                        result.Add(s);
                    }
                }
                return result;
            } 
        }

        //Constructors
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() : this(Color.White)
        {

        }

        //Methods
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void Draw()
        {
            SwinGame.ClearScreen(Background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
                if(shape.Selected)
                {
                    shape.DrawOutline();
                }
            }

        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    if (s.Selected == true)
                    {
                        s.Selected = false;
                    }
                    else
                    {
                        s.Selected = true;
                    }
                }
            }
        }

        public void DeselectShape()
        {
            foreach(Shape s in SelectedShapes)
            {
                _shapes.Remove(s);
            }
        }

        
    }
}
