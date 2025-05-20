using SportsFixture.Models;
using System.ComponentModel.DataAnnotations;

namespace SportsFixture.Dtos.Team
{
    public class CreateSportTeamDto
    {
        public int SportId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        //Gets the ID referenced in the API
        public int APIid { get; set; }

    }
}
