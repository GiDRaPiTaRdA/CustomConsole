# Custom Console
Customized console and menu console interactions

Code example:

        static void Main(string[] args)
        {
            Dictionary<string, Action> commandsDiscionary = null;
            commandsDiscionary = new Dictionary<string, Action>
            {
                {"set dir sourse", () =>
                    {
                        Console.WriteLine("Enter dir path:");
                        string source = Console.ReadLine();
                    }
                },
                {"dir source", ()=>Console.WriteLine($"Source: {source}")},
                {"do", DoWork},
                {"sequence",
                    () =>
                    {
                        commandsDiscionary.RunCommand("set dir sourse");
                        commandsDiscionary.RunCommand("dir source");
                        commandsDiscionary.RunCommand("do");
                    }},
            };

            Console.WriteLine("->run [TEST CONSOLE]", ConsoleColor.Yellow);
            ConsoleMenu.Help(commandsDiscionary);
            while (ConsoleMenu.Menu(commandsDiscionary)) { }
            }
        
        static void RunCommand(this Dictionary<string, Action> commandsDiscionary, string command)
        {
            Console.WriteLine($"->{command}", ConsoleColor.Yellow);
            commandsDiscionary[command].Invoke();
        }
