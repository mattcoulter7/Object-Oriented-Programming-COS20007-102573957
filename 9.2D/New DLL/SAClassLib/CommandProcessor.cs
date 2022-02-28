using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
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

        public string RunCommand(Player p, string[] ACommand)
        {
            string key = ACommand[0];
            foreach (Command command in _commands)
            {
                foreach (string id in command.Identifiers)
                {
                    if (key == id)
                    {
                        return command.Execute(p,ACommand);
                    }
                }
            }
            return "I don't Understand" + key;
        }

        public void AddCommandType(Command c)
        {
            _commands.Add(c);
        }
    }
}
