using System.Xml.Linq;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrEmptyExceptionMessage);
                }
                name = value;
            }
        }
        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(p => p.Stats);
                }
                return 0;
            }
        }
        public void AddPlayer(Player player) => players.Add(player);
        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);

            if (player is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerNotFoundExceptionMessage, playerName, Name));
            }
            players.Remove(player);
        }

    }
}
