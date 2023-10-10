using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IHeroFactory heroFactory;
        private ICollection<IBaseHero> heros;
        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
            heros = new List<IBaseHero>();
        }
        public void Run()
        {
            int count = int.Parse(reader.ReadLine());
            while (count > 0)
            {
                string name = reader.ReadLine();
                string type = reader.ReadLine();
                IBaseHero hero = null;
                try
                {
                    
                    heros.Add(CreateHero(name, type));
                    count--;
                }
                catch (ArgumentException ex)
                {

                    writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    throw;
                }
               
            }
            foreach (var hero in heros)
            {
                writer.WriteLine(hero.CastAbility());
            }

            int bossHealth = int.Parse(reader.ReadLine());


            int sum = heros.Sum(h => h.Power);
            if (sum >= bossHealth)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
        private IBaseHero CreateHero(string name, string type)
        {
            IBaseHero hero = heroFactory.CreateHero(type, name);
            return hero;
        }
    }
}
