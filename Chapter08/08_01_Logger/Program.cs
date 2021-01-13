using System;
using System.Diagnostics;

namespace _08_01_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: What is Debugger and Debug different?
            Debugger.Log(0, null, "This is a test debugger message.\n");
            Debug.WriteLine("This is a test debug message.");
            Console.Read();
        }
    }
}
