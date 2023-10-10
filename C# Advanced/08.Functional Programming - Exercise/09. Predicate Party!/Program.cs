using System;
using System.Collections.Generic;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Predicate<string>> filters = new();
            List<string> people = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Add filter")
                {
                    if (!filters.ContainsKey(filter + value))
                    {
                        filters.Add(filter + value, GetPredicate(filter, value));
                    }
                }
                else
                {
                    filters.Remove(filter + value);
                }
            }

            foreach (var filter in filters)
            {
                people.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(' ', people));
        }

        private static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with": return n => n.StartsWith(value);
                case "Ends with": return n => n.EndsWith(value);
                case "Length": return n => n.Length == int.Parse(value);
                case "Contains": return n => n.Contains(value);
                default:
                    return default(Predicate<string>);
            }

        }
    }
}