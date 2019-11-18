using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomConsole
{
    public static class ConsoleMenu
    {
        public static bool Menu(Dictionary<string, Action> actions)
        {
            string command = Console.ReadLine();

            if (actions.ContainsKey(command))
            {
                actions.RunCommand(command);
            }
            else
            {
                switch (command)
                {
                    case "help":
                        Help(actions);
                        break;
                    case "0":
                        Console.WriteLine("Exit");
                        return false;
                    default:
                        NoSuchCommand(command);
                        break;
                }
            }

            return true;
        }

        public static void RunCommand(this Dictionary<string, Action> commandsDiscionary, string command)
        {
            Console.WriteLine($"->{command}", ConsoleColor.Yellow);

            if (commandsDiscionary.ContainsKey(command))
            {
                commandsDiscionary[command].Invoke();
            }
            else
            {
                NoSuchCommand(command);
            }          
        }

        private static void NoSuchCommand(string command)
        {
            Console.WriteLine("No such command " + command);
        }

        public static void Help(Dictionary<string, Action> commandsDiscionary)
        {
            commandsDiscionary.Select(a => a.Key).ToList().ForEach(a1 => Console.Write($"[{a1}] "));
            Console.WriteLine();
        }
    }
}