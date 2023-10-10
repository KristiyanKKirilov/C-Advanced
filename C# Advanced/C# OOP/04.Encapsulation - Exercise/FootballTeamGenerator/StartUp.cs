using FootballTeamGenerator.Models;
using System;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                try
                {
                    switch (command)
                    {
                        case "Team":
                            AddTeam(tokens[1], teams);
                            break;
                        case "Add":
                            AddPlayer(tokens[1], 
                                tokens[2], 
                                int.Parse(tokens[3]), 
                                int.Parse(tokens[4]), 
                                int.Parse(tokens[5]), 
                                int.Parse(tokens[6]), 
                                int.Parse(tokens[7]), 
                                teams);
                            break;
                        case "Remove":
                            RemovePlayer(tokens[1], tokens[2], teams);
                            break;
                        case "Rating":
                            PrintRating(tokens[1], teams);
                            break;
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void AddTeam(string teamName, List<Team> teams) => teams.Add(new Team(teamName));
        static void AddPlayer(string teamName, string playerName, int endurance,
            int sprint, int dribble, int passing, int shooting, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.TeamNotFoundExceptionMessage,teamName));
            }
            team.AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
        }
        static void RemovePlayer(string teamName, string playerName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.TeamNotFoundExceptionMessage, teamName));
            }
            team.RemovePlayer(playerName);
        }
        static void PrintRating(string teamName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.TeamNotFoundExceptionMessage, teamName));
            }

            Console.WriteLine($"{teamName} - {team.Rating:f0}");
        }


    }
}