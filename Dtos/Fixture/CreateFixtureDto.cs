using SportsFixture.Models;
using System.ComponentModel.DataAnnotations;

namespace SportsFixture.Dtos.Fixture
{
    public class CreateFixtureDto
    {

        [Required]
        public string EventName { get; set; }
        public int? SportCompetitionId { get; set; }
        public DateTime? EventDateTime { get; set; }
        public string StatusShort { get; set; }
        public string Location { get; set; }
        public int SportId { get; set; }
    }

    public class CreateMatchEventDto : CreateFixtureDto {
        public string? Referee { get; set; }
        public string? HomeResult { get; set; }
        public string? AwayResults { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
    }
    public class CreateMultiTeamEventDto : CreateFixtureDto
    {
        public ICollection<int> TeamsIds { get; set; } = new List<int>();
        public int? Length { get; set; }
        public int? WinningTeamId { get; set; }
    }

}
