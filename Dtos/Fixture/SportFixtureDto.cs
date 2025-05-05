namespace SportsFixture.Dtos.Fixture
{
    public class SportFixtureDto
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public DateTime? EventDateTime { get; set; } 
        public string StatusShort { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
    public class MatchEventDto : SportFixtureDto
    {
        public string? Referee { get; set; } 
        public string? HomeTeamName { get; set; }
        public string? AwayTeamName { get; set; }
    }

    public class MutliTeamEventDto : SportFixtureDto
    {
        public int? Length { get; set; }
        public string? WinningTeamName { get; set; }
    }
}
