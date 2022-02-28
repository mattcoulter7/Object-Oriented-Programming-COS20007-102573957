using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    public class LookCommand : Command
    {
        public LookCommand(string[] ids) : base(ids)
        {
            
        }

        public override string Execute(Player p, string[] text,Path path)
        {
            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0].ToLower() != "look")
                {
                    return "Error in Look input";
                }
                
                if (text[1].ToLower() != "at")
                {
                    return "What do you want to look at?";
                }
                
                if (text.Length == 5)
                {
                    if (text[3].ToLower() != "in")
                    {
                        return "What do you want to look in";
                    }
                }
                
                if (text.Length == 3)
                {
                    return LookAtIn(text[2], p);
                }
                else
                {
                    IHaveInventory container = FetchContainer(p, text[4]);
                    if (container == null)
                    {
                        return "I cannot find the " + text[4];
                    }
                    else
                    {
                        return LookAtIn(text[2], container);
                    }
                }
            }
            return "Command not found";
        }

        private IHaveInventory FetchContainer(Player p,string containerid)
        {
            return p.Locate(containerid) as IHaveInventory;
        }

        private string LookAtIn(string thingid, IHaveInventory container)
        {
            if (container.Locate(thingid) == null)
            {
                return "I cannot find the " + thingid + " from the " + container.Name;
            }
            else
            {
                return container.Locate(thingid).FullDescription;
            }
        }
    }
}
