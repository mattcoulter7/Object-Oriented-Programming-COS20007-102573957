using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure2
{
    public class CommandProcessor
    {
        List<Command> _commands = new List<Command>();
        public CommandProcessor(params Command[] commands)
        {
            foreach (Command command in commands)//automattically adds all of the command into the dictionary
            {
                AddCommandType(command);
            }
        }

        public string RunCommand(Player p, string[] Acommand,Path path)
        {
            string key = Acommand[0];
            foreach (Command command in _commands)
            {
                foreach (string id in command.Identifiers)
                {
                    if (key == id)
                    {
                        return command.Execute(p,Acommand,path);
                    }
                }
            }
            return null;
        }

        public void AddCommandType(Command c)
        {
            _commands.Add(c);
        }
    }
}
