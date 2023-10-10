using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private string team;
        private double rating;

        public Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }
        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player name cannot be null or empty.");
                }
                name = value;
            }
        }

        public double Rating
        {
            get => rating; 
            protected set
            {
                rating = value;
            }
        }

        public string Team
        {
            get => team; 
            private set
            {
                team = value;
            }
        }

        public abstract void DecreaseRating();//minimum value for Rating 1
        

        public abstract void IncreaseRating();//maximum value for Rating 10

        public void JoinTeam(string name)
        {
            this.Team = name;
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.GetType().Name}: {Name}");
            sb.AppendLine($"--Rating: {Rating}");
            return sb.ToString().TrimEnd();
        }
    }
    
}
