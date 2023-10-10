using System;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> uniqueForceSide = new();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = tokens[0];
                    string forceUser = tokens[1];

                    if (!uniqueForceSide.Values.Any(u => u.Contains(forceUser)))
                    {
                        if (!uniqueForceSide.ContainsKey(forceSide))
                        {
                            uniqueForceSide.Add(forceSide, new SortedSet<string>());
                        }
                        uniqueForceSide[forceSide].Add(forceUser);
                    }

                }
                else
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = tokens[0];
                    string forceSide = tokens[1];

                    foreach (var (side, users) in uniqueForceSide)
                    {
                        if (users.Contains(forceUser))
                        {
                            users.Remove(forceUser);
                            break;
                        }
                    }

                    if (!uniqueForceSide.ContainsKey(forceSide))
                    {
                        uniqueForceSide.Add(forceSide, new SortedSet<string>());
                    }

                    uniqueForceSide[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

            } 

            foreach (var (side, users) in uniqueForceSide.OrderByDescending(x => x.Value.Count))
            {
                if (users.Count > 0)
                {
                    Console.WriteLine($"Side: {side}, Members: {users.Count}");

                    foreach (var user in users)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}