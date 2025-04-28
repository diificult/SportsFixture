using System.ComponentModel.DataAnnotations.Schema;

namespace SportsFixture.Models
{
    [Table("SportsFixture")]
    public class SportFixture
    {
        public int Id { get; set; }
        public string EventName { get; set; } = String.Empty;
        public int? SportCompetitionId { get; set; }
        public SportCompetition? SportCompetition { get; set; }
        public DateTime? EventDateTime { get; set; }
         public string StatusShort { get; set; }
        public string Location { get; set; }
        public int? SportId { get; set; }
        public Sport? Sport { get; set; }
    }

    public class MatchEvent : SportFixture
    {
        public string? Referee { get; set; }
        public string? HomeResult { get; set; }
        public string? AwayResults { get; set; }
        public int HomeTeamId { get; set; }
        public SportTeam HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public SportTeam AwayTeam { get; set; }
    }

    public class MultiTeamEvent : SportFixture
    {
        public ICollection<int> TeamsIds { get; set; } = new List<int>();
        public int? Length { get; set; }
        public int? WinningTeamId { get; set; }
        public SportTeam? WinningTeam { get; set; }
    }
    
}
