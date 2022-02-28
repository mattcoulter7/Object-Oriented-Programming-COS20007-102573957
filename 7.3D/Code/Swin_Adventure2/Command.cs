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
        public abstract string Execute(Player p, string[] ACommand, Path path);
    }
}
