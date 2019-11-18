using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomConsole;
using Console = CustomConsole.Console;

namespace ConsoleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = Console.ReadType<int>();
            var i1 = Console.ReadType<float>();
            var i2 = Console.ReadType<double>();
            var i3 = Console.ReadType<long>();
            var i4 = Console.ReadType<uint>();
            var i5 = Console.ReadType<ConsoleColor>();
        }
    }
}
