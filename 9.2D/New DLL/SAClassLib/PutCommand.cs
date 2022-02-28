using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class PutCommand : Command
    {
        public PutCommand(string[] ids) : base(ids)
        {

        }
        public override string Execute(Player p, string[] ACommand)
        {
            if (ACommand.Length == 2)
            {
                if (ACommand[0] == "put" || ACommand[0] == "drop")
                {
                    if (p.Location != null)
                    {
                        if (p.Locate(ACommand[1]) != null)
                        {
                            p.Location.Inventory.Put(p.Locate(ACommand[1]) as Item);
                            p.Inventory.Take(ACommand[1]);
                            return ACommand[1] + " dropped into the " + p.Location.FirstId;
                        }
                        return "Could not find the " + ACommand[1];
                    }
                    return "You are not in a valid location";
                }
            }
            return "Error in Put Command";
        }
    }
}
