using System;
using System.Diagnostics;

namespace _08_01_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Debugger.Log(0, null, "This is a test debug message.\n");
            Console.Read();
        }
    }
}
