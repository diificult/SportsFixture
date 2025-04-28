using System.ComponentModel.DataAnnotations;

namespace SportsFixture.Dtos.Competition
{
    public class CreateCompetitionDto
    {
        
        [MaxLength(32,ErrorMessage ="Too Long of a name" )]
        [Required]
        public string SportEventName { get; set; }

    }
}
