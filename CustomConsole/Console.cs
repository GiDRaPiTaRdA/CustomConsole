using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConsole
{
    public static class Console
    {
        public static void WriteLine() => System.Console.WriteLine();
        public static void WriteLine(object obj)=> System.Console.WriteLine(obj);
        public static void WriteLine(object obj, ConsoleColor color) => color.Color(()=>System.Console.WriteLine(obj));
        public static void Write(object obj) => System.Console.Write(obj);
        public static void Write(object obj, ConsoleColor color) => color.Color(() => System.Console.Write(obj));
        public static string ReadLine()
        {
            ConsoleColor.Yellow.Color(() =>Write("$ "));

            return System.Console.ReadLine(); ;
        }

        private static void Color(this ConsoleColor color, Action action)
        {
            ConsoleColor temp = System.Console.ForegroundColor;

            System.Console.ForegroundColor = color;
            action?.Invoke();
            System.Console.ForegroundColor = temp;
        }

        public static ConsoleKeyInfo ReadKey(bool intercept = false) => System.Console.ReadKey(intercept);
    }
}
