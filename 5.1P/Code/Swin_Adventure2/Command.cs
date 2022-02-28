using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    public abstract class Command : IdentifiableObject
    {
        //constructor
        public Command(string[] ids) : base(ids)
        {
            
        }

        //methods
        public abstract string Execute(Player p, string[] test);
    }
}
