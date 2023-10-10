namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void CreatingArenaShouldWorkCorrectly()
        {           

            //List<Warrior> expectedArena = new();

            Assert.AreEqual(new List<Warrior>() { }, arena.Warriors);
        }

        [Test]
        public void CreatingArenaConstructorShouldWorkCorrectly()
        {
            Arena arena = new Arena();
            Assert.AreEqual(new List<Warrior>() { }, arena.Warriors);
        }

        [TestCase("Tobi", 30, 100, "Tobi2", 20, 80)]
        [TestCase("Penio", 10, 110, "Penio2", 30, 100)]
        public void CreatingArenaCountShouldBeCorrect
            (string name, int damage, int hp, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior enemy = new(enemyName, enemyDamage, enemyHP);
            int expectedCount = 2;

            arena.Enroll(warrior);
            arena.Enroll(enemy);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expectedCount, arena.Count);
        }


        [TestCase("Tobi", 30, 80)]
        public void CreatingArenaEnrollMethodShouldWorkCorrectly(string name, int damage, int hp)
        {
            Warrior warrior = new(name, damage, hp);

            Warrior expectedWarrior = new(name, damage, hp);
            string expectedName = expectedWarrior.Name;
            int expectedDamage = expectedWarrior.Damage;
            int expectedHP = expectedWarrior.HP;

            arena.Enroll(warrior);

            Warrior actualWarrior = arena.Warriors.FirstOrDefault(w => w.Name == name);
            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expectedName, actualWarrior.Name);
            Assert.AreEqual(expectedDamage, actualWarrior.Damage);
            Assert.AreEqual(expectedHP, actualWarrior.HP);

        }

        [TestCase("Tobi", 30, 80)]
        public void CreatingArenaEnrollMethodShouldThrowExceptionWhenWarriorAlreadyExists(string name, int damage, int hp)
        {
            Warrior warrior = new(name, damage, hp);            

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior), "Warrior is already enrolled for the fights!");
        }

        [TestCase("Tobi", 30, 100, "Tobi2", 20, 80)]
        [TestCase("Penio", 10, 110, "Penio2", 30, 100)]
        public void FightMethodShouldWorkCorrectly
            (string name, int damage, int hp, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior enemy = new(enemyName, enemyDamage, enemyHP);

            arena.Enroll(warrior);
            arena.Enroll(enemy);
            arena.Fight(warrior.Name, enemy.Name);

            int expectedWarriorHP = hp - enemyDamage;
            int expectedEnemyWarriorHP = enemyHP - damage;

            Assert.AreEqual(expectedWarriorHP, warrior.HP);
            Assert.AreEqual(expectedEnemyWarriorHP, enemy.HP);
        }

        [TestCase("Tobi", 30, 100, "Tobi2", 20, 80)]
        [TestCase("Penio", 10, 110, "Penio2", 30, 100)]
        public void FightMethodShouldThrowExceptionIfEnemyWarriorIsNull
            (string name, int damage, int hp, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior enemy = new(enemyName, enemyDamage, enemyHP);

            arena.Enroll(warrior);
            
            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(warrior.Name, enemy.Name), 
                $"There is no fighter with name {enemy.Name} enrolled for the fights!");           
        }

        [TestCase("Tobi", 30, 100, "Tobi2", 20, 80)]
        [TestCase("Penio", 10, 110, "Penio2", 30, 100)]
        public void FightMethodShouldThrowExceptionIfOurWarriorIsNull
            (string name, int damage, int hp, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior enemy = new(enemyName, enemyDamage, enemyHP);

            arena.Enroll(enemy);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(warrior.Name, enemy.Name),
                $"There is no fighter with name {warrior.Name} enrolled for the fights!");
        }

        [TestCase("Tobi", 30, 100, "Tobi2", 20, 80)]
        [TestCase("Penio", 10, 110, "Penio2", 30, 100)]
        public void FightMethodShouldThrowExceptionIfrWarriorsAreNull
            (string name, int damage, int hp, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior enemy = new(enemyName, enemyDamage, enemyHP);
                      
            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(warrior.Name, enemy.Name),
                $"There is no fighter with name {enemy.Name} enrolled for the fights!");
        }

    }
}
