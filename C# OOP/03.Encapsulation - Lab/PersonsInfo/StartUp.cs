using System;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new();
            Team team = new Team("sSAD");
            for (int i = 0; i < lines; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3]));
                team.AddPlayer(person);
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count}");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count}");





        }
    }
}