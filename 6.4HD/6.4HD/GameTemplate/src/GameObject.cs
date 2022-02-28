using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public abstract class GameObject
    {
        //private field
        private Sprite _sprite = new Sprite();
        //property
        public Sprite Sprite { get => _sprite; set => _sprite = value; }
        public float X
        {
            get {
                return _sprite.X;
            }
            set {
                _sprite.X = value;
            }
        }
        public float Y
        {
            get
            {
                return _sprite.Y;
            }
            set
            {
                _sprite.Y = value;
            }
        }

        public Color Color
        {
            get
            {
                return Sprite.Container[0].Color;
            }
            set
            {
                Sprite.Container[0].Color = value;
            }
        }

        //constructor
        public GameObject(float x, float y)
        {
            X = x;
            Y = y;
        }
        //methods
        public void Draw()
        {
            _sprite.Draw();
        }
        public abstract int? GetIndex();

    }
}
