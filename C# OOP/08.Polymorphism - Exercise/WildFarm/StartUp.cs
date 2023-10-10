using System;
using WildFarm.Core;
using WildFarm.Core.Intefaces;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;
using WildFarm.IO;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new FoodFactory(), new AnimalFactory());
            engine.Run();
        }
    }
}