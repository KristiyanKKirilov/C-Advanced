using BorderControl.Core;
using BorderControl.Core.Interfaces;
using BorderControl.IO;
using System;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}