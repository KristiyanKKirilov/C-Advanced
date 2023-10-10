using MilitaryElite.Core;
using MilitaryElite.Core.Interfaces;
using MilitaryElite.Models;
using System;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}