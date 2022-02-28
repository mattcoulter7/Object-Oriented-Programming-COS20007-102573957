using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class LookCommand : Command
    {
        public LookCommand(string[] ids) : base(ids)
        {
            
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 2)
            {
                if (text[0].ToLower() == "examine")
                {
                    if (p.Location.Locate(text[1]) != null)
                    {
                        return LookAtIn(text[1], p.Location);
                    }
                }
            }
            else if (text.Length == 3 || text.Length == 5)
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
                    return LookAtIn(text[2], p.Location);
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
            return container.Locate(thingid).FullDescription;
        }
    }
}
