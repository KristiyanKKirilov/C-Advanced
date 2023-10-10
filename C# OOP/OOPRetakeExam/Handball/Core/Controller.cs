using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Core
{
    public class Controller : IController
    {
        private PlayerRepository players;
        private TeamRepository teams;
        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }
        public string LeagueStandings()
        {
            StringBuilder sb = new();
            sb.AppendLine("***League Standings***");

            foreach (var team in teams.Models.OrderByDescending(t => t.PointsEarned).ThenByDescending(t => t.OverallRating).ThenBy(t => t.Name))
            {
                sb.AppendLine(team.ToString());
                sb.AppendLine(string.Join(", ", team.Players));
            }

            return sb.ToString().TrimEnd();
        }

        public string NewContract(string playerName, string teamName)
        {
            var player = players.GetModel(playerName);
            if (player is null)
            {
                return $"Player with the name {playerName} does not exist in the {nameof(PlayerRepository)}.";
            }

            var team = teams.GetModel(teamName);
            if (team is null)
            {
                return $"Team with the name {teamName} does not exist in the {nameof(TeamRepository)}.";
            }

            if (player.Team != null)
            {
                return $"Player {playerName} has already signed with {player.Team}.";
            }

            player.JoinTeam(teamName);
            team.SignContract(player);
            //check if u should remove it from his last team
            return $"Player {playerName} signed a contract with {teamName}.";

        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            var firstTeam = teams.GetModel(firstTeamName);
            var secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return $"Team {firstTeam.Name} wins the game over {secondTeam.Name}!";
            }
            else if (firstTeam.OverallRating == secondTeam.OverallRating)
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return $"The game between {firstTeam.Name} and {secondTeam.Name} ends in a draw!";
            }
            else
            {
                firstTeam.Lose();
                secondTeam.Win();
                return $"Team {secondTeam.Name} wins the game over {firstTeam.Name}!";
            }

        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != "Goalkeeper" && typeName != "CenterBack" && typeName != "ForwardWing")
            {
                return $"{typeName} is invalid position for the application.";
            }

            var player = players.GetModel(name);
            if (player != null)
            {
                return $"{name} is already added to the {nameof(PlayerRepository)} as {player.GetType().Name}.";
            }

            switch (typeName)
            {
                case "Goalkeeper":
                    player = new Goalkeeper(name);
                    break;
                case "CenterBack":
                    player = new CenterBack(name);
                    break;
                case "ForwardWing":
                    player = new ForwardWing(name);
                    break;
            }
            players.AddModel(player);

            return $"{name} is filed for the handball league.";
        }

        public string NewTeam(string name)
        {
            var team = teams.GetModel(name);

            if (team != null)
            {
                return $"{name} is already added to the {nameof(TeamRepository)}.";//teams.GetType().Name
            }
            team = new Team(name);

            teams.AddModel(team);

            return $"{name} is successfully added to the {nameof(TeamRepository)}.";
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new();
            sb.AppendLine($"***{teamName}***");

            var team = teams.GetModel(teamName);

            foreach (var player in team.Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
