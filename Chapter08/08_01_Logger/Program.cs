using System;
using System.Diagnostics;

namespace _08_01_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            // chapter 8.1.1
            // TODO: What is Debugger and Debug different?
            Debugger.Log(0, null, "This is a test debugger message.\n");
            Debug.WriteLine("This is a test debug message.");

            // chapter 8.1.2
            // 可用 SourceLevels 列舉類型來針對記錄檔事件等級進行過濾。
            var source = new TraceSource("Foobar", SourceLevels.All);
            var eventTypes = Enum.GetValues<TraceEventType>();
            var eventId = 1;
            Array.ForEach(eventTypes, et => source.TraceEvent(et, eventId++, $"This is a {et} message."));

            Console.Read();
        }
    }
}
