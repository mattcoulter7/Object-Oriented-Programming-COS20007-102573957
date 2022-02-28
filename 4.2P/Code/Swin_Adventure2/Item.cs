using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    class Item : GameObject
    {
        //constructor
        public Item(string[] idents, string name, string desc): base(idents,name,desc)
        {
            name = Name;
            desc = FullDescription;
        }
    }
}
