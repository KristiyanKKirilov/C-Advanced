using System;

namespace MonsterExtermination
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] armorArr = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] soldiersArr = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> monsterArmors = new(armorArr);
            Stack<int> soldiersImpact = new(soldiersArr);
            int monsterKilled = 0;
            while (true)
            {
                if (monsterArmors.Count == 0)
                {
                    Console.WriteLine("All monsters have been killed!".TrimEnd());
                    break;
                }
                if (soldiersImpact.Count == 0)
                {
                    Console.WriteLine("The soldier has been defeated.".TrimEnd());
                    break;
                }
                int currentMonster = monsterArmors.Dequeue();
                int currentSoldierImpact = soldiersImpact.Pop();

                int lastElement = currentSoldierImpact - currentMonster;
                int lastArmor = currentMonster - currentSoldierImpact;

                if (currentMonster < currentSoldierImpact)
                {
                    
                    if (soldiersImpact.Any())
                    {
                        if (lastElement != 0)
                        {                            
                            int lastSum = soldiersImpact.Pop();
                            soldiersImpact.Push(lastElement + lastSum);
                        }
                    }
                    else
                    {
                        if (lastElement != 0)
                        {
                            soldiersImpact.Push(lastElement);
                        }
                    }
                    monsterKilled++;

                }
                else if (currentMonster == currentSoldierImpact)
                {
                    monsterKilled++;
                }
                else
                {                   
                    monsterArmors.Enqueue(lastArmor);

                }
            }

            Console.WriteLine($"Total monsters killed: {monsterKilled}".TrimEnd());
        }
    }
}