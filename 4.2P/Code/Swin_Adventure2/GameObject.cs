using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    public abstract class GameObject : IdentifiableObject
    {
        //private field
        private string _description;
        private readonly string _name;

        //public field
        public string ShortDescription
        {
            get { return Name + " (" + FirstId + ")"; }
        }

        public virtual string FullDescription
        {
            get { return _description; }
        }

        //Property
        public string Name => _name;
        
        //constructor
        public GameObject(string[] ids, string name, string desc): base(ids)
        {
            _description = desc;
            _name = name;
        }
    }

}
