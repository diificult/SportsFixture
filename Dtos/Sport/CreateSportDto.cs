using System.ComponentModel.DataAnnotations;

namespace SportsFixture.Dtos.Sport
{
    public class CreateSportDto
    {
        [Required]
        public string SportName { get; set; }
    }
}
