namespace FootballTeamGenerator.Models
{
    public class Player
    {             
        private const int MinValue = 0;
        private const int MaxValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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
        public int Endurance
        {
            get => endurance;
            set
            {
                if (CheckStat(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.StatInvalidValueExceptionMessage, nameof(Endurance)));
                }
                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            set
            {
                if (CheckStat(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.StatInvalidValueExceptionMessage, nameof(Sprint)));
                }
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            set
            {
                if (CheckStat(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.StatInvalidValueExceptionMessage, nameof(Dribble)));
                }
                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            set
            {
                if (CheckStat(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.StatInvalidValueExceptionMessage, nameof(Passing)));
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            set
            {
                if (CheckStat(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.StatInvalidValueExceptionMessage, nameof(Shooting)));
                }
                shooting = value;
            }
        }
        public double Stats => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

        private bool CheckStat(int value) => value < MinValue || value > MaxValue;
    }
}
