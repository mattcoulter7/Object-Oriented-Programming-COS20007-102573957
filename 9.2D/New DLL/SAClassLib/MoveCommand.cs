using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swin_Adventure
{
    public class MoveCommand : Command
    {
        private Dictionary<string, double> _directions = new Dictionary<string, double>();
        public MoveCommand(string[] ids) : base(ids)
        {
            _directions.Add("north",90);
            _directions.Add("east", 0);
            _directions.Add("south", -90);
            _directions.Add("west", 180);
            _directions.Add("up", 90);
            _directions.Add("right", 0);
            _directions.Add("down", -90);
            _directions.Add("left", 180);
        }
        //methods
        public override string Execute(Player p, string[] text)
        {
            //leave command
            if (text.Length == 2)
            {
                //if player leaves location
                if (text[0] == "leave")
                {
                    if (text[1] != p.Location.FirstId)//if they try to leave a location that they are not in
                    {
                        return "You are not in " + p.Location.FirstId;
                    }
                    else
                    {
                        p.LeaveLocation(); //sets location to null
                        return "\nYou have left " + p.Objectives[p.Objectives.IndexOf(p.Path) - 1].Destination.Name;
                    }
                }
            }

            //all moving commands
            else if (text.Length >= 2 && text.Length <= 5) 
            {
                //if the user types a worded direction
                if (_directions.ContainsKey(text[1]))
                {
                    Direction dir = new Direction(_directions[text[1]]);
                    if (text.Length == 2)//doesn't specify distance
                    {
                        p.Path.UpdatePlayerPosition(p,1,dir);
                        return YouMovedTo(p) + p.Path.CheckPlayerLocation(p);
                    }
                    else if(text.Length == 4)//specifies distance
                    {
                        if (text[3] == "step" || text[3] == "steps")
                        {
                            p.Path.UpdatePlayerPosition(p, Convert.ToInt32(text[2]),dir);
                            return YouMovedTo(p) + p.Path.CheckPlayerLocation(p);
                        }
                    }
                }

                //if the user types a numerical direction
                else if (text[2] == "degrees")
                {
                    Direction dir = new Direction(Convert.ToDouble(text[1]));
                    if (text.Length == 3)//doesn't specify distance
                    {
                        p.Path.UpdatePlayerPosition(p,1,dir);

                        return YouMovedTo(p) + p.Path.CheckPlayerLocation(p);
                    }
                    else if (text.Length == 5)//specifies distance
                    {
                        if (text[4] == "step" || text[4] == "steps")
                        {
                            p.Path.UpdatePlayerPosition(p, Convert.ToInt32(text[3]),dir);
                            return YouMovedTo(p) + p.Path.CheckPlayerLocation(p);
                        }
                    }
                }
            }

            return "error with move command structure";
        }

        public string YouMovedTo(Player p)
        {
            return "You moved to (" + p.X + "," + p.Y + ").\n";
        }
    }
}
