using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private const int InitialPoints = 0;

        private string name;
        private int pointsEarned;
        private double overallRating;
        //private IReadOnlyCollection<IPlayer> players;//??????
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            players = new();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Team name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int PointsEarned
        {
            get => pointsEarned;
            private set
            {
                pointsEarned = value;
                //check if u should set the initial value
            }
        }

        public double OverallRating
        {
            get => overallRating;
            private set
            {

                double sum = Players.Sum(p => p.Rating);
                double average = sum / players.Count;
                overallRating = double.Parse($"{average:F2}");

            }
        }

        public IReadOnlyCollection<IPlayer> Players
        {
            get => Players;
            private set
            {
                players = value.ToList();//?????
                //players = value;
            }
        }

        public void Draw()
        {
            PointsEarned += 1;
            foreach (var player in Players)
            {
                if (player.GetType().Name == "Goalkeeper")
                {
                    player.IncreaseRating();
                }
            }
        }

        public void Lose()
        {
            foreach (var player in Players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            Players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;

            foreach (var player in Players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            //if(Players.Count == 0)
            //{
            //    sb.AppendLine($"--Players: none");
            //}
            //else
            //{
            //    sb.AppendLine($"--Players: {string.Join(", ", Players)}");
            //}           
            return sb.ToString().TrimEnd();
        }
    }
}
