using System;
using System.ComponentModel;
using System.Globalization;

namespace CustomConsole
{
    public static class Console
    {
        public static void WriteLine() => System.Console.WriteLine();
        public static void WriteLine(object obj) => System.Console.WriteLine(obj);
        public static void WriteLine(object obj, ConsoleColor color) => color.Color(() => System.Console.WriteLine(obj));
        public static void Write(object obj) => System.Console.Write(obj);
        public static void Write(object obj, ConsoleColor color) => color.Color(() => System.Console.Write(obj));
        public static string ReadLine()
        {
            ConsoleColor.Yellow.Color(() => Write("$ "));

            return System.Console.ReadLine(); ;
        }

        public static T ReadType<T>(ConsoleColor color = ConsoleColor.White)
        {
            T result;

            while (true)
            {
                Console.WriteLine($"Input {typeof(T).Name}:", color);
                string inputLine = Console.ReadLine();


                bool parseResult = TryParse(inputLine, out result);

                if (parseResult)
                    break;
                else
                {
                    Console.WriteLine($"Invalid input for {typeof(T)}: \"{inputLine}\"",ConsoleColor.Red);
                }
            }

            return result;
        }

        public static ConsoleKeyInfo ReadKey(bool intercept = false) => System.Console.ReadKey(intercept);

        public static bool TryParse<T>(string stringValue, out T result)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            bool isValid = converter.IsValid(stringValue);

            result = isValid
                ? (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, stringValue)
                : default(T);

            return isValid;
        }

        private static void Color(this ConsoleColor color, Action action)
        {
            ConsoleColor temp = System.Console.ForegroundColor;

            System.Console.ForegroundColor = color;
            action?.Invoke();
            System.Console.ForegroundColor = temp;
        }
    }
}
