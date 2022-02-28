using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class TakeCommand : Command
    {
        public TakeCommand(string[] ids) : base(ids)
        {

        }
        public override string Execute(Player p, string[] text)
        {
            if (p.Location != null)
            {
                if (text.Length == 2 || text.Length == 4)
                {
                    if (text[0] == "take" || text[0] == "pickup")
                    {
                        if (p.Location.Locate(text[1]) != null)
                        {
                            if (text.Length == 2)
                            {
                                p.Inventory.Put(p.Location.Locate(text[1]) as Item);
                                p.Location.Inventory.Take(text[1]);
                                return "You have picked up the " + text[1] + " from the " + p.Location.Name;
                            }
                            if (text.Length == 4 || text.Length == 6)
                            {
                                if (text[2].ToLower() == "from")
                                {
                                    if (text.Length == 4)
                                    {
                                        if (p.Location.AreYou(text[3]))
                                        {
                                            p.Inventory.Put(p.Location.Locate(text[1]) as Item);
                                            p.Location.Inventory.Take(text[1]);
                                            return "You have picked up the " + text[1] + " from the " + p.Location.Name;
                                        }
                                    }
                                    else if (text.Length == 6)
                                    {
                                        if (text[4].ToLower() == "in")
                                        {

                                        }
                                    }
                                }
                            
                            }
                        
                        }
                        return "Could not find the" + text[1] + " in the " + p.Location.FirstId;
                    }
                    return "Error in Put input";
                }
                return "Error in Put Command";
            }
            return "The " + text[1] + " does not exist in your location";
        }
    }
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
