# Custom Console
Customized console and menu console interactions

        static void Main(string[] args)
        {
            string source = @"C:\Users\Maksim\Desktop\New folder\Debug1";

            string target = @"C:\Work\Commons\NewCommons\ApplicationUpdater\ApplicationUpdaterService\Repository\Release";

            string ignoreConfigPath = Path.Combine("Configs","IgnoreConfig.xml");

            IgnoreConfig ignoreConfig = null;

            Dictionary<string, Action> commandsDiscionary = null;
            commandsDiscionary = new Dictionary<string, Action>
            {
                {"set dir sourse", () =>
                    {
                        Console.WriteLine("Enter dir path:");
                        source = Console.ReadLine();
                    }
                },
                {"dir source", ()=>Console.WriteLine($"Source: {source}")},

                {"set dir target", () =>
                    {
                        Console.WriteLine("Enter dir path:");
                        target = Console.ReadLine();
                    }
                },
                {"dir target", ()=>Console.WriteLine($"Target: {target}")},
                {"init ignore", ()=> ignoreConfig = LoadCreateIgnoreConfig(ignoreConfigPath)},
                {"compose", () =>Compose(source,target,includeConfig: null)},
                {"s",
                    () =>
                    {
                        commandsDiscionary.RunCommand("dir source");
                        commandsDiscionary.RunCommand("dir target");
                        commandsDiscionary.RunCommand("init ignore");
                        commandsDiscionary.RunCommand("compose");
                    }},
            };

            Console.WriteLine("->run [RELEASE COMPOSER]", ConsoleColor.Yellow);
            ConsoleMenu.Help(commandsDiscionary);
            while (ConsoleMenu.Menu(commandsDiscionary)) { }
