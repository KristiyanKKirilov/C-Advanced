namespace FootballTeamGenerator
{
    public static class ExceptionMessages
    {
        public const string NameNullOrEmptyExceptionMessage = "A name should not be empty.";
        public const string StatInvalidValueExceptionMessage = "{0} should be between 0 and 100.";
        public const string PlayerNotFoundExceptionMessage = "Player {0} is not in {1} team.";
        public const string TeamNotFoundExceptionMessage = "Team {0} does not exist.";
    }
}
