namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Threading;

    [TestFixture]
    public class WarriorTests
    {
        [TestCase("Tobi", 30, 80)]
        public void CreatingWarriorConstructorShouldWorkCorrectly(string name, int damage, int hp)
        {
            Warrior warrior = new(name, damage, hp);
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);

        }

        [TestCase(null, 30, 80)]
        [TestCase("  ", 30, 80)]
        public void CreatingWarriorConstructorNameSetterShouldThrowExceptipnWhenNameIsNullOrWhiteSpace
            (string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, hp), "Name should not be empty or whitespace!");
        }


        [TestCase("Tobi", 0, 80)]
        [TestCase("Penio", -1, 80)]
        public void CreatingWarriorConstructorDamageSetterShouldThrowExceptipnWhenDamageIsZeroOrNegative
            (string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, hp), "Damage value should be positive!");
        }

        [TestCase("Tobi", 30, -1)]
        [TestCase("Penio", 10, -20)]
        public void CreatingWarriorConstructorHPSetterShouldThrowExceptipnWhenValueIsNegative
            (string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, hp), "HP should not be negative!");
        }

        [TestCase("Tobi", 30, 100, "Tobi2", 20, 80)]
        [TestCase("Penio", 10, 110, "Penio2", 30, 100)]
        public void AttackMethodShouldWorkCorrectly
            (string name, int damage, int hp, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior enemy = new(enemyName, enemyDamage, enemyHP);            

            warrior.Attack(enemy);

            int expectedWarriorHP = hp - enemyDamage;
            int expectedEnemyWarriorHP = enemyHP - damage;

            Assert.AreEqual(expectedWarriorHP, warrior.HP);
            Assert.AreEqual(expectedEnemyWarriorHP, enemy.HP);
        }


        [TestCase("Tobi", 50, 80, "Tobi2", 70, 110)]
        [TestCase("Penio", 25, 80, "Penio2", 50, 100)]
        public void AttackMethodShouldThrowExceptionWhenHPIsBelowOrEqualToMinumumHP
            (string name, int damage, int hp, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior enemy = new(enemyName, enemyDamage, enemyHP);
            //int minAttackHp = 30;

            warrior.Attack(enemy);

            Assert.Throws<InvalidOperationException>(()
                => warrior.Attack(enemy), "Your HP is too low in order to attack other warriors!");
        }

        [TestCase("Tobi", 10, 80, "Tobi2", 70, 20)]
        [TestCase("Penio", 5, 50, "Penio2", 30, 30)]
        public void AttackMethodShouldThrowExceptionWhenEnemyHPIsBelowMinumumHP
            (string name, int damage, int hp, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior enemy = new(enemyName, enemyDamage, enemyHP);  
            int minAttackHp = 30;
                       
            Assert.Throws<InvalidOperationException>(()
                => warrior.Attack(enemy), $"Enemy HP must be greater than {minAttackHp} in order to attack him!");
        }

        [TestCase("Tobi", 10, 31, "Tobi2", 40, 40)]
        [TestCase("Penio", 5, 50, "Penio2", 60, 45)]
        public void AttackMethodShouldThrowExceptionWhenEnemyDamageIsHigherThanOurHP
            (string name, int damage, int hp, string enemyName, int enemyDamage, int enemyHP)
        {
            Warrior warrior = new(name, damage, hp);
            Warrior enemy = new(enemyName, enemyDamage, enemyHP);
            //int minAttackHp = 30;

            Assert.Throws<InvalidOperationException>(()
                => warrior.Attack(enemy), "You are trying to attack too strong enemy");
        }

        [Test]
        public void EnemyHpShouldBeSetToZeroIfWarriorDamageIsGreaterThanHisHp()
        {
            Warrior attacker = new("Pesho", 50, 100);
            Warrior defender = new("Gosho", 45, 40);

            attacker.Attack(defender);

            int expectedAttackerHp = 55;
            int expectedDefenderHp = 0;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
    }
}