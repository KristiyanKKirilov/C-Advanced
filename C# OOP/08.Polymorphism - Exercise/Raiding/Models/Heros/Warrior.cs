﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models.Heros
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;
        public Warrior(string name) 
            : base(name, WarriorPower)
        {
        }

        public override int Power => WarriorPower;
        public override string CastAbility()
            => $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
